using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace PayZan.framework.Contracts.Pocos
{
    public class Wallet
    {
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public double Money { get; set; }

        public Wallet(string imgpath, string imgName, double money)
        {
            this.ImageUrl = imgpath;
            this.Name = imgName;
            this.Money = money;
        }

    }
    public class WalletDetails
    {
        public string MobileNumber { get; set; }
        public string Amount { get; set; }
        public string Comment { get; set; }
    }
}

