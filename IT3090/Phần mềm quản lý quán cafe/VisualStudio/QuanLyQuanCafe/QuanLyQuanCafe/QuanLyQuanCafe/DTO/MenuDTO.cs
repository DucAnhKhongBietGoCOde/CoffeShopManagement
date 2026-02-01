using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class MenuDTO
    {
        private string foodName;

        private int quantity;

        private float price;

        private float totalPrice;

        public string FoodName { get => foodName; set => foodName = value; }

        public int Quantity { get => quantity; set => quantity = value; }

        public float Price { get => price; set => price = value; }

        public float TotalPrice { get => totalPrice; set => totalPrice = value; }

        public MenuDTO(string foodName, int quantity, float price, float totalPrice = 0)
        {
            this.FoodName = foodName;
            this.Quantity = quantity;
            this.Price = price;
            this.totalPrice = totalPrice;
        }
        public MenuDTO(DataRow row)
        {
            this.FoodName = row["FOOD_NAME"].ToString();
            this.Quantity = Convert.ToInt32(row["QUANTITY"]);
            this.Price = Convert.ToSingle(row["PRICE"]);
            this.TotalPrice = Convert.ToSingle(row["totalPrice"]);
        }

    }
}
