using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp1.SanPham
{
    public partial class SuaLoaiSanPhamGUI : Form
    {
        LoaiSanPhamBUS lspBus = new LoaiSanPhamBUS();
        LoaiSanPhamDTO lspDto;
        DataGridView gridlsp;
        public SuaLoaiSanPhamGUI(DataGridView gridlsp, string maSanPham)
        {
            InitializeComponent();
            this.gridlsp = gridlsp;
            textBox1.Text = maSanPham;
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            else
            {
                lspDto = new LoaiSanPhamDTO(int.Parse(textBox1.Text), textBox2.Text, true);
                if (lspBus.suaLoaiSanPham(lspDto))
                {
                    MessageBox.Show("Sửa thành công");
                    gridlsp.DataSource = lspBus.getLoaiSanPham();
                    this.Close();
                }
                else
                    MessageBox.Show("Sửa thất bại");
            }
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
