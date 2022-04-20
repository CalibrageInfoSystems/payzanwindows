using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Contacts;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using PayZan.framework.Contracts.Pocos;
using System.Net.NetworkInformation;
using Windows.UI.Popups;
using PayZan.Helpers;
using Facebook;
using PayZan.views.home;
using PayZan.services;
using PayZan.common;
using static PayZan.framework.Contracts.Pocos.UserResponceModel;
using PayZan.Interfaces;
using PayZan.framework.Properties;
using PayZan.framework.Contracts;
using PayZan.framework.services;
using System.Threading.Tasks;
using Windows.UI;
using PayZan.Payzan_WinDB;
using SQLiteWp8._1.Model;
using Windows.UI.Xaml.Media.Imaging;

namespace PayZan.views.loginAndRegistation
{
    
    public sealed partial class LoginView : Page
    {
        ILocalDataServices localDB = new LocalDataServices();

        IRemoteServices api = new RemoteServices();
    
        DatabaseHelperClass Db_Helper = new DatabaseHelperClass();

        bool tapped = true;
        Frame rootFrame = Window.Current.Content as Frame;

        public LoginView()
        {
            this.InitializeComponent();
           
            tapped = true;
            passwordimage.Source = new BitmapImage(new Uri(this.BaseUri, "/Assets/eye-hide.png"));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private async void login_btn_Click(object sender, RoutedEventArgs e)
        {

            DatabaseHelperClass Db_Helper = new DatabaseHelperClass();

            UserData c = new UserData();
           
            var login = new LoginModel
            {
                userName = txt_Email.Text.Trim(),
                password = txt_password.Password.Trim(),
                clientId =  Constants.clientid,
                clientSecret = Constants.clientsecret,
                scope= Constants.scope
            };

            if (IsvalidUI(login)) 
            {
                loading();
                var user = await api.UserLogin(login);
                if (user.IsSuccess == true)
                {
                    c.ISLOGIN = 1;
                    c.UserID = user.Result.User.Id;
                    c.MobileNumber = user.Result.User.PhoneNumber;
                    c.Email = user.Result.User.Email;
                    c.TokenType = user.Result.TokenType;
                    c.Token = user.Result.AccessToken;
                    c.WalletUID = user.Result.UserWallet.WalletId;
                    c.WalletID = user.Result.UserWallet.Id;
                    c.Balance = user.Result.UserWallet.Balance;
                   

                    Db_Helper.Insert(c);
                    MessageDialog msgs = new MessageDialog("Login Successful...");
                    await msgs.ShowAsync();
                    this.Frame.Navigate(typeof(BottomNavigationView));
                }
                else
                {
                    var msg = new MessageDialog(user.EndUserMessage);
                    await msg.ShowAsync();
                } 
            }
            else
            {
                
            }
        }

        private void loading()
        {
 
            proring.IsActive = !(proring.IsActive);

            if (proring.Visibility == Visibility.Collapsed)
            {
                proring.Visibility = Visibility.Visible;
            }
            else
            {
                proring.Visibility = Visibility.Collapsed;
            }


        }

        private void errormessage()
        {
            lbl_username.Text = "";
            lbl_password.Text = "";
        }

        private bool IsvalidUI(LoginModel login)

        {
            if (ValidationUtil.isNotnulSring(login.userName))
            {
                lbl_username.Text = Constants.mobileerror;
                return false;
            }

            else if (!ValidationUtil.IsValidMobileNumber(login.userName))
            {
                lbl_username.Text = Constants.mobilenumbrerror;
                return false;
            }
            else if (ValidationUtil.isNotnulSring(login.password))
            {
                lbl_username.Text = "";
                lbl_password.Text = Constants.passerror;
                return false;
            }

           
             lbl_password.Text = "";
            return true;
        }

        private void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            rootFrame.Navigate(typeof(signupView));
        }

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            rootFrame.Navigate(typeof(BottomNavigationView));
        }

        private void txt_Email_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                if (FocusManager.GetFocusedElement() == txt_password)
                {
                    FocusManager.TryMoveFocus(FocusNavigationDirection.Next);
                    FocusManager.TryMoveFocus(FocusNavigationDirection.Next);
                }
                else
                {
                    FocusManager.TryMoveFocus(FocusNavigationDirection.Next);
                }
                e.Handled = true;
            }
        }

        private void login_btn_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                if (FocusManager.GetFocusedElement() == login_btn)
                {
                    FocusManager.TryMoveFocus(FocusNavigationDirection.Next);
                    FocusManager.TryMoveFocus(FocusNavigationDirection.Next);
                }
                else
                {
                    FocusManager.TryMoveFocus(FocusNavigationDirection.Next);
                }
                e.Handled = true;
            }
        }

        private void text_terms_Tapped(object sender, TappedRoutedEventArgs e)
        {
            
        }

        private void text_Privacy_Tapped(object sender, TappedRoutedEventArgs e)
        {
        }

        private void passwordimage_Tapped(object sender, TappedRoutedEventArgs e)
        {

            if (tapped)
            {
                tapped = false;
                txt_password1.Visibility = Windows.UI.Xaml.Visibility.Visible;
                txt_password.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                txt_password1.Text = txt_password.Password;
                
                passwordimage.Source = new BitmapImage(new Uri(this.BaseUri, "/Assets/eye icon.png"));
            }
            else
            {
                tapped = true;
                txt_password1.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                txt_password.Visibility = Windows.UI.Xaml.Visibility.Visible;
                txt_password.Password = txt_password1.Text;
                passwordimage.Source = new BitmapImage(new Uri(this.BaseUri, "/Assets/eye-hide.png"));
            }
        }

        private void txt_Email_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            ValidationUtil.validS((TextBox)sender, true);
        }
    }
}
        