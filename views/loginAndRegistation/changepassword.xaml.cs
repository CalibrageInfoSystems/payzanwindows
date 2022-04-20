using PayZan.common;
using PayZan.framework.Properties;
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
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace PayZan.views.loginAndRegistation
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class changepassword : Page
    {
        Frame rootFrame = Window.Current.Content as Frame;

        IRemoteServices api = new RemoteServices();

        DatabaseHelperClass Db_Helper = new DatabaseHelperClass();

        UserData c = new UserData();
        bool tapped = true;
        public changepassword()
        {
            this.InitializeComponent();
            c = Db_Helper.ReadUser();
            tapped = true;
            passwordimage.Source = new BitmapImage(new Uri(this.BaseUri, "/Assets/eye-hide.png"));
            passwordimage1.Source = new BitmapImage(new Uri(this.BaseUri, "/Assets/eye-hide.png"));
            passwordimage2.Source = new BitmapImage(new Uri(this.BaseUri, "/Assets/eye-hide.png"));
        }

       
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void Backarrow_img_Tapped(object sender, TappedRoutedEventArgs e)
        {
            rootFrame.Navigate(typeof(MyProfile));
        }

        private async void changepass_btn_Click(object sender, RoutedEventArgs e)
        {
            var changepass = new Changepassword
            {
                UserName = c.MobileNumber,
                OldPassword = text_cuurrentpass.Password.Trim(),
                NewPassword = text_Newpass.Password.Trim(),
                ConfirmPassword = text_Retypepass.Password.Trim()
            };
            if (IsValidUI(changepass))
            {
                var pass = await api.Changespasswordinfo(changepass);
                if(pass.IsSuccess == true)
                {
                    MessageDialog msgs = new MessageDialog("Password Changed Successfully");
                    await msgs.ShowAsync();

                    text_cuurrentpass.Password = "";
                    text_Newpass.Password = "";
                    text_Retypepass.Password = "";

                }
                else
                {
                    var msgs = new MessageDialog(pass.EndUserMessage);
                    await msgs.ShowAsync();

                    text_cuurrentpass.Password = "";
                    text_Newpass.Password = "";
                    text_Retypepass.Password = "";
                }
            }
            else
            {
              
            }
        }

        private void Errormessage()
        {
            lbl_currentpassword.Text = "";
            lbl_newpassword.Text = "";
            lbl_retypepassword.Text= "";
        }

        private bool IsValidUI(Changepassword changepass)
        {
            Errormessage();
            if (ValidationUtil.isNotnulSring(changepass.OldPassword))
            {
                lbl_currentpassword.Text = Constants.currnetpass;
                return false;
            }
            else if(!ValidationUtil.IsPasswordsEqual(changepass.OldPassword))
            {
                lbl_currentpassword.Text = Constants.passworderror;
                return false;
            }
            else if(ValidationUtil.isNotnulSring(changepass.NewPassword))
            {
                lbl_newpassword.Text = Constants.newpass;
                return false;
            }
            else if(!ValidationUtil.IsPasswordsEqual(changepass.NewPassword))
            {
                lbl_newpassword.Text = Constants.passworderror;
                return false;
            }
            else if(ValidationUtil.isNotnulSring(changepass.ConfirmPassword))
            {
                lbl_retypepassword.Text = Constants.retype;
                return false;
            }
            else if(!ValidationUtil.IsConPasswordsEqual(changepass.NewPassword, changepass.ConfirmPassword))
            {
                lbl_retypepassword.Text = Constants.newpassworderror;
                return false;
            }

            return true;
        }

        private void text_cuurrentpass_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                if (FocusManager.GetFocusedElement() == text_Newpass)
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

        private void text_Newpass_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                if (FocusManager.GetFocusedElement() == text_Retypepass)
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

        private void text_Retypepass_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                if (FocusManager.GetFocusedElement() == changepass_btn)
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

        private void passwordimage_Tapped(object sender, TappedRoutedEventArgs e)
        {

            if (tapped)
            {
                tapped = false;
                txt_password1.Visibility = Windows.UI.Xaml.Visibility.Visible;
                text_cuurrentpass.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                txt_password1.Text = text_cuurrentpass.Password;

                passwordimage.Source = new BitmapImage(new Uri(this.BaseUri, "/Assets/eye icon.png"));
            }
            else
            {
                tapped = true;
                txt_password1.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                text_cuurrentpass.Visibility = Windows.UI.Xaml.Visibility.Visible;
                text_cuurrentpass.Password = txt_password1.Text;
                passwordimage.Source = new BitmapImage(new Uri(this.BaseUri, "/Assets/eye-hide.png"));
            }
        }

        private void passwordimage1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (tapped)
            {
                tapped = false;
                txt_password.Visibility = Windows.UI.Xaml.Visibility.Visible;
                text_Newpass.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                txt_password.Text = text_Newpass.Password;

                passwordimage1.Source = new BitmapImage(new Uri(this.BaseUri, "/Assets/eye icon.png"));
            }
            else
            {
                tapped = true;
                txt_password.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                text_Newpass.Visibility = Windows.UI.Xaml.Visibility.Visible;
                text_Newpass.Password = txt_password1.Text;
                passwordimage1.Source = new BitmapImage(new Uri(this.BaseUri, "/Assets/eye-hide.png"));
            }
        }

        private void passwordimage2_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (tapped)
            {
                tapped = false;
                txt_password2.Visibility = Windows.UI.Xaml.Visibility.Visible;
                text_Retypepass.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                txt_password2.Text = text_Retypepass.Password;

                passwordimage2.Source = new BitmapImage(new Uri(this.BaseUri, "/Assets/eye icon.png"));
            }
            else
            {
                tapped = true;
                txt_password2.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                text_Retypepass.Visibility = Windows.UI.Xaml.Visibility.Visible;
                text_Retypepass.Password = txt_password1.Text;
                passwordimage2.Source = new BitmapImage(new Uri(this.BaseUri, "/Assets/eye-hide.png"));
            }
        }
    }
}
