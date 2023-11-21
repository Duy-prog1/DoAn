using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class DangNhapGUI : Form
    {
       
        TaiKhoanDTO dto=new TaiKhoanDTO();
        TaiKhoanBUS bus=new TaiKhoanBUS();
        public static string tenDangNhap;
        public static string matKhau;

        public string MaNhanVien = new TaiKhoanBUS().LayMaNhanVien(tenDangNhap, matKhau);
        public string TenNhanVien = new TaiKhoanBUS().LayTenNhanVien(tenDangNhap, matKhau);
        public DangNhapGUI()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DangKyGUI dangky=new DangKyGUI();
            dangky.Show();
            //this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            QuenMatKhauGUI quenMatKhau = new QuenMatKhauGUI();  
            quenMatKhau.ShowDialog();
        }

        

        private void DangNhapGUI_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            int cornerRadius = 10; // Độ cong của góc

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(new Rectangle(0, 0, 2 * cornerRadius, 2 * cornerRadius), 180, 90);
                path.AddArc(new Rectangle(panel.Width - 2 * cornerRadius, 0, 2 * cornerRadius, 2 * cornerRadius), 270, 90);
                path.AddArc(new Rectangle(panel.Width - 2 * cornerRadius, panel.Height - 2 * cornerRadius, 2 * cornerRadius, 2 * cornerRadius), 0, 90);
                path.AddArc(new Rectangle(0, panel.Height - 2 * cornerRadius, 2 * cornerRadius, 2 * cornerRadius), 90, 90);
                path.CloseAllFigures();

                using (Region region = new Region(path))
                {
                    panel.Region = region;
                }
            }
        }
        // đăng nhập
        public void dangNhap()
        {
           tenDangNhap = textBox1.Text;
             matKhau= textBox2.Text;
          
            if (string.IsNullOrEmpty(tenDangNhap))
            {
                MessageBox.Show("tên đăng nhập không được bỏ trống");
                return;
            }  
            if(string.IsNullOrEmpty(matKhau)) {
                MessageBox.Show("mật khẩu không được bỏ trống");
                return;
            }
            bool result=bus.dangNhap(tenDangNhap, matKhau);
            if(result)

            {
                MessageBox.Show("đăng nhập thành công");
              
                
                BanHangGUI banHangGUI = new BanHangGUI();
               

                MenuGUI menu = new MenuGUI(1);
                menu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("tên đăng nhập hoặc mật khẩu không chính xác");
            }

        }
        // đăng nhập
        private void button1_Click(object sender, EventArgs e)
        {
            dangNhap();

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
                dangNhap();
                MenuGUI menu = new MenuGUI(1);
                menu.Show();
                this.Hide();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
