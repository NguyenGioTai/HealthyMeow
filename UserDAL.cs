using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;




namespace DAL
{

    public class UserDAL
    {
        private readonly string connectionString = "Data Source=HUY\\MSSQLSERVER10;Initial Catalog=QuanLySucKhoe;Integrated Security=True;";
        /// <summary>
        /// Xác thực người dùng bằng cách kiểm tra tên đăng nhập và mật khẩu đã mã hóa trong cơ sở dữ liệu.
        /// </summary>
        public bool ValidateUser(UserDTO user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM [user] WHERE username = @Username AND password = @Password";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", user.Username);
                        cmd.Parameters.AddWithValue("@Password", user.Password); // Không dùng băm mật khẩu


                        int result = (int)cmd.ExecuteScalar();
                        Console.WriteLine($"Truy vấn trả về kết quả: {result}");
                        return result > 0;
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("Lỗi SQL: " + sqlEx.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi không xác định: " + ex.Message);
                return false;
            }
        }
    }
}
