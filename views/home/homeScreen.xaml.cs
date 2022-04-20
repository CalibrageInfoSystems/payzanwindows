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
using static PayZan.framework.Contracts.Pocos.ImageViewModel;
using PayZan.views.Agent_Request;
using Windows.Phone.UI.Input;
using Windows.UI.Popups;
using PayZan.views.popup;

namespace PayZan.views.home
{

    public sealed partial class HomeScreen : Page
    {
        List<ImageInfo> datalsit = new List<ImageInfo>();

        List<ImageViewModel.Image> itemList = new List<ImageViewModel.Image>();

        List<BannerModel> itemList_banner = new List<BannerModel>();

        List<WalletInfo> walletlist = new List<WalletInfo>();

        Frame rootFrame = Window.Current.Content as Frame;
        public HomeScreen()
        {
            this.InitializeComponent();

            HardwareButtons.BackPressed += HardwareButtons_BackPressed;

            datalsit.Add(new ImageInfo("/Assets/mobile.png", "Mobile", 0));
            datalsit.Add(new ImageInfo("/Assets/landline_icon.PNG", "Landline", 1));
            datalsit.Add(new ImageInfo("/Assets/dth_icon.PNG", "DTH", 2));
            datalsit.Add(new ImageInfo("/Assets/internet.png", "Broadband", 3));
            datalsit.Add(new ImageInfo("/Assets/television.png", "Cable TV", 4));
            datalsit.Add(new ImageInfo("/Assets/dth_electricity.PNG", "Electricity", 5));
            datalsit.Add(new ImageInfo("/Assets/water-tap.png", "Water", 6));
            datalsit.Add(new ImageInfo("/Assets/internet.png", "Data Card", 7));
            //lst_GridList.ItemsSource = datalsit;
            lst_paybill.ItemsSource = datalsit;
            //lst_bookPay.ItemsSource = datalsit;


            itemList_banner.Add(new BannerModel("/Assets/1.jpg", @"Mobile", 0));
            itemList_banner.Add(new BannerModel("/Assets/2.jpg", @"Mobile", 1));
            itemList_banner.Add(new BannerModel("/Assets/3.jpg", @"Mobile", 2));
            itemList_banner.Add(new BannerModel("/Assets/4.jpg", @"Mobile", 3));


            lst_adds.ItemsSource = itemList_banner;


            walletlist.Add(new WalletInfo("/Assets/payadd.png", "Pay/Send", 0));
            walletlist.Add(new WalletInfo("/Assets/sendwithadraw.png", "Add/Withdraw", 1));
            walletlist.Add(new WalletInfo("/Assets/orderhistory.png", "My Transactions", 2));
          
            lst_GridList.ItemsSource = walletlist;
        }

        public void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
          Frame  frame = sender as Frame;

            if (frame == null)
            {
                return;
            }

            if (frame.CanGoBack)
            {
               Frame.GoBack();
                e.Handled = true;
            }
            else
            {
            //    MessageDialog msgbox = new MessageDialog("Do you want close this app");
            //    var okBtn = new UICommand("OK");
            //    var cancelBtn = new UICommand("Cancel");
            //    msgbox.Commands.Add(okBtn);
            //    msgbox.Commands.Add(cancelBtn);
            //    IUICommand result = await msgbox.ShowAsync();
            //    e.Handled = true;

            //    if (backPressCount == 2)
            //    {
            //        Application.Current.Exit();
            //    }
            }

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }
        private void lst_paybill_ItemClick(object sender, ItemClickEventArgs e)
        {
            {
                ImageInfo data = (ImageInfo)e.ClickedItem;
                int value = data.itemId;
                switch (value)
                {
                    case 0:
                        rootFrame.Navigate(typeof(mobileRechargeView));
                        break;
                    case 1:
                        rootFrame.Navigate(typeof(landlineView));
                        break;
                    case 2:
                        rootFrame.Navigate(typeof(dthView));
                        break;
                    case 3:
                        rootFrame.Navigate(typeof(BroadbandView));
                        break;
                    case 4:
                        rootFrame.Navigate(typeof(cableTvVView));
                        break;
                    case 5:
                        rootFrame.Navigate(typeof(electricityView));
                        break;
                    case 6:
                        rootFrame.Navigate(typeof(WaterView));
                        break;
                    case 7:
                        rootFrame.Navigate(typeof(dataCardView));
                        break;
                    default:
                        break;
                }

            }

        }


        private void lst_GridList_ItemClick(object sender, ItemClickEventArgs e)
        {
            WalletInfo info = (WalletInfo)e.ClickedItem;
            int value = info.itemId;
            switch (value)
            {
                case 0:
                    this.Frame.Navigate(typeof(walletView), 0);
                    break;
                case 1:
                    this.Frame.Navigate(typeof(walletView), 1);
                    break;
                case 2:
                    this.Frame.Navigate(typeof(walletView), 2);
                    break;
                default:
                    break;
            }
          //  this.Frame.Navigate(typeof(walletView));
        }

        public async void showPopUp(int value)
        {
            switch (value)
            {
                case 0:
                    ContentDialog1 control = new ContentDialog1();
                    await control.ShowAsync();
                    break;
                case 1:
                    ContentDialog2 content = new ContentDialog2();
                    await content.ShowAsync();
                    break;
                case 2:
                    ContentDialog3 contents = new ContentDialog3();
                    await contents.ShowAsync();
                    break;
                case 3:
                    ContentDialog4 conten = new ContentDialog4();
                    await conten.ShowAsync();
                    break;

            }
        }
        private void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            rootFrame.Navigate(typeof(Request_For_Agent));
        }

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
        }

        private void lst_adds_ItemClick(object sender, ItemClickEventArgs e)
        {
            
            BannerModel image = (BannerModel)e.ClickedItem;
            int value = image.itemId;
            switch (value)
            {
                case 0:
                    rootFrame.Navigate(typeof(ContentDialog1));
                    showPopUp(value);
                    break;
                case 1:
                    rootFrame.Navigate(typeof(ContentDialog2));
                    showPopUp(value);
                    break;
                case 2:
                    rootFrame.Navigate(typeof(ContentDialog3));
                    showPopUp(value);
                    break;
                case 3:
                    rootFrame.Navigate(typeof(ContentDialog4));
                    showPopUp(value);
                    break;

            }
            
        }

       
    }

}


