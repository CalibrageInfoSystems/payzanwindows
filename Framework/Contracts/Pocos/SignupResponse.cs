using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayZan.framework.Contracts.Pocos
{
     public class SignupResponse
    {
        public SignupResponsedata Result { get; set; }
        public bool IsSuccess { get; set; }
        public int AffectedRecords { get; set; }
        public string EndUserMessage { get; set; }
        public List<object> ValidationErrors { get; set; }
        public object Exception { get; set; }

        public class SignupResponsedata
        {
            public string Id { get; set; }
            public string UserName { get; set; }
            public string NormalizedUserName { get; set; }
            public string Email { get; set; }
            public string NormalizedEmail { get; set; }
            public bool EmailConfirmed { get; set; }
            public string PasswordHash { get; set; }
            public string SecurityStamp { get; set; }
            public string ConcurrencyStamp { get; set; }
            public string PhoneNumber { get; set; }
            public bool PhoneNumberConfirmed { get; set; }
            public bool TwoFactorEnabled { get; set; }
            public object LockoutEnd { get; set; }
            public bool LockoutEnabled { get; set; }
            public int AccessFailedCount { get; set; }
        }

        
    }

}
