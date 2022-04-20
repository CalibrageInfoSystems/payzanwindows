using PayZan.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayZan.framework.Contracts.Pocos;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using PayZan.Framework.Contracts.Pocos;
using PayZan.framework.Properties;
using SQLiteWp8._1.Model;
using PayZan.Payzan_WinDB;
using Windows.UI.Xaml.Controls;
using PayZan.views.loginAndRegistation;
using Windows.UI.Xaml;
using PayZan.common;

namespace PayZan.services
{
    class RemoteServices : IRemoteServices
    {
        #region Constants and Urls
        //public static string BASEURL = "http://payzandev1.azurewebsites.net/api/";

        //public static string BASEURL = "http://103.211.39.50/PayZan/PayZanAPI/api/";

        public static string BASEURL = "http://192.168.1.160/PayZanAPI/api/";

        //public static string BASEURL = "http://192.168.1.34/PayZanAPI/api/";

        //public static string BASEURL = "http://192.168.1.165/PayZanAPI/api/";

        //public static string BASEURL = "http://192.168.1.119/PayZanAPI/api/";

        public static string AGENTREQUESTINFO = "AgentRequestInfo/AddAgentRequestInfo";
        public static String BaseUrl = BASEURL;

        public static HttpClient client;
        public static HttpContent content;
        public static string GetDistrictsInfo = "Districts/GetDistrictsInfo/";
        public static string GETMANDALS = "Mandals/GetMandalInfo/";
        public static string GetStateInfo = "States/GetStateInfo/1";
        public static string GETVILLAGES = "Villages/GetVillageInfo/";
        public static string SERVICEPROVIDER = "Serviceprovider/GetServiceProvidersByServiceType/";
        public static string USERLOGIN = "Register/Login";
        public static string USERRegister = "Register/Register";
        public static string USERWALLET = "UserWallet/GetPassbookDetails/";
        public static string USERPROFILE = "UserInfo/GetUserPersonalInfo/";
        public static string SENDMONEY = "UserWallet/SendMoneyToUserWallet";
        public static string ADDMONEY = "UserWallet/AddMoneyToUserWallet";
        public static string UserBalance= "UserWallet/Get/";
        public static string Addressinsert = "Address/insert";
        public static string GetProvinces = "Province/GetProvinces/null";
        public static string GETTYPECDMS = "TypeCdDmts/GetTypeCdDmtsByClassType/4";
        public static string GETADDRESS = "Address/GetAddressByUserId/";
        public static string EDITADDRESS = "Address/GetAddressByAddressId/";
        public static string DELETEADDRESS = "Address/delete/";
        public static string UPDATEADDRESS = "Address/update";
        public static string UPDATEPROFILE = "UserInfo/UpdateUserPersonalInfo";
        public static string CHANGEPASSWORD = "Register/ChangePassword";


        /* authrization tokens */

        /*  to get wallt balence from api by id*/

        public static int TransactionTypeId = 31;
    

        RootObject RootObject = new RootObject();

        String Type = "application/json";

        UserData c = new UserData();


        DatabaseHelperClass Db_Helper = new DatabaseHelperClass();

        Frame rootFrame = Window.Current.Content as Frame;

        string token = "";

        #endregion

        #region constructor

        public RemoteServices()
        {
            getTokens();
            client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl); 
        }
        #endregion

        private void getTokens()
        {
            if (c != null)
            {
                c = Db_Helper.ReadUser();

                if (ValidationUtil.ChekLogin())
                {
                    token = c.TokenType + " " + c.Token;
                }
            }
        }

        #region LoginAPI
        public async Task<userRootObject> UserLogin(LoginModel userData)
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Type));
                var json = JsonConvert.SerializeObject(userData);

                HttpContent content = new StringContent(json);
                content.Headers.ContentType = new MediaTypeHeaderValue(Type);

                var response = await client.PostAsync(USERLOGIN, content);
                var Result = response.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<userRootObject>(Result);
            }
            catch (Exception exc)
            {
                return null;
            }
        }
        #endregion

        #region RegistrationAPI

        public async Task<SignupResponse> UserRegistration(SignUpModel signup_data)
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Type));
                var json = JsonConvert.SerializeObject(signup_data);

                HttpContent content = new StringContent(json);
                content.Headers.ContentType = new MediaTypeHeaderValue(Type);
               

                var response = await client.PostAsync(USERRegister, content);
                var Result = response.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<SignupResponse>(Result);

            }
            catch (Exception)
            {
                return null;
            }

        }

        #endregion

        #region AgentRequest API
        public async Task<AgentRequestResponce> AgentRequestinfo(AgentRequest agentRequest)
        {

            try
            {

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Type));

                var json = JsonConvert.SerializeObject(agentRequest);

             
                HttpContent content = new StringContent(json);
           
                content.Headers.ContentType = new MediaTypeHeaderValue(Type);
              
                
                var response = await client.PostAsync(AGENTREQUESTINFO, content);
                var Result = response.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<AgentRequestResponce>(Result);

            }
            catch (Exception exc)
            {
                return null;
            }
        }
        #endregion

        #region District Api
        public async Task<Districts> GetDistricts(int Id)
        {

            try
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Type));

                var response = await client.GetAsync(GetDistrictsInfo + Id);
                var Result = response.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<Districts>(Result);


            }
            catch (Exception exc)
            {

                return null;
            }
        }

        #endregion

        #region Mandals Api
        public async Task<Mandals> GetMandals(int Id)
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Type));

                var response = await client.GetAsync(GETMANDALS + Id);
                var Result = response.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<Mandals>(Result);

            }
            catch (Exception exc)
            {

                return null;
            }
        }
        #endregion

        #region Serviceprovider Api

        public async Task<Serviceprovider> GetServiceProvider(string id)
        {
            var service = new Serviceprovider();
            try
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Type));
               


                var response = await client.GetAsync(SERVICEPROVIDER + id);
                var Result = response.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<Serviceprovider>(Result);
 
            }
            catch (Exception exc)
            {

                return null;
            }
        }
        #endregion

        #region States API

        public async Task<States> GetStates()
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Type));

                client.DefaultRequestHeaders.Add("Authorization", token);

                var response = await client.GetAsync(GetStateInfo);

                var Result = response.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<States>(Result);

            }
            catch (Exception exc)
            {
                return null;
            }

        }

        #endregion

        #region Villages Api
        public async Task<Villages> GetVillages(int Id)
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Type));

                var response = await client.GetAsync(GETVILLAGES + Id);

                var Result = response.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<Villages>(Result);

            }
            catch (Exception exc)
            {

                return null;
            }
        }


        #endregion

        #region UserProfile

        public async Task<Userprofile> GetUserPersonalInfo(string UserId)
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Type));
                client.DefaultRequestHeaders.Add("Authorization", token);

                var response = await client.GetAsync(USERPROFILE + UserId);
                var Result = response.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<Userprofile>(Result);
            }
            catch (Exception exc)
            {
                return null;
            }
        }



        #endregion

        #region passbookdetails

        public async Task<Userwallet> GetPassbookDetails(string WalletId)
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Type));


                var response = await client.GetAsync(USERWALLET + WalletId +"/"+TransactionTypeId);
                var Result = response.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<Userwallet>(Result);
            }
            catch (Exception exc)
            {
                return null;
            }
        }
        #endregion

        #region Addmoney
        public async Task<AddmoneyResponse> AddMoneyToUserWallet(Addmoney adddata)
        {
            try
            {
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(BaseUrl);

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Type));

                client.DefaultRequestHeaders.Add("Authorization", token);

                var json = JsonConvert.SerializeObject(adddata);


                HttpContent content = new StringContent(json);

                content.Headers.ContentType = new MediaTypeHeaderValue(Type);
                

                var response = await client.PostAsync(ADDMONEY, content);

                var Result = response.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<AddmoneyResponse>(Result);
           
            }
            catch (Exception exc)
            {

                return null;
            }
        }

        #endregion

        #region Sendmoney

        public async Task<SendmoneyResponse> SendMoneyToUserWallet(SendmoneyRewquest senddata)
        {
            try
            {
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Type));
                client.DefaultRequestHeaders.Add("Authorization", token);


                var json = JsonConvert.SerializeObject(senddata);

                HttpContent content = new StringContent(json);
                content.Headers.ContentType = new MediaTypeHeaderValue(Type);
               
                var response = await client.PostAsync(SENDMONEY, content);
                var Result = response.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<SendmoneyResponse>(Result);

            }
            catch (Exception)
            {

                return null;
            }
        }

        #endregion

        #region wallet balance

        public async Task<Walletbalance> GetBalance(int WalletID)
        {
            try
            {
                HttpClient Client = new HttpClient();

                Client.BaseAddress = new Uri(BaseUrl);

                Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Type));

                Client.DefaultRequestHeaders.Add("Authorization", token );

                var response = await Client.GetAsync(UserBalance + WalletID);

                var Result = response.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<Walletbalance>(Result);

            }
            catch (Exception exc)
            {
                return null;
            }
        }


        #endregion

        #region Provinceresult
        public async Task<Provinceresponse> GetProvince()
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Type));

               // client.DefaultRequestHeaders.Add("Authorization", token);

                var response = await client.GetAsync(GetProvinces);

                var Result = response.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<Provinceresponse>(Result);

            }
            catch (Exception exc)
            {
                return null;
            }
        }

        #endregion

        #region addressinsert

        public async Task<Addaddressresponse> addressinsert(Addinsert address)
        {
            try
            {
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Type));
                client.DefaultRequestHeaders.Add("Authorization", token);


                var json = JsonConvert.SerializeObject(address);

                HttpContent content = new StringContent(json);
                content.Headers.ContentType = new MediaTypeHeaderValue(Type);

                var response = await client.PostAsync(Addressinsert, content);
                var Result = response.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<Addaddressresponse>(Result);

            }
            catch (Exception)
            {

                return null;
            }

        }

        #endregion

        #region getaddress

        public async Task<Getaddress> Getaddressinfo(string Userid)
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Type));

                client.DefaultRequestHeaders.Add("Authorization", token);

                var response = await client.GetAsync(GETADDRESS + Userid);

                var Result = response.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<Getaddress>(Result);

            }
            catch (Exception exc)
            {
                return null;
            }
        }

        #endregion

        #region Editaddressinfo

        public async Task<editaddresResponse> Editaddressinfo(string addressid)
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Type));

                client.DefaultRequestHeaders.Add("Authorization", token);

                var response = await client.GetAsync(EDITADDRESS + addressid);

                var Result = response.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<editaddresResponse>(Result);

             

            }
            catch (Exception exc)
            {
                return null;
            }
        }

        #endregion

        #region Updateaddress

        public async Task<UpdateadressResponse> Updateaddressinfo(Addinsert address)
        {
            try
            {
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Type));
                client.DefaultRequestHeaders.Add("Authorization", token);


                var json = JsonConvert.SerializeObject( address);

                HttpContent content = new StringContent(json);
                content.Headers.ContentType = new MediaTypeHeaderValue(Type);

                var response = await client.PutAsync(UPDATEADDRESS, content);
                var Result = response.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<UpdateadressResponse>(Result);

            }
            catch (Exception)
            {

                return null;
            }
        }

        #endregion

        #region Deleteaddress

        public async Task<Deleteaddressresponse> deleteaddressinfo(string addressid)
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Type));
               
               

                var response = await client.DeleteAsync(DELETEADDRESS + addressid);

                var Result = response.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<Deleteaddressresponse>(Result);


            }
            catch (Exception exc)
            {
                return null;
            }
        }



        #endregion

        #region titletypeid

        public async Task<Titletype> GetTypeCdDmtsByClass()
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Type));

                var response = await client.GetAsync(GETTYPECDMS);

                var Result = response.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<Titletype>(Result);


            }
            catch (Exception exc)
            {
                return null;
            }
        }
        #endregion

        #region Updateprofile

        public async Task<Updateprofileresponse> Updateprofileinfo(Updateprofile updateprofile)
        {
            try
            {
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Type));
                client.DefaultRequestHeaders.Add("Authorization", token);


                var json = JsonConvert.SerializeObject(updateprofile);

                HttpContent content = new StringContent(json);
                content.Headers.ContentType = new MediaTypeHeaderValue(Type);

                var response = await client.PostAsync(UPDATEPROFILE, content);
                var Result = response.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<Updateprofileresponse>(Result);

            }
            catch (Exception ex)
            {

                return null;
            }
        }
        #endregion

        #region ChangePassword

        public async Task<Changepasswordresponse> Changespasswordinfo(Changepassword changepass)
        {
            try
            {
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Type));
                client.DefaultRequestHeaders.Add("Authorization", token);


                var json = JsonConvert.SerializeObject(changepass);

                HttpContent content = new StringContent(json);
                content.Headers.ContentType = new MediaTypeHeaderValue(Type);

                var response = await client.PostAsync(CHANGEPASSWORD, content);
                var Result = response.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<Changepasswordresponse>(Result);

            }
            catch (Exception ex)
            {

                return null;
            }
        }

        #endregion
    }
}



