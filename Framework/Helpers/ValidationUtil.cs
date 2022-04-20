using PayZan.framework.Contracts.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using PayZan.views.Agent_Request;
using System.ComponentModel;
using Windows.UI.Xaml.Controls;
using System.Globalization;
using Newtonsoft.Json.Linq;
using PayZan.framework.Properties;
using Windows.UI.Popups;
using PayZan.framework.Contracts;
using PayZan.framework.services;
using PayZan.views.loginAndRegistation;
using Windows.UI.Xaml.Media;
using Windows.UI;
using Windows.UI.Xaml;
using PayZan.Payzan_WinDB;
using SQLiteWp8._1.Model;

namespace PayZan.common
{
    class ValidationUtil
    {


        INavigate navigate;

        private static Frame frame;

        public static ILocalDataServices localDB = new LocalDataServices();

        public static DatabaseHelperClass Db_Helper = new DatabaseHelperClass();

        public static UserData user = new UserData();

     
        public static bool isNotnulSring(String input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool isnulSring(String input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public static bool isValidEmail(String Email)
        {
            string Emailpattern = (@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            Regex re = new Regex(Emailpattern);

            if (re.IsMatch(Email))
            {
                return true;
            }

            else
            {
                return false;
            }

        }

        public static bool IsValidname(String FirstName)
        {
            Regex regex = new Regex("^[A-Za-z]*$");

            if (regex.IsMatch(FirstName) && FirstName.Length >= 3)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool IsValidmiddlename(String MiddleName)
        {
            if (MiddleName.Length <= 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsValidlastname(String LastName)
        {
        
            if (LastName.Length >= 3 )

            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsValidMobileNumber(String strNumber)
        {
            Regex mobilePattern = new Regex(@"^\d{10}$");

            if (mobilePattern.IsMatch(strNumber))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsValidaddress1(String Address1)
        {
            if (Address1.Length >= 20)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsValidaddress2(String Address2)
        {
            if (Address2.Length >= 20)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsValidlandmark(String LandMark)
        {
            if (LandMark.Length >= 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsValidcomments(String Comments)
        {

            if (Comments.Length >= 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsPasswordsEqual(String Password)
        {

            var Number = new Regex("[0-9]");
            var UpperChar = new Regex("[A-Z]");
            var MiniMaxChars = new Regex(@".{8,15}");
            var LowerChar = new Regex("[a-z]");
            var Symbols = new Regex("[!@#$%^&*]");

            if (!LowerChar.IsMatch(Password) || !UpperChar.IsMatch(Password) || !MiniMaxChars.IsMatch(Password) || !Number.IsMatch(Password) || !Symbols.IsMatch(Password))
            {
                return false;
            }

            else
            {
                return true;
            }

        }

        public static bool IsConPasswordsEqual(String Password, String Conformpassword)
        {
            string pass = Password;
            string newpass = Conformpassword;
            if (string.Equals(pass, newpass))
            {
                return true;
            }
            return false;
        }

        public static bool IsValidusername(String strNumber)
        {
            Regex mobilePattern = new Regex(@"^\d{10}$");

            if (mobilePattern.IsMatch(strNumber))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsValidLandlineNo(String strnumber)

        {
            Regex landlinePattern = new Regex(@"/^[0-9]\d{2,4}-\d{6,8}$/");

            if (landlinePattern.IsMatch(strnumber))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsValidaccountno(String strnumber)
        {
            Regex accountpattern = new Regex(@"^\d{9}$");

            if (accountpattern.IsMatch(strnumber))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsValidamount(string Amount)
        {
            int length = 5000;

            int amount = Convert.ToInt32(Amount);

            if (amount <= length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool ValidateDate(DateTime datetime)
        {

            DateTime CurrentDate = DateTime.Today;
            DateTime SelectedDate = datetime;


            if (SelectedDate < CurrentDate)
            {
                /*   Valid date */
                return true;
            }
            else
            {
                /* not valid*/
                return false;
            }


        }

        public static bool ChekLogin()
        {
            user = Db_Helper.ReadUser();

            if ((user != null) && user.ISLOGIN == Constants.LOGIN)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsLogin(Frame frameview)
        {
            frame = frameview;

            user = Db_Helper.ReadUser();

            if ((user != null) && user.ISLOGIN == Constants.LOGIN)
            {
                return true;
            }
            else
            {
                MessageDialog showDialog = new MessageDialog("Please Login ......");
                showDialog.Commands.Add(new UICommand("Ok", new UICommandInvokedHandler(CommandhandlerlOGIN)));
                showDialog.Commands.Add(new UICommand("Cancel", new UICommandInvokedHandler(Commandhandle)));

                showDialog.DefaultCommandIndex = 0;
                showDialog.CancelCommandIndex = 1;
                showDialog.ShowAsync();
            }
            return false;
        }

        public static bool SignOut()
        {
            try
            {
                localDB.ClearData();
                Db_Helper.DeleteAllContact();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        private static void CommandhandlerlOGIN(IUICommand command)
        {
            frame.Navigate(typeof(LoginView));

        }

        private static void Commandhandle(IUICommand command)
        {

        }

        public static bool startloading()
        {
            ProgressBar ring = new ProgressBar();

            ring.Foreground = new SolidColorBrush(Colors.White);
            ring.Background = new SolidColorBrush(Colors.Black);
            ring.IsIndeterminate = true;

            TextBlock txt = new TextBlock();
            txt.Text = "please wait Loading...";
            txt.FontSize = 17;
            txt.Foreground = new SolidColorBrush(Colors.Gray);
            txt.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Center;

            StackPanel stk = new StackPanel();
            stk.Children.Add(ring);
            stk.Children.Add(txt);


            ContentDialog dlg = new ContentDialog();
            dlg.Content = stk;

            SolidColorBrush color = new SolidColorBrush(Colors.White);
            color.Opacity = 0.7;
            dlg.Background = color;

            dlg.Margin = new Thickness(0, 250, 0, 0);


            if (dlg != null)
            {
                dlg.Visibility = Visibility.Visible;
                return true;
            }
            else
            {
                Task.Delay(10);
                dlg.Visibility = Visibility.Collapsed;
                return false;

            }

        }

        public static bool isvalidcardnumber(string cardnumber)
        {
            Regex mobilePattern = new Regex(@"^4[0-9]{12}(?:[0-9]{3})?$");

            if (mobilePattern.IsMatch(cardnumber))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal  static void valid(TextBox textbox, bool v)
        {
            string[] invalidcharacters = { ".", "@", "#", "$", "%", "&", "*", "!", "-","/","?",":",
                                         "(", ")", "1", "2","3","4", "5","6","7", "8","9","0" };

            for (int index = 0; index < invalidcharacters.Length; index++)
            {
                textbox.Text = textbox.Text.Replace(invalidcharacters[index], "");
            }
            
        }
        internal static void validS(TextBox textbox, bool v)
        {
            string[] invalidcharacters = { ".", "@", "#", "$", "%", "&", "*", "!" };
                                       

            for (int index = 0; index < invalidcharacters.Length; index++)
            {
                textbox.Text = textbox.Text.Replace(invalidcharacters[index], "");
            }

        }
        private  static void amountlength()
        {
            int length = 5000;
            for (int i = 0; i <= length; i++)
            {

            }
        }

    }

}




