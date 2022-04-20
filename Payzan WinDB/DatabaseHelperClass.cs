using SQLite;
using SQLiteWp8._1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayZan.Payzan_WinDB
{
    class DatabaseHelperClass
    {
        SQLiteConnection dbConn;

        //Create Tabble 
        public async Task<bool> onCreate(string DB_PATH)
        {
            try
            {
                if (!CheckFileExists(DB_PATH).Result)
                {
                    using (dbConn = new SQLiteConnection(DB_PATH))
                    {
                        dbConn.CreateTable<UserData>();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        private async Task<bool> CheckFileExists(string fileName)
        {
            try
            {
                var store = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Retrieve the specific contact from the database. 

        public UserData ReadContact(int contactid)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                var existingconact = dbConn.Query<UserData>("select * from Contacts where Id =" + contactid).FirstOrDefault();
                return existingconact;
            }
        }
        // Retrieve the all contact list from the database. 

        public ObservableCollection<UserData> ReadContacts()
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                List<UserData> myCollection = dbConn.Table<UserData>().ToList<UserData>();
                ObservableCollection<UserData> ContactsList = new ObservableCollection<UserData>(myCollection);
                return ContactsList;
            }
        }

        public UserData ReadUser()
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                List<UserData> myCollection = dbConn.Table<UserData>().ToList<UserData>();
                 UserData ContactsList = new ObservableCollection<UserData>(myCollection).FirstOrDefault();
                return ContactsList;
            }
        }

        //Update existing conatct 

        public void UpdateContact(UserData contact)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                var existingconact = dbConn.Query<UserData>("select * from UserData where ISLOGIN =" + contact.ISLOGIN).FirstOrDefault();
                if (existingconact != null)
                {
                    existingconact.ISLOGIN = contact.ISLOGIN;
                    existingconact.UserID = contact.UserID;
                    existingconact.MobileNumber = contact.MobileNumber;
                    existingconact.TokenType = contact.TokenType;
                    existingconact.Token = contact.Token;

                    existingconact.WalletUID = contact.WalletUID;
                    existingconact.WalletID = contact.WalletID;
                    existingconact.Balance = contact.Balance;

                    dbConn.RunInTransaction(() =>
                    {
                        dbConn.Update(existingconact);
                    });
                }
            }
        }


        public void UpdateWalletBalance(double balance)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                var existingconact = dbConn.Query<UserData>("select * from UserData where ISLOGIN =" + 1).FirstOrDefault();

                if (existingconact != null)
                {
                    existingconact.Balance = balance;

                    dbConn.RunInTransaction(() =>
                    {
                        dbConn.Update(existingconact);
                    });
                }
            }
        }
        // Insert the new contact in the Contacts table. 

        public void Insert(UserData newcontact)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                dbConn.RunInTransaction(() =>
                {
                    dbConn.Insert(newcontact);
                });
            }
        }

        //Delete specific contact 

        public void DeleteContact(int Id)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                var existingconact = dbConn.Query<UserData>("select * from Contacts where Id =" + Id).FirstOrDefault();

                if (existingconact != null)
                {
                    dbConn.RunInTransaction(() =>
                    {
                        dbConn.Delete(existingconact);
                    });
                }
            }
        }

        //Delete all contactlist or delete Contacts table 

        public void DeleteAllContact()
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                //dbConn.RunInTransaction(() => 
                //   { 
                dbConn.DropTable<UserData>();
                dbConn.CreateTable<UserData>();
                dbConn.Dispose();
                dbConn.Close();
                //}); 
            }
        }
       
    
}
}
