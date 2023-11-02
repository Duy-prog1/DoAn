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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class SuaThongTinNhanVienGUI : Form
    {
        NhanVienDTO nvDto;
        NhanVienBUS nvBus = new NhanVienBUS();
        DataGridView tblNv;
        bool kichHoatSua = false;
        public SuaThongTinNhanVienGUI(NhanVienDTO nvDto, DataGridView tblNv)
        {
            InitializeComponent();
            this.nvDto = nvDto;
            this.tblNv = tblNv;
            this.loadChucVu(cbChucVu);
            showThongTin();
        }

        public void loadChucVu(System.Windows.Forms.ComboBox comboBox)
        {
            comboBox.Items.Clear();
            comboBox.Items.Add("Danh sách chúc Vụ");

            foreach (NhanVienDTO nv in nvBus.getList())
            {
                string item = nv.chucVu.ToString();
                if (!comboBox.Items.Contains(item))
                {
                    comboBox.Items.Add(item);
                }
            }
            comboBox.SelectedIndex = 0;

        }
        public void showThongTin()
        {
            tbMaNv.Enabled = false;
            tbTenNv.Enabled = false;
            tbSdt.Enabled = false;
            mtbNgaySinh.Enabled = false;
            rbNam.Enabled = false;
            rbNu.Enabled = false;
            cbChucVu.Enabled = false;
            rtbDiaChi.Enabled = false;


            tbMaNv.Text = nvDto.maNv;
            tbTenNv.Text = nvDto.tenNv;
            tbSdt.Text = nvDto.sdtNv;
            rtbDiaChi.Text = nvDto.diaChiNv;
        //    rbNam.Checked = true;
            if (cbChucVu.Items.Contains(nvDto.chucVu))
            {
                cbChucVu.SelectedItem = nvDto.chucVu;
            }          
            if (nvDto.gioiTinhNv.Equals("Nam"))
            {
                rbNam.Checked = true;
            }
            else
            {
                rbNu.Checked = true;
            }
            mtbNgaySinh.Text = nvDto.ngaySinhNv;
                

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbSdt.Enabled = true;      
            cbChucVu.Enabled = true;
            kichHoatSua = true;
            tbTenNv.Enabled = true;
            mtbNgaySinh.Enabled = true;
            rtbDiaChi.Enabled = true;

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(kichHoatSua)
            {
                suaThongTinNhanVien();
            }
            else
                this.Close();
           
        }

        public void suaThongTinNhanVien()
        {
            if (checkNgaySinhVaSdt())
            {
                if (tbTenNv.Text == "")
                {
                    lbTenNv.Text = "Vui lòng nhập tên nhân viên!";
                }
                else
                    lbTenNv.Text = "";
                if (rtbDiaChi.Text == "")
                {
                    lbDiaChi.Text = "Vui lòng nhập đia chỉ nhân viên!";
                }
                else
                    lbDiaChi.Text = "";
                if (cbChucVu.SelectedIndex == 0)
                {
                    lbChucVu.Text = "Vui lòng chọn chức vụ cho nhân viên!";
                }
                else
                    lbChucVu.Text = "";
                if (!rbNam.Checked && !rbNu.Checked)
                {
                    lbGioiTinh.Text = "Vui lòng chọn giới tính cho nhân viên!";
                }
                else
                    lbGioiTinh.Text = "";
                if (tbSdt.Text != "" && cbChucVu.SelectedIndex != 0 && mtbNgaySinh.Text != "" && CheckPhoneNumber(tbSdt.Text) && checkDate(mtbNgaySinh.Text, lbNgaySinh))
                {
                    lbTenNv.Text = "";
                    lbSdt.Text = "";
                    lbNgaySinh.Text = "";
                    lbGioiTinh.Text = "";
                    lbChucVu.Text = "";
                    this.nvDto.tenNv = tbTenNv.Text;
                    this.nvDto.ngaySinhNv = xuLyNgaySinh();
                    this.nvDto.sdtNv = tbSdt.Text;
                    this.nvDto.chucVu = xuLychucVu();
                    this.nvDto.diaChiNv = rtbDiaChi.Text;
                    if (nvBus.suaNhanVien(nvDto))
                    {
                        tblNv.DataSource = nvBus.getNhanVien();
                        MessageBox.Show("Sửa thành công!");
                        this.Dispose();
                    }
                    else
                        MessageBox.Show("Sửa thất bại!");
                }
            }
          
            else if (cbChucVu.SelectedIndex == 0)
            {
                lbChucVu.Text = "Bạn chưa chọn chức vụ!";
            }
            else if (tbSdt.Text == "")
            {
                lbSdt.Text = "Vui lòng nhập thông tin vào!";
            }
        }
        public bool checkNgaySinhVaSdt()
        {
            if (CheckPhoneNumber(tbSdt.Text) && !checkDate(mtbNgaySinh.Text, lbNgaySinh))
            {
                return true;
            }
            if (checkDate(mtbNgaySinh.Text, lbNgaySinh) && !CheckPhoneNumber(tbSdt.Text))
            {
                return true;
            }
            if (CheckPhoneNumber(tbSdt.Text) && checkDate(mtbNgaySinh.Text, lbNgaySinh))
            {
                return true;
            }
            if (checkDate(mtbNgaySinh.Text, lbNgaySinh) && CheckPhoneNumber(tbSdt.Text))
            {
                return true;
            }
            return false;
        }
        public string xuLychucVu()
        {
            string chucVu = "";
            if (cbChucVu.SelectedIndex != 0)
            {
                chucVu = cbChucVu.SelectedItem.ToString();
            }
            return chucVu;
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
            foreach (NhanVienDTO nv in nvBus.getList())
            {
                if (tbMaNv.Text.Equals(nv.maNv) && phoneNumber.Equals(nv.sdtNv))
                {
                    return true;
                }
                if (!tbMaNv.Text.Equals(nv.maNv) && phoneNumber.Equals(nv.sdtNv))
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
        public string xuLyNgaySinh()
        {
            string ngaySinh = "";
            string ngaySinhNv = mtbNgaySinh.Text;
            DateTime ngayTrongMaskedTextBox;

            if (DateTime.TryParseExact(ngaySinhNv, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out ngayTrongMaskedTextBox))
            {
                DateTime ngayHienTai = DateTime.Now;

                if (ngayHienTai > ngayTrongMaskedTextBox)
                {
                    ngaySinh = ngayTrongMaskedTextBox.ToString();

                }

            }
            return ChuyenDoiNgay(ngaySinh);
        }
        public string ChuyenDoiNgay(string ngayTruoc)
        {
            if (DateTime.TryParseExact(ngayTruoc, "dd/MM/yyyy h:mm:ss tt", null, System.Globalization.DateTimeStyles.None, out DateTime ngayGioSau))
            {
                return ngayGioSau.ToString("yyyy-MM-dd HH:mm:ss");
            }
            else
            {
                return "Ngày giờ không hợp lệ";
            }
        }

        public bool checkDate(string date, Label lbngaySinh)
        {
            DateTime ngayTrongMaskedTextBox;

            if (DateTime.TryParseExact(date, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out ngayTrongMaskedTextBox))
            {
                DateTime ngayHienTai = DateTime.Now;

                if (ngayHienTai > ngayTrongMaskedTextBox)
                {
                    lbngaySinh.Text = "";
                    return true;

                    //    Console.WriteLine("Ngày hiện tại lớn hơn ngày trong chuỗi.");
                }
                else if (ngayHienTai <= ngayTrongMaskedTextBox)
                {
                    lbngaySinh.Text = "Không được lớn hơn ngày hiện tại!";
                    //      MessageBox.Show("ngày sinh lớn hơn ngày hiện tại " + ngayTrongMaskedTextBox.ToString());
                    return false;
                }

            }
            else
            {
                lbngaySinh.Text = "Ngày sinh không hợp lệ!";
                return false;
            }
            return false;
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
