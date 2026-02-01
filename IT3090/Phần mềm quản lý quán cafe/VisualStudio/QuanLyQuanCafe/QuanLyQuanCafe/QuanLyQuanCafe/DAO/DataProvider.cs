using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    // Lớp DataProvider chịu trách nhiệm giao tiếp với cơ sở dữ liệu SQL Server
    // Áp dụng Singleton Pattern để đảm bảo chỉ có một instance duy nhất
    public class DataProvider
    {
        // Biến static lưu trữ instance duy nhất của lớp
        private static DataProvider instance;

        // Thuộc tính Instance để truy cập instance của DataProvider
        public static DataProvider Instance
        {
            get
            {
                // Nếu instance chưa được khởi tạo thì tạo mới
                if (instance == null)
                    instance = new DataProvider();

                return DataProvider.instance;
            }
            private set
            {
                // Ngăn việc gán instance từ bên ngoài
                DataProvider.instance = value;
            }
        }

        // Constructor private để ngăn việc khởi tạo trực tiếp từ bên ngoài
        private DataProvider() { }

        // Chuỗi kết nối tới cơ sở dữ liệu SQL Server
        private string connectionSTR =
            "Data Source=.\\sqlexpress;Initial Catalog=QuanLyQuanCafe;Integrated Security=True";

        // Thực thi câu lệnh SELECT và trả về kết quả dạng DataTable
        public DataTable ExcuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                // Gán giá trị cho các tham số trong câu truy vấn (nếu có)
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;

                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                // Sử dụng SqlDataAdapter để đổ dữ liệu vào DataTable
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);

                connection.Close();
            }

            return data;
        }

        // Thực thi các câu lệnh INSERT, UPDATE, DELETE
        // Trả về số dòng bị ảnh hưởng
        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;

                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteNonQuery();
                connection.Close();
            }

            return data;
        }

        // Thực thi câu truy vấn trả về một giá trị duy nhất
        // Ví dụ: COUNT, SUM, MAX, MIN
        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;

                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteScalar();
                connection.Close();
            }

            return data;
        }
    }

}
