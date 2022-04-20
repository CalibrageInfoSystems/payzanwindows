using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayZan.framework.Contracts.Pocos
{ 
    
    

        public class VillagesData
    {
            public string CountryName { get; set; }
            public int CountryId { get; set; }
            public string StateName { get; set; }
            public int StateId { get; set; }
            public string DistrictName { get; set; }
            public int DistrictId { get; set; }
            public string MandalName { get; set; }
            public string Code { get; set; }
            public string Name { get; set; }
            public int MandalId { get; set; }
            public int PostCode { get; set; }
            public int Id { get; set; }
            public bool IsActive { get; set; }
            public string CreatedBy { get; set; }
            public string ModifiedBy { get; set; }
            public DateTime Created { get; set; }
            public DateTime Modified { get; set; }
        }

        public class Villages
    {
            public List<VillagesData> ListResult { get; set; }
            public bool IsSuccess { get; set; }
            public int AffectedRecords { get; set; }
            public string EndUserMessage { get; set; }
            public List<object> ValidationErrors { get; set; }
            public object Exception { get; set; }
        }
    }

