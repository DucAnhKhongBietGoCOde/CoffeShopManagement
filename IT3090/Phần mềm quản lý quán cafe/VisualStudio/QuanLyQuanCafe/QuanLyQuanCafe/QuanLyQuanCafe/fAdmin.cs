using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class fAdmin : Form
    {


        BindingSource foodList = new BindingSource();

        public Account loginAccount;
        public fAdmin()
        {
            InitializeComponent();
            LoadData();
            dataGridViewAccount.CellFormatting += dataGridViewAccount_CellFormatting;

        }

        BindingSource accountList = new BindingSource();



        #region Method


        void LoadData()
        {
            SetupFoodDataGridView();
            dataGridViewFood.DataSource = foodList;
            SetupAccountDataGridView();
            dataGridViewAccount.DataSource = accountList;

            LoadDateTimePickerBill();
            LoadListBillByDate(dateTimeStart.Value, dateTimeEnd.Value);
            LoadListFood();
            LoadAccount();
            AddFoodBinding();
            AddAccountBinding();
            LoadCategoryIntoComboBox(comboBoxFoodCatagory);
            
            

        }
        
        void LoadAccount()
        {
            accountList.DataSource = AccountDAO.Instance.GetListAccount();
        }

        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dateTimeStart.Value = new DateTime(today.Year, today.Month, 1);
            dateTimeEnd.Value = dateTimeStart.Value.AddMonths(1).AddDays(-1);
        }

        void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            dataGridViewBill.DataSource = BillDAO.Instance.GetBillListByDate(checkIn, checkOut);
        }

        void LoadCategoryIntoComboBox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "Name";
        }

        void LoadListFood()
        {
            foodList.DataSource = FoodDAO.Instance.GetListFood();
        }

        void AddFoodBinding()
        {
            textBoxFoodName.DataBindings.Add(new Binding("Text", dataGridViewFood.DataSource, "Name", true, DataSourceUpdateMode.Never));
            textBoxID.DataBindings.Add(new Binding("Text", dataGridViewFood.DataSource, "ID", true, DataSourceUpdateMode.Never));
            numericPrice.DataBindings.Add(new Binding("Value", dataGridViewFood.DataSource, "price", true, DataSourceUpdateMode.Never));

        }

        void AddAccountBinding()
        {
            textBoxUserName.DataBindings.Add(new Binding("Text", dataGridViewAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            textBoxDisplayName.DataBindings.Add(new Binding("Text", dataGridViewAccount.DataSource, "DISPLAY_NAME", true, DataSourceUpdateMode.Never));
            numTypeAccount.DataBindings.Add(new Binding("Value", dataGridViewAccount.DataSource, "TYPE", true, DataSourceUpdateMode.Never));
        } 

        List<Food> SearchFoodByName (string name)
        {
            List<Food> listfood = FoodDAO.Instance.SearchFoodByName(name);
            return listfood;
        }

        void SetupFoodDataGridView()
        {
            dataGridViewFood.AutoGenerateColumns = false;
            dataGridViewFood.Columns.Clear();

            dataGridViewFood.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colID",
                HeaderText = "ID",
                DataPropertyName = "ID"
            });

            dataGridViewFood.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colName",
                HeaderText = "Food Name",
                DataPropertyName = "Name"
            });

            dataGridViewFood.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPrice",
                HeaderText = "Price",
                DataPropertyName = "Price",
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "N0"
                }
            });

            dataGridViewFood.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCategory",
                HeaderText = "Category",
                DataPropertyName = "CatagoryID"
            });
        }

        void SetupAccountDataGridView()
        {
            dataGridViewAccount.AutoGenerateColumns = false;
            dataGridViewAccount.Columns.Clear();
            dataGridViewAccount.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colUserName",
                HeaderText = "User Name",
                DataPropertyName = "UserName"
            });
            dataGridViewAccount.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDisplayName",
                HeaderText = "Display Name",
                DataPropertyName = "DISPLAY_NAME"
            });
            dataGridViewAccount.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colType",
                HeaderText = "Type",
                DataPropertyName = "TYPE"
            });
        }

        void AddAccount(string userName, string displayName, int type)
        {
            if (AccountDAO.Instance.InsertAccount(userName, displayName, type))
            {
                MessageBox.Show("Account added successfully");
            }
            else
            {
                MessageBox.Show("An error occurred while adding the account.");
            }
            LoadAccount();
        }

        void EditAccount(string userName, string displayName, int type)
        {
            if (AccountDAO.Instance.UpdateAccount(userName, displayName, type))
            {
                MessageBox.Show("Account updated successfully");
            }
            else
            {
                MessageBox.Show("An error occurred while updating the account.");
            }
            LoadAccount();
        }

        void DeleteAccount(string userName)
        {
            if(loginAccount.UserName.Equals(userName))
            {
                MessageBox.Show("You cannot delete your own account.");
                return;
            }

            if (AccountDAO.Instance.DeleteAccount(userName))
            {
                MessageBox.Show("Account deleted successfully");
            }
            else
            {
                MessageBox.Show("An error occurred while deleting the account.");
            }
            LoadAccount();
        }

        void ResetPassWord(string userName)
        {
            if (AccountDAO.Instance.ResetPassWord(userName))
            {
                MessageBox.Show("Password reset successfully to default password '0'");
            }
            else
            {
                MessageBox.Show("An error occurred while resetting the password.");
            }
        }

        #endregion

        #region Event
        private void buttonApply_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dateTimeStart.Value, dateTimeEnd.Value);
        }

        private void textBoxFoodID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewFood.SelectedCells.Count > 0)
                {
                    int id = (int)dataGridViewFood.SelectedCells[0].OwningRow.Cells["CatagoryID"].Value;

                    Category cateogory = CategoryDAO.Instance.GetCategoryByID(id);

                    comboBoxFoodCatagory.SelectedItem = cateogory;

                    int index = -1;
                    int i = 0;
                    foreach (Category item in comboBoxFoodCatagory.Items)
                    {
                        if (item.ID == cateogory.ID)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }

                    comboBoxFoodCatagory.SelectedIndex = index;
                }
            }
            catch { }
        }

        private void buttonAddFood_Click(object sender, EventArgs e)
        {
            string name = textBoxFoodName.Text;
            int catagoryID = (comboBoxFoodCatagory.SelectedItem as Category).ID;
            float price = (float)numericPrice.Value;

            if (FoodDAO.Instance.InsertFood(name, catagoryID, price))
            {
                MessageBox.Show("Food item added successfully");
                LoadListFood();
                if(insertFood != null)
                    insertFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("An error occurred while adding the food item.");
            }
        }

        private void buttonEditFood_Click(object sender, EventArgs e)
        {
            string name = textBoxFoodName.Text;
            int catagoryID = (comboBoxFoodCatagory.SelectedItem as Category).ID;
            float price = (float)numericPrice.Value;
            int id = Convert.ToInt32(textBoxID.Text);

            if (FoodDAO.Instance.UpdateFood(id, name, catagoryID, price))
            {
                MessageBox.Show("Food item updated successfully");
                LoadListFood();
                if(updateFood!=null)
                    updateFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("An error occurred while updating the food item.");
            }
        }

        private void buttonDeleteFood_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBoxID.Text);
            if (FoodDAO.Instance.DeleteFood(id))
            {
                MessageBox.Show("Food item deleted successfully");
                LoadListFood();
                if(deleteFood!=null)
                    deleteFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("An error occurred while deleting the food item.");
            }
        }

        private void buttonViewFood_Click(object sender, EventArgs e)
        {
            LoadListFood();
        }

        private event EventHandler insertFood;
        public event EventHandler InsertFood
        {
            add { insertFood += value; }
            remove { insertFood -= value; }
        }
        
        private event EventHandler deleteFood;
        public event EventHandler DeleteFood
        {
            add { deleteFood += value; }
            remove { deleteFood -= value; }
        }

        private event EventHandler updateFood;
        public event EventHandler UpdateFood
        {
            add { updateFood += value; }
            remove { updateFood -= value; }
        }


        private void buttonFindFoodName_Click(object sender, EventArgs e)
        {
            foodList.DataSource = SearchFoodByName(textBoxFindFood.Text);
        }

        private void buttonViewAccount_Click(object sender, EventArgs e)
        {
            LoadAccount();
        }


        private void buttonAddAccount_Click(object sender, EventArgs e)
        {
            string userName = textBoxUserName.Text;
            string displayName = textBoxDisplayName.Text;
            int type = (int)numTypeAccount.Value;
            AddAccount(userName, displayName, type);

        }


        private void buttonDeleteAccount_Click(object sender, EventArgs e)
        {
                string userName = textBoxUserName.Text;
                DeleteAccount(userName);

        }

        private void buttonEditAccount_Click(object sender, EventArgs e)
        {
            string userName = textBoxUserName.Text;
            string displayName = textBoxDisplayName.Text;
            int type = (int)numTypeAccount.Value;
            EditAccount(userName, displayName, type);
        }

        private void dataGridViewAccount_CellFormatting(
    object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewAccount.Columns[e.ColumnIndex].DataPropertyName == "TYPE"
                && e.Value != null)
            {
                // CHỈ format khi value là số
                if (int.TryParse(e.Value.ToString(), out int type))
                {
                    e.Value = (type == 1) ? "Admin" : "Staff";
                    e.FormattingApplied = true;
                }
            }
        }

        private void buttonResetPass_Click(object sender, EventArgs e)
        {
            string userName = textBoxUserName.Text;
            ResetPassWord(userName);
        }


        #endregion


    }
}

