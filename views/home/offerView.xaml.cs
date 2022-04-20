
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.ApplicationModel.Resources.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Globalization;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;



// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace PayZan.views.home
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class offerView : Page
    {
        string lang;
        Frame rootFrame = Window.Current.Content as Frame;

       

        public offerView()
        {
           
            this.InitializeComponent();
           
        }

       
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            rootFrame.Navigate(typeof(BottomNavigationView));
        }

        private void ApplyCulture()
        {
            //var cul = new CultureInfo("en-US");
            //Windows.Globalization.ApplicationLanguages.PrimaryLanguageOverride = cul.Name;
            //CultureInfo.DefaultThreadCurrentCulture = cul;
            //CultureInfo.DefaultThreadCurrentUICulture = cul;
       
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
        }
        private void textbox_KeyUp(object sender, KeyRoutedEventArgs e)
        {
           
        }

        private void textbox_KeyDown(object sender, KeyRoutedEventArgs e)
        {

            valid((TextBox)sender, false);
            //    var Number = new Regex("[^0-9]");

            //    if(Number.IsMatch(textbox.Text))
            //    {
            //        e.Handled = true;
            //    }
            //    //if (!Regex.IsMatch(textbox.Text, " ^[1-9]$"))
            //    //{
            //    //    textbox.Text = "";

            //    //}

        }

        private  void valid(TextBox textbox,  bool allowdecimals)
        {
            string[] invalidcharacters = { "." };
            if(!allowdecimals)
            {
                invalidcharacters[invalidcharacters.Length - 1] = ".";
            }
            for(int index =0; index<invalidcharacters.Length; index++)
            {
                textbox.Text = textbox.Text.Replace(invalidcharacters[index], "");
            }

        }
        private void textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
           
        }
    }
}
