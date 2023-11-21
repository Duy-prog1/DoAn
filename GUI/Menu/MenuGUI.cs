using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.NhapHang;
using WindowsFormsApp1.SanPham;

namespace WindowsFormsApp1
{
    public partial class MenuGUI : Form
    {
        private BanHangGUI banHangGUI=new BanHangGUI();
        private SanPhamGUI sanPhamGUI = new SanPhamGUI();
        private NhanVienGUI nhanVienGUI=new NhanVienGUI();
        private KhachhangGUI khachhangGUI=new KhachhangGUI();
        private KhuyenMaiGUI khuyenMaiGUI=new KhuyenMaiGUI();
        private PhieuNhapGUI phieuNhapGUI=new PhieuNhapGUI();
        private ThongKeGUI thongKeGUI =new ThongKeGUI();

        private List<PictureBox> pictureBoxes = new List<PictureBox>();
        int maQuyen; //maQuyen=1 (Quanly), maQuyen=2 (NhanVienBanHang) , maQuyen=3 (NhanVienKho)
        public MenuGUI(int maQuyen)
        {
            InitializeComponent();
            pictureBoxes.Add(pictureBox1);
            pictureBoxes.Add(pictureBox2);
            pictureBoxes.Add(pictureBox3);
            pictureBoxes.Add(pictureBox5);
            if (maQuyen == 2)
            {
                tableLayoutPanel3.Controls.RemoveAt(6); //8
                tableLayoutPanel3.Controls.RemoveAt(5); //7
                tableLayoutPanel3.Controls.RemoveAt(4); //6
                tableLayoutPanel3.Controls.RemoveAt(2); //4
            }
            pictureBoxes.Add(pictureBox6);
            pictureBoxes.Add(pictureBox7);
            if (maQuyen == 3)
            {
                tableLayoutPanel3.Controls.RemoveAt(6); //8
                tableLayoutPanel3.Controls.RemoveAt(3); //5
                tableLayoutPanel3.Controls.RemoveAt(2); //4
                tableLayoutPanel3.Controls.RemoveAt(1); //3
                tableLayoutPanel3.Controls.RemoveAt(0); //2

            }
            this.StartPosition = FormStartPosition.CenterScreen;
            this.maQuyen = maQuyen;
        }

        private void MenuGUI_Load(object sender, EventArgs e)
        {
            // Thêm tất cả các PictureBox vào danh sách và gán sự kiện Click
            if (maQuyen == 1) //QuanLy
            {
                pictureBoxes.Add(pictureBox1); //banHang
                pictureBoxes.Add(pictureBox2); //Home
                pictureBoxes.Add(pictureBox3);//sanPham
                pictureBoxes.Add(pictureBox4);  //nhanVien
                pictureBoxes.Add(pictureBox5); //khachHang
                pictureBoxes.Add(pictureBox6);//khuyenMai
                pictureBoxes.Add(pictureBox7);  //nhapHang
                pictureBoxes.Add(pictureBox8);  //ThongKe
            }
            if (maQuyen == 2) //BanHang
            {
                pictureBoxes.Add(pictureBox1);
                pictureBoxes.Add(pictureBox2);
                pictureBoxes.Add(pictureBox3);
                pictureBoxes.Add(pictureBox5);
            }
            if (maQuyen == 3) //Kho
            {
                pictureBoxes.Add(pictureBox2);
                pictureBoxes.Add(pictureBox6);
                pictureBoxes.Add(pictureBox7);
            }

            foreach (PictureBox pictureBox in pictureBoxes)
            {
                pictureBox.Click += PictureBox_Click;
            }
          
            //ShowChildForm(childFormToShow, tableLayoutPanel5);
        }
        private void ShowChildForm(Form childForm, Control container)
        {
            if (container.Controls.Count > 0)
            {
                container.Controls.Remove(container.Controls[0]); // Loại bỏ form con hiện tại (nếu có)
            }

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            container.Controls.Add(childForm);
            container.Tag = childForm; // Lưu trữ form con cho việc loại bỏ sau này
            childForm.Show();
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox clickedPictureBox = sender as PictureBox;

            // Đặt lại màu cho tất cả các PictureBox
            foreach (PictureBox pictureBox in pictureBoxes)
            {
                pictureBox.BackColor = Color.DodgerBlue; // Đổi màu về màu ban đầu
            }

            // Đặt màu cho PictureBox được bấm
            clickedPictureBox.BackColor = Color.OrangeRed; // Đổi màu

            // Hiển thị form con tương ứng
            Form childFormToShow = null;
            if (clickedPictureBox == pictureBox1) 
            {
                childFormToShow = banHangGUI;
              
            }
            //Home
            else if (clickedPictureBox == pictureBox2)
            {
                childFormToShow = (Form)tableLayoutPanel5.Controls[0];
            }
            //San Pham
            else if (clickedPictureBox == pictureBox3)
            {
                childFormToShow = sanPhamGUI;
            }
            //Nhan Vien
            else if (clickedPictureBox == pictureBox4)
            {
                childFormToShow = nhanVienGUI;
            }
            //khach hang
            else if (clickedPictureBox == pictureBox5)
            {
                childFormToShow = khachhangGUI;
            }
            //khuyen mai
            else if (clickedPictureBox == pictureBox6)
            {
                childFormToShow = khuyenMaiGUI;
            }
            //nhap hang
            else if (clickedPictureBox == pictureBox7)
            {
                childFormToShow = phieuNhapGUI;
            }
            //thong ke
            else if (clickedPictureBox == pictureBox8)
            {
                childFormToShow = thongKeGUI;
            }
          

            childFormToShow.Dock = DockStyle.Fill;
            // Thêm các else if tương ứng cho các PictureBox khác

            if (childFormToShow != null)
            {
                ShowChildForm(childFormToShow, tableLayoutPanel5);
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
