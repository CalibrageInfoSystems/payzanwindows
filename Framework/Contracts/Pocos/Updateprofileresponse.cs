using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayZan.Framework.Contracts.Pocos
{
   
    public class Updateprofileresponsedata
    {
        public string AspNetUserId { get; set; }
        public int TitleTypeId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int GenderTypeId { get; set; }
        public DateTime DOB { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Landmark { get; set; }
        public int VillageId { get; set; }
        public string ParentAspNetUserId { get; set; }
        public object EducationTypeId { get; set; }
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }

  
    public class Updateprofileresponse
    {
        public Updateprofileresponsedata Result { get; set; }
        public bool IsSuccess { get; set; }
        public int AffectedRecords { get; set; }
        public string EndUserMessage { get; set; }
        public List<object> ValidationErrors { get; set; }
        public object Exception { get; set; }
    }
}
