using PayZan.common;
using PayZan.framework.Properties;
using PayZan.framework.Contracts.Pocos;
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
   
    public sealed partial class WaterView : Page
    {

        Frame rootFrame = Window.Current.Content as Frame;
        public WaterView()
        {
            this.InitializeComponent();
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
            lbl_board.Text = "";
            lbl_consumerno.Text = "";
            lbl_amount.Text = "";
        }
        public bool isValidUi(Waterdetails water)
        {
            Errormessage();
            if (text_board.SelectedItem == null)
            {
                lbl_board.Text = Constants.borderror;
                return false;
            }

           else if (ValidationUtil.isNotnulSring(water.CosumerNo))
            {
               
                lbl_consumerno.Text = Constants.consumerno;
                return false;
            }
            else if (ValidationUtil.isNotnulSring(water.Amount))
            {
             
                lbl_amount.Text = Constants.amounterror;
                return false;
            }
            else if (!ValidationUtil.IsValidamount(water.Amount))
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
            var water = new Waterdetails();

            water.CosumerNo = text_consumerno.Text.Trim();
            water.Amount = text_amount.Text.Trim();
            if (ValidationUtil.IsLogin(this.Frame) && isValidUi(water))
            {
                /* api cal*/
            }
            else
            {
                /* error msg */
            }
        }

        private void text_consumerno_KeyDown(object sender, KeyRoutedEventArgs e)
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

        private void text_board_ItemsPicked(ListPickerFlyout sender, ItemsPickedEventArgs args)
        {

        }

        private void text_amount_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            ValidationUtil.validS((TextBox)sender, true);
        }
    }

}
