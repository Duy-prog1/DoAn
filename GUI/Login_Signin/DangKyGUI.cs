using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class DangKyGUI : Form
    {
        TaiKhoanBUS bus=new TaiKhoanBUS();
        public DangKyGUI()
        {
            InitializeComponent();
            AcceptButton = null;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DangNhapGUI dangnhap=new DangNhapGUI();
            dangnhap.Show();
            this.Hide();
        }
        // đăng ký gui
        private void dangky()
        {
            string tenDangNhap = textBox1.Text;
            string matKhau = textBox2.Text;
            string xacNhanMatKhau = textBox3.Text;
            string email = textBox4.Text;

            if (string.IsNullOrEmpty(tenDangNhap))
            {
                MessageBox.Show("tên đăng nhập không được bỏ trống");
                return;
            }

            if (string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("mật khẩu không được bỏ trống");
                return;
            }

            if (matKhau == xacNhanMatKhau)
            {
                string emailPattern = @"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[\w]{2,7}$";
                if (!Regex.IsMatch(email, emailPattern, RegexOptions.IgnoreCase))
                {
                    MessageBox.Show("Email không hợp lệ");
                    return;
                }
                TaiKhoanDTO dto = new TaiKhoanDTO(tenDangNhap, matKhau, email);

                Boolean result = bus.themTaiKhoan(dto);
                if (result)
                {
                    MessageBox.Show("Đăng ký thành công");
                    DangNhapGUI dangnhap = new DangNhapGUI();
                    dangnhap.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("tên đăng nhập đã tồn tại");
                }

            }
            else
            {
                MessageBox.Show("Mật khẩu nhập lại không chính xác");
            }
        }

        private void DangKyGUI_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dangky();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; 
                textBox2.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; 
                textBox3.Focus(); 
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                textBox4.Focus();
            }

        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                dangky();
            }
        }

        
    }
}
