using BUS;
using DTO;
using System;
using System.Collections;
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
    public partial class ThongTinNhanVienGUI : Form
    {
        DataGridView tblNv;
        NhanVienDTO nvDto;
        TaiKhoanDTO tkDto;
        TaiKhoanBUS tkBus = new TaiKhoanBUS();
        NhanVienBUS nvBus = new NhanVienBUS();
        NhanVienGUI nvGui;
        public ThongTinNhanVienGUI(NhanVienGUI nvGui, DataGridView tblNv)
        {
            InitializeComponent();
            this.nvGui = nvGui;
            this.tblNv = tblNv;
            this.tbMaNv.Text = capNhatId2();
            this.tbMaNv.Enabled = false;
            this.loadChucVu(cbChucVu);
            this.tblNv = tblNv;
        }

        public void loadChucVu(ComboBox comboBox)
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

        private void button1_Click(object sender, EventArgs e)
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
                if (tbTenNv.Text != "" && tbSdt.Text != "" && cbChucVu.SelectedIndex != 0 && (rbNam.Checked || rbNu.Checked) && maskedTextBox1.Text != "" && rtbDiaChi.Text != "" 
                    && checkDate(maskedTextBox1.Text, lbNgaySinh) && CheckPhoneNumber(tbSdt.Text))
                {
                    lbDiaChi.Text = "";
                    lbTenNv.Text = "";
                    lbSdt.Text = "";
                    lbNgaySinh.Text = "";
                    lbGioiTinh.Text = "";
                    lbChucVu.Text = "";
                    nvDto = new NhanVienDTO(capNhatId2(), tbTenNv.Text, XuLyGioiTinh(), XuLySdt(), rtbDiaChi.Text, xuLychucVu(), xuLyNgaySinh(), true);
                    int maSo = nvBus.getList().Count + 1;
                    string tenDn = "nhanvien" + maSo;
                    string mk = "nhanvien" + maSo;
                    if (nvBus.themNhanVien(nvDto))
                    {
                        if(taoTk(nvDto.chucVu, nvDto.maNv, tenDn, mk))
                        {
                            MessageBox.Show("thêm thành công");
                            tblNv.DataSource = nvBus.getNhanVien();
                            this.Dispose();
                        }
                        else
                            MessageBox.Show("thêm thất bại");

                    }
                    else
                        MessageBox.Show("thêm thất bại");
                }
            }  
            else
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
            }
            
               

        }

        public bool checkNgaySinhVaSdt()
        {
            if (CheckPhoneNumber(tbSdt.Text)&&!checkDate(maskedTextBox1.Text, lbNgaySinh))
            {
                return true;
            }
            if(checkDate(maskedTextBox1.Text, lbNgaySinh)&&!CheckPhoneNumber(tbSdt.Text))
            {
                return true;
            }
            if(CheckPhoneNumber(tbSdt.Text) && checkDate(maskedTextBox1.Text, lbNgaySinh))
            {
                return true;
            }
            if (checkDate(maskedTextBox1.Text, lbNgaySinh) && CheckPhoneNumber(tbSdt.Text) )
            {
                return true;
            }
            return false;
        }       
        public String XuLyGioiTinh()
        {
            String gioiTinh = "Nam";
            if(rbNu.Checked)
            {              
                gioiTinh = "Nữ";
            }           
            return gioiTinh;

        }
        
        public string XuLySdt()
        {
            string sdt ="";
            if (checkSdt(tbSdt.Text))
            {
                sdt = tbSdt.Text;
            }
            return sdt;
        }
         public bool checkSdt(string phoneNumber)
        {
            // Biểu thức chính quy kiểm tra số điện thoại với định dạng cụ thể (10 số và bắt đầu bằng số 0)
            string phonePattern = @"^0\d{9}$";
            foreach (NhanVienDTO nv in nvBus.getList())           
            {
                    if (phoneNumber.Equals(nv.sdtNv))
                    {                    
                        return false;
                    }
            }
            // Kiểm tra sự trùng khớp của số điện thoại với biểu thức chính quy
            return Regex.IsMatch(phoneNumber, phonePattern);
        }

        public bool CheckPhoneNumber(string phoneNumber)
        {
            // Biểu thức chính quy kiểm tra số điện thoại với định dạng cụ thể (10 số và bắt đầu bằng số 0)
            string phonePattern = @"^0\d{9}$";

            // Kiểm tra đầu vào là null hoặc rỗng
            if (string.IsNullOrEmpty(phoneNumber))
            {
                lbSdt.Text = "Số điện thoại không được để trống!";
                return false;
            }

            // Kiểm tra độ dài của số điện thoại
            if (phoneNumber.Length != 10 || !phoneNumber.StartsWith("0"))
            {
                lbSdt.Text = "Số điện thoại không hợp lệ!";
                return false;
            }

            // Kiểm tra trùng lặp với danh sách nhân viên
            foreach (NhanVienDTO nv in nvBus.getList())
            {
                if (phoneNumber.Equals(nv.sdtNv))
                {
                    lbSdt.Text = "Số điện thoại bị trùng!";
                    return false;
                }
            }

            // Kiểm tra sự trùng khớp của số điện thoại với biểu thức chính quy
            if (!Regex.IsMatch(phoneNumber, phonePattern))
            {
                lbSdt.Text = "Số điện thoại không đúng định dạng!";
                return false;
            }
            lbSdt.Text = "";
            return true;
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
        public string xuLychucVu()
        {
            string chucVu = "";
            if (cbChucVu.SelectedIndex != 0)
            {
                chucVu = cbChucVu.SelectedItem.ToString().Trim();
            }        
            return chucVu;
        }
        public string xuLyNgaySinh()
        {
            string ngaySinh = "";
            string ngaySinhNv = maskedTextBox1.Text;
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
        public string capNhatId2()
        {
            String maNv = "";
            int soMaNv = nvBus.getList().Count + 1;
            if (soMaNv >= 10)
            {
                maNv = "NV" + soMaNv;
            }
            else
                maNv = "NV0" + soMaNv;
            return maNv;
        }
        /*
        public string capNhatId()
        {
            String maNv = "";
            int soMaNv = 0;
            foreach (NhanVienDTO nv in nvBus.getList())
            {
                string temp = nv.maNv.ToString().Substring(2);
                int max = int.Parse(temp);
                if(max > soMaNv)
                {
                    soMaNv = max;
                }

            }
            soMaNv += 1;
            if (soMaNv >= 10)
            {
                maNv = "NV" + soMaNv;
            }
            else
                maNv = "NV0" + soMaNv;
            return maNv;
        }
        */
        private void button2_Click(object sender, EventArgs e)
        {

            this.Dispose();
        }

        public bool taoTk(string chucVu, string maNv, string tenDn, string mk)
        {
            int maQuyen = 0;        
            if (chucVu.Equals("Quản lý"))
            {
                maQuyen = 1;
            }
            else if (chucVu.Equals("NV kho"))
            {
                maQuyen = 3;
            }
            else
            {
                maQuyen = 2;
            }

            tkDto = new TaiKhoanDTO(maNv, maQuyen,tenDn, mk, 1);
            return tkBus.themTaiKhoan(tkDto);
        }
    }
}
