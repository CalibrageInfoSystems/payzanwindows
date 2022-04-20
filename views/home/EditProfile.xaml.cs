using PayZan.common;
using PayZan.framework.Contracts;
using PayZan.framework.Properties;
using PayZan.framework.services;
using PayZan.Framework.Contracts.Pocos;
using PayZan.Interfaces;
using PayZan.services;
using PayZan.views.loginAndRegistation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
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
    public sealed partial class EditProfile : Page
    {
        String ImagePath;

        CoreApplicationView view;

        Frame rootFrame = Window.Current.Content as Frame;
        IRemoteServices api = new RemoteServices();

        ILocalDataServices localDB = new LocalDataServices();

        public EditProfile()
        {
            this.InitializeComponent();
            view = CoreApplication.GetCurrentView();
        }

       
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            rootFrame.Navigate(typeof(MyProfile));
        }

        

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

            RadioButton rb = sender as RadioButton;
            rb.Name = rb.GroupName + " " + rb.Name;
        }

        private void save_btn_Click(object sender, RoutedEventArgs e)
        {
            var editsave = new editprofileinfo
            {
                FirstName = text_firstname.Text.Trim(),
                LastName = text_lastname.Text.Trim(),
                displayName =text_displayname.Text.Trim(),
               

            };
            if(IsvalidUI(editsave))
            {

            }
        }
        private void Errormessage()
        {
            lbl_firstname.Text = "";
            lbl_lastname.Text = "";
            lbl_displayname.Text = "";
            lbl_date.Text = "";
        }

        private bool IsvalidUI(editprofileinfo editsave)
        {
            Errormessage();
            if (ValidationUtil.isNotnulSring(editsave.FirstName))
            {
                lbl_firstname.Text = Constants.firstname;
                return false;
            }
          
            else if (ValidationUtil.isNotnulSring(editsave.LastName))
            {
                lbl_firstname.Text = "";
                lbl_lastname.Text = Constants.lastname;
                return false;
            }
           
            else if(ValidationUtil.isNotnulSring(editsave.displayName))
            {
                lbl_lastname.Text = "";
                lbl_displayname.Text = Constants.username;
                return false;
            }
            else if (!ValidationUtil.ValidateDate(selectDate.Date.UtcDateTime))
            {
                lbl_displayname.Text = "";
                lbl_date.Text = Constants.dateerror;
                return false;
            }
            else if(ValidationUtil.isNotnulSring(editsave.Gender))
             {
                lbl_date.Text = "";
                lbl_gender.Text = Constants.gendererror;
                return false;
             }

            lbl_gender.Text = "";
            return true;
            
        }

        private void selectDate_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {

            /*   1.selected date   2. current date*/

            if (ValidationUtil.ValidateDate(e.NewDate.UtcDateTime))
            {
                /* Date is valid Bind data*/
            }
            else
            {
                /* Date is not valid Show error msg ..!*/
            }
        }

        private void text_firstname_KeyDown(object sender, KeyRoutedEventArgs e)
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

        private void text_displayname_KeyDown(object sender, KeyRoutedEventArgs e)
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

        private void editname_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ImagePath = string.Empty;
            FileOpenPicker filePicker = new FileOpenPicker();
            filePicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            filePicker.ViewMode = PickerViewMode.Thumbnail;

            // Filter to include a sample subset of file types
            filePicker.FileTypeFilter.Clear();
            filePicker.FileTypeFilter.Add(".bmp");
            filePicker.FileTypeFilter.Add(".png");
            filePicker.FileTypeFilter.Add(".jpeg");
            filePicker.FileTypeFilter.Add(".jpg");

            filePicker.PickSingleFileAndContinue();
            view.Activated += viewActivated;
        }
        private async void viewActivated(CoreApplicationView sender, IActivatedEventArgs args1)
        {
            FileOpenPickerContinuationEventArgs args = args1 as FileOpenPickerContinuationEventArgs;

            if (args != null)
            {
                if (args.Files.Count == 0) return;

                view.Activated -= viewActivated;
                StorageFile storageFile = args.Files[0];
                var stream = await storageFile.OpenAsync(Windows.Storage.FileAccessMode.Read);
                var bitmapImage = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
                await bitmapImage.SetSourceAsync(stream);

                var decoder = await Windows.Graphics.Imaging.BitmapDecoder.CreateAsync(stream);
                profile_img.Source = bitmapImage;
            }
        }

      
    }
}
