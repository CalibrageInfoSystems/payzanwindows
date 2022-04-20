using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayZan.framework.Contracts.Pocos
{
         public class AgentRequestResponceData
    {
            public int Id { get; set; }
            public int AgentRequestCategoryId { get; set; }
            public int TitleTypeId { get; set; }
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }
            public string MobileNumber { get; set; }
            public string Email { get; set; }
            public string AddressLine1 { get; set; }
            public string AddressLine2 { get; set; }
            public string Landmark { get; set; }
            public int VillageId { get; set; }
            public string Comments { get; set; }
            public DateTime Created { get; set; }
        }

        public class AgentRequestResponce
        {
            public AgentRequestResponceData Result { get; set; }
            public bool IsSuccess { get; set; }
            public int AffectedRecords { get; set; }
            public string EndUserMessage { get; set; }
            public List<object> ValidationErrors { get; set; }
            public object Exception { get; set; }
        }
    }

