using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayZan.Framework.Contracts.Pocos
{



    public class UserWalletdata
    {
        public int Id { get; set; }
        public string WalletId { get; set; }
        public int Amount { get; set; }
        public int TransactionTypeId { get; set; }
        public string TransactionType { get; set; }
        public int ReasonTypeId { get; set; }
        public string ReasonType { get; set; }
        public bool IsActive { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }


    public class Userwallet
    {
        public List<UserWalletdata> ListResult { get; set; }
        public bool IsSuccess { get; set; }
        public int AffectedRecords { get; set; }
        public string EndUserMessage { get; set; }
        public List<object> ValidationErrors { get; set; }
        public object Exception { get; set; }
    }
}
