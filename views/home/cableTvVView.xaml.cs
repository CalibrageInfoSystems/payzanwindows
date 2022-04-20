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

namespace PayZan.views.home
{

    public sealed partial class cableTvVView : Page
    {
        IRemoteServices api = new RemoteServices();
        Serviceprovider serviceResponce;
        Frame rootFrame = Window.Current.Content as Frame;


        public cableTvVView()
        {
            this.InitializeComponent();
            serviceProvider();
        }

       
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        #region Methods

        private async void serviceProvider()
        {
            serviceResponce = await api.GetServiceProvider(Constants.SERVICE_PROVIDER_ID_CABLEBILL);
            Cable_list.ItemsSource = serviceResponce.ListResult;
        }

        private void Errormessage()
        {
            lbl_operator.Text = "";
            lbl_accountNo.Text = "";
            lbl_amount.Text = "";
        }
        public bool IsValidateUi(Cabledetails cable)
        {
            Errormessage();
            if (Cable_list.SelectedItem == null)
            {
                lbl_operator.Text = Constants.ComboboxError;
                return false;
            }
          else  if (ValidationUtil.isNotnulSring(cable.AccountNumber))
            {
              
                lbl_accountNo.Text = Constants.accountnumber;
                return false;
            }

            else if (ValidationUtil.isNotnulSring(cable.Amount))
            {
           
                lbl_amount.Text = Constants.amounterror;
                return false;
            }
            else if (!ValidationUtil.IsValidamount(cable.Amount))
            {

                lbl_amount.Text = Constants.amountinerror;
                return false;
            }

            return true;
        }
        #endregion

        #region Events

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            rootFrame.Navigate(typeof(BottomNavigationView));
        }

        private void Recharge_btn_Click(object sender, RoutedEventArgs e)
        {
            var cable = new Cabledetails
            {
                AccountNumber = text_accountno.Text.Trim(),
                Amount = text_Amount.Text.Trim()
            };

            if (ValidationUtil.IsLogin(this.Frame) && IsValidateUi(cable))
            {
                /* api cal */
            }
        }

        private void text_accountno_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                if (FocusManager.GetFocusedElement() == text_Amount)
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

        private void Cable_list_ItemsPicked(ListPickerFlyout sender, ItemsPickedEventArgs args)
        {

            serviceproviderdata data = (Cable_list.SelectedItem) as serviceproviderdata;
            frombtn.Content = data.Name;
        }

        #endregion

        private void text_accountno_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            ValidationUtil.validS((TextBox)sender, true);
        }

        private void text_Amount_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            ValidationUtil.validS((TextBox)sender, true);
        }
    }
}
