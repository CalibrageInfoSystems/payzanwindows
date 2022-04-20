using PayZan.common;
using PayZan.framework.Properties;
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
using Windows.ApplicationModel.Resources.Core;

namespace PayZan.views.home
{
    
    public sealed partial class BroadbandView : Page
    {
        Frame rootFrame = Window.Current.Content as Frame;

        public BroadbandView()
        {
            this.InitializeComponent();

            //ResourceMap rmap = ResourceManager.Current.MainResourceMap.GetSubtree("Resources");
            //textblck.Text = rmap.GetValue("Broadband", App.ctx).ValueAsString;
            //textb.Text = rmap.GetValue("Broadband", App.ctx).ValueAsString;
            //selectname.Text = rmap.GetValue("Select Operator", App.ctx).ValueAsString;
            //text_serviceNo.PlaceholderText = rmap.GetValue("Service No", App.ctx).ValueAsString;
            //text_amount.PlaceholderText = rmap.GetValue("Amount", App.ctx).ValueAsString;
            //Recharge_butn.Content = rmap.GetValue("Proceed to Pay Bill", App.ctx).ValueAsString;

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            rootFrame.Navigate(typeof(BottomNavigationView));
        }
        #region Methods

        private void Errormessage()
        {
            lbl_operator.Text = "";
            lbl_serviceNo.Text = "";
            lbl_Amount.Text = "";
        }
        public bool isValidUi(Broadband broadband)
        {
            Errormessage();
          if (Broadband_list.SelectedItem == null)
            {
                lbl_operator.Text = Constants.ComboboxError;
                return false;
            }
          else if (ValidationUtil.isNotnulSring(broadband.seriviceno))
            {
              
                lbl_serviceNo.Text = Constants.servicenumber;
                return false;
            }

          else  if (ValidationUtil.isNotnulSring(broadband.amount))
            {
                lbl_Amount.Text = Constants.amounterror;
                return false;
            }
          else if(!ValidationUtil.IsValidamount(broadband.amount))
            {
                lbl_Amount.Text = Constants.amountinerror;
                return false;      
            }
           
            return true;
        }

        #endregion

        #region events

        private void Recharge_butn_Click(object sender, RoutedEventArgs e)
        {
            var broadband = new Broadband
            {
                seriviceno = text_serviceNo.Text.Trim(),
                amount = text_amount.Text.Trim()
            };

            if (ValidationUtil.IsLogin(this.Frame) && isValidUi(broadband))
                
            {
                /* api cal*/
            }
          
        }

        private void text_serviceNo_KeyDown(object sender, KeyRoutedEventArgs e)
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

        private void text_amount_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                if (FocusManager.GetFocusedElement() == Recharge_butn)
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

        private void text_amount_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            ValidationUtil.validS((TextBox)sender, true);
        }
    }
}
