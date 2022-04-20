using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayZan.Framework.Contracts.Pocos
{
  
        public class Getaddressdata
        {
            public string CountryName { get; set; }
            public object ProvinceName { get; set; }
            public string DistrictName { get; set; }
            public string MandalName { get; set; }
            public string VillageName { get; set; }
            public int PostCode { get; set; }
            public int ProvinceId { get; set; }
            public int DistrictId { get; set; }
            public int MandalId { get; set; }
            public int CountryId { get; set; }
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

        public class Getaddress
        {
            public List<Getaddressdata> ListResult { get; set; }
            public bool IsSuccess { get; set; }
            public int AffectedRecords { get; set; }
            public string EndUserMessage { get; set; }
            public List<object> ValidationErrors { get; set; }
            public object Exception { get; set; }
        }
    
}
