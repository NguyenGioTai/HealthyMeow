﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI
{
    public partial class DangNhap : Form
    {
        private readonly UserBLL _userBLL = new UserBLL();
        public DangNhap()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label_matkhau_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel_dangki_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button_thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label_taikhoan_Click(object sender, EventArgs e)
        {

        }

        private void button_dangnhap_Click(object sender, EventArgs e)
        {
            // Tạo đối tượng UserDTO với tên đăng nhập và mật khẩu từ UI
            UserDTO user = new UserDTO
            {
                Username = textBox_taikhoan.Text.Trim(),
                Password = textBox_matkhau.Text.Trim()
            };

            // Gọi phương thức Authenticate và nhận về thông báo kết quả
            string result = _userBLL.Authenticate(user);

            // Hiển thị thông báo kết quả
            MessageBox.Show(result);

            // Kiểm tra nếu thông báo là "Đăng nhập thành công!", thì chuyển sang giao diện chính
            if (result == "Đăng nhập thành công!")
            {
                Console.WriteLine("Dang nhap thanh cong");
                this.Hide();
                PhieuSucKhoe mainForm = new PhieuSucKhoe();
                //mainForm.Show();
            }
        }

        private void checkBox_hienthi_CheckedChanged(object sender, EventArgs e)
        {
            textBox_matkhau.UseSystemPasswordChar = checkBox_hienthi.Checked;
        }
    }
}
