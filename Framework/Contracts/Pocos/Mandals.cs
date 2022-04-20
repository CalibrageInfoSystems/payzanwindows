using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayZan.framework.Contracts.Pocos
{
    
    
        public class MandalsData
        {
            public string CountryName { get; set; }
            public int CountryId { get; set; }
            public string StateName { get; set; }
            public int StateId { get; set; }
            public string DistrictName { get; set; }
            public string Code { get; set; }
            public string Name { get; set; }
            public bool IsCity { get; set; }
            public int DistrictId { get; set; }
            public int Id { get; set; }
            public bool IsActive { get; set; }
            public string CreatedBy { get; set; }
            public string ModifiedBy { get; set; }
            public DateTime Created { get; set; }
            public DateTime Modified { get; set; }
        }

        public class Mandals
        {
            public List<MandalsData> ListResult { get; set; }
            public bool IsSuccess { get; set; }
            public int AffectedRecords { get; set; }
            public string EndUserMessage { get; set; }
            public List<object> ValidationErrors { get; set; }
            public object Exception { get; set; }
        }
    }

