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

namespace WindowsFormsApp1
{
    public partial class KhachhangGUI : Form
    {
        KhachHangDTO khDto;
        KhachHangBUS khBus = new KhachHangBUS();
        public KhachhangGUI()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string key = textBox1.Text;

            dataGridView1.DataSource = khBus.getFindKhachHang(key);
        }

        private void KhachhangGUI_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = this.khBus.getKhachHang();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            khDto = new KhachHangDTO();
            Form thongTinKhGui = null;
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dataGridView1.CurrentRow.Selected = true;

                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                khDto.maKh = int.Parse( row.Cells["cotMaKh"].Value.ToString());
                khDto.tenKh = row.Cells["cotTenKh"].Value.ToString();             
                khDto.sdtKh = row.Cells["cotSdt"].Value.ToString();
                khDto.tichDiem = int.Parse(row.Cells["cotTichDiem"].Value.ToString());
                khDto.tongChi = double.Parse(row.Cells["cotTongChi"].Value.ToString());
                thongTinKhGui = new ThongTinKhachHangGUI(khDto);
                thongTinKhGui.StartPosition = FormStartPosition.CenterScreen;
                thongTinKhGui.ShowDialog();

            }
        }
    }
}
