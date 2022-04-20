using PayZan.common;
using PayZan.framework.Contracts;
using PayZan.framework.Properties;
using PayZan.framework.services;
using PayZan.Framework.Contracts.Pocos;
using PayZan.Interfaces;
using PayZan.services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;



namespace PayZan.views.home
{
    
    public sealed partial class profileView : Page
    {
        IRemoteServices api = new RemoteServices();

        ILocalDataServices localDB = new LocalDataServices();

        Userprofile profile;

        String ImagePath;

        CoreApplicationView view;

        public profileView()
        {
            this.InitializeComponent();
            view = CoreApplication.GetCurrentView();
            
        }

        private async void profileapi()
        {
            profile = await api.GetUserPersonalInfo(Constants.UserId);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }

        #region Events

        private  void Logout_Click(object sender, RoutedEventArgs e)
        {

            if (ValidationUtil.SignOut())
            {
                this.Frame.Navigate(typeof(BottomNavigationView));
            }

        }

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HomeScreen));
           

        }

      
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            rb.Name = rb.GroupName + " " + rb.Name;
        }
        private void editname_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ImagePath = string.Empty;
            FileOpenPicker filePicker = new FileOpenPicker();
            filePicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            filePicker.ViewMode = PickerViewMode.Thumbnail;

            // Filter to include a sample subset of file types
            filePicker.FileTypeFilter.Clear();
            filePicker.FileTypeFilter.Add(".bmp");
            filePicker.FileTypeFilter.Add(".png");
            filePicker.FileTypeFilter.Add(".jpeg");
            filePicker.FileTypeFilter.Add(".jpg");

            filePicker.PickSingleFileAndContinue();
            view.Activated += viewActivated;
        }
        private async void viewActivated(CoreApplicationView sender, IActivatedEventArgs args1)
        {
            FileOpenPickerContinuationEventArgs args = args1 as FileOpenPickerContinuationEventArgs;

            if (args != null)
            {
                if (args.Files.Count == 0) return;

                view.Activated -= viewActivated;
                StorageFile storageFile = args.Files[0];
                var stream = await storageFile.OpenAsync(Windows.Storage.FileAccessMode.Read);
                var bitmapImage = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
                await bitmapImage.SetSourceAsync(stream);

                var decoder = await Windows.Graphics.Imaging.BitmapDecoder.CreateAsync(stream);
                img_profile.Source = bitmapImage;
            }
        }

        #endregion

       
    }
}
