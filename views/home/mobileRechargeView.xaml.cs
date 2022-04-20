using PayZan.common;
using PayZan.framework.Properties;
using PayZan.Interfaces;
using PayZan.framework.Contracts.Pocos;
using PayZan.services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel.Contacts;
using PayZan.views.loginAndRegistation;

namespace PayZan.views.home
{
   
    public sealed partial class mobileRechargeView : Page
    {
        IRemoteServices api = new RemoteServices();

        Serviceprovider serviceResponce;

        Frame rootFrame = Window.Current.Content as Frame;

        public mobileRechargeView()
        {
            this.InitializeComponent();
            serviceProvider();
       
        }
        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            rootFrame.Navigate(typeof(BottomNavigationView));
        }

    

        #region Methods


        private async void serviceProvider()
        {
            serviceResponce = await api.GetServiceProvider(Constants.SERVICE_PROVIDER_ID_PREPAID);
            serviceList.ItemsSource = serviceResponce.ListResult;

        }
       
        private void Errormessage()
        {
            lbl_mobileNumber.Text = "";
            lbl_Operator.Text = "";
            lbl_Amount.Text = "";
        }
        public bool isValidate(Mobiledetails mobile)
        {
            Errormessage();

            if (ValidationUtil.isNotnulSring(mobile.Mobilenumber))
            { 
                lbl_mobileNumber.Text = Constants.mobileerror;
                return false;
            }
            
            else if (!ValidationUtil.IsValidMobileNumber(mobile.Mobilenumber))
            {
                lbl_mobileNumber.Text = Constants.mobilenumbrerror;
                return false;
            }
            else if (serviceList.SelectedItem == null)
            { 
                lbl_Operator.Text = Constants.ComboboxError;
                return false;
            }
            else if(ValidationUtil.isNotnulSring(mobile.Amount))
            {
                lbl_Amount.Text = Constants.amounterror;
                return false;
            }
           else if(!ValidationUtil.IsValidamount(mobile.Amount))
            {
                lbl_Amount.Text = Constants.amountinerror;
                return false;
            }


            return true;
            
        }
        #endregion

        #region Events
        private void recharge_btn_Click(object sender, RoutedEventArgs e)
        {
           
            var mobile = new Mobiledetails();
            mobile.Mobilenumber = Edit_Mobilenumber.Text.Trim();
            mobile.Amount = Edit_amount.Text.Trim();

            if (ValidationUtil.IsLogin(this.Frame) && isValidate(mobile))
            {
               

            }
            
            
        }
        private void serviceList_ItemsPicked(ListPickerFlyout sender, ItemsPickedEventArgs args)
        {

            serviceproviderdata data = (serviceList.SelectedItem) as serviceproviderdata;
            frombtn.Content = data.Name;


        }

        private void talktime_btn_Click(object sender, RoutedEventArgs e)
        {
            talktime_btn.Background = new SolidColorBrush(Colors.DarkRed);
            talktime_btn.Foreground = new SolidColorBrush(Colors.White);
            specilrecharge_btn.Background = new SolidColorBrush(Colors.White);
            specilrecharge_btn.Foreground = new SolidColorBrush(Colors.DarkRed);
        }

        private void specilrecharge_btn_Click(object sender, RoutedEventArgs e)
        {
            specilrecharge_btn.Background = new SolidColorBrush(Colors.DarkRed);
            talktime_btn.Foreground = new SolidColorBrush(Colors.DarkRed);
            talktime_btn.Background = new SolidColorBrush(Colors.White);
            specilrecharge_btn.Foreground = new SolidColorBrush(Colors.White);
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            rb.Name = rb.GroupName + " " + rb.Name;

        }
        private void Edit_Mobilenumber_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                if (FocusManager.GetFocusedElement() == serviceList)
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

        private async void contact_img_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var contactPicker = new ContactPicker();
            contactPicker.DesiredFieldsWithContactFieldType.Add(ContactFieldType.PhoneNumber);
            Contact contact = await contactPicker.PickContactAsync();

            var number = GetPhones(contact);
            Edit_Mobilenumber.Text = number.Number;
        }

        private static ContactPhone GetPhones(Contact contact)
        {
            return contact.Phones.FirstOrDefault();
        }



        #endregion

        private void Edit_Mobilenumber_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            ValidationUtil.validS((TextBox)sender, true);
        }

        private void Edit_amount_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            ValidationUtil.validS((TextBox)sender, true);
        }
    }
}


