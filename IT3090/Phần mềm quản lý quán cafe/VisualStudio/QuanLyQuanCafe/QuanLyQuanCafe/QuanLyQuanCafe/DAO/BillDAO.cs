using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;
        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return BillDAO.instance; }
            private set { BillDAO.instance = value; }
        }

        private BillDAO() { }
        public int GetUncheckedBillIDByTableID(int tableID)
        {
            string query = "SELECT * FROM dbo.BILLS WHERE TABLE_ID = @tableID AND STATUS = 0";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { tableID });

            if (data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.ID_Bill;
            }
            return -1;
        }


        public void InsertBill(int id)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC USP_INSERTBILL @idTable", new object[] { id });
        }

        public int getMaxIDBill()
        {
            try 
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT MAX(BILL_ID) FROM dbo.BILLS");
            }
            catch
            {
                return 1;
            }
        }

        public void Checkout(int id, int discount, float totalPrice)
        {
            string query = "UPDATE dbo.BILLS SET CHECKOUT_TIME = GETDATE(), STATUS = 1, " +
                           "DISCOUNT = @discount , TOTALPRICE = @totalPrice WHERE BILL_ID = @id";

            DataProvider.Instance.ExecuteNonQuery(query, new object[] { discount, totalPrice, id });
        }




        public DataTable GetBillListByDate(DateTime checkIn, DateTime checkOut)
        {
            return DataProvider.Instance.ExcuteQuery("EXEC USP_GetBillListByDate @fromDate , @toDate", new object[] { checkIn, checkOut });

        }
    }
}
