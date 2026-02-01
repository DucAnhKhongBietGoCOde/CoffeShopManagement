using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class Account
    {
        public Account(string userName, string passWord, string displayName, string type)
        {
            this.UserName = userName;
            this.Password = passWord;
            this.DisplayName = displayName;
            this.Type = type;

        }

        public Account(DataRow row) {
            this.UserName = row["USERNAME"].ToString();
            this.Password = row["PASSWORD"].ToString();
            this.DisplayName = row["DISPLAY_NAME"].ToString();
            this.Type = row["TYPE"].ToString();
            
        }
        
        private string userName;
        private string displayName;
        private string password;
        private string type;    

        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
        public string DisplayName { get => displayName; set => displayName = value; }
        public string Type { get => type; set => type = value; }
    }
}
