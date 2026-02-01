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
using System.Globalization;
using System.Threading;

namespace QuanLyQuanCafe
{
    public partial class fFormManager : Form
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount.Type); }
        }
        public fFormManager(Account Acc)
        {
            InitializeComponent();

            this.LoginAccount = Acc;

            LoadTable();

            LoadCategory();

            LoadComboBoxTable(comboBoxSwitchTable);
            
        }

        #region Method

        void ChangeAccount(string type)
        {
            adminToolStripMenuItem.Enabled = type == "1" ;
            menuInfoToolStrip.Text += "(" + LoginAccount.DisplayName + ")";
        } 

        void LoadCategory()
        {
            List<Category> listCategory = CategoryDAO.Instance.GetListCategory();
            comboBoxCategory.DataSource = listCategory;
            comboBoxCategory.DisplayMember = "Name";
        }


        void LoadFoodListByCategoryID(int id)
        {
            List<Food> listFood = FoodDAO.Instance.GetFoodByCategoryID(id);
            comboBoxFood.DataSource = listFood;
            comboBoxFood.DisplayMember = "Name";
        }

        void LoadTable()
        {
            flowTable.Controls.Clear();

            List<Table> tableList = TableDAO.Instance.LoadTableList();

            foreach (Table item in tableList)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                btn.Text = item.Name + Environment.NewLine + item.Status;
                btn.Click += btn_Click;
                btn.Tag = item;

                switch (item.Status)
                {
                    case "Empty":
                        btn.BackColor = Color.Aqua;
                        break;
                    default:
                        btn.BackColor = Color.LightPink;
                        break;
                }

                flowTable.Controls.Add(btn);
            }
        }

        void ShowBill(int id)
        {
            listBill.Items.Clear();

            List<QuanLyQuanCafe.DTO.MenuDTO> listBillInfo = MenuDAO.Instance.GetListMenuByTable(id);
            float totalBill = 0;

            foreach (QuanLyQuanCafe.DTO.MenuDTO item in listBillInfo) {
                ListViewItem listItem = new ListViewItem(item.FoodName.ToString());
                listItem.SubItems.Add(item.Quantity.ToString());
                listItem.SubItems.Add(item.Price.ToString());
                listItem.SubItems.Add(item.TotalPrice.ToString());
                totalBill += item.TotalPrice;
                listBill.Items.Add(listItem);
            }

            CultureInfo culture = new CultureInfo("vi-VN");
            Thread.CurrentThread.CurrentCulture = culture;
            // Set the total bill text box with formatted currency

            textBoxTotalBill.Text = totalBill.ToString("c");


        }

        void LoadComboBoxTable(ComboBox cb)
        {
            cb.DataSource = TableDAO.Instance.LoadTableList();
            cb.DisplayMember = "Name";
        }

        #endregion

        #region Events
        private void btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Table).ID;
            listBill.Tag = (sender as Button).Tag;
            ShowBill(tableID);
        }
        private void logoutToolStrip_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void stripMenuInfo_Click(object sender, EventArgs e)
        {
            fAccountProfile f = new fAccountProfile(LoginAccount);
            f.UpdateAccount += f_UpdateAccount;   
            f.ShowDialog();
        }

        private void addFoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonAddFood_Click (this, new EventArgs());

        }

        private void checkoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonCheck_Click(this, new EventArgs());
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            f.loginAccount = LoginAccount;
            f.UpdateFood += f_UpdateFood;
            f.DeleteFood += f_DeleteFood;
            f.InsertFood += f_InsertFood;

            f.ShowDialog();
        }

        void f_InsertFood(object sender, EventArgs e)
        {
            LoadFoodListByCategoryID((comboBoxCategory.SelectedItem as Category).ID);
            if (listBill.Tag != null)
                ShowBill((listBill.Tag as Table).ID);
        }

        void f_DeleteFood(object sender, EventArgs e)
        {
            LoadFoodListByCategoryID((comboBoxCategory.SelectedItem as Category).ID);
            if (listBill.Tag != null)
                ShowBill((listBill.Tag as Table).ID);
            LoadTable();
        }

        void f_UpdateFood(object sender, EventArgs e)
        {
            LoadFoodListByCategoryID((comboBoxCategory.SelectedItem as Category).ID);
            if (listBill.Tag != null)
                ShowBill((listBill.Tag as Table).ID);
        }


        void f_UpdateAccount(object sender, AccountEvent e)
        {
            this.LoginAccount = e.Acc;
            menuInfoToolStrip.Text = "Account Info (" + e.Acc.DisplayName + ")";
        }

        private void comboBoxSelectChange_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;

            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
                return;

            Category selected = cb.SelectedItem as Category;
            id = selected.ID;

            LoadFoodListByCategoryID(id);
        }

        private void buttonAddFood_Click(object sender, EventArgs e)
        {
            Table table = listBill.Tag as Table;
            if (table == null)
            {
                MessageBox.Show("Please select a table first.", "Notification");
                return;
            }

            int billID = BillDAO.Instance.GetUncheckedBillIDByTableID(table.ID);
            int foodID = (comboBoxFood.SelectedItem as Food).ID;
            int count = (int)numAddFood.Value;
            if (billID == -1)
            {
                BillDAO.Instance.InsertBill(table.ID);
                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.getMaxIDBill(), foodID, count);
            }
            else
            {
                BillInfoDAO.Instance.InsertBillInfo(billID, foodID, count);
            }

            ShowBill(table.ID);

            LoadTable();
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            Table table = listBill.Tag as Table;
            if (table == null)
            {
                MessageBox.Show("Please select a table first.", "Notification");
                return;
            }

            int billID = BillDAO.Instance.GetUncheckedBillIDByTableID(table.ID);
            int discount = (int)numDiscount.Value;

            float totalPrice = float.Parse(textBoxTotalBill.Text, NumberStyles.Currency);
            float finalPrice = totalPrice - (totalPrice / 100) * discount;
            CultureInfo culture = new CultureInfo("vi-VN");


            if (billID != -1)
            {
                if (MessageBox.Show(
                    string.Format("Do you want to checkout the bill for {0}? \n" +
                    "Total Price - (Total Price / 100) x Discount = {1} - ({1} / 100) x {2} = {3}  ", table.Name, totalPrice, discount, finalPrice ),
                    "Notification",
                    MessageBoxButtons.OKCancel) == DialogResult.OK)
                {

                    BillDAO.Instance.Checkout(billID, discount,(float)finalPrice);


                    TableDAO.Instance.SetTableStatus(table.ID, "Empty");


                    listBill.Items.Clear();
                    textBoxTotalBill.Text = "0";


                    LoadTable();
                }
            }
        }

        private void buttonSwitchTable_Click(object sender, EventArgs e)
        {
            int id1 = (listBill.Tag as Table).ID;
            int id2 = (comboBoxSwitchTable.SelectedItem as Table).ID;

            if (MessageBox.Show(
                $"Do you want to switch {(listBill.Tag as Table).Name} with {(comboBoxSwitchTable.SelectedItem as Table).Name} ? ",
                "Notification",
                MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                TableDAO.Instance.SwitchTable(id1, id2);
                LoadTable();
                
            }
        }


        #endregion

        
    }
}

