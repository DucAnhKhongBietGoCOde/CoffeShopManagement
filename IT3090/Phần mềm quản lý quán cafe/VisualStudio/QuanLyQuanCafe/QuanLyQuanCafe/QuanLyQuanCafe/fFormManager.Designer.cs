namespace QuanLyQuanCafe
{
    partial class fFormManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuInfoToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.stripMenuInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listBill = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.numAddFood = new System.Windows.Forms.NumericUpDown();
            this.buttonAddFood = new System.Windows.Forms.Button();
            this.comboBoxFood = new System.Windows.Forms.ComboBox();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.flowTable = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.comboBoxSwitchTable = new System.Windows.Forms.ComboBox();
            this.textBoxTotalBill = new System.Windows.Forms.TextBox();
            this.buttonSwitchTable = new System.Windows.Forms.Button();
            this.numDiscount = new System.Windows.Forms.NumericUpDown();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAddFood)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDiscount)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.menuInfoToolStrip,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(969, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.adminToolStripMenuItem.Text = "Admin";
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // menuInfoToolStrip
            // 
            this.menuInfoToolStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stripMenuInfo,
            this.logoutToolStrip});
            this.menuInfoToolStrip.Name = "menuInfoToolStrip";
            this.menuInfoToolStrip.Size = new System.Drawing.Size(160, 24);
            this.menuInfoToolStrip.Text = "Personal Information";
            // 
            // stripMenuInfo
            // 
            this.stripMenuInfo.Name = "stripMenuInfo";
            this.stripMenuInfo.Size = new System.Drawing.Size(229, 26);
            this.stripMenuInfo.Text = "Personal Information";
            this.stripMenuInfo.Click += new System.EventHandler(this.stripMenuInfo_Click);
            // 
            // logoutToolStrip
            // 
            this.logoutToolStrip.Name = "logoutToolStrip";
            this.logoutToolStrip.Size = new System.Drawing.Size(229, 26);
            this.logoutToolStrip.Text = "Logout";
            this.logoutToolStrip.Click += new System.EventHandler(this.logoutToolStrip_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.listBill);
            this.panel2.Location = new System.Drawing.Point(538, 105);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(419, 427);
            this.panel2.TabIndex = 2;
            // 
            // listBill
            // 
            this.listBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listBill.Font = new System.Drawing.Font("Segoe UI", 7.8F);
            this.listBill.HideSelection = false;
            this.listBill.Location = new System.Drawing.Point(0, 3);
            this.listBill.Name = "listBill";
            this.listBill.Size = new System.Drawing.Size(417, 421);
            this.listBill.TabIndex = 0;
            this.listBill.UseCompatibleStateImageBehavior = false;
            this.listBill.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Food Name";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Quantity";
            this.columnHeader2.Width = 75;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Price";
            this.columnHeader3.Width = 82;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Total Price";
            this.columnHeader4.Width = 89;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.numAddFood);
            this.panel1.Controls.Add(this.buttonAddFood);
            this.panel1.Controls.Add(this.comboBoxFood);
            this.panel1.Controls.Add(this.comboBoxCategory);
            this.panel1.Location = new System.Drawing.Point(538, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(418, 68);
            this.panel1.TabIndex = 4;
            // 
            // numAddFood
            // 
            this.numAddFood.Location = new System.Drawing.Point(343, 24);
            this.numAddFood.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numAddFood.Name = "numAddFood";
            this.numAddFood.Size = new System.Drawing.Size(72, 22);
            this.numAddFood.TabIndex = 3;
            // 
            // buttonAddFood
            // 
            this.buttonAddFood.BackColor = System.Drawing.Color.LightGray;
            this.buttonAddFood.Font = new System.Drawing.Font("Segoe UI", 7.8F);
            this.buttonAddFood.Location = new System.Drawing.Point(252, 0);
            this.buttonAddFood.Name = "buttonAddFood";
            this.buttonAddFood.Size = new System.Drawing.Size(85, 68);
            this.buttonAddFood.TabIndex = 2;
            this.buttonAddFood.Text = "Add";
            this.buttonAddFood.UseVisualStyleBackColor = false;
            this.buttonAddFood.Click += new System.EventHandler(this.buttonAddFood_Click);
            // 
            // comboBoxFood
            // 
            this.comboBoxFood.FormattingEnabled = true;
            this.comboBoxFood.Location = new System.Drawing.Point(3, 36);
            this.comboBoxFood.Name = "comboBoxFood";
            this.comboBoxFood.Size = new System.Drawing.Size(247, 24);
            this.comboBoxFood.TabIndex = 1;
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Location = new System.Drawing.Point(3, 6);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(247, 24);
            this.comboBoxCategory.TabIndex = 0;
            this.comboBoxCategory.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelectChange_SelectedIndexChanged);
            // 
            // flowTable
            // 
            this.flowTable.Location = new System.Drawing.Point(10, 31);
            this.flowTable.Name = "flowTable";
            this.flowTable.Size = new System.Drawing.Size(519, 580);
            this.flowTable.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.comboBoxSwitchTable);
            this.panel3.Controls.Add(this.textBoxTotalBill);
            this.panel3.Controls.Add(this.buttonSwitchTable);
            this.panel3.Controls.Add(this.numDiscount);
            this.panel3.Controls.Add(this.buttonCheck);
            this.panel3.Location = new System.Drawing.Point(538, 538);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(418, 73);
            this.panel3.TabIndex = 5;
            // 
            // comboBoxSwitchTable
            // 
            this.comboBoxSwitchTable.FormattingEnabled = true;
            this.comboBoxSwitchTable.Location = new System.Drawing.Point(5, 41);
            this.comboBoxSwitchTable.Name = "comboBoxSwitchTable";
            this.comboBoxSwitchTable.Size = new System.Drawing.Size(107, 24);
            this.comboBoxSwitchTable.TabIndex = 7;
            // 
            // textBoxTotalBill
            // 
            this.textBoxTotalBill.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTotalBill.ForeColor = System.Drawing.Color.Red;
            this.textBoxTotalBill.Location = new System.Drawing.Point(216, 7);
            this.textBoxTotalBill.Name = "textBoxTotalBill";
            this.textBoxTotalBill.ReadOnly = true;
            this.textBoxTotalBill.Size = new System.Drawing.Size(108, 31);
            this.textBoxTotalBill.TabIndex = 6;
            this.textBoxTotalBill.Text = "0";
            this.textBoxTotalBill.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // buttonSwitchTable
            // 
            this.buttonSwitchTable.BackColor = System.Drawing.Color.LightGray;
            this.buttonSwitchTable.Font = new System.Drawing.Font("Segoe UI", 7.8F);
            this.buttonSwitchTable.Location = new System.Drawing.Point(5, 3);
            this.buttonSwitchTable.Name = "buttonSwitchTable";
            this.buttonSwitchTable.Size = new System.Drawing.Size(108, 35);
            this.buttonSwitchTable.TabIndex = 4;
            this.buttonSwitchTable.Text = "Move ";
            this.buttonSwitchTable.UseVisualStyleBackColor = false;
            this.buttonSwitchTable.Click += new System.EventHandler(this.buttonSwitchTable_Click);
            // 
            // numDiscount
            // 
            this.numDiscount.Location = new System.Drawing.Point(216, 41);
            this.numDiscount.Name = "numDiscount";
            this.numDiscount.Size = new System.Drawing.Size(108, 22);
            this.numDiscount.TabIndex = 4;
            this.numDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonCheck
            // 
            this.buttonCheck.BackColor = System.Drawing.Color.LightGray;
            this.buttonCheck.Font = new System.Drawing.Font("Segoe UI", 7.8F);
            this.buttonCheck.Location = new System.Drawing.Point(330, 2);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(85, 68);
            this.buttonCheck.TabIndex = 3;
            this.buttonCheck.Text = "Checkout";
            this.buttonCheck.UseVisualStyleBackColor = false;
            this.buttonCheck.Click += new System.EventHandler(this.buttonCheck_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFoToolStripMenuItem,
            this.checkoutToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // addFoToolStripMenuItem
            // 
            this.addFoToolStripMenuItem.Name = "addFoToolStripMenuItem";
            this.addFoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.addFoToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.addFoToolStripMenuItem.Text = "Add Food";
            this.addFoToolStripMenuItem.Click += new System.EventHandler(this.addFoToolStripMenuItem_Click);
            // 
            // checkoutToolStripMenuItem
            // 
            this.checkoutToolStripMenuItem.Name = "checkoutToolStripMenuItem";
            this.checkoutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
            this.checkoutToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.checkoutToolStripMenuItem.Text = "Checkout";
            this.checkoutToolStripMenuItem.Click += new System.EventHandler(this.checkoutToolStripMenuItem_Click);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Location = new System.Drawing.Point(264, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(8, 8);
            this.propertyGrid1.TabIndex = 6;
            // 
            // fFormManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 624);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.flowTable);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "fFormManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Coffee shop management";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numAddFood)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDiscount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuInfoToolStrip;
        private System.Windows.Forms.ToolStripMenuItem stripMenuInfo;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStrip;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView listBill;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonAddFood;
        private System.Windows.Forms.ComboBox comboBoxFood;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.Button buttonCheck;
        private System.Windows.Forms.NumericUpDown numAddFood;
        private System.Windows.Forms.FlowLayoutPanel flowTable;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.NumericUpDown numDiscount;
        private System.Windows.Forms.Button buttonSwitchTable;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TextBox textBoxTotalBill;
        private System.Windows.Forms.ComboBox comboBoxSwitchTable;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkoutToolStripMenuItem;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
    }
}