using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayZan.framework.Contracts.Pocos
{

    public class electricitydetails
    {
        public string ServiceNo { get; set; }
        public string Amount { get; set; }
        public string selectoperator { get; set; }
    }

    public class Datacarddetails
    {
        public string DatacardNumber { get; set; }
        public string Amount { get; set; }
        public string selectoperator { get; set; }
    }
    public class Waterdetails
    {
        public string selectboard { get; set; }
        public string CosumerNo { get; set; }
        public string Amount { get; set; }

    }
}
