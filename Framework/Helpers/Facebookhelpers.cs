using Facebook;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.Security.Authentication.Web;

namespace PayZan.Helpers
{
   public  class Facebookhelpers
    {

        FacebookClient _fb = new FacebookClient();
        readonly Uri _callbackUri = WebAuthenticationBroker.GetCurrentApplicationCallbackUri();
        readonly Uri _loginUrl;
        private const string FacebookAppId = "181384252440998";            //Enter your FaceBook App ID here  
        private const string FacebookPermissions = "user_about_me,read_stream,publish_stream";
        public string AccessToken
        {
            get { return _fb.AccessToken; }
        }

        public Facebookhelpers()
        {
            _loginUrl = _fb.GetLoginUrl(new
            {
                client_id = FacebookAppId,
                redirect_uri = _callbackUri.AbsoluteUri,
                scope = FacebookPermissions,
                display = "popup",
                response_type = "token"
            });

            Debug.WriteLine(_callbackUri);                              //This is useful for fill Windows Store ID in Facebook WebSite  
        }
        private void ValidateAndProccessResult(WebAuthenticationResult result)
        {
            if (result.ResponseStatus == WebAuthenticationStatus.Success)
            {
                var responseUri = new Uri(result.ResponseData.ToString());
                var facebookOAuthResult = _fb.ParseOAuthCallbackUrl(responseUri);

                if (string.IsNullOrWhiteSpace(facebookOAuthResult.Error))
                    _fb.AccessToken = facebookOAuthResult.AccessToken;
                else
                {

                }
            }
            else if (result.ResponseStatus == WebAuthenticationStatus.ErrorHttp)
            {// error de http    
            }
            else
            {
                _fb.AccessToken = null;//Keep null when user signout from facebook    
            }
        }
        public void LoginAndContinue()
        {
            WebAuthenticationBroker.AuthenticateAndContinue(_loginUrl);
        }
        public void ContinueAuthentication(WebAuthenticationBrokerContinuationEventArgs args)
        {
            ValidateAndProccessResult(args.WebAuthenticationResult);
        }
    }
}

