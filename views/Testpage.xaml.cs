using Newtonsoft.Json;
using Ninject.Activation;
using PayZan.common;
using PayZan.framework.Contracts.Pocos;
using PayZan.framework.Properties;
using PayZan.Interfaces;
using PayZan.Payzan_WinDB;
using PayZan.services;
using PayZan.views.home;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Threading;
using Windows.UI.Xaml.Input;

using Windows.UI.Xaml.Navigation;
using static PayZan.framework.Contracts.Pocos.ImageViewModel;
using Windows.ApplicationModel.Resources.Core;
using Windows.UI.Xaml.Media;
using Windows.UI;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml.Controls.Primitives;
using System.Threading.Tasks;

namespace PayZan.views
{

    public sealed partial class Testpage : Page
    {
       
        
        
        public Testpage()
        {

            this.InitializeComponent();

            //ResourceMap rmap = ResourceManager.Current.MainResourceMap.GetSubtree("Resources");
            //textblck.Text = rmap.GetValue("Add Money to Wallet", App.ctx).ValueAsString;
            //textbox1.PlaceholderText = rmap.GetValue("Enter Promo Code", App.ctx).ValueAsString;
            //textbox.PlaceholderText = rmap.GetValue("Mobile Number", App.ctx).ValueAsString;
            //btn.Content = rmap.GetValue("Add Money", App.ctx).ValueAsString;

            //btn.Content= cs.Getname();
        }

   

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
          
        }
        private void CmboxLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

          
            if (CmboxLanguage.SelectedIndex == 0)
            {

                ResourceContext ctx = new ResourceContext();
                ctx.Languages = new string[] { "en-US" };
                ResourceMap rmap = ResourceManager.Current.MainResourceMap.GetSubtree("Resources");
                //textblck.Text = rmap.GetValue("Add Money to Wallet", ctx).ValueAsString;
                textbox1.Text = rmap.GetValue("Enter Promo Code", ctx).ValueAsString;
                textbox.Text = rmap.GetValue("Mobile Number", ctx).ValueAsString;
           
            }
            else
            {
                ResourceContext ctx = new ResourceContext();
                ctx.Languages = new string[] { "hi-IN" };
                ResourceMap rmap = ResourceManager.Current.MainResourceMap.GetSubtree("Resources");
                textblck.Text = rmap.GetValue("Add Money to Wallet", ctx).ValueAsString;
                textbox1.Text = rmap.GetValue("Enter Promo Code", ctx).ValueAsString;
                textbox.Text = rmap.GetValue("Mobile Number", ctx).ValueAsString;
              
            }
        }

    }

}  

    


