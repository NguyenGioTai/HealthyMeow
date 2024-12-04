using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class UserBLL
    {
        private readonly UserDAL _userDAL = new UserDAL();

        /// <summary>
        /// Phương thức xác thực người dùng
        /// </summary>
        /// <param name="user">Đối tượng UserDTO chứa thông tin đăng nhập</param>
        /// <param name="message">Thông báo kết quả xác thực</param>
        /// <returns>True nếu xác thực thành công, False nếu thất bại</returns>
        public bool Authenticate(UserDTO user, out string message)
        {
            if (!IsValidUsername(user.Username))
            {
                message = "Tên đăng nhập không hợp lệ! Tên phải có ít nhất 4 ký tự, không ký tự đặc biệt và không toàn số.";
                return false;
            }

            if (!IsValidPassword(user.Password))
            {
                message = "Mật khẩu không hợp lệ! Mật khẩu phải có ít nhất 6 ký tự, gồm ít nhất 1 chữ hoa và 1 số.";
                return false;
            }

            bool isAuthenticated = _userDAL.ValidateUser(user);
            message = isAuthenticated ? "Đăng nhập thành công!" : "Tên đăng nhập hoặc mật khẩu không đúng!";
            Console.WriteLine($"Đăng nhập: {user.Username}, Kết quả: {(isAuthenticated ? "Thành công" : "Thất bại")}");
            return isAuthenticated;
        }

        /// <summary>
        /// Kiểm tra tính hợp lệ của tên đăng nhập
        /// </summary>
        private bool IsValidUsername(string username)
        {
            Console.WriteLine($"Kiểm tra tên đăng nhập: {username}");
            return Regex.IsMatch(username, @"^(?=.*[a-zA-Z])[a-zA-Z\d]{4,}$");
        }

        /// <summary>
        /// Kiểm tra tính hợp lệ của mật khẩu
        /// </summary>
        private bool IsValidPassword(string password)
        {
            Console.WriteLine($"Kiểm tra mật khẩu: {password}");
            return Regex.IsMatch(password, @"^(?=.*[A-Z])(?=.*\d)[A-Za-z\d]{6,}$");
        }
    }
}
