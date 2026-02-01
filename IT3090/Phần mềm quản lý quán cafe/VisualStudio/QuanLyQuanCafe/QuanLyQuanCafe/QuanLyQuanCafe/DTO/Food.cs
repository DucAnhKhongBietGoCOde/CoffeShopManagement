using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class Food
    {
        public Food(int id, string name, float price, int catagoryID)
        {
            this.ID = id;
            this.Name = name;
            this.Price = price;
            this.CatagoryID = catagoryID;
        }

        public Food(DataRow row) {
            this.ID = (int)row["FOOD_ID"];
            this.Name = row["FOOD_NAME"].ToString();
            this.Price = (float)Convert.ToDouble(row["PRICE"].ToString());
            this.CatagoryID = (int)row["CATEGORY_ID"];
        }

        private int iD;
        private string name;
        private float price;
        private int catagoryID;

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public float Price { get => price; set => price = value; }
        public int CatagoryID { get => catagoryID; set => catagoryID = value; }
    }
}
