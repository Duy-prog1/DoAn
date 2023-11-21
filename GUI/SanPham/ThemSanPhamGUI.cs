using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.SanPham
{
    public partial class ThemSanPhamGUI : Form
    {
        SanPhamBUS spBus = new SanPhamBUS();
        SanPhamDTO spDto;
        LoaiSanPhamBUS lspBus = new LoaiSanPhamBUS();
        DataGridView gridsp;
        DataTable dt;
        public ThemSanPhamGUI(DataGridView gridsp)
        {
            InitializeComponent();
            this.gridsp = gridsp;
            this.load_BaoHanh(cbb_TGBH);
            this.load_MaLoai(cbb_MaLoai);
        }

        void load_BaoHanh(ComboBox cbb)
        {
            cbb.Items.Clear();
            cbb.Items.Add(12);
            cbb.Items.Add(24);
            cbb.Items.Add(36);
            cbb.SelectedIndex = 0;
        }

        public void load_MaLoai(ComboBox cbb)
        {
            cbb.Items.Clear();
            dt = lspBus.getLoaiSanPham();
            cbb.DisplayMember = "maLoai";
            cbb.DataSource = dt;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Ảnh (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(open.FileName);
                pictureBox1.BackColor = Color.Azure;
            }
        }
        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (checkBoTrong())
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            else if (checkMaSanPham() == false || checkGiaBan() == false)
                MessageBox.Show("Mã sản phẩm bị trùng hoặc giá bán không hợp lệ");
            else
            {
                spDto = new SanPhamDTO(tb_MaSanPham.Text.ToString(), 
                    tb_TenSanPham.Text.ToString(), float.Parse(tb_GiaBan.Text), 
                    0, ImageToByteArray(pictureBox1.Image), int.Parse(cbb_TGBH.Text), 
                    true, int.Parse(cbb_MaLoai.Text));
                if (spBus.themSanPham(spDto))
                {
                    MessageBox.Show("Thêm thành công");
                    gridsp.DataSource = spBus.getSanPham();
                    this.Close();
                }
                else
                    MessageBox.Show("Thêm thất bại");
            }
        }

        bool checkBoTrong()
        {
            if (tb_MaSanPham.ToString() == "" || tb_TenSanPham.ToString() == ""
                || tb_GiaBan.ToString() == "" || pictureBox1.Image == null)
                return true;
            return false;
        }

        bool checkMaSanPham()
        {
            dt = spBus.getSanPham();
            foreach (DataRow dr in dt.Rows)
                if (dr["maSP"].ToString() == tb_MaSanPham.Text)
                    return false;
            return true;
        }

        bool checkGiaBan()
        {
            string giaBan = tb_GiaBan.Text.ToString();
            bool isNumber = true;
            foreach (Char c in giaBan)
            {
                if (!Char.IsDigit(c))
                {
                    isNumber = false;
                    break;
                }
            }
            if (giaBan.Length < 7 || isNumber == false)
                return false;
            return true;
        }

        byte[] ImageToByteArray(Image img)
        {
            MemoryStream m = new MemoryStream();
            img.Save(m, System.Drawing.Imaging.ImageFormat.Jpeg);
            return m.ToArray();
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
