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
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp1.SanPham
{
    public partial class SanPhamGUI : Form
    {
        SanPhamBUS spBus = new SanPhamBUS();
        LoaiSanPhamBUS lspBus = new LoaiSanPhamBUS();

        public SanPhamGUI()
        {
            InitializeComponent();
        }

        private void SanPhamGUI_Load(object sender, EventArgs e)
        {
            //SanPham
            grid_SanPham.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid_SanPham.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid_SanPham.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid_SanPham.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid_SanPham.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid_SanPham.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid_SanPham.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            grid_SanPham.DataSource = this.spBus.getSanPham();
            //LoaiSanPham
            grid_LoaiSanPham.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid_LoaiSanPham.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid_LoaiSanPham.DataSource = this.lspBus.getLoaiSanPham();
        }

        private void btn_ThemSanPham_Click(object sender, EventArgs e)
        {
            ThemSanPhamGUI themSanPham = new ThemSanPhamGUI(grid_SanPham);
            themSanPham.ShowDialog();
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            //Lấy mã sản phẩm và ảnh
            string maSanPham = grid_SanPham.SelectedRows[0].Cells[0].Value.ToString();
            Image img = null;
            if (grid_SanPham.SelectedRows[0].Cells[4].Value.ToString() != "")//Nếu có ảnh
            {
                MemoryStream stream = new MemoryStream((byte[])grid_SanPham.SelectedRows[0].Cells[4].Value);
                img = Image.FromStream(stream);
            }
            //Truyền vào GUI sửa SP
            SuaSanPhamGUI suaSanPham = new SuaSanPhamGUI(grid_SanPham, maSanPham, img);
            suaSanPham.ShowDialog();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này không?", "Xóa sản phẩm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string maSanPham = grid_SanPham.SelectedRows[0].Cells[0].Value.ToString();
                spBus.xoaSanPham(maSanPham);
                grid_SanPham.DataSource = spBus.getSanPham();
            }
            else
            {
                return;
            }
        }
        private void tb_Tim_TextChanged(object sender, EventArgs e)
        {
            if (tb_Tim.Text == "")
                grid_SanPham.DataSource = this.spBus.getSanPham();
            else
                grid_SanPham.DataSource = this.spBus.timSanPham(tb_Tim.Text);
        }

        private void btn_ThemLoaiSanPham_Click(object sender, EventArgs e)
        {
            ThemLoaiSanPhamGUI themLoaiSanPham = new ThemLoaiSanPhamGUI(grid_LoaiSanPham);
            themLoaiSanPham.ShowDialog();
        }

        private void btn_Sua2_Click(object sender, EventArgs e)
        {
            string maLoai = grid_LoaiSanPham.SelectedRows[0].Cells[0].Value.ToString();
            SuaLoaiSanPhamGUI suaLoaiSanPham = new SuaLoaiSanPhamGUI(this.grid_LoaiSanPham, maLoai);
            suaLoaiSanPham.ShowDialog();
        }

        private void btn_Xoa2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa không?", "Xóa loại sản phẩm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string maLoai = grid_LoaiSanPham.SelectedRows[0].Cells[0].Value.ToString();
                lspBus.xoaLoaiSanPham(int.Parse(maLoai));
                grid_LoaiSanPham.DataSource = lspBus.getLoaiSanPham();
            }
            else
            {
                return;
            }
        }

        private void tb_Tim2_TextChanged(object sender, EventArgs e)
        {
            if (tb_Tim2.Text == "")
                grid_LoaiSanPham.DataSource = this.lspBus.getLoaiSanPham();
            else
                grid_LoaiSanPham.DataSource = this.lspBus.timLoaiSanPham(tb_Tim2.Text);
        }
    }
}
