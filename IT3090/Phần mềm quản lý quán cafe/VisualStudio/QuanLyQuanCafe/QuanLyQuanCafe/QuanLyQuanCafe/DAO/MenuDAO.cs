using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace QuanLyQuanCafe.DAO
{
    public class MenuDAO
    {
        private static MenuDAO instance;

        public static MenuDAO Instance
        {
            get { if (instance == null) instance = new MenuDAO(); return MenuDAO.instance; }
            private set { MenuDAO.instance = value; }
        }

        private MenuDAO() { }

        public List<MenuDTO> GetListMenuByTable(int id) 
        {
            List<MenuDTO> listMenu = new List<MenuDTO>();

            string query = "SELECT f.FOOD_NAME, bi.QUANTITY, f.PRICE, f.PRICE * bi.QUANTITY AS totalPrice FROM dbo.BILL_INFO AS bi, dbo.FOODS AS f, dbo.BILLS AS b\r\n     WHERE bi.BILL_ID = b.BILL_ID AND bi.FOOD_ID = f.FOOD_ID AND b.STATUS = 0 AND b.TABLE_ID = " + id;

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                
                MenuDTO menu = new MenuDTO(item);
                listMenu.Add(menu);
            }
            return listMenu;
        }

    }
}
