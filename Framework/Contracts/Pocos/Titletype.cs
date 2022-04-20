using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayZan.Framework.Contracts.Pocos
{
   
        public class Titletypedata
    {
            public string ClassName { get; set; }
            public int Id { get; set; }
            public int ClassTypeId { get; set; }
            public string Description { get; set; }
            public string TableName { get; set; }
            public string ColumnName { get; set; }
            public string SortOrder { get; set; }
            public bool IsActive { get; set; }
            public string CreatedBy { get; set; }
            public DateTime Created { get; set; }
            public string ModifiedBy { get; set; }
            public DateTime Modified { get; set; }
        }

        public class Titletype
        {
            public List<Titletypedata> ListResult { get; set; }
            public bool IsSuccess { get; set; }
            public int AffectedRecords { get; set; }
            public string EndUserMessage { get; set; }
            public List<object> ValidationErrors { get; set; }
            public object Exception { get; set; }
        }
    
}
