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
using Windows.Storage;
using PayZan.services;
using PayZan.common;
using PayZan.framework.Contracts.Pocos;
using PayZan.Interfaces;
using PayZan.framework.Properties;




namespace PayZan.views.home
{
   
    public sealed partial class dthView : Page
    {
        IRemoteServices api = new RemoteServices();
        Serviceprovider serviceResponce;
        Frame rootFrame = Window.Current.Content as Frame;
        public dthView()
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
            serviceResponce = await api.GetServiceProvider(Constants.SERVICE_PROVIDER_ID_DTH);
            dthlist.ItemsSource = serviceResponce.ListResult;
        }
        private void Errormessage()
        {
           
            lbl_subscribrid.Text = "";
            lbl_operator.Text = "";
            lbl_Amount.Text = "";
        }
        public bool isValidUi(Dthdetails dth)
        {
            Errormessage();
            if (ValidationUtil.isNotnulSring(dth.SubscribrId))
            {
                lbl_subscribrid.Text = Constants.sunscriberid;
                return false;
            }
            else if (dthlist.SelectedItem == null)
            {
                
                lbl_operator.Text = Constants.ComboboxError;
                return false;

            }
            else if (ValidationUtil.isNotnulSring(dth.Amount))
            { 
                lbl_Amount.Text = Constants.amounterror;
                return false;
            }
            else if (!ValidationUtil.IsValidamount(dth.Amount))
            {
                lbl_Amount.Text = Constants.amountinerror;
                return false;
            }

            return true;
        }
        #endregion

        #region Events
        private void recharge_button_Click(object sender, RoutedEventArgs e)
        {
            var dth = new Dthdetails();

            dth.SubscribrId = text_subscriberid.Text.Trim();
            dth.Amount = text_amount.Text.Trim();


            if (ValidationUtil.IsLogin(this.Frame) && isValidUi(dth))
            {
                /* api cal*/
            }
          
        }

        private void text_subscriberid_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                if (FocusManager.GetFocusedElement() == dthlist)
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

        private void dthlist_ItemsPicked(ListPickerFlyout sender, ItemsPickedEventArgs args)
        {

            serviceproviderdata data = (dthlist.SelectedItem) as serviceproviderdata;
            frombtn.Content = data.Name;
        }

        private void text_amount_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            ValidationUtil.validS((TextBox)sender, true);
        }
    }
}


