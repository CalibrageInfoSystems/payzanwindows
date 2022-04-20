using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayZan.framework.Contracts
{
    public interface ILocalDataServices
    {
        String Getvalue(string str_value);

        bool AddValue(String str_key, string str_value);

        bool ClearData();

        string languagestype(string lang);

    }
}
