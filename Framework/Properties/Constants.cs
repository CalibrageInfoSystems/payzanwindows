using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayZan.framework.Properties
{
   public class Constants
    {



        public const string APP_NAME = "PayZan";

        /* User Values */

        public  const string ISLOGIN = "ISLOGIN";
       
        public const int LOGIN = 1; /*"login"*/
        public const string LOGOUT = "logout";
        public const string Email = "";
        public const string PASSWORD = "";

        /* Error msgs*/

        public const string Nullerror = "Emter mobile number";
        public static string nameerror = "Enter your name";

        
        public const string mobileerror = "Enter Mobile Number";
        public const string passerror = "Please Enter Password ";
        public const string EmailError = "Enter Valid Email Id";
        public const string mobilenumbrerror = "Enter Valid Mobile Number";
        public const string conpasserror = " Please Enter confirm password ";
        public const string passworderror = "Password Should be 5-15length atleast,1number/1uppercase/1symbol";
        public const string Conformerror = "Password and Confirm password don't match";
        public const string amounterror = "Enter amount ";
        public const string sunscriberid = "Enter subscriber id";
        public const string servicenumber = "Enter service number";
        public const string accountnumber = "Enter account number";
        public const string ComboboxError = "Please select operator ";
        public const string borderror = "Please select board ";
    
        public const string consumerno = "Enter Consumer Number";
        public const string datacardno = "Enter Datacard Number";
        public const string cardno = "Enter Card Number";
        public const string cardnumber = "Please Enter Valid Cardnumber";
        public const string cardholdername = "Enter Cardholder Name";
        public const string firstname = "Enter First Name";
        public const string lastname = "Enter Last Name ";
        public const string address1 = "Enter Address1";
        public const string address2 = "Enter Address2";
        public const string lanamark = "Enter Landmark";
        public const string commnets = "Enter Comments";
        public const string amountinerror = " Amount Should be lessthan 5000";

        public const string username = "Enter User Name";
        public const string stateerror = "Please Select your Province";
        public const string dtstricterror = "Please Select your district";
        public const string mandalerror = "Please Select your mandal";
        public const string villageerror = "Please Select your village";

        public const string currnetpass = " Please Enter Current Password ";
        public const string newpass = "Please Enter New password";

        public const string retype = "Please Enter Retype password";

        public const string newpassworderror = "Newpassword and Re type Password don't match";
        public const string gendererror = " please Select the Gender";
        public const string dateerror = "Invalid Date";
        public const string nameinerror = "  ";



        /* services providers ids*/

        public const string SERVICE_PROVIDER_ID_POSTPAID = "8";
        public const string SERVICE_PROVIDER_ID_PREPAID = "7";
        public const string SERVICE_PROVIDER_ID_ELECTRICITY = "9";
        public const string SERVICE_PROVIDER_ID_DTH = "12";
        public const string SERVICE_PROVIDER_ID_WATER = "10";
        public const string SERVICE_PROVIDER_ID_DATACARD = "40";
        public const string SERVICE_PROVIDER_ID_LANDLINE = "41";
        public const string SERVICE_PROVIDER_ID_CABLEBILL = "42";

        /* wallet id */

        public static  string WalletId = "071f3ea9-c045-4685-afe3-7695c1b07b0b";
        public static string UserId = "bbb587aa-b353-47ad-9a31-a9b214277b5e";
        public static int ReasonTypeId = 31;
        public static int TransactionTypeId = 36;
        public static string Created = "2017-11-20T06:19:11.464016+00:00";
        public static string Modified= "2017-11-20T06:19:11.464016+00:00";
        public static string clientid = "payzan.mobile";

        public static string clientsecret = "PayZan!@";
        
        public static string scope = "offline_access";



    
    }
}
