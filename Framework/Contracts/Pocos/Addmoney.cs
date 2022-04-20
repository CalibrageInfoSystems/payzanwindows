using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayZan.Framework.Contracts.Pocos
{
   public class Addmoney
    {
            public string WalletId { get; set; }
            public string  Amount { get; set; }
            public int TransactionTypeId { get; set; }
            public int ReasonTypeId { get; set; }
            public int Id { get; set; }
            public bool IsActive { get; set; }
            public string CreatedBy { get; set; }
            public string ModifiedBy { get; set; }
            public string Created { get; set; }
            public string Modified { get; set; }
        
    }

    
}
