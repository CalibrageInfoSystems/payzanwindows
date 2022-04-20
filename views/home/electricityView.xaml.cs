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


namespace PayZan.views.home
{
    public sealed partial class electricityView : Page
    {
        IRemoteServices api = new RemoteServices();

        Serviceprovider serviceResponce;

        Frame rootFrame = Window.Current.Content as Frame;

        public electricityView()
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
            serviceResponce = await api.GetServiceProvider(Constants.SERVICE_PROVIDER_ID_ELECTRICITY);
            electricitylist.ItemsSource = serviceResponce.ListResult;
        }
        private void Errormessage()
        {
            lbl_operator.Text = "";
            lbl_serviseNo.Text = "";
            lbl_amount.Text = "";
        }


        public bool isValidUi(electricitydetails electcity)
        {
            Errormessage();
            if (electricitylist.SelectedItem == null)
            {
                lbl_operator.Text = Constants.ComboboxError;
                return false;

            }
           else if (ValidationUtil.isNotnulSring(electcity.ServiceNo))
            {
        
                lbl_serviseNo.Text = Constants.servicenumber;
                return false;
            }
            else if (ValidationUtil.isNotnulSring(electcity.Amount))
            {
              
                lbl_amount.Text = Constants.amounterror;
                return false;
            }
            else if (!ValidationUtil.IsValidamount(electcity.Amount))
            {

                lbl_amount.Text = Constants.amountinerror;
                return false;
            }

            return true;
        }
        #endregion

        #region Events
        private void Recharge_btn_Click(object sender, RoutedEventArgs e)
        {

            var electcity = new electricitydetails();
            electcity.ServiceNo = text_serviseNo.Text.Trim();
            electcity.Amount = text_amount.Text.Trim();

            if (ValidationUtil.IsLogin(this.Frame) && isValidUi(electcity))
            {
                /* api cal*/
            }
            else
            {
                /* error msg */
            }
        }

        private void text_serviseNo_KeyDown(object sender, KeyRoutedEventArgs e)
        {

            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                if (FocusManager.GetFocusedElement() == text_amount)
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
        #endregion

        private void electricitylist_ItemsPicked(ListPickerFlyout sender, ItemsPickedEventArgs args)
        {

            serviceproviderdata data = (electricitylist.SelectedItem) as serviceproviderdata;
            frombtn.Content = data.Name;
        }

        private void text_amount_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            ValidationUtil.validS((TextBox)sender, true);
        }
    }
}
