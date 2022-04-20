using PayZan.framework.Contracts.Pocos;
using PayZan.Framework.Contracts.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayZan.Interfaces
{
    interface IRemoteServices
    {
        /*    All API requests placed fo...!  */

        #region UserRegistration
        Task<userRootObject> UserLogin(LoginModel userData);

         Task<SignupResponse> UserRegistration(SignUpModel signup_data);

        #endregion

        /*  Request for Agent Related API  */

        #region Request for Agent

        #region StatesAPI
        Task<States> GetStates();
        #endregion

        #region DistrictsAPI
        Task<Districts> GetDistricts(int Id);
        #endregion

        #region MandalsAPI
        Task<Mandals> GetMandals(int Id);
        #endregion

        #region VillagesAPI
        Task<Villages> GetVillages(int Id);
        #endregion

        #region AgentRequestAPI
        Task<AgentRequestResponce> AgentRequestinfo(AgentRequest agentRequest);
        #endregion

        #endregion


        #region  ServiceProvider Api

        Task<Serviceprovider> GetServiceProvider(string id);
        #endregion

        #region  Payzan Wallet

        #region UserWallet
        Task<Userwallet> GetPassbookDetails(string WalletId);
        #endregion

        #region SendMoney
        Task<SendmoneyResponse> SendMoneyToUserWallet(SendmoneyRewquest senddata);
        #endregion

        #region Addmoney
        Task<AddmoneyResponse> AddMoneyToUserWallet(Addmoney adddata);
        #endregion

        #endregion

        #region Userprofile
   
        Task<Userprofile> GetUserPersonalInfo( string UserId);
        #endregion

        Task<Walletbalance> GetBalance(int WalletID);


        #region Province
        Task<Provinceresponse> GetProvince();
        #endregion

        #region addressinsert
        Task<Addaddressresponse> addressinsert(Addinsert address);
        #endregion

        #region getaddress
        Task<Getaddress> Getaddressinfo(string Userid);
        #endregion

        #region Editaddress
        Task<editaddresResponse> Editaddressinfo(string addressid);
        #endregion

        #region Updateaddress
        Task<UpdateadressResponse> Updateaddressinfo(Addinsert address);
        #endregion

        #region Deleteaddress
        Task<Deleteaddressresponse> deleteaddressinfo(string addressid);
        #endregion

        #region Titletypeid
        Task<Titletype> GetTypeCdDmtsByClass();
        #endregion

        #region Updateprofile
        Task<Updateprofileresponse> Updateprofileinfo(Updateprofile updateprofile);
        #endregion

        #region Changepassword
        Task<Changepasswordresponse> Changespasswordinfo(Changepassword changepass);
        #endregion


    }


}
