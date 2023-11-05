using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.SanPham
{
    public partial class SanPhamGUI : Form
    {
        public SanPhamGUI()
        {
            InitializeComponent();
        }

        private void btn_ThemSanPham_Click(object sender, EventArgs e)
        {
            ThemSanPhamGUI themSanPham = new ThemSanPhamGUI();
            themSanPham.ShowDialog();
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            SuaSanPhamGUI suaSanPham = new SuaSanPhamGUI();
            suaSanPham.ShowDialog();
        }

        private void btn_ThemLoaiSanPham_Click(object sender, EventArgs e)
        {
            ThemLoaiSanPhamGUI themLoaiSanPham = new ThemLoaiSanPhamGUI();
            themLoaiSanPham.ShowDialog();
        }

        private void btn_Sua2_Click(object sender, EventArgs e)
        {
            SuaLoaiSanPhamGUI suaLoaiSanPham = new SuaLoaiSanPhamGUI();
            suaLoaiSanPham.ShowDialog();
        }
    }
}
