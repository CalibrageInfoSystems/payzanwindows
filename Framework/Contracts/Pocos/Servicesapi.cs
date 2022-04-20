using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayZan.framework.Contracts.Pocos
{

    public class serviceproviderdata 
    {
      

        public string Name { get; set; }
        public string Remarks { get; set; }
        public string FileName { get; set; }
        public string FileLocation { get; set; }
        public string FileExtension { get; set; }
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }

    public class Serviceprovider
    {
        public List<serviceproviderdata> ListResult { get; set; }
        public bool IsSuccess { get; set; }
        public int AffectedRecords { get; set; }
        public string EndUserMessage { get; set; }
        public List<object> ValidationErrors { get; set; }
        public object Exception { get; set; }
    }


   
}

