
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayZan.framework.Contracts.Pocos
{
    public class LoginModel
    {
        public string clientId { get; set; }
        public string clientSecret { get; set; }
        public string scope { get; set; }
        public string userName { get; set; }
        public string password { get; set; }

    }
}

