using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace QuanLyQuanCafe.DTO
{
    public class Bill
    {

        public Bill(int ID_Bill, DateTime? dateCheckIn, DateTime? dateCheckOut, int status, int discount = 0)
        {
            this.ID_Bill = iD_Bill;
            this.DateCheckIn = dateCheckIn;
            this.DateCheckOut = dateCheckOut;
            this.Status = status;
            this.Discount = discount;
        }

        public Bill(DataRow row)
        {
            this.ID_Bill = (int)row["BILL_ID"];
            this.DateCheckIn = (DateTime?)row["CHECKIN_TIME"];

            // Xử lý CHECKOUT_TIME (Kiểm tra DBNull trước khi ép kiểu)

            var dateCheckOutTemp = row["CHECKOUT_TIME"];
            if (dateCheckOutTemp != DBNull.Value)
            {
                this.DateCheckOut = (DateTime?)dateCheckOutTemp;
            }

            this.Status = (int)row["STATUS"];

            // Xử lý DISCOUNT (Phòng trường hợp NULL trong DB)
            if (row.Table.Columns.Contains("DISCOUNT") && row["DISCOUNT"] != DBNull.Value)
            {
                this.Discount = (int)row["DISCOUNT"];
            }
            else
            {
                this.Discount = 0;
            }
        }

        private int iD_Bill;

        private DateTime? dateCheckIn;

        private DateTime? dateCheckOut;

        private int status;

        private int discount;


        public int ID_Bill { get => iD_Bill; set => iD_Bill = value; }

        public DateTime? DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }

        public DateTime? DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }

        public int Status { get => status; set => status = value; }
        public int Discount { get => discount; set => discount = value; }
    }
}
