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
    public partial class ThemLoaiSanPhamGUI : Form
    {
        LoaiSanPhamBUS lspBus = new LoaiSanPhamBUS();
        LoaiSanPhamDTO lspDto;
        DataGridView gridlsp;
        public ThemLoaiSanPhamGUI(DataGridView gridlsp)
        {
            InitializeComponent();
            this.gridlsp = gridlsp;
        }

        private void ThemLoaiSanPhamGUI_Load(object sender, EventArgs e)
        {
            textBox1.Text = (lspBus.getAllLoaiSanPham().Rows.Count + 1).ToString();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            else
            {
                lspDto = new LoaiSanPhamDTO(int.Parse(textBox1.Text), textBox2.Text, true);
                if (lspBus.themLoaiSanPham(lspDto))
                {
                    MessageBox.Show("Thêm thành công");
                    gridlsp.DataSource = lspBus.getLoaiSanPham();
                    this.Close();
                }
                else
                    MessageBox.Show("Thêm thất bại");
            }
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
