using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class fAccountProfile : Form
    {

        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount); }
        }
        public fAccountProfile(Account acc)
        {
            InitializeComponent();

            LoginAccount = acc;
        }

        void ChangeAccount(Account acc)
        {
            textBoxUserName.Text = LoginAccount.UserName;
            textBoxDisplayName.Text = LoginAccount.DisplayName;
            
        }

        void UpdateAccountInfo()
        {
            string displayName = textBoxDisplayName.Text;
            string password = textBoxPass.Text;
            string reEnterPass = textBoxReEnterPass.Text;
            string newPass = textBoxNewPass.Text;
            string userName = textBoxUserName.Text;
            if(!newPass.Equals(reEnterPass))
            {
                MessageBox.Show("Please re-enter the new password correctly.");
            }
            else
            {
                if(AccountDAO.Instance.UpdateAccount(userName, displayName, password, newPass) )
                {
                    MessageBox.Show("Update successful.");
                    if (updateAccount != null)
                        updateAccount(this, new AccountEvent(AccountDAO.Instance.GetAccountByUserName(userName)));
                }
                else
                {
                    MessageBox.Show("Incorrect current password. Please try again.");
                }
                
            }


        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            UpdateAccountInfo();
        }

        private event EventHandler<AccountEvent> updateAccount; 
        public event EventHandler <AccountEvent> UpdateAccount
        {
            add { updateAccount += value; }
            remove { updateAccount -= value; }
        }
    }

    public class AccountEvent : EventArgs
    {
        private Account acc;
        public Account Acc { get => acc; set => acc = value; }
        public AccountEvent(Account acc)
        {
            this.Acc = acc;
        }
    }


}
