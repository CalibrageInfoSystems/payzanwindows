using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace PayZan.Framework.Contracts.Pocos
{
   
        public class Deleteaddressresponsedata
        {
            public string AspNetUserId { get; set; }
            public string Name { get; set; }
            public string AddressLine1 { get; set; }
            public string AddressLine2 { get; set; }
            public string Landmark { get; set; }
            public string MobileNumber { get; set; }
            public int VillageId { get; set; }
            public int Id { get; set; }
            public bool IsActive { get; set; }
            public string CreatedBy { get; set; }
            public string ModifiedBy { get; set; }
            public DateTime Created { get; set; }
            public DateTime Modified { get; set; }
        }

        public class Deleteaddressresponse
        {
            public Deleteaddressresponsedata Result { get; set; }
            public bool IsSuccess { get; set; }
            public int AffectedRecords { get; set; }
            public string EndUserMessage { get; set; }
            public List<object> ValidationErrors { get; set; }
            public object Exception { get; set; }

        
    }
    
}
