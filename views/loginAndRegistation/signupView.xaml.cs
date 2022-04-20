using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using PayZan.services;
using PayZan.framework.Contracts.Pocos;
using PayZan.common;
using PayZan.Interfaces;
using PayZan.framework.Properties;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace PayZan.views.loginAndRegistation
{
   
    public sealed partial class signupView : Page
    {
        IRemoteServices api = new RemoteServices();
        Frame rootFrame = Window.Current.Content as Frame;

        bool tapped = true;

        string PswdText = "";

        public signupView()
        {
            this.InitializeComponent();
            tapped = true;
            image.Source = new BitmapImage(new Uri(this.BaseUri, "/Assets/eye-hide.png"));
        
            img_password.Source = new BitmapImage(new Uri(this.BaseUri, "/Assets/eye-hide.png"));
         
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }

     
        private async void signup_Click(object sender, RoutedEventArgs e)
        {
     
            var reg = new SignUpModel
            {
                MobileNumber = txt_MobileNumber.Text.Trim(),
                Email = txt_Email.Text.Trim(),
                Password = txt_Password.Password.Trim(),
                ConfirmPassword = txt_conpassword.Password.Trim(),
                RoleId = "0a610882-32dc-4a14-8d6e-9b182ff4dc73"
            };
            if(isValidUi(reg))

            //if ((sign != null) && (sign.IsSuccess= true))
            {
               
                var sign = await api.UserRegistration(reg);
               
                var msg = new MessageDialog(sign.EndUserMessage + "Please Login ..!");
                await msg.ShowAsync();
                this.Frame.Navigate(typeof(BottomNavigationView));
            }

        }
       private void Errormessage()
        {
            lbl_mobilenumber.Text = "";
            lbl_email.Text = "";
            lbl_password.Text = "";
            lbl_conformpassword.Text = "";

        }
        public bool isValidUi(SignUpModel reg)
        {
            Errormessage();
            if (ValidationUtil.isNotnulSring(reg.MobileNumber))
            {
                lbl_mobilenumber.Text = Constants.mobileerror;
                return false;
               
            }

            else if(!ValidationUtil.IsValidMobileNumber(reg.MobileNumber))
            {
                lbl_mobilenumber.Text = Constants.mobilenumbrerror;
                return false;
            }
            else if (ValidationUtil.isNotnulSring(reg.Email))
            {
                lbl_mobilenumber.Text = "";
                lbl_email.Text = Constants.EmailError;
                return false;
            }
            else if (!ValidationUtil.isValidEmail(reg.Email))
            {
            
                lbl_email.Text = Constants.EmailError;
                return false;
            }

            else if(ValidationUtil.isNotnulSring(reg.Password))
            {
                lbl_email.Text = "";
                lbl_password.Text = Constants.passerror;
                return false;
            }
    
            else if(!ValidationUtil.IsPasswordsEqual(reg.Password))
            {
                lbl_password.Text = Constants.passworderror;
                return false;
            }
            else if(ValidationUtil.isNotnulSring(reg.ConfirmPassword))
            {
                lbl_password.Text = "";
                lbl_conformpassword.Text = Constants.conpasserror;
                return false;
            }

            else if(!ValidationUtil.IsConPasswordsEqual(reg.Password,reg.ConfirmPassword))
            {
                lbl_conformpassword.Text = Constants.Conformerror;
                return false;
            }

            lbl_conformpassword.Text = "";
            return true;
        }
      
        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (tapped)
            {
                tapped = false;
                txt_password1.Visibility = Windows.UI.Xaml.Visibility.Visible;
                txt_Password.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                txt_password1.Text = txt_Password.Password;
                image.Source = new BitmapImage(new Uri(this.BaseUri, "/Assets/eye icon.png"));
                
            }
            else
            {
                tapped = true;
                txt_password1.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                txt_Password.Visibility = Windows.UI.Xaml.Visibility.Visible;
                txt_Password.Password = txt_password1.Text;
                image.Source = new BitmapImage(new Uri(this.BaseUri, "/Assets/eye-hide.png"));


           }
        }

        private void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LoginView));
        }

        private void txt_MobileNumber_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                if (FocusManager.GetFocusedElement() == txt_Email)
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

        private void txt_Email_KeyDown(object sender, KeyRoutedEventArgs e)
        {
          
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                if (FocusManager.GetFocusedElement() == txt_Password)
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

        private void Image_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LoginView));
        }

        private void img_password_Tapped(object sender, TappedRoutedEventArgs e)
        {

            if (tapped)
            {
                tapped = false;
                txt_conpassword1.Visibility = Windows.UI.Xaml.Visibility.Visible;
                txt_conpassword.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                txt_conpassword1.Text = txt_conpassword.Password;
                img_password.Source = new BitmapImage(new Uri(this.BaseUri, "/Assets/eye icon.png"));
                
            }
            else
            {
                tapped = true;
                txt_conpassword1.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                txt_conpassword.Visibility = Windows.UI.Xaml.Visibility.Visible;
                txt_conpassword.Password = txt_conpassword1.Text;
                img_password.Source = new BitmapImage(new Uri(this.BaseUri, "/Assets/eye-hide.png"));
            }
        }

        private void txt_MobileNumber_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            ValidationUtil.validS((TextBox)sender, true);
        }
    }
}
