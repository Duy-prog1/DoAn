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
    public partial class ThongTinKhachHangGUI : Form
    {
        KhachHangDTO khDto;
        public ThongTinKhachHangGUI(KhachHangDTO khDto)
        {
            InitializeComponent();
            this.khDto = khDto;
            this.showThongTin();
        }

        public void showThongTin()
        {
            tbMaKh.Enabled = false;
            tbTenKh.Enabled = false;
            tbTichDiem.Enabled = false;
            tbTongChi.Enabled = false;
            tbSdt.Enabled = false;
//            rtbDiaChi.Enabled = false;

            tbMaKh.Text = khDto.maKh.ToString();
            tbTenKh.Text = khDto.tenKh;
            tbTichDiem.Text = khDto.tichDiem.ToString();
            tbTongChi.Text = khDto.tongChi.ToString();
            tbSdt.Text = khDto.sdtKh;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbTenKh.Enabled = true;
            tbSdt.Enabled = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
