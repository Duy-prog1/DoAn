using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class BanHangGUI : Form
    {
       
       
       
        private int soLuongSanPham = 1;
        private DataTable gioHang;
        BanHangBUS bus = new BanHangBUS();
        KhachHangBUS khachHangBUS=new KhachHangBUS();
        KhuyenMaiBUS khuyenMaiBUS = new KhuyenMaiBUS();
        HoaDonBUS hoaDonBus=new HoaDonBUS();
        ChiTietHoaDonBUS chiTietHoaDonBUS = new ChiTietHoaDonBUS();
        decimal soLuongSPTrongDB;
        //public string maNhanVien { get; set; }
        DataGridViewComboBoxColumn comboBoxColumn ;
        public BanHangGUI()
        {
            InitializeComponent();
            HienThiHoaDon();
           
            comboBox3.Enabled = false;
            gioHang = new DataTable();
            gioHang.Columns.Add("MaSP", typeof(string));
            gioHang.Columns.Add("TenSP", typeof(string));
            gioHang.Columns.Add("GiaBan", typeof(decimal));
            gioHang.Columns.Add("SoLuong", typeof(int));
            gioHang.Columns.Add("ThanhTien", typeof(decimal));
            gioHang.Columns.Add("Xoa", typeof(bool)).SetOrdinal(0);
            gioHang.Columns.Add("KhuyenMai", typeof(string));
            gioHang.Columns.Add("TienSauGiamGia", typeof(string));
            dataGridView2.DataSource = gioHang;

            dataGridView2.Columns["MaSP"].HeaderText = "Mã SP";
            dataGridView2.Columns["TenSP"].HeaderText = "Tên SP";
            dataGridView2.Columns["GiaBan"].HeaderText = "Giá bán";
            dataGridView2.Columns["SoLuong"].HeaderText = "Số lượng";
            dataGridView2.Columns["ThanhTien"].HeaderText = "Thành tiền";
            dataGridView2.Columns["KhuyenMai"].HeaderText = "Khuyễn mãi";
            dataGridView2.Columns["TienSauGiamGia"].HeaderText = "Tiền Giảm Giá";
            dataGridView2.Columns["Xoa"].HeaderText = "Xóa";
        }
        private void capNhatSoLuong()
        {

        }
        
        private void BanHangGUI_Load(object sender, EventArgs e)
        {
          
          
            dataGridView1.DataSource = bus.getDSSP();
            // load combobox khách hàng
            DataTable dtKhachHang=khachHangBUS.getKhachHang();
            if (dtKhachHang.Rows.Count > 0)
            {
                dtKhachHang.Columns.Add("MaTenKH", typeof(string), "maKH + ' - ' + tenKH");
                comboBox2.DataSource = dtKhachHang;
                comboBox2.DisplayMember = "MaTenKH";
                comboBox2.ValueMember = "maKH";
              
            }    
            comboBox2.SelectedIndex = -1;
        }

        // nút thanh toán
        private void button3_Click(object sender, EventArgs e)
        {
            thanhToan();
            HienThiHoaDon();
        }

      
        // tìm kiếm
        private void button1_Click(object sender, EventArgs e)
        {
           string keyword = textBox1.Text;    
            if (!string.IsNullOrEmpty(keyword))
            {
                DataTable searchResult = bus.TimKiemSanPham(keyword); 

                if (searchResult != null && searchResult.Rows.Count > 0)
                {
                    dataGridView1.DataSource = searchResult;
                }
                else
                {
                    dataGridView1.DataSource = null; 
                    MessageBox.Show("Không tìm thấy sản phẩm nào.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.");
            }
        }
        // tải lại trang
        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bus.getDSSP();
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            //textBox7.Text = "";
            textBox8.Text = "";
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                string maSP = selectedRow.Cells["Column1"].Value.ToString();
                string tenSP = selectedRow.Cells["Column2"].Value.ToString();
                decimal giaBan = decimal.Parse(selectedRow.Cells["Column4"].Value.ToString());
                string maLoai = selectedRow.Cells["Column3"].Value.ToString();
                soLuongSPTrongDB = decimal.Parse(selectedRow.Cells["Column22"].Value.ToString());
                string anh = selectedRow.Cells["Column5"].Value.ToString();
                textBox3.Text = maSP;
                textBox2.Text = tenSP;
                textBox5.Text = giaBan.ToString();

                //string imagePath = "E:\\BanDienThoai\\DoAn\\GUI\\img\\rogphone6.jpg";
                string imagePath = Path.Combine("E:\\BanDienThoai\\DoAn\\GUI", anh);
                if (File.Exists(imagePath))
                {
                    pictureBox1.Image = Image.FromFile(imagePath);
                }
                else
                {
                    MessageBox.Show("Image file not found: " + imagePath, "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    pictureBox1.Image = null;
                }

            }

            dataGridView2.ClearSelection();
            comboBox3.SelectedIndex = -1;
            comboBox3.Enabled = false;
        }
        // click vào đây để lấy ra khuyễn mãi
        string masp;
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView2.Rows.Count)
            {
                DataGridViewRow selectedRow = dataGridView2.Rows[e.RowIndex];
                string tensp = selectedRow.Cells["TenSP"].Value.ToString();
                masp = selectedRow.Cells["MaSP"].Value.ToString();

                // Kiểm tra nếu sản phẩm có trong giỏ hàng
                DataRow[] gioHangRows = gioHang.Select("MaSP = '" + masp + "'");
                
                if (gioHangRows.Length > 0)
                {
                    // Hiển thị combobox khi chỉ chọn sản phẩm trong giỏ hàng
                    DataTable dtKhuyenMai = bus.LayMaKhuyenMai(tensp);
                    if (dtKhuyenMai.Rows.Count > 0)
                    {
                        dtKhuyenMai.Columns.Add("MaTenKM", typeof(string), "maKM + ' - ' + tenKM");
                        comboBox3.DataSource = dtKhuyenMai;
                        comboBox3.DisplayMember = "MaTenKM";
                        comboBox3.ValueMember = "maKM";
                        comboBox3.SelectedIndex = -1;
                        comboBox3.Enabled = true;
                    }
                }
               

                dataGridView1.ClearSelection();
            }
           
        }
        // thêm mã giảm giá
        private string selectedKhuyenMai = "";

        private void button8_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(masp))
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm từ giỏ hàng trước khi thêm mã giảm giá.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DateTime ngayHienTai = DateTime.Now;
            DataRowView selectedRow = comboBox3.SelectedItem as DataRowView;
            if (selectedRow != null)
            {
                DateTime ngayBatDau = Convert.ToDateTime(selectedRow["ngayBD"]);
                DateTime ngayKetThuc = Convert.ToDateTime(selectedRow["ngayKT"]);

                if (ngayHienTai < ngayBatDau || ngayHienTai > ngayKetThuc)
                {
                    MessageBox.Show("Mã giảm giá đã hết hạn hoặc chưa có hiệu lực.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            selectedKhuyenMai = comboBox3.SelectedValue?.ToString();
            HienThiMaGiamGiaTrongGioHang();
            TinhTongSoTienGiam();
        }
        // hiển thị giảm giá trong giỏ hàng
        private void HienThiMaGiamGiaTrongGioHang()
        {
            
            foreach (DataRow row in gioHang.Rows)
            {
               
                if (row["MaSP"].ToString() == masp)
                {
                    if (string.IsNullOrEmpty(row["KhuyenMai"].ToString()))
                    {
                        row["KhuyenMai"] = selectedKhuyenMai;
                    }
                    else
                    {
                        row["KhuyenMai"] = selectedKhuyenMai;
                    }
                   
                    tienSauKhuyenMai(row);
                    break; 
                }

            }
            comboBox3.SelectedIndex = -1;

        }
       
        //



        // thành tiến sau khi giảm giá
        private void tienSauKhuyenMai(DataRow row)
        {
            DataRowView selectedRow = comboBox3.SelectedItem as DataRowView;
            if (selectedRow != null)
            {
                DataTable dtKhuyenMai = bus.getkhuyenMaiBanhang();
                decimal tienKhuyenMai;
                decimal donViGiam = Convert.ToDecimal(selectedRow["donViGiam"].ToString());
                if (donViGiam >0)
                {
                        decimal giaBan = Convert.ToDecimal(row["GiaBan"]);
                        int soLuong = Convert.ToInt32(row["SoLuong"]);
                        tienKhuyenMai = (giaBan * soLuong * donViGiam) / 100;
                        row["TienSauGiamGia"] = tienKhuyenMai;
                }
                else
                {
                    row["TienSauGiamGia"] = 0;
                }
              
            }
           
        }
        private void TinhTongSoTienGiam()
        {
            decimal tongTienGiam = 0;
            
            foreach (DataRow row in gioHang.Rows)
            {
                object tienSauGiamGiaObj = row["TienSauGiamGia"];

                if (tienSauGiamGiaObj != DBNull.Value)
                {
                    // Nếu giá trị không phải là DBNull, thì thực hiện chuyển đổi
                    tongTienGiam += Convert.ToDecimal(tienSauGiamGiaObj);

                }
            }
            decimal thanhTienSauGiamGia = tongTien - tongTienGiam;
            textBox8.Text = thanhTienSauGiamGia.ToString("#,##0 ");
            // Hiển thị tổng số tiền đã giảm trong textBox4
            textBox4.Text = tongTienGiam.ToString("#,##0 ");
            
        }

        // thêm vào giỏ
        decimal tongTien;
        private void themvaogio()
        {
            string maSP = textBox3.Text;
            string tenSP = textBox2.Text;
            if (string.IsNullOrEmpty(maSP))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm trước khi thêm vào giỏ hàng.");
                return;
            }

            decimal giaBan = decimal.Parse(textBox5.Text);
            DataRow[] existingRows = gioHang.Select("MaSP = '" + maSP + "'");


            if (existingRows.Length > 0)
            {
                int soLuong = Convert.ToInt32(existingRows[0]["SoLuong"]);
                if (soLuong + soLuongSanPham <= soLuongSPTrongDB)
                {

                    existingRows[0]["SoLuong"] = soLuong + soLuongSanPham;
                    existingRows[0]["KhuyenMai"] = DBNull.Value;
                    existingRows[0]["TienSauGiamGia"]= DBNull.Value;
                    textBox4.Text = "";
                }
                else
                {
                    MessageBox.Show("sản phẩm tạm thời hết hàng");
                }
               
            }
            else
            {
                if (soLuongSanPham > soLuongSPTrongDB)
                {
                    MessageBox.Show("sản phẩm tạm thời hết hàng ");
                }
                else
                {
                    DataRow newRow = gioHang.NewRow();
                    newRow["MaSP"] = maSP;
                    newRow["TenSP"] = tenSP;
                    newRow["GiaBan"] = giaBan;
                    newRow["SoLuong"] = soLuongSanPham;
                    newRow["Xoa"] = false;
                  
                    gioHang.Rows.Add(newRow);
                  
                }
            }
            foreach (DataRow row in gioHang.Rows)
            {
                tienSauKhuyenMai(row);
            }
            tongTien = 0;
            foreach (DataRow row in gioHang.Rows)
            {
                
                decimal gia = Convert.ToDecimal(row["GiaBan"]);
                int soLuong = Convert.ToInt32(row["SoLuong"]);

                row["ThanhTien"] = gia * soLuong;
             
                tongTien += gia * soLuong;
                label21.Text = "Tổng Tiền: " + tongTien.ToString("#,##0 VND");
                textBox8.Text = tongTien.ToString("#,##0 ");
            }
           
            TinhTongSoTienGiam();
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            themvaogio();
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            //textBox7.Text = "";
           

        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            soLuongSanPham = (int)numericUpDown1.Value;

            if(soLuongSanPham < 1)
            {
                MessageBox.Show("số lượng sản phẩm lớn hơn 0");
                soLuongSanPham = 1; 
                numericUpDown1.Value = soLuongSanPham; 
            }
           


        }
        // xóa giỏ hàng
        private void button4_Click(object sender, EventArgs e)
        {
            var rowsToDelete = gioHang.Select("Xoa = true");
            foreach (DataRow row in rowsToDelete)
            {
                gioHang.Rows.Remove(row);
            }
            // Tính lại tổng tiền
            tongTien = 0;
            foreach (DataRow row in gioHang.Rows)
            {
                decimal gia = Convert.ToDecimal(row["GiaBan"]);
                int soLuong = Convert.ToInt32(row["SoLuong"]);
                row["ThanhTien"] = gia * soLuong;
                tongTien += gia * soLuong;
            }

            // Hiển thị tổng tiền
            label21.Text = "Tổng Tiền: " + tongTien.ToString("#,##0 VND");
            foreach (DataRow row in gioHang.Rows)
            {
                row.SetField("Xoa", false);
            }
           
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        // tính tiền khuyến mãi 
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //tienSauKhuyenMai();
        }
       
        
       
        // datagridview4 bảng chi tiết hóa đơn
        private void HienThiChiTietHoaDon(int maHD)
        {
            dataGridView4.DataSource = chiTietHoaDonBUS.GetChiTietHoaDon(maHD);
        }
        private void HienThiHoaDon()
        {
            dataGridView5.DataSource = hoaDonBus.getDSHD();
        }
        private void dataGridView5_Click(object sender, EventArgs e)
        {
            if (dataGridView5.SelectedCells.Count > 0)
            {
                int selectedRow = dataGridView5.SelectedCells[0].RowIndex;
                DataGridViewRow row = dataGridView5.Rows[selectedRow];
                int maHoaDon = Convert.ToInt32(row.Cells[0].Value);
                HienThiChiTietHoaDon(maHoaDon);
            }
        }
        
        // hàm thanh toán
        private void thanhToan()
        {
            if (gioHang.Rows.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống. Vui lòng thêm sản phẩm vào giỏ hàng trước khi thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return; 
            }
          
            if (string.IsNullOrEmpty(comboBox2.Text))
            {
                MessageBox.Show("Vui lòng chọn mã khách hàng trước khi thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return; 
            }
            DangNhapGUI d = new DangNhapGUI();
            string maKhachHang = comboBox2.Text;
            if (decimal.TryParse(textBox8.Text, out decimal thanhTien))
            {
                if (decimal.TryParse(textBox4.Text, out decimal soTienGiam))
                {
                    DateTime ngayLap = DateTime.Now;
                    FormThanhToan thanhToan = new FormThanhToan();
                    thanhToan.SoTienGiam=soTienGiam;
                    thanhToan.tenNhanVien = d.TenNhanVien;
                    thanhToan.MaKhachHang = maKhachHang;
                    thanhToan.ThanhTien = thanhTien;
                    thanhToan.GioHang = gioHang;
                    thanhToan.ngayLap = ngayLap;
                    thanhToan.ShowDialog();
                    string maKhachHangHD = comboBox2.SelectedValue.ToString();
                    if (int.TryParse(maKhachHangHD, out int maKH))
                    {
                        HoaDonDTO hoaDon = new HoaDonDTO
                        {
                            maNV = d.MaNhanVien,
                            maKH = maKH,
                            ngayLap = ngayLap,
                            tongTien = (float)thanhTien
                        };

                        if (hoaDonBus.TaoHoaDon(hoaDon))
                        {
                            int maHoaDon = hoaDonBus.GetMaHoaDonMoiNhat();
                            if (maHoaDon != -1)
                            {
                                foreach (DataRow row in gioHang.Rows)
                                {
                                    string maSP = row["MaSP"].ToString();
                                    string tenSP = row["TenSP"].ToString();
                                  //  int maKM = (row["KhuyenMai"] != DBNull.Value) ? Convert.ToInt32(row["KhuyenMai"]) : -1;

                                    int soLuong = Convert.ToInt32(row["SoLuong"]);
                                    decimal giaBan = Convert.ToDecimal(row["GiaBan"]);

                                    if (!bus.CapNhatSoLuongSPTrongDB(maSP, soLuong))
                                    {
                                        MessageBox.Show("Có lỗi khi cập nhật số lượng sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }

                                    ChiTietHoaDonDTO chiTietHoaDon = new ChiTietHoaDonDTO
                                    {
                                        maHD = maHoaDon,
                                        maSP = maSP,
                                        giaBan = (float)giaBan,
                                        soLuong = soLuong,
                                        tongTien = (float)(soLuong * giaBan),
                                       // maKM = maKM,
                                    };

                                    if (!chiTietHoaDonBUS.ThemChiTietHoaDon(chiTietHoaDon))
                                    {
                                        MessageBox.Show("Có lỗi khi thêm chi tiết hóa đơn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Không thể lấy mã hóa đơn mới nhất.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Có lỗi khi tạo hóa đơn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập một số hợp lệ vào ô Số tiền giảm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập một số hợp lệ vào ô Thành tiền.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //decimal thanhTien = decimal.Parse(textBox8.Text);

            dataGridView1.DataSource = bus.getDSSP();
        }
        // tìm kiếm hóa đơn
        private void button6_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dateTimePicker1.Value;
            DateTime toDate = dateTimePicker2.Value;
            DataTable result = hoaDonBus.TimKiemHoaDonTheoKhoangNgay(fromDate, toDate);
            dataGridView5.DataSource = result;
        }
        // tải lại phần hóa đơn
        private void button7_Click(object sender, EventArgs e)
        {
            HienThiHoaDon();
            ResetDateTimePickers();
        }
        private void ResetDateTimePickers()
        {
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
        }
        private void dataGridView2_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            
            MessageBox.Show("Có lỗi xảy ra khi xử lý dữ liệu trong DataGridView.");
            e.Cancel = true; 
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
