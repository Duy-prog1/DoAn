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
    public partial class NhanVienGUI : Form
    {
        NhanVienBUS nvBus = new NhanVienBUS();
        NhanVienDTO nvDto = new NhanVienDTO();
        public NhanVienGUI()
        {
            InitializeComponent();
        }

        private void NhanVienGUI_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = this.nvBus.getNhanVien();
            cotXoa.Text = "Xóa";
            cotXoa.UseColumnTextForButtonValue = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Form themSp = null;
            themSp = new ThongTinNhanVienGUI(this, dataGridView1);
            themSp.StartPosition = FormStartPosition.CenterScreen;
            themSp.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "cotXoa")
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string ID = row.Cells["cotMaNv"].Value.ToString();
                // Xóa
                if (nvBus.xoaNhanVien(ID))
                {
                    MessageBox.Show("Xóa thành công");
                    dataGridView1.DataSource = nvBus.getNhanVien(); // get thanh vien
                }
                else
                {
                    MessageBox.Show("Xóa ko thành công");
                }
            }
        }

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            nvDto = new NhanVienDTO();
            Form thongTinNv = null;
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name != "cotXoa")
                {
                    dataGridView1.CurrentRow.Selected = true;

                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    nvDto.maNv = row.Cells["cotMaNv"].Value.ToString();
                    nvDto.tenNv = row.Cells["cotTenNv"].Value.ToString();
                    nvDto.gioiTinhNv = bool.Parse(row.Cells["cotGioiTinh"].Value.ToString());
                    nvDto.sdtNv = row.Cells["cotSdt"].Value.ToString();
                    nvDto.chucVu = row.Cells["cotChucVu"].Value.ToString();
                    nvDto.ngaySinhNv = row.Cells["cotNgaySinh"].Value.ToString();
                    nvDto.trangThai = true;
                    thongTinNv = new SuaThongTinNhanVienGUI(nvDto, dataGridView1);
                    thongTinNv.StartPosition = FormStartPosition.CenterScreen;
                    thongTinNv.ShowDialog();


                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string key = textBox1.Text;

            dataGridView1.DataSource = nvBus.getFindThanhVien(key);
        }
    }

}
