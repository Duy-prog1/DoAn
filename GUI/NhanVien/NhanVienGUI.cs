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
            cotSua.Text = "Sửa";
            cotSua.UseColumnTextForButtonValue = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Form themSp = null;
            themSp = new ThongTinNhanVienGUI(this,dataGridView1);
            themSp.StartPosition = FormStartPosition.CenterScreen;
            themSp.ShowDialog();
        }
    }

}
