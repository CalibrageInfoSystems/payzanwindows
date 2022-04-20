
#region Using
using PayZan.views.home;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using PayZan.services;
using Windows.UI.Popups;
using PayZan.framework.Contracts.Pocos;
using PayZan.common;
using PayZan.Interfaces;
using PayZan.framework.Properties;
using System.Text.RegularExpressions;
#endregion


namespace PayZan.views.Agent_Request
{
   
    public sealed partial class Request_For_Agent : Page
    {
        #region variable

        Frame rootFrame = Window.Current.Content as Frame;

        int id = 1;
        IRemoteServices api = new RemoteServices();
        AgentRequestResponce data;
        States state;
        Districts districts;
        Mandals mandals;
        Villages villages;

        #endregion

        public Request_For_Agent()
        {
            this.InitializeComponent();

            if (ValidationUtil.ChekLogin())
            {
                Agentrequest();
            }

        }

        private async void Agentrequest()
        {
            state = await api.GetStates();
            lstcombobox.ItemsSource = state.ListResult;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            rootFrame.Navigate(typeof(BottomNavigationView));
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            var request = new AgentRequest
            {
                Id = 101,
                FirstName = text_firstname.Text.Trim(),
                MiddleName = text_middlename.Text.Trim(),
                LastName = text_lastname.Text.Trim(),
                MobileNumber = text_mobilenumber.Text.Trim(),
                Email = text_email.Text.Trim(),
                AddressLine1 = text_address1.Text.Trim(),
                AddressLine2 = text_address2.Text.Trim(),
                Landmark = text_landmark.Text.Trim(),
                Comments = text_comments.Text.Trim(),
                AgentRequestCategoryId = 38,
                TitleTypeId = 4,
                VillageId = id
            };

            if (ValidationUtil.IsLogin(rootFrame) && isValidUI(request))
            {
                data = await api.AgentRequestinfo(request);

                var msg = new MessageDialog(data.EndUserMessage);
                await msg.ShowAsync();
                rootFrame.Navigate(typeof(BottomNavigationView));
            }
            else
            {
            }
          }

        private void Errormessage()
        {
            lbl_firstname.Text = "";
            lbl_middlename.Text = "";
            lbl_lastname.Text = "";
            lbl_mobilenumber.Text = "";
            lbl_email.Text = "";
            lbl_State.Text = "";
            lbl_District.Text = "";
            lbl_mandal.Text = "";
            lbl_villages.Text = "";
            lbl_address1.Text = "";
            lbl_address2.Text = "";
            lbl_Landmark.Text = "";
            lbl_Comments.Text = "";

        }

        public  bool isValidUI(AgentRequest agentdata)
        {
            Errormessage();
            if (ValidationUtil.isNotnulSring(agentdata.FirstName))
            {
                lbl_firstname.Text = Constants.firstname;
                return false;
            }
            else if (!ValidationUtil.IsValidname(agentdata.FirstName))
            {
                lbl_firstname.Text = Constants.nameinerror;
                return false;
            }
            else if (ValidationUtil.isnulSring(agentdata.MiddleName))
            { 
                lbl_middlename.Text = Constants.Nullerror;
                return false;
            }
           
            else if (ValidationUtil.isNotnulSring(agentdata.LastName))
            {
                lbl_lastname.Text = Constants.lastname;
                return false;
            }

            else if (!ValidationUtil.IsValidlastname(agentdata.LastName))
            {
                lbl_lastname.Text = Constants.nameinerror;
                return false;
            }
            else if (ValidationUtil.isNotnulSring(agentdata.MobileNumber))
            {
                lbl_mobilenumber.Text = Constants.mobileerror;
                return false;
            }
            else if (!ValidationUtil.IsValidMobileNumber(agentdata.MobileNumber))
            {
                lbl_mobilenumber.Text = Constants.mobilenumbrerror;
                return false;
            }
            else if (ValidationUtil.isNotnulSring(agentdata.Email))
            {
                lbl_email.Text = Constants.EmailError;
                return false;
            }
            else if (!ValidationUtil.isValidEmail(agentdata.Email))
            {
                lbl_email.Text = Constants.EmailError;
                return false;
            }
            else if (lstcombobox.SelectedItem == null)
            { 
                lbl_State.Text = Constants.stateerror;
                return false;
            }
            else if (lstcomboboxdistrict.SelectedItem == null)
            { 
                lbl_District.Text = Constants.dtstricterror;
                return false;
            }
            else if (lstcomboboxmanal.SelectedItem == null)
            { 
                lbl_mandal.Text = Constants.mandalerror;
                return false;
            }
            else if (lstcomboboxvillages.SelectedItem == null)
            {
                lbl_villages.Text = Constants.villageerror;
                return false;
            }
            else if (ValidationUtil.isNotnulSring(agentdata.AddressLine1))
            {  
                lbl_address1.Text = Constants.address1;
                return false;
            }
            else if (!ValidationUtil.IsValidaddress1(agentdata.AddressLine1))
            {
                lbl_address1.Text = Constants.nameinerror;
                return false;
            }

            else if (ValidationUtil.isNotnulSring(agentdata.AddressLine2))
            {
                lbl_address2.Text = Constants.address2;
                return false;
            }
            else if (!ValidationUtil.IsValidaddress2(agentdata.AddressLine2))
            {
                lbl_address2.Text = Constants.nameinerror;
                return false;
            }

            else if (ValidationUtil.isNotnulSring(agentdata.Landmark))
            {
                lbl_Landmark.Text = Constants.lanamark;
                return false;
            }
          
            else if (ValidationUtil.isNotnulSring(agentdata.Comments))
            {
                lbl_Comments.Text = Constants.commnets;
                return false;
            }
          
            return true; 
        }


        private async void lstcombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.lstcombobox.SelectedValue = lstcombobox.SelectedItem;
            var data = (StatesData)lstcombobox.SelectedValue;
           
            districts = await api.GetDistricts(data.Id);
            lstcomboboxdistrict.ItemsSource = districts.ListResult;
        }

        private async void lstcomboboxdistrict_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             this.lstcomboboxdistrict.SelectedValue = lstcomboboxdistrict.SelectedItem;
             var data = (DistrictsData)lstcomboboxdistrict.SelectedValue;
             mandals = await api.GetMandals(data.Id);
             lstcomboboxmanal.ItemsSource = mandals.ListResult;    
        }

        private  async void lstcomboboxmanal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.lstcomboboxmanal.SelectedValue = lstcomboboxmanal.SelectedItem;
            var data = (MandalsData)lstcomboboxmanal.SelectedValue;
            villages = await api.GetVillages(data.Id);
            lstcomboboxvillages.ItemsSource = villages.ListResult;
        }

        private   void lstcomboboxvillages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.lstcomboboxvillages.SelectedValue = lstcomboboxvillages.SelectedItem;
            var data = (VillagesData)lstcomboboxvillages.SelectedValue;
          
            id= data.Id;
        }

        private void text_firstname_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                if (FocusManager.GetFocusedElement() == text_middlename)
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

        private void text_middlename_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                if (FocusManager.GetFocusedElement() == text_lastname)
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

        private void text_lastname_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                if (FocusManager.GetFocusedElement() == text_mobilenumber)
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

        private void text_mobilenumber_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                if (FocusManager.GetFocusedElement() == text_email)
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

        private void text_email_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                if (FocusManager.GetFocusedElement() ==lstcombobox)
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

        private void lstcombobox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                if (FocusManager.GetFocusedElement() == lstcomboboxdistrict)
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

        private void lstcomboboxdistrict_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                if (FocusManager.GetFocusedElement() == lstcomboboxmanal)
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

        private void lstcomboboxmanal_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                if (FocusManager.GetFocusedElement() == lstcomboboxvillages)
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

        private void lstcomboboxvillages_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                if (FocusManager.GetFocusedElement() == text_address1)
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

        private void text_address1_KeyDown(object sender, KeyRoutedEventArgs e)
        {
          
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                if (FocusManager.GetFocusedElement() == text_address2)
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

        private void text_address2_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                if (FocusManager.GetFocusedElement() == text_landmark)
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

        private void text_landmark_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                if (FocusManager.GetFocusedElement() ==text_comments)
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

        private void text_comments_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                if (FocusManager.GetFocusedElement() == button)
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

        private void text_firstname_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            ValidationUtil.valid((TextBox)sender, true);

        }

        private void text_middlename_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            ValidationUtil.valid((TextBox)sender, true);
        }

        private void text_lastname_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            ValidationUtil.valid((TextBox)sender, true);
        }

        private void text_mobilenumber_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            ValidationUtil.validS((TextBox)sender, true);
        }

    }
}






 

