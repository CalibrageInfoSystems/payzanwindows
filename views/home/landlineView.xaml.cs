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
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using static PayZan.framework.Contracts.Pocos.ImageViewModel;
using Windows.ApplicationModel.Contacts;

namespace PayZan.views.home
{
    
    public sealed partial class landlineView : Page
    {
        IRemoteServices api = new RemoteServices();
        Serviceprovider serviceResponce;
        Frame rootFrame = Window.Current.Content as Frame;
        public landlineView()
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
            serviceResponce = await api.GetServiceProvider(Constants.SERVICE_PROVIDER_ID_LANDLINE);
            landline_list.ItemsSource = serviceResponce.ListResult;
        }
        private void Errormessage()
        {
            lbl_operator.Text = "";
            lbl_stdcode.Text = "";
            lbl_Amount.Text = "";
        }
        public bool IsValidateUi(Landlinedetails landline)
        {
            Errormessage();
            if (landline_list.SelectedItem == null)
            {
                lbl_operator.Text = Constants.ComboboxError;
                return false;
            }
            else if (ValidationUtil.isNotnulSring(landline.NumberwithSTDCode))
            {
           
                lbl_stdcode.Text = Constants.mobileerror;
                return false;
            }

          else if (ValidationUtil.isNotnulSring(landline.Amount))
            {
             
                lbl_Amount.Text = Constants.amounterror;
                return false;
            }
            else if (!ValidationUtil.IsValidamount(landline.Amount))
            {

                lbl_Amount.Text = Constants.amountinerror;
                return false;
            }

            return true;
        }

        #endregion

        #region Events

        private void Recharge_btn_Click(object sender, RoutedEventArgs e)
        {
            var landline = new Landlinedetails();

            landline.NumberwithSTDCode = test_stdcode.Text.Trim();
            landline.Amount = test_amont.Text.Trim();

            if (ValidationUtil.IsLogin(this.Frame) && IsValidateUi(landline))
            {
                /* api cal*/
            }
            else
            {
                /* errot msg */
            }
        }

        private void test_stdcode_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                if (FocusManager.GetFocusedElement() == test_amont)
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

      

        private async void phonebook_img_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var contactPicker = new Windows.ApplicationModel.Contacts.ContactPicker();
            contactPicker.DesiredFieldsWithContactFieldType.Add(ContactFieldType.PhoneNumber);
            Contact contact = await contactPicker.PickContactAsync();

            var number = GetPhones(contact);
            test_stdcode.Text = number.Number;
        }
        private static ContactPhone GetPhones(Contact contact)
        {
            return contact.Phones.FirstOrDefault();
        }
        #endregion

        private void landline_list_ItemsPicked(ListPickerFlyout sender, ItemsPickedEventArgs args)
        {
            serviceproviderdata data = (landline_list.SelectedItem) as serviceproviderdata;
            frombtn.Content = data.Name;
        }

        private void test_stdcode_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            ValidationUtil.validS((TextBox)sender, true);
        }

        private void test_amont_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            ValidationUtil.validS((TextBox)sender, true);
        }
    }
}

