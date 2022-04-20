using PayZan.common;
using PayZan.framework.Contracts;
using PayZan.framework.Properties;
using PayZan.framework.services;
using PayZan.Framework.Contracts.Pocos;
using PayZan.Interfaces;
using PayZan.Payzan_WinDB;
using PayZan.services;
using PayZan.views.home;
using SQLiteWp8._1.Model;
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
    public sealed partial class MyProfile : Page
    { 
        IRemoteServices api = new RemoteServices();

        ILocalDataServices localDB = new LocalDataServices();

        Frame rootFrame = Window.Current.Content as Frame;

        Userprofile profile = new Userprofile();

        UserData c = new UserData();

        DatabaseHelperClass Db_Helper = new DatabaseHelperClass();

        public MyProfile()
        {
            this.InitializeComponent();

            c = Db_Helper.ReadUser();
            text_username.Text = c.MobileNumber;
            tect_usermail.Text = c.Email;
            walletmoney_btn.Content = c.Balance;

        }
       

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
           
        }

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            rootFrame.Navigate(typeof(Editprofile));
        }

        private void Addmoneyy_btn_Click(object sender, RoutedEventArgs e)
        {
            rootFrame.Navigate(typeof(walletView));
        }

        private void Text_savefield_Tapped(object sender, TappedRoutedEventArgs e)
        {
            rootFrame.Navigate(typeof(SaveCards)); 
        }

        private void text_orderField_Tapped(object sender, TappedRoutedEventArgs e)
        {
            rootFrame.Navigate(typeof(Orderhistory));
        }

        private void text_changepasswordField_Tapped(object sender, TappedRoutedEventArgs e)
        {
            rootFrame.Navigate(typeof(changepassword));
        }

        private void text_aboutfield_Tapped(object sender, TappedRoutedEventArgs e)
        {
            rootFrame.Navigate(typeof(AboutUs));
        }

        private void text_supportField_Tapped(object sender, TappedRoutedEventArgs e)
        {
            rootFrame.Navigate(typeof(AboutUs));
        }

        private void text_servicefield_Tapped(object sender, TappedRoutedEventArgs e)
        {
            rootFrame.Navigate(typeof(TermsofService));
        }

        private void Signout_btn_Click(object sender, RoutedEventArgs e)
        {
            if (ValidationUtil.SignOut())
            {
                rootFrame.Navigate(typeof(BottomNavigationView));
            }
        }

        private void Backarrow_img_Tapped(object sender, TappedRoutedEventArgs e)
        {
            rootFrame.Navigate(typeof(BottomNavigationView));
            
        }

        private void Scancode_btn_Click(object sender, RoutedEventArgs e)
        {
            rootFrame.Navigate(typeof(Testpage));
        }

        private void text_address_Tapped(object sender, TappedRoutedEventArgs e)
        {

            rootFrame.Navigate(typeof(Add_Address));
        }
    }
}
