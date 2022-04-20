using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayZan.Framework.Contracts.Pocos
{
   public class orderhistory
    {
        public string  Name { get; set; }
        public int  Date { get; set; }
        public string Time { get; set; }

        public orderhistory(string name, int date ,string time)
        {
            this.Name = name;
            this.Date = date;
            this.Time = time;

        }
    }
}
