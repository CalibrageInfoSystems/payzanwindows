using PayZan.Framework.Contracts.Pocos;
using PayZan.Interfaces;
using PayZan.Payzan_WinDB;
using PayZan.services;
using PayZan.views.home;
using PayZan.views.loginAndRegistation;
using SQLiteWp8._1.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
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

namespace PayZan
{
   
    public sealed partial class Add_Address : Page
    {
       

        
        Frame rootFrame = Window.Current.Content as Frame;

        IRemoteServices api = new RemoteServices();

        DatabaseHelperClass Db_Helper = new DatabaseHelperClass();
     
       
        UserData c = new UserData();


        public Add_Address()
        {
            this.InitializeComponent();
            c = Db_Helper.ReadUser();
            getadress();
        }

        private async void getadress()
        {
            var addres = await api.Getaddressinfo(c.UserID);
            lst_GridList.ItemsSource = addres.ListResult;
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
           
        }

        private void addnewaddress_btn_Click(object sender, RoutedEventArgs e)
        {

            rootFrame.Navigate(typeof(AddNewAddress));
        }

        private void Backarrow_img_Tapped(object sender, TappedRoutedEventArgs e)
        {
            rootFrame.Navigate(typeof(MyProfile));
        }

        private async void delete_btn_Click(object sender, RoutedEventArgs e)
        {
            Button delete_btn = sender as Button;

            string value = delete_btn.CommandParameter.ToString();

            MessageDialog showDialog = new MessageDialog("Do You want delete this Item....");

            showDialog.Commands.Add(new UICommand("Yes") { Id = 0 });

            showDialog.Commands.Add(new UICommand("No") { Id = 1 });

            showDialog.DefaultCommandIndex = 0;

            showDialog.CancelCommandIndex = 1;

            var result = await showDialog.ShowAsync();

            if ((int)result.Id == 0)
            {
               var deleteeid = await api.deleteaddressinfo(value);
               
            }
            else
            {

            }
        }
     
        private void edit_Click_1(object sender, RoutedEventArgs e)
        { 
            Button edit = (Button)sender;

            var  addresid = edit.CommandParameter.ToString();
            
            rootFrame.Navigate(typeof(EditAddress), addresid);
        }
        
       
    }
}
