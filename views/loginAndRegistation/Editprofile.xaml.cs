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
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace PayZan.views.loginAndRegistation
{
   
    public sealed partial class Editprofile : Page
    {
        Frame rootFrame = Window.Current.Content as Frame;
        Provinceresponse Province;
        IRemoteServices api = new RemoteServices();
        Districts districts;
        Mandals mandals;
        Villages villages;
        int id = 1;
        Userprofile profile;
        UserData c = new UserData();
        DatabaseHelperClass Db_Helper = new DatabaseHelperClass();

        public Editprofile()
        {
            this.InitializeComponent();
            c = Db_Helper.ReadUser();
            profileapi();
        }

        private async void Titles()
        {
            var title = await api.GetTypeCdDmtsByClass();
            titlelist.ItemsSource = title.ListResult;
          
           
        }
        private async void Provinces()
        {
            Province = await api.GetProvince();
            provincelist.ItemsSource = Province.ListResult;
            Titles();
        }
        private async void profileapi()
        {
           profile = await api.GetUserPersonalInfo(c.UserID);

            if (profile != null  && profile.IsSuccess == true)
            {
                text_firstname.Text = string.IsNullOrEmpty(profile.Result.FirstName) ? "" : profile.Result.FirstName;
                text_middlename.Text = string.IsNullOrEmpty(profile.Result.MiddleName) ? "" : profile.Result.MiddleName;
                text_lastname.Text = string.IsNullOrEmpty(profile.Result.LastName) ? "" : profile.Result.LastName;
                text_mobilenumber.Text = string.IsNullOrEmpty(profile.Result.Phone) ? "" : profile.Result.Phone;
                text_address1.Text = string.IsNullOrEmpty(profile.Result.Address1) ? "" : profile.Result.Address1;
                text_address2.Text = string.IsNullOrEmpty(profile.Result.Address2) ? "" : profile.Result.Address2;
                text_email.Text = profile.Result.Email.ToString();
                text_username.Text = profile.Result.Phone.ToString();
                selectDate.Date = profile.Result.DOB.HasValue ? profile.Result.DOB.Value : DateTime.Now;;
                titlename.Content = string.IsNullOrEmpty(profile.Result.Title) ? "" : profile.Result.Title;
              //selectDate.Date = profile.Result.DOB.Value != null ? profile.Result.DOB.Value : DateTime.Now;
                text_landmark.Text = string.IsNullOrEmpty(profile.Result.Landmark) ? "" : profile.Result.Landmark;
                provincename.Content = string.IsNullOrEmpty(profile.Result.ProvinceName) ? "" : profile.Result.ProvinceName;
                Districtname.Content = string.IsNullOrEmpty(profile.Result.DistrictName) ? "" : profile.Result.DistrictName;
                mandalname.Content = string.IsNullOrEmpty(profile.Result.MandalName) ? "" : profile.Result.MandalName;
                Villagename.Content = string.IsNullOrEmpty(profile.Result.VillageName) ? "" : profile.Result.VillageName;
                text_Pincode.Text = profile.Result.PostCode.ToString();
                
            }
            Provinces();

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            if (rb != null )
            {
                string name = rb.Content.ToString();
               
            }
            else
            {
                
            }
        }

        private void Profileback_img_Tapped(object sender, TappedRoutedEventArgs e)
        {
            rootFrame.Navigate(typeof(MyProfile));
        }

        private void selectDate_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {

            /* 1.selected date   2.current date*/

            if (ValidationUtil.ValidateDate(e.NewDate.UtcDateTime))
            {
                /*Date is valid Bind data*/
            }
            else
            {
                /* Date is not valid Show error msg ..!*/
            }
        }

        private async void provincelist_ItemsPicked(ListPickerFlyout sender, ItemsPickedEventArgs args)
        {
            Provinceresponsedata data = (provincelist.SelectedItem) as Provinceresponsedata;
            provincename.Content = data.Name;

            districts = await api.GetDistricts(data.Id);
            districtList.ItemsSource = districts.ListResult;
        }

        private async void districtList_ItemsPicked(ListPickerFlyout sender, ItemsPickedEventArgs args)
        {
            DistrictsData data = (districtList.SelectedItem) as DistrictsData;
            Districtname.Content = data.Name;
            mandals = await api.GetMandals(data.Id);
            mandalList.ItemsSource = mandals.ListResult;
        }

        private async void mandalList_ItemsPicked(ListPickerFlyout sender, ItemsPickedEventArgs args)
        {
            MandalsData data = (mandalList.SelectedItem) as MandalsData;
            mandalname.Content = data.Name;
            villages = await api.GetVillages(data.Id);
            villageList.ItemsSource = villages.ListResult;
        }

        private void villageList_ItemsPicked(ListPickerFlyout sender, ItemsPickedEventArgs args)
        {
            VillagesData data = (villageList.SelectedItem) as VillagesData;
            Villagename.Content = data.Name;
            id = data.Id;
            text_Pincode.Text = data.PostCode.ToString();
        }

        private  void titlelist_ItemsPicked(ListPickerFlyout sender, ItemsPickedEventArgs args)
        {
            Titletypedata data = (titlelist.SelectedItem) as Titletypedata;
            titlename.Content = data.Description;
        }

        private async void save_btn_Click(object sender, RoutedEventArgs e)
        {
            Titletypedata data = (titlelist.SelectedItem) as Titletypedata;
            var SelectedValue = data.Id;

           var updateprofile = new Updateprofile();
            updateprofile.FirstName = text_firstname.Text.Trim();
            updateprofile.Address1 = text_address1.Text.Trim();
            updateprofile.Address2 = text_address2.Text.Trim();
            updateprofile.Landmark = text_landmark.Text.Trim();
            updateprofile.MiddleName = text_middlename.Text.Trim();
            updateprofile.Phone = text_mobilenumber.Text.Trim();
            updateprofile.Email = text_email.Text.Trim();
            updateprofile.LastName = text_lastname.Text.Trim();
            updateprofile.AspNetUserId = c.UserID;
            updateprofile.ParentAspNetUserId = c.UserID;
            updateprofile.Id = profile.Result.Id;
            updateprofile.DOB = selectDate.Date.Date;
            updateprofile.VillageId = 1;
            updateprofile.TitleTypeId = SelectedValue;
            updateprofile.EducationTypeId = null;
            if(rbmale.IsChecked== true)
            {
                updateprofile.GenderTypeId = 20;
            }
            else
            {
                updateprofile.GenderTypeId = 21;
            }
            updateprofile.Created = Constants.Created;
            updateprofile.Modified = Constants.Modified;
            updateprofile.IsActive = true;
            updateprofile.CreatedBy = c.UserID;
            updateprofile. ModifiedBy = c.UserID;
            

            var editinfo = await api.Updateprofileinfo(updateprofile);
            {
                if(editinfo != null && editinfo.IsSuccess == true)
                {
                    var msg = new MessageDialog(editinfo.EndUserMessage);
                    await msg.ShowAsync();
                    rootFrame.Navigate(typeof(MyProfile));
                }
                else
                {

                }
            }
        }

        public bool isValidUI(Updateprofile updateprofile)
        {
            if (ValidationUtil.isNotnulSring(updateprofile.FirstName))
            {
                lbl_firstname.Text = Constants.firstname;
                return false;
            }
            else if(!ValidationUtil.IsValidname(updateprofile.FirstName))
            {
                lbl_firstname.Text = Constants.nameinerror;
                return false;
            }
            else if(ValidationUtil.isnulSring(updateprofile.MiddleName))
            {
                return false;
            }
            else if(ValidationUtil.isNotnulSring(updateprofile.LastName))
            {
                lbl_lastname.Text = Constants.lastname;
                return false;
            }
            else if(!ValidationUtil.IsValidlastname(updateprofile.LastName))
            {
                lbl_lastname.Text = Constants.nameinerror;
                return false;
            }
            else if(ValidationUtil.isNotnulSring(updateprofile.Phone))
            {
                lbl_mobilenumber.Text = Constants.mobileerror;
                return false;
            }
            else if(!ValidationUtil.IsValidMobileNumber(updateprofile.Phone))
            {
                lbl_mobilenumber.Text = Constants.mobilenumbrerror;
                return false;

            }
            else if(ValidationUtil.isNotnulSring(updateprofile.Address1))
            {
                lbl_address1.Text = Constants.address1;
                return false;
            }
            else if(ValidationUtil.isNotnulSring(updateprofile.Address2))
            {
                lbl_address2.Text = Constants.address2;
                return false;

            }
            else if(ValidationUtil.isNotnulSring(updateprofile.Landmark))
            {
                lbl_lastname.Text = Constants.lanamark;
                return false;
            }
            else if(ValidationUtil.isNotnulSring(updateprofile.Email))
            {
                lbl_email.Text = Constants.Email;
                return false;
            }
            else if(!ValidationUtil.isValidEmail(updateprofile.Email))
            {
                lbl_email.Text = Constants.EmailError;
                return false;
            }
            else if(provincelist.SelectedItem == null)
            {
                lbl_Province.Text = Constants.stateerror;
                return false;

            }
            else if(districtList.SelectedItem == null)
            {
                lbl_district.Text = Constants.dtstricterror;
                return false;
            }
            else if(mandalList.SelectedItem== null)
            {
                lbl_mandal.Text = Constants.mandalerror;
                return false;
            }
            else if(villageList.SelectedItem == null)
            {
                lbl_village.Text = Constants.villageerror;
                return false;
            }
            else if(ValidationUtil.ValidateDate(updateprofile.DOB))
            {
                lbl_date.Text = Constants.dateerror;
                return false;

            }
           
            

            return true;
            
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
                if (FocusManager.GetFocusedElement() == text_username)
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

        private void text_username_KeyDown(object sender, KeyRoutedEventArgs e)
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

        private void text_mobilenumber_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            ValidationUtil.validS((TextBox)sender, true);
        }

        private void text_username_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            ValidationUtil.validS((TextBox)sender, true);
        }

        private void text_lastname_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            ValidationUtil.valid((TextBox)sender, true);
        }

        private void text_middlename_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            ValidationUtil.valid((TextBox)sender, true);
        }

        private void text_firstname_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            ValidationUtil.valid((TextBox)sender, true);
        }

        private void text_Pincode_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            ValidationUtil.validS((TextBox)sender, true);
        }
    }
}
