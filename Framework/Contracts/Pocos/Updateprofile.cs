using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayZan.Framework.Contracts.Pocos
{
   
        public class Updateprofile
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
            public object VillageId { get; set; }
            public string ParentAspNetUserId { get; set; }
            public string EducationTypeId { get; set; }
            public int Id { get; set; }
            public bool IsActive { get; set; }
            public string CreatedBy { get; set; }
            public string ModifiedBy { get; set; }
            public string Created { get; set; }
            public string Modified { get; set; }
        }
  }
