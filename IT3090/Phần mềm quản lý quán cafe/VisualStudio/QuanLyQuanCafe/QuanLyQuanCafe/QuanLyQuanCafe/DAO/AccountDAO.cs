using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace QuanLyQuanCafe.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return AccountDAO.instance; }
            private set { instance = value; }
        }

        private AccountDAO() { }

        public bool Login(string userName, string passWord)
        {
   

            string query = "USP_Login @userName , @passWord";

            DataTable result = DataProvider.Instance.ExcuteQuery(query, new object[] { userName, passWord });

            return result.Rows.Count > 0;
        }

        public Account GetAccountByUserName(string userName)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT * FROM dbo.USERS WHERE USERNAME = '" + userName + "'");
            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;
        }

        public DataTable GetListAccount()
        {
            return DataProvider.Instance.ExcuteQuery("SELECT USERNAME, DISPLAY_NAME, TYPE FROM dbo.USERS");
        }
        public bool UpdateAccount(string userName, string displayName, string passWord, string newPassWord)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("EXEC USP_UPDATEACCOUNT @userName , @displayName , @passWord , @newPassWord", new object[] { userName, displayName, passWord, newPassWord });
            return result > 0;
        }

        public bool InsertAccount(string userName, string displayName, int type)
        {
            string query = string.Format("INSERT dbo.USERS ( USERNAME, DISPLAY_NAME, TYPE )VALUES ( N'{0}', N'{1}', {2})", userName, displayName, type);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;

        }



        public bool UpdateAccount(string name, string displayName, int type)
        {
            string query = string.Format("UPDATE dbo.USERS SET DISPLAY_NAME = N'{1}', TYPE = {2} WHERE USERNAME = N'{0}'", name, displayName, type);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteAccount(string name)
        {
            string query = string.Format("Delete USERS where USERNAME = N'{0}'", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool ResetPassWord(string name)
        {
            string query = string.Format("UPDATE dbo.USERS SET PASSWORD = N'0' WHERE USERNAME = N'{0}'", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
