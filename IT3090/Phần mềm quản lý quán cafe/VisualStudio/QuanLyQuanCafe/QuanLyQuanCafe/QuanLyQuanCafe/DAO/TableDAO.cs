using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;
        public static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; }
            private set { TableDAO.instance = value; }
        }

        public static int TableWidth = 85;
        public static int TableHeight = 85;

        private TableDAO() { }

        public List<Table> LoadTableList()
        {
            List<Table> tableList = new List<Table>();

            DataTable data = DataProvider.Instance.ExcuteQuery("USP_TableList");

            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tableList.Add(table);
            }

            return tableList;
        }

        public void SetTableStatus(int tableID, string status)
        {
            string query = "UPDATE TABLEFOOD SET STATUS = @status WHERE TABLE_ID = @id";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { status, tableID });
        }


        public void SwitchTable(int id1, int id2)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC USP_SWITCHTABLE @idTable1 , @idTable2", new object[] { id1, id2 });
        }

    }
}
