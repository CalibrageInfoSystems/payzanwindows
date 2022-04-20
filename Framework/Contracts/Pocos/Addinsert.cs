using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayZan.Framework.Contracts.Pocos
{
    public  class Addinsert
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
        public string Created { get; set; }
        public string Modified { get; set; }
    }
}
