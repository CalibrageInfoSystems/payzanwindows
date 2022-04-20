using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayZan.framework.Contracts;

namespace PayZan.framework.services
{
    class LocalDataServices :ILocalDataServices
    {
        public static Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

        public bool AddValue(string str_key, string str_value)
        {
            try
            {
                localSettings.Values.Add(str_key, str_value);
                return true;

            }
            catch (Exception exc)
            {
                return false;

            }
        }

        public string Getvalue(string str_value)
        {
            Object result = "Logout";
            try
            {
                if (!String.IsNullOrEmpty(localSettings.Values[str_value].ToString()))
                {
                    result = localSettings.Values[str_value];
                    return result.ToString();
                }
                return result.ToString();

            }
            catch (Exception exc)
            {
                return result.ToString();

            }
        }

        public bool ClearData()
        {
            try
            {
                localSettings.Values.Clear();
                return true;
            }
            catch (Exception exc)
            {
                return false;

            }
        }

        public string languagestype(string lang)
        {
            throw new NotImplementedException();


        }
    }
}
