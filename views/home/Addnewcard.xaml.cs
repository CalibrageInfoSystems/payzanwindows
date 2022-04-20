using PayZan.common;
using PayZan.framework.Properties;
using PayZan.Framework.Contracts.Pocos;
using PayZan.views.loginAndRegistation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace PayZan.views.home
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Addnewcard : Page
    {
        Frame rootFrame = Window.Current.Content as Frame;

        public Addnewcard()
        {
            this.InitializeComponent();
           
        }

      
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
        private void Backarrow_img_Tapped(object sender, TappedRoutedEventArgs e)
        {
            rootFrame.Navigate(typeof(SaveCards));
        }
        private void saveradiobtn_Click(object sender, RoutedEventArgs e)
        {
           
                
        }

      
        private void Savecard_btn_Click(object sender, RoutedEventArgs e)
        {
            var addcard = new addingnewcard
            {
                CardHoldersName = text_Holdername.Text.Trim(),
                CardNumber = text_cardnumber.Text.Trim(),
                Cardlabel = text_cardlabel.Text.Trim(),
    
            };

            if(ValidUI(addcard))
            { 

            }
            else
            {

            }

        }

        private bool ValidUI(addingnewcard addcard)
        {
            if (ValidationUtil.isNotnulSring(addcard.CardNumber))
            {
                lbl_cardnumber.Text = Constants.cardno;
                return false;
            }
            else if (!ValidationUtil.isvalidcardnumber(addcard.CardNumber))
            {
                lbl_cardnumber.Text = Constants.cardnumber;
                return false;
            }

            else if (ValidationUtil.isNotnulSring(addcard.CardHoldersName))
            {
                lbl_cardholdername.Text = Constants.cardholdername;
                return false;
            }

            else if (ValidationUtil.isnulSring(addcard.Cardlabel))
            {
                return false;
            }
            return true;
        }

        private void text_cardnumber_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                if (FocusManager.GetFocusedElement() == selectDate)
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
        private void selectDate_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                if (FocusManager.GetFocusedElement() == text_Holdername)
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
        private void text_Holdername_KeyDown(object sender, KeyRoutedEventArgs e)
        {

            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                if (FocusManager.GetFocusedElement() == text_cardlabel)
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

     
    }
}
