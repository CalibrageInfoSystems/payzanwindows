using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Devices;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using PayZan.Framework.Contracts.Pocos;
using ZXing;
using ZXing.Common;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.Devices.Enumeration;
using Windows.UI.Core;
using System.Threading.Tasks;
using static ZXing.RGBLuminanceSource;
using Lumia.Imaging;
using Caliburn.Micro;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace PayZan.views.home
{
   
    public sealed partial class QR_Scanner : Page
    {
        private CameraPreviewImageSource _cameraPreviewImageSource;
        private VideoDeviceController _videoDevice;
        private WriteableBitmap _writeableBitmap;
        private WriteableBitmapRenderer _writeableBitmapRenderer;
        private readonly BarcodeReader _reader;

        private DispatcherTimer _timer;

        private bool _initialized;
        private bool _isRendering;
        private bool _decoding;
        private bool _focusing;

        private double _width;
        private double _height;

        private readonly IEventAggregator _eventAggregator;

        private DateTime _lastFrame = DateTime.Now;

        public QR_Scanner()
        {
            this.InitializeComponent();

         
            _reader = new BarcodeReader()
            {
                AutoRotate = true,

                Options = new DecodingOptions()
                {
                    TryHarder = true
                }
            };
        }
    

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            DisplayInformation.AutoRotationPreferences = DisplayOrientations.Landscape;
            StatusBar.GetForCurrentView().HideAsync();
            Init();
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            DisplayInformation.AutoRotationPreferences = DisplayOrientations.Portrait;
            StatusBar.GetForCurrentView().ShowAsync();
            Clean();
        }

        private async void Init()
        {
            //Get back camera
            var devices = await DeviceInformation.FindAllAsync(DeviceClass.VideoCapture);
            var backCameraId = devices.FirstOrDefault(x => x.EnclosureLocation != null && x.EnclosureLocation.Panel == Windows.Devices.Enumeration.Panel.Back).Id;

            //Start preview
            _cameraPreviewImageSource = new CameraPreviewImageSource();
            await _cameraPreviewImageSource.InitializeAsync(backCameraId);
            var properties = await _cameraPreviewImageSource.StartPreviewAsync();

            //Setup preview
            _width = 640.0;
            _height = (_width / properties.Width) * properties.Height;
            var bitmap = new WriteableBitmap((int)_width, (int)_height);

            _writeableBitmap = bitmap;

            PreviewImage.Source = _writeableBitmap;

            _writeableBitmapRenderer = new WriteableBitmapRenderer(_cameraPreviewImageSource, _writeableBitmap);

            _cameraPreviewImageSource.PreviewFrameAvailable += OnPreviewFrameAvailable;

            _videoDevice = (VideoDeviceController)_cameraPreviewImageSource.VideoDeviceController;

            //Set timer for auto focus

            if (_videoDevice.FocusControl.Supported)
            {
                var focusSettings = new FocusSettings
                {
                    AutoFocusRange = AutoFocusRange.Macro,
                    Mode = FocusMode.Auto,
                    WaitForFocus = false,
                    DisableDriverFallback = false
                };

                _videoDevice.FocusControl.Configure(focusSettings);

                _timer = new DispatcherTimer
                {
                    Interval = new TimeSpan(0, 0, 0, 4, 0)
                };
                _timer.Tick += TimerOnTick;
                _timer.Start();
            }

            await _videoDevice.ExposureControl.SetAutoAsync(true);

            _initialized = true;
        }

        private void TimerOnTick(object sender, object e)
        {
            Focus();
        }

        private async void Clean()
        {
            if (_cameraPreviewImageSource != null)
            {
                await _cameraPreviewImageSource.StopPreviewAsync();
            }

            if (_timer != null)
            {
                _timer.Stop();
            }
        }

        private async void OnPreviewFrameAvailable(IImageSize args)
        {
            if (!_initialized || _isRendering)
                return;

            _isRendering = true;

            await Dispatcher.RunAsync(
                CoreDispatcherPriority.High,
                () =>
                {
                    _writeableBitmap.Invalidate();
                });

            await _writeableBitmapRenderer.RenderAsync();

            await Dispatcher.RunAsync(
                CoreDispatcherPriority.High,
                () =>
                {
                    Deocode(_writeableBitmap.PixelBuffer.ToArray(), BitmapFormat.Unknown);
                });

            //FPS calculation
            var now = DateTime.Now;
            var delta = now - _lastFrame;
            _lastFrame = now;

            var fps = 1000.0 / delta.TotalMilliseconds;

            await Dispatcher.RunAsync(
               CoreDispatcherPriority.High,


               () =>
               {
                   FpsCounter.Text = String.Format("FPS: {0:0.0}", fps);
               });

            _isRendering = false;
        }

        private async void Deocode(byte[] rawRgb, BitmapFormat bitmapFormat)
        {
            await Task.Run(() =>
            {
                if (_decoding)
                    return;

                _decoding = true;

                var decoded = _reader.Decode(rawRgb, (int)_width, (int)_height, bitmapFormat);

                if (decoded != null)
                {
                    _eventAggregator.PublishOnUIThread(new QRCodemessage(decoded.Text));
                    //Stop();
                }
                _decoding = false;
            });
        }

     
        private async void Focus()
        {
            if (_focusing || !_initialized || _videoDevice == null || !_videoDevice.FocusControl.Supported)
                return;

            _focusing = true;
            await _videoDevice.FocusControl.LockAsync();
            await _videoDevice.FocusControl.FocusAsync();
            await _videoDevice.FocusControl.UnlockAsync();
            _focusing = false;
        }

        private void Page_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Focus();
        }
    }
}
