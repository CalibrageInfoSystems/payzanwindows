using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayZan.Framework.Contracts.Pocos
{
  public class savecards
    {

        public string ImageUrl { get; set; }
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
        public string Editimage { get; set; }
        public string Deleteimg { get; set; }

        public savecards(string imgpath,   string bankName, string editimage, string deleteimg )
        {
            this.ImageUrl = imgpath;
         
            this.BankName = bankName;
            this.Editimage = editimage;
            this.Deleteimg = deleteimg;

        }
    }
}
