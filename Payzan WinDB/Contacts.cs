using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteWp8._1.Model
{
    public class UserData
    {
        //The Id property is marked as the Primary Key
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int id { get; set; }
        public int ISLOGIN { get; set; }
        public string Email { get; set; }
        public string UserID { get; set; }
        public string MobileNumber { get; set; }
        public string TokenType { get; set; }
        public string Token { get; set; }
        public string WalletUID { get; set;}
        public int WalletID { get; set; }
        public double Balance { get; set; }
      
        
        public UserData()
        {
            //empty constructor
        }
        public UserData(int iSLOGIN, string userID , string email, string mobileNumber, string tokenType, string token, string walletUID, int walletID, double balance )
        {
            ISLOGIN = iSLOGIN;
            UserID = userID;
            Email = email;
            MobileNumber = mobileNumber;
            TokenType = tokenType;
            Token = token;
            WalletUID = walletUID;
            WalletID = walletID;
            Balance = balance;
        
        }

        public UserData(int iSLOGIN)
        {
            ISLOGIN = iSLOGIN;
        }

        public UserData(double balance)
        {
            Balance = balance;
        }
    }
}
