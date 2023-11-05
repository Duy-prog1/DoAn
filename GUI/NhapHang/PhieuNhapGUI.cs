using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.NhapHang
{
    public partial class PhieuNhapGUI : Form
    {
        public PhieuNhapGUI()
        {
            InitializeComponent();
        }

        private void btn_ThemPhieuNhap_Click(object sender, EventArgs e)
        {
            ThemPhieuNhapGUI themPhieuNhap = new ThemPhieuNhapGUI();
            themPhieuNhap.ShowDialog();
        }

        private void btn_ChiTiet_Click(object sender, EventArgs e)
        {
            CTPhieuNhapGUI ctPhieuNhap = new CTPhieuNhapGUI();
            ctPhieuNhap.ShowDialog();
        }
    }
}
