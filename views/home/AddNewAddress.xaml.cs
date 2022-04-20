
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

namespace PayZan.views.home
{
   
    public sealed partial class AddNewAddress : Page
    {

        Frame rootFrame = Window.Current.Content as Frame;

        Provinceresponse Province;

        IRemoteServices api = new RemoteServices();
      
        Districts districts;
        Mandals mandals;
        Villages villages;
        int id = 1;
        UserData c = new UserData();
   
        DatabaseHelperClass Db_Helper = new DatabaseHelperClass();
        public AddNewAddress()
        {
            this.InitializeComponent();
            Provinces();
            c = Db_Helper.ReadUser();
        }
        private async void Provinces()
        {
            Province = await api.GetProvince();
            provincelist.ItemsSource = Province.ListResult;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void Backarrow_img_Tapped(object sender, TappedRoutedEventArgs e)
        {
            rootFrame.Navigate(typeof(Add_Address));
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
            text_Pincode.Text = data.PostCode.ToString();
           

        }

        private async void addressnew_btn_Click(object sender, RoutedEventArgs e)
        {
            var address = new Addinsert
            {
                Name = text_name.Text.Trim(),
                AddressLine1 = text_address1.Text.Trim(),
                AddressLine2 = text_address2.Text.Trim(),
                Landmark = text_landmark.Text.Trim(),
                MobileNumber = text_mobilenumber.Text.Trim(),
                AspNetUserId =c.UserID,
                VillageId = 1,
                Id = 0,
                Created = Constants.Created,
                Modified = Constants.Modified,
                IsActive = true,
                CreatedBy = c.UserID,
                ModifiedBy = c.UserID,

            };

            if (isValidUI(address))
            {
                var insertresponse = await api.addressinsert(address);
                if (insertresponse.IsSuccess == true)
                {
                    var msg = new MessageDialog(insertresponse.EndUserMessage);
                    rootFrame.Navigate(typeof(Add_Address));
                }
            }
            else
            {

            }
        }

        public bool isValidUI(Addinsert address)
        {
         
            if (ValidationUtil.isNotnulSring(address.Name))
            {
                lbl_name.Text = Constants.nameerror;
                return false;
            }
            else if (!ValidationUtil.IsValidname(address.Name))
            {
                return false;
            }
       
          
            else if (ValidationUtil.isNotnulSring(address.AddressLine1))
            {
                lbl_address1.Text = Constants.address1;
                return false;
            }
            //else if (!ValidationUtil.IsValidaddress1(address.AddressLine1))
            //{
            //    lbl_address1.Text = Constants.nameinerror;
            //    return false;
            //}

            else if (ValidationUtil.isNotnulSring(address.AddressLine2))
            {
                lbl_address2.Text = Constants.address2;
                return false;
            }
            //else if (!ValidationUtil.IsValidaddress2(address.AddressLine2))
            //{
            //    lbl_address2.Text = Constants.nameinerror;
            //    return false;
            //}
            else if (ValidationUtil.isNotnulSring(address.Landmark))
            {
                lbl_landmark.Text = Constants.lanamark;
                return false;
            }

            else if (ValidationUtil.isNotnulSring(address.MobileNumber))
            {
                lbl_mobilenumber.Text = Constants.mobileerror;
                return false;
            }

            else if (!ValidationUtil.IsValidMobileNumber(address.MobileNumber))
            {
                lbl_mobilenumber.Text = Constants.mobilenumbrerror;
                return false;
            }
          
            else if (provincelist.SelectedItem == null)
            {
                lbl_Province.Text = Constants.stateerror;
                return false;
            }
            else if (districtList.SelectedItem == null)
            {
                lbl_district.Text = Constants.dtstricterror;
                return false;
            }
            else if (mandalList.SelectedItem == null)
            {
                lbl_mandal.Text = Constants.mandalerror;
                return false;
            }
            else if (villageList.SelectedItem == null)
            {
                lbl_village.Text = Constants.villageerror;
                return false;
            }
          
            return true;
        }

        private void text_name_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            ValidationUtil.valid((TextBox)sender, true);
        }

        private void text_mobilenumber_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            ValidationUtil.validS((TextBox)sender, true);
        }
    }
}
