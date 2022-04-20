using PayZan.common;
using PayZan.framework.Contracts.Pocos;
using PayZan.framework.Properties;
using PayZan.Framework.Contracts.Pocos;
using PayZan.Interfaces;
using PayZan.Payzan_WinDB;
using PayZan.services;
using SQLiteWp8._1.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.ApplicationModel.Contacts;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;


namespace PayZan.views.home
{

    public sealed partial class walletView : Page
    {
        List<Wallet> Itemslist = new List<Wallet>();

        IRemoteServices api = new RemoteServices();

        Userwallet User;

        UserData c = new UserData();

        private double pullToRefreshThreshold;

        DatabaseHelperClass Db_Helper = new DatabaseHelperClass();

        SendmoneyRewquest senddetails = new SendmoneyRewquest();

        Walletbalance Userbal;


        public walletView()
        {
            this.InitializeComponent();
            this.SizeChanged += Testpage_SizeChanged;
            this.Loaded += Testpage_Loaded;

            c = Db_Helper.ReadUser();
          
            if (ValidationUtil.ChekLogin())
            {
                Balance();
            }
        }

        private async void Balance()
        {    
            Userbal = await api.GetBalance(c.WalletID);
            
            if (Userbal != null && Userbal.IsSuccess == true)
            {
               Db_Helper.UpdateWalletBalance(c.Balance);
              
               text_balance.Text= "Wallet Balance:" + c.Balance;

            }
        }

        private void Testpage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.pullToRefreshScroller.Height = e.NewSize.Height;
            this.listView.Height = e.NewSize.Height;
        }

        private void Testpage_Loaded(object sender, RoutedEventArgs e)
        {

            this.pullToRefreshThreshold = this.refreshVisual.Height;

            this.pullToRefreshScroller.ChangeView(0, this.pullToRefreshThreshold, null);
        }

        private void pullToRefreshScroller_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {
            if (this.pullToRefreshScroller.VerticalOffset < this.pullToRefreshThreshold)
            {
                if (!e.IsIntermediate)
                {
                    this.pullToRefreshScroller.ChangeView(0, this.pullToRefreshThreshold, null);
                    VisualStateManager.GoToState(this, "Idle", true);
                }
                else
                {
                    if (this.pullToRefreshScroller.VerticalOffset == 0)
                    {
                        VisualStateManager.GoToState(this, "Refreshing", true);
                    }
                }
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

          
        }

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BottomNavigationView));
        }

        #region Sendmoneytowallet

        #region Methods

        private void Errormessages()
          {
            lbl_mobilenumber.Text = "";
            lbl_amount.Text = "";
            lbl_Comment.Text = "";
          }
        
           private bool IsvalidUI(SendmoneyRewquest senddetails)
             {
                 Errormessages();

              if (ValidationUtil.isNotnulSring(senddetails.UserWalletHistory.Mobilenumber))
              {
                lbl_mobilenumber.Text = Constants.mobileerror;
                return false;
            }

            else if(!ValidationUtil.IsValidMobileNumber(senddetails.UserWalletHistory.Mobilenumber))
            {   
                lbl_mobilenumber.Text = Constants.mobilenumbrerror;
                return false;
             
            }
           else if(ValidationUtil.isNotnulSring(senddetails.UserWalletHistory.Amount))
            {
                lbl_mobilenumber.Text = "";
                lbl_amount.Text = Constants.amounterror;
                return false;
            }
            else if (!ValidationUtil.IsValidamount(senddetails.UserWalletHistory.Amount))
            {
                lbl_amount.Text = Constants.amountinerror;
                return false;
            }

            else if(ValidationUtil.isnulSring(senddetails.UserWalletHistory.Comments))
            {
                lbl_amount.Text = "";
                return false;
            }
            return true;
        }

        #endregion

        #region Events

        private void rootPivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (PivotItem pivotItem in rootPivot.Items)
            {
                if (pivotItem == rootPivot.Items[rootPivot.SelectedIndex])
                {
                    //Header of the selected Item to white

                    ((TextBlock)pivotItem.Header).Foreground = new SolidColorBrush(Colors.DarkRed);
                }
                else
                {
                    //headers of Other items to slightly darker
                    ((TextBlock)pivotItem.Header).Foreground = new SolidColorBrush(Colors.Black);
                }
            }

        }

        private async void Sendmoney_btn_Click(object sender, RoutedEventArgs e)
        {

            //User = await api.GetPassbookDetails("86e27fda-8ee4-416f-b9d6-2812f0d0f1db");
            if (ValidationUtil.IsLogin(this.Frame))
            {
                senddetails.UserWalletHistory.TransactionTypeId = Constants.TransactionTypeId;
                senddetails.UserWalletHistory.ReasonTypeId = Constants.ReasonTypeId;
                senddetails.UserWalletHistory.IsActive = true;
                senddetails.UserWalletHistory.Created = Constants.Created;
                senddetails.UserWalletHistory.Modified = Constants.Modified;
                senddetails.recieverUserName = text_mobilenumber.Text.Trim();
                senddetails.UserWalletHistory.WalletId = c.WalletUID;
                senddetails.UserWalletHistory.CreatedBy = c.UserID;
                senddetails.UserWalletHistory.ModifiedBy = c.UserID;
                senddetails.UserWalletHistory.Mobilenumber = text_mobilenumber.Text.Trim();
                senddetails.UserWalletHistory.Amount = text_amount.Text.Trim();
                senddetails.UserWalletHistory.Comments = text_Comment.Text.Trim();

                if (IsvalidUI(senddetails))
                {

                    var result = await api.SendMoneyToUserWallet(senddetails);

                    if (result.IsSuccess== true)
                    {

                        Db_Helper.UpdateWalletBalance(result.Result.Balance);

                        text_balance.Text = "Wallet Balance:" + result.Result.Balance;

                        MessageDialog msg = new MessageDialog("User Wallet Updated Succesfully ");
                        await msg.ShowAsync();


                        text_mobilenumber.Text = "";
                        text_amount.Text = "";
                        text_Comment.Text = "";
                    }
                    else
                    {
                        var msg = new MessageDialog(result.EndUserMessage);
                        await msg.ShowAsync();

                        text_mobilenumber.Text = "";
                        text_amount.Text = "";
                        text_Comment.Text = "";
                    }
                }
                else
                {

                }
               
            }

        }

        private void text_Enteramount_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                if (FocusManager.GetFocusedElement() == text_promo)
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

        private void text_amout_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                if (FocusManager.GetFocusedElement() == Addmoney)
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
            var contactPicker = new Windows.ApplicationModel.Contacts.ContactPicker();
            contactPicker.DesiredFieldsWithContactFieldType.Add(ContactFieldType.PhoneNumber);
            Contact contact = await contactPicker.PickContactAsync();

            var number = GetPhones(contact);
            text_mobilenumber.Text = number.Number;
        }

        private static ContactPhone GetPhones(Contact contact)
        {
            return contact.Phones.FirstOrDefault();
        }

        private void text_mobilenumber_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            ValidationUtil.validS((TextBox)sender, true);
        }

        private void text_amount_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            ValidationUtil.validS((TextBox)sender, true);
        }

        #endregion

        #endregion

        #region Addmoney


        #region Methods
        private void Errormessage()
        {
            lbl_Enteramount.Text = "";
        }

        private bool IsValidUi(Addmoney adddetails)
        {
            Errormessage();
            if (ValidationUtil.isNotnulSring(adddetails.Amount))
            {
                lbl_Enteramount.Text = Constants.amounterror;
                return false;
            }
            else if (!ValidationUtil.IsValidamount(adddetails.Amount))
            {
                lbl_amount.Text = Constants.amountinerror;
                return false;
            }


            return true;
        }
        #endregion

        #region Events
        private async void Addmoney_Click(object sender, RoutedEventArgs e)
        {
            if (ValidationUtil.IsLogin(this.Frame))
            {
                var adddetails = new Addmoney
                {
                    WalletId = c.WalletUID,
                    TransactionTypeId = 31,
                    ReasonTypeId = 29,
                    IsActive = true,
                    CreatedBy = c.UserID,
                    ModifiedBy = c.UserID,
                    Created = Constants.Created,
                    Modified = Constants.Modified,
                    Amount = text_Enteramount.Text.Trim()
                };

                if (IsValidUi(adddetails))
                {
                    AddmoneyResponse result = await api.AddMoneyToUserWallet(adddetails);

                    if ( result.IsSuccess==true)
                    {
                        Db_Helper.UpdateWalletBalance(result.Result.Balance);
                        text_balance.Text = "Wallet Balance:" + result.Result.Balance;
                        MessageDialog msgs = new MessageDialog(result.EndUserMessage);
                        await msgs.ShowAsync();

                        text_Enteramount.Text = "";
                        text_promo.Text = "";
                        text_Enteramount.Tag = 0;
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            } 
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (text_Enteramount.Tag is int)
            {
                int a = (int)text_Enteramount.Tag;

                a = a + 100;

                text_Enteramount.Tag = a;

                text_Enteramount.Text = a.ToString();
            }
            else
            {
                int a = 100;

                text_Enteramount.Tag = a;

                text_Enteramount.Text = a.ToString();

            }
            
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (text_Enteramount.Tag is int)
            {
                int a = (int)text_Enteramount.Tag;
                a=a+500;

                text_Enteramount.Tag = a;

                text_Enteramount.Text = a.ToString();
            }
            else
            {
                int a = 500;

                text_Enteramount.Tag = a;

                text_Enteramount.Text = a.ToString();

            }
           
        }

        private void button3_Click(object sender, RoutedEventArgs e)  
        {
 
            if (text_Enteramount.Tag is int)
            {
                int a = (int)text_Enteramount.Tag;
                a = a + 1000;

                text_Enteramount.Tag = a;

                text_Enteramount.Text = a.ToString();
            }
            else
            {
                int a = 1000;

                text_Enteramount.Tag = a;

                text_Enteramount.Text = a.ToString();

            }
           
        }

        private void text_mobilenumber_KeyDown(object sender, KeyRoutedEventArgs e)
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
                if (FocusManager.GetFocusedElement() == text_Comment)
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

        private void text_Comment_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                if (FocusManager.GetFocusedElement() == Sendmoney_btn)
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

        #endregion

        private void text_amount_TextChanged(object sender, TextChangedEventArgs e)
        {
            int number = 1234567890;
            Convert.ToDecimal(number).ToString("#,##0.00");
        }


        private void text_Enteramount_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            ValidationUtil.validS((TextBox)sender, true);
        }
    }

}

  
    
    

