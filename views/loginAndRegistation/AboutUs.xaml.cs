using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace PayZan.views.loginAndRegistation
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AboutUs : Page
    {
        Frame rootFrame = Window.Current.Content as Frame;

        public AboutUs()
        {
            this.InitializeComponent();
        }

       
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            webview1.Navigate(new Uri("https://www.tutorialspoint.com"));
        }

        private void Backarrow_img_Tapped(object sender, TappedRoutedEventArgs e)
        {
            rootFrame.Navigate(typeof(MyProfile));
        }
    }
}
