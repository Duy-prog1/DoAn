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
        NhanVienBUS nvBus = new NhanVienBUS();
        NhanVienGUI nvGui;
        public ThongTinNhanVienGUI(NhanVienGUI nvGui, DataGridView tblNv)
        {
            InitializeComponent();
            this.nvGui = nvGui;
            this.tblNv = tblNv;
            this.tbMaNv.Text = capNhatId();
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
            nvDto = new NhanVienDTO(capNhatId(), tbTenNv.Text,XuLyGioiTinh() ,xuLySdt(), xuLychucVu(), "2003-05-19", true);
            if (nvBus.themNhanVien(nvDto))
            {
                MessageBox.Show("thêm thành công");
                tblNv.DataSource = nvBus.getNhanVien();
            }
            else
                MessageBox.Show("thêm thất bại");
            Console.WriteLine(nvDto.maNv);
            Console.WriteLine(nvDto.tenNv);
            Console.WriteLine(nvDto.gioiTinhNv);
            Console.WriteLine(nvDto.sdtNv);
            Console.WriteLine(nvDto.chucVu);
            Console.WriteLine(nvDto.ngaySinhNv);
            Console.WriteLine(nvDto.trangThai);
           
        }

        
        public bool XuLyGioiTinh()
        {
            bool gioiTinh = false;
            if (rbNam.Checked)
            {
                lbGioiTinh.Text = "";
                gioiTinh = true;
                MessageBox.Show("chọn nam");
            }
            else if(rbNu.Checked)
            {
                lbGioiTinh.Text = "";
                gioiTinh = false;
            }
            else
            {
                lbGioiTinh.Text = "Bạn chưa chọn giới tính!";
            }
            return gioiTinh;

        }
        public string xuLySdt()
        {
            string sdt = "";
            if (tbSdt.Text != "")
            {
                if (checkSdt(tbSdt.Text))
                {
                    lbSdt.Text = "";
                    sdt = tbSdt.Text;
                }
                else
                {
                    lbSdt.Text = "Số điện thoại không hợp lệ!";
                }
            }
            else
                lbSdt.Text = "Không được để trống";

            return sdt;

        }
         public bool checkSdt(string phoneNumber)
        {
            // Biểu thức chính quy kiểm tra số điện thoại với định dạng cụ thể (10 số và bắt đầu bằng số 0)
            string phonePattern = @"^0\d{9}$";

            // Kiểm tra sự trùng khớp của số điện thoại với biểu thức chính quy
            return Regex.IsMatch(phoneNumber, phonePattern);
        }

        public string xuLychucVu()
        {
            string chucVu = "";
            if (cbChucVu.SelectedIndex != 0)
            {
                lbChucVu.Text = "";
                chucVu = cbChucVu.SelectedItem.ToString();
            }
            else
                lbChucVu.Text = "Bạn chưa chọn chức vụ!";
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
                    lbNgaySinh.Text = "";
                    ngaySinh = ngayTrongMaskedTextBox.ToString();

                //    Console.WriteLine("Ngày hiện tại lớn hơn ngày trong chuỗi.");
                }
                else if (ngayHienTai <= ngayTrongMaskedTextBox)
                {
                    lbNgaySinh.Text = "Lhông được lớn hơn ngày hiện tại!";
              //      MessageBox.Show("ngày sinh lớn hơn ngày hiện tại " + ngayTrongMaskedTextBox.ToString());
        
                }
             
            }
            else
            {
                lbNgaySinh.Text = "Ngày sinh không hợp lệ!";
                MessageBox.Show("Ngày sinh không hợp lệ!");
            }
            return ngaySinh;
        }

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

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(cbChucVu.SelectedItem.ToString());
            Console.WriteLine("Quản lý");
            Console.WriteLine("trần Quang Trưởng");
        }
    }
}
