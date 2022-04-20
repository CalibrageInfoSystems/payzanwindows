using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayZan.framework.Contracts.Pocos
{



    public class UserResponceModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        

    }
        public class Role
        {
            public string UserId { get; set; }
            public string RoleId { get; set; }
        }

        public class ActivityRight
        {
            public string RoleId { get; set; }
            public int ActivityRightId { get; set; }
        }

        public class UserWallet
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

        public class userResult
        {
            public UserResponceModel User { get; set; }
            public List<Role> Roles { get; set; }
            public List<ActivityRight> ActivityRights { get; set; }
            public UserWallet UserWallet { get; set; }
            public string AccessToken { get; set; }
            public int ExpiresIn { get; set; }
            public string TokenType { get; set; }
        }

        public class userRootObject
        {
            public userResult Result { get; set; }
            public bool IsSuccess { get; set; }
            public int AffectedRecords { get; set; }
            public string EndUserMessage { get; set; }
            public List<object> ValidationErrors { get; set; }
            public object Exception { get; set; }
        }
    
}
