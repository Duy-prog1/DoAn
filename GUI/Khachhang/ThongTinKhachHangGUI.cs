using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ThongTinKhachHangGUI : Form
    {
        KhachHangDTO khDto;
        KhachHangBUS khBus = new KhachHangBUS();
        DataGridView tblKh;
        bool kichHoatSua = false;
        public ThongTinKhachHangGUI(KhachHangDTO khDto, DataGridView tblKh)
        {
            InitializeComponent();
            this.khDto = khDto;
            this.showThongTin();
            this.tblKh = tblKh;
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
            kichHoatSua = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (kichHoatSua)
            {
                suaThongTinKh();
            }
            else
                this.Close();
        }

        public void suaThongTinKh()
        {
            if (!tbSdt.Text.Equals("")&&!tbTenKh.Text.Equals("")){
                lbSdt.Text = "";
                lbTenKh.Text = "";
                if (CheckPhoneNumber(tbSdt.Text.Trim()))
                {
                    this.khDto.tenKh = tbTenKh.Text;
                    this.khDto.sdtKh = tbSdt.Text;
                    if (khBus.suakhachHang(khDto))
                    {
                        tblKh.DataSource = khBus.getKhachHang();
                        MessageBox.Show("Sửa thành công!");
                        this.Dispose();
                    }
                    else
                        MessageBox.Show("Sửa thất bại!");
                }
                else
                {
                    lbSdt.Text = "Số điện thoại không đúng định dạng!";
                }
            }
            else if (tbSdt.Text.Equals(""))
            {
                lbSdt.Text = "Số điện thoại không được để trống!";
            }
            else if(tbTenKh.Text.Equals(""))
            {
                lbTenKh.Text = "Tên khách hàng không được để trống!";
            }
            else
            {
                lbSdt.Text = "Số điện thoại không được để trống!";
                lbTenKh.Text = "Tên khách hàng không được để trống!";
            }
        }

        public bool CheckPhoneNumber(string phoneNumber)
        {
            // Biểu thức chính quy kiểm tra số điện thoại với định dạng cụ thể (10 số và bắt đầu bằng số 0)
            string phonePattern = @"^0\d{9}$";

            // Kiểm tra đầu vào là null hoặc rỗng
            if (string.IsNullOrEmpty(phoneNumber))
            {
                lbSdt.Text = "Số điện thoại không được để trống";
                return false;
            }

            // Kiểm tra độ dài của số điện thoại
            if (phoneNumber.Length != 10 || !phoneNumber.StartsWith("0"))
            {
                lbSdt.Text = "Số điện thoại không hợp lệ";
                return false;
            }

            // Kiểm tra trùng lặp với danh sách nhân viên
            foreach (KhachHangDTO kh in khBus.getList())
            {
                if (tbMaKh.Text.Equals(kh.maKh) && phoneNumber.Equals(kh.maKh))
                {
                    return true;
                }
                if (!tbMaKh.Text.Equals(kh.maKh) && phoneNumber.Equals(kh.maKh))
                {
                    lbSdt.Text = "Số điện thoại bị trùng";
                    return false;
                }
            }

            // Kiểm tra sự trùng khớp của số điện thoại với biểu thức chính quy
            if (!Regex.IsMatch(phoneNumber, phonePattern))
            {
                lbSdt.Text = "Số điện thoại không đúng định dạng";
                return false;
            }
            lbSdt.Text = "";
            return true;
        }
    }
}
