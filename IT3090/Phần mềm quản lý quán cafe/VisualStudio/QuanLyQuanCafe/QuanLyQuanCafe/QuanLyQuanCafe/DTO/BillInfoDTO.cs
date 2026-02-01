using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class BillInfo
    {
        public BillInfo(int id, int billID, int foodID, int quantity) {
            this.ID = id;
            this.BillID = billID;
            this.FoodID = foodID;
            this.Quantity = quantity;

        }

        public BillInfo(DataRow row)
        {
            this.ID = (int)row["BILL_INFO_ID"];
            this.BillID = (int)row["BILL_ID"];
            this.FoodID = (int)row["FOOD_ID"];
            this.Quantity = (int)row["QUANTITY"];

        }

        private int iD;
        private int billID;
        private int foodID;
        private int quantity;

        public int ID { get => iD; set => iD = value; }
        public int BillID { get => billID; set => billID = value; }
        public int FoodID { get => foodID; set => foodID = value; }
        public int Quantity { get => quantity; set => quantity = value; }
    }
}
