using PayZan.Helpers;
using PayZan.views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using SQLite.Net.Interop;
using Windows.Phone.UI.Input;
using Windows.UI.Popups;

using System.Threading.Tasks;
using Windows.Storage;
using SQLite;
using SQLiteWp8._1.Model;
using System.Globalization;
using System.Diagnostics;
using Windows.ApplicationModel.Resources.Core;

// The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace PayZan
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public sealed partial class App : Application
    {
        ContinuationManager _continuator = new ContinuationManager();

        private TransitionCollection transitions;

        public static ResourceContext ctx;

      //  internal string ScannedValue;

        public static String appCulture = "en-US";

        public static string DB_PATH = Path.Combine(Path.Combine(ApplicationData.Current.LocalFolder.Path, "payzan.sqlite"));//DataBase Name 

      //  private string Name;

        public object RootFrame { get; private set; }

        public App()
        {
            this.InitializeComponent();

            ctx = new ResourceContext();
            ctx.Languages = new string[] { appCulture };

            if (!CheckFileExists("payzan.sqlite").Result)
            {
                using (var db = new SQLiteConnection(DB_PATH))
                {
                    db.CreateTable<UserData>();
                }
            }
            this.Suspending += this.OnSuspending;

            HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        }
        private async Task<bool> CheckFileExists(string fileName)
        {
            try
            {
                var store = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                return true;
            }
            catch
            {
            }
            return false;
        }


 
#if WINDOWS_PHONE_APP

        public async void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            Frame _currentFrame = Window.Current.Content as Frame;

            if (_currentFrame != null && _currentFrame.CanGoBack)
            {
                e.Handled = true;
                _currentFrame.GoBack();
            }
        }
        private void InitializeLanguage()
        {
            try
            {
                if (String.IsNullOrWhiteSpace(appCulture) == false)
                {
                    var cul = new CultureInfo(appCulture);
                   
                    Windows.Globalization.ApplicationLanguages.PrimaryLanguageOverride = cul.Name;
                    CultureInfo.DefaultThreadCurrentCulture = cul;
                    CultureInfo.DefaultThreadCurrentUICulture = cul;
                }
            }
            catch
            { 
                if (Debugger.IsAttached)
                {
                    Debugger.Break();
                }
                throw;
            }
        }

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
#if DEBUG
            Popup popup = new Popup();
   
            popup.IsOpen = true;
   
            {
                Task.Delay(TimeSpan.FromSeconds(2)).Wait();
            };
           
            {
                //This event occurs when the execution of the task has terminated.
                popup.IsOpen = false;
            };
           
            if (System.Diagnostics.Debugger.IsAttached)
            {
                this.DebugSettings.EnableFrameRateCounter = true;
            }
#endif

            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                // TODO: change this value to a cache size that is appropriate for your application
                rootFrame.CacheSize = 1;

                // Set the default language
                rootFrame.Language = Windows.Globalization.ApplicationLanguages.Languages[0];

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    // TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                // Removes the turnstile navigation for startup.
                if (rootFrame.ContentTransitions != null)
                {
                    this.transitions = new TransitionCollection();
                    foreach (var c in rootFrame.ContentTransitions)
                    {
                        this.transitions.Add(c);
                    }
                }

                rootFrame.ContentTransitions = null;
                rootFrame.Navigated += this.RootFrame_FirstNavigated;

                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                if (!rootFrame.Navigate(typeof(BottomNavigationView), e.Arguments))
                {
                    throw new Exception("Failed to create initial page");
                }
            }

            // Ensure the current window is active
            Window.Current.Activate();
        }

        /// <summary>
        /// Restores the content transitions after the app has launched.
        /// </summary>
        /// <param name="sender">The object where the handler is attached.</param>
        /// <param name="e">Details about the navigation event.</param>
        private void RootFrame_FirstNavigated(object sender, NavigationEventArgs e)
        {
            var rootFrame = sender as Frame;
            rootFrame.ContentTransitions = this.transitions ?? new TransitionCollection() { new NavigationThemeTransition() };
            rootFrame.Navigated -= this.RootFrame_FirstNavigated;
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private async void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            await SuspensionManager.SaveAsync();
            // TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
    }
#endif