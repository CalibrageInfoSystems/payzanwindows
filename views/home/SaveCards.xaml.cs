using PayZan.Framework.Contracts.Pocos;
using PayZan.views.loginAndRegistation;
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
   
    public sealed partial class SaveCards : Page
    {
        List<savecards> Itemslist = new List<savecards>();

        Frame rootFrame = Window.Current.Content as Frame;

        public SaveCards()
        {
            this.InitializeComponent();

            Itemslist.Add(new savecards("/Assets/icons8-visa-48.png", "4567 ****  **** 8578 | BankName", "/Assets/edit icon.png", "/Assets/Deleteimage.png"));
            Itemslist.Add(new savecards("/Assets/icons8-visa-48.png", "4567 ****  **** 8578 | BankName", "/Assets/edit icon.png", "/Assets/Deleteimage.png"));
            Itemslist.Add(new savecards("/Assets/icons8-visa-48.png", "4567 ****  **** 6578 | BankName", "/Assets/edit icon.png", "/Assets/Deleteimage.png"));
            Itemslist.Add(new savecards("/Assets/icons8-visa-48.png", "4567 ****  **** 4578 | BankName", "/Assets/edit icon.png", "/Assets/Deleteimage.png"));
            savecard.ItemsSource = Itemslist;
        }

        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void Edit_img_Tapped(object sender, TappedRoutedEventArgs e)
        { 

        }

        private void Delete_img_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void Backarrow_img_Tapped(object sender, TappedRoutedEventArgs e)
        {
            rootFrame.Navigate(typeof(MyProfile));
        }

        private void Addnewcard_btn_Click(object sender, RoutedEventArgs e)
        {
            rootFrame.Navigate(typeof(Addnewcard));
        }
    }
}
