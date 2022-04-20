
#region Using
using PayZan.common;
using PayZan.framework.Contracts;
using PayZan.framework.Properties;
using PayZan.framework.services;
using PayZan.Payzan_WinDB;
using PayZan.views.home;
using PayZan.views.loginAndRegistation;
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
#endregion

namespace PayZan.views
{
    public sealed partial class BottomNavigationView : Page
    {
        ILocalDataServices localDB = new LocalDataServices();

        private static UserData user = new UserData();

        private static DatabaseHelperClass Db_Helper = new DatabaseHelperClass();


        public BottomNavigationView()
        {
            this.InitializeComponent();

            nav1.Navigate(typeof(HomeScreen), null);

            user = Db_Helper.ReadUser();

            if (user != null)
            {
                if (user.ISLOGIN == Constants.LOGIN)
                {
                    nav_profile.Label = "Profile";
                    //nav_profile.Label = "Login";
                }
                else
                {
                    //nav_profile.Label = "Profile";
                    nav_profile.Label = "Login";

                }
            }
            else
            {
                nav_profile.Label = "Login";
            }
     
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            nav1.Navigate(typeof(HomeScreen), null);
        }

        private void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            
            if ((user !=null) &&  user.ISLOGIN == Constants.LOGIN)
            {
              nav1.Navigate(typeof(MyProfile), null);
            }
            else
            {
                nav1.Navigate(typeof(LoginView), null);             
            }
        } 

        private void AppBarButton_Click_2(object sender, RoutedEventArgs e)
        {
            nav1.Navigate(typeof(walletView), null);
        }

        private void AppBarButton_Click_3(object sender, RoutedEventArgs e)
        {
            nav1.Navigate(typeof(offerView), null);
        }

       
    }
}
