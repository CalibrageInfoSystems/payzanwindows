using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayZan.Framework.Contracts.Pocos
{
   
    public class Walletbalancedata
    {
        public string UserId { get; set; }
        public string WalletId { get; set; }
        public double Balance { get; set; }
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }

  

    public class Walletbalance
    {
        public Walletbalancedata Result { get; set; }
        public bool IsSuccess { get; set; }
        public int AffectedRecords { get; set; }
        public string EndUserMessage { get; set; }
        public List<object> ValidationErrors { get; set; }
        public object Exception { get; set; }
    }
}
