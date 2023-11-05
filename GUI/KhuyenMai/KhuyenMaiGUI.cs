using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;
using System.Globalization;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class KhuyenMaiGUI : Form
    {
        ChiTietKhuyenMaiBUS ctkmBus = new ChiTietKhuyenMaiBUS();
        KhuyenMaiBUS kmBus = new KhuyenMaiBUS();
        ChiTietKhuyenMaiDTO ctkmDto;
        KhuyenMaiDTO kmDto;
        private bool isTextBox5Changing = false;
        private bool isTextBox6Changing = false;
        public KhuyenMaiGUI()
        {
            InitializeComponent();
        }


        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void KhuyenMaiGUI_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = this.kmBus.getKhuyenMai();
            dataGridView2.DataSource = this.ctkmBus.getChiTietKhuyenMai();
            comboBox2.DataSource = this.ctkmBus.getAllMaKhuyenMai();
            comboBox1.DataSource = this.ctkmBus.getAllMaSanPham();
            comboBox2.DisplayMember = "MaKM";
            comboBox1.DisplayMember = "MaSP";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            textBox1.Text = capNhatMa().ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox3.Text = dateTimePicker1.Value.ToString("dd/MM/yyyy");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            textBox4.Text = dateTimePicker2.Value.ToString("dd/MM/yyyy");
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            kmDto = new KhuyenMaiDTO();
            string tenKM = textBox2.Text;
            string ngayBD = textBox3.Text;
            string ngayKT = textBox4.Text;

            DateTime startDate, endDate;
            string dateFormat = "dd/MM/yyyy";
            DateTime.TryParseExact(ngayBD, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate);
            DateTime.TryParseExact(ngayKT, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out endDate);
            if (ValidateTenKhuyenMai(tenKM) && ValidateDates(startDate, endDate))
            {
                kmDto.maKhuyenMai = capNhatMa();
                kmDto.tenKhuyenMai = tenKM;
                kmDto.ngayBatDau = startDate;
                kmDto.ngayKetThuc = endDate;

                if (kmBus.themKhuyenMai(kmDto))
                {
                    // Thêm thành công, hiển thị thông báo
                    MessageBox.Show("Thêm thành công!");
                    dataGridView1.DataSource = this.kmBus.getKhuyenMai();
                    textBox1.Text = string.Empty;
                    textBox2.Text = string.Empty;
                    textBox3.Text = string.Empty;
                    textBox4.Text = string.Empty;
                }

            }
        }

        public int capNhatMa()
        {
            int maKM = 0;
            foreach (KhuyenMaiDTO nv in kmBus.getList())
            {
                if (nv.maKhuyenMai > maKM)
                {
                    maKM = nv.maKhuyenMai;
                }
            }
            maKM += 1;

            return maKM;
        }


        private bool ValidateTenKhuyenMai(string promoName)
        {
            // Kiểm tra nếu tên khuyến mãi không được rỗng
            if (string.IsNullOrWhiteSpace(promoName))
            {
                MessageBox.Show("Tên khuyến mãi không được để trống.");
                return false;
            }

            // Nếu tên khuyến mãi hợp lệ
            return true;
        }


        private bool ValidateDates(DateTime startDate, DateTime endDate)
        {
            // Kiểm tra nếu ngày bắt đầu và ngày kết thúc không được bỏ trống
            if (startDate == DateTime.MinValue || endDate == DateTime.MinValue)
            {
                MessageBox.Show("Ngày bắt đầu và ngày kết thúc không được để trống.");
                return false;
            }

            // Kiểm tra nếu ngày bắt đầu và ngày kết thúc không trùng nhau
            if (startDate == endDate)
            {
                MessageBox.Show("Ngày bắt đầu và ngày kết thúc không được trùng nhau.");
                return false;
            }

            // Kiểm tra nếu ngày bắt đầu nhỏ hơn ngày kết thúc
            if (startDate >= endDate)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc.");
                return false;
            }

            // Nếu tất cả điều kiện đều thỏa mãn
            return true;
        }



        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            kmDto = new KhuyenMaiDTO();
            string maKMStr = textBox1.Text;
            string tenKM = textBox2.Text;
            string ngayBD = textBox3.Text;
            string ngayKT = textBox4.Text;

            DateTime startDate, endDate;
            string dateFormat = "dd/MM/yyyy";
            DateTime.TryParseExact(ngayBD, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate);
            DateTime.TryParseExact(ngayKT, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out endDate);
            if (ValidateTenKhuyenMai(tenKM) && ValidateDates(startDate, endDate))
            {
                int maKM;

                if (int.TryParse(maKMStr, out maKM))
                kmDto.maKhuyenMai = maKM;
                kmDto.tenKhuyenMai = tenKM;
                kmDto.ngayBatDau = startDate;
                kmDto.ngayKetThuc = endDate;

                if (kmBus.suaKhuyenMai(kmDto))
                {
                    // Thêm thành công, hiển thị thông báo
                    MessageBox.Show("Sửa thành công!");
                    dataGridView1.DataSource = this.kmBus.getKhuyenMai();
                    textBox1.Text = string.Empty;
                    textBox2.Text = string.Empty;
                    textBox3.Text = string.Empty;
                    textBox4.Text = string.Empty;

                }

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string maKMStr = textBox1.Text;
            int maKM;
            if (int.TryParse(maKMStr, out maKM))
            if(kmBus.xoaKhuyenMai(maKM))
            {
                // Xóa thành công, hiển thị thông báo
                kmBus.xoaKhuyenMai(maKM);
                MessageBox.Show("Xóa thành công!");
                dataGridView1.DataSource = this.kmBus.getKhuyenMai();
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
                textBox4.Text = string.Empty;
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];

                // Lấy dữ liệu từ các cột trong hàng được chọn và hiển thị lên các TextBox
                comboBox2.Text = row.Cells["dataGridViewTextBoxColumn1"].Value.ToString();// Thay "Column1" bằng tên cột thích hợp
                comboBox1.Text = row.Cells["dataGridViewTextBoxColumn2"].Value.ToString();
                textBox5.Text = row.Cells["dataGridViewTextBoxColumn3"].Value.ToString();
                textBox6.Text = row.Cells["dataGridViewTextBoxColumn4"].Value.ToString();

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Lấy dữ liệu từ các cột trong hàng được chọn và hiển thị lên các TextBox
                textBox1.Text = row.Cells["Column1"].Value.ToString();// Thay "Column1" bằng tên cột thích hợp
                textBox2.Text = row.Cells["Column2"].Value.ToString();

                // Chuyển giá trị từ "Column3" thành đối tượng DateTime và định dạng thành "dd/MM/yyyy"
                if (DateTime.TryParse(row.Cells["Column3"].Value.ToString(), out DateTime dateValue3))
                {
                    textBox3.Text = dateValue3.ToString("dd/MM/yyyy");
                }
                else
                {
                    // Xử lý lỗi nếu giá trị không thể chuyển đổi thành DateTime
                    textBox3.Text = "Giá trị không hợp lệ";
                }

                // Chuyển giá trị từ "Column4" thành đối tượng DateTime và định dạng thành "dd/MM/yyyy"
                if (DateTime.TryParse(row.Cells["Column4"].Value.ToString(), out DateTime dateValue4))
                {
                    textBox4.Text = dateValue4.ToString("dd/MM/yyyy");
                }
                else
                {
                    // Xử lý lỗi nếu giá trị không thể chuyển đổi thành DateTime
                    textBox4.Text = "Giá trị không hợp lệ";
                }

                // Thêm các TextBox khác tương ứng với các cột trong DataGridView
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (!isTextBox6Changing) // Kiểm tra xem textBox6 có đang thay đổi không
            {
                isTextBox5Changing = true; // Đánh dấu rằng textBox5 đang thay đổi

                string maSP = comboBox1.Text;
                string discount = textBox5.Text;
                int discountValue = 0;

                if (!string.IsNullOrEmpty(discount) && !string.IsNullOrEmpty(maSP))
                {
                    if (int.TryParse(discount, out discountValue))
                    {
                        float value = ctkmBus.getGiaBanByID(maSP);
                        float result = value * ((discountValue / 100.0f));
                        textBox6.Text = result.ToString("0");
                    }
                }
                else
                {
                    textBox6.Text = string.Empty;
                }

                isTextBox5Changing = false; // Đánh dấu rằng textBox5 đã thay đổi xong
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (!isTextBox5Changing) // Kiểm tra xem textBox5 có đang thay đổi không
            {
                isTextBox6Changing = true; // Đánh dấu rằng textBox6 đang thay đổi
                if (!string.IsNullOrEmpty(textBox6.Text))
                {
                    textBox5.Text = "0";
                } else
                {
                    textBox5.Text = string.Empty;
                }

                isTextBox6Changing = false; // Đánh dấu rằng textBox6 đã thay đổi xong
            }
        }
        private bool ValidateDiscountUnit(string discountUnit)
        {
            if (string.IsNullOrWhiteSpace(discountUnit))
            {
                MessageBox.Show("Đơn vị giảm không được để trống.");
                return false;
            }

            if (!int.TryParse(discountUnit, out int discountValue))
            {
                MessageBox.Show("Đơn vị giảm không hợp lệ. Xin vui lòng nhập một số nguyên.");
                return false;
            }

            if (discountValue < 0 || discountValue > 100)
            {
                MessageBox.Show("Đơn vị giảm phải nằm trong khoảng từ 0 đến 100.");
                return false;
            }

            return true; // Đơn vị giảm hợp lệ
        }



        private bool ValidateDiscountValue(string discountValueStr)
        {
            if (decimal.TryParse(discountValueStr, out decimal discountValue))
            {
                if (discountValue < 0)
                {
                    MessageBox.Show("Giá trị giảm phải lớn hơn hoặc bằng 0.");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Giá trị giảm không hợp lệ. Xin vui lòng nhập một số.");
                return false;
            }

            return true; // Giá trị giảm hợp lệ
        }




        private void pictureBox6_Click(object sender, EventArgs e)
        {
            ctkmDto = new ChiTietKhuyenMaiDTO();
            string maKMStr = comboBox2.Text;
            string maSP = comboBox1.Text;
            string donViGiamStr = textBox5.Text;
            string giaTriGiamStr = textBox6.Text;
            int maKM = 0;
            int donViGiam = 0;
            int giaTriGiam = 0;
            if (ValidateDiscountUnit(donViGiamStr) && ValidateDiscountValue(giaTriGiamStr))
            {
                if (int.TryParse(maKMStr, out maKM) && int.TryParse(donViGiamStr, out donViGiam) && int.TryParse(giaTriGiamStr, out giaTriGiam))
                {
                    ctkmDto.maKhuyenMai = maKM;
                    ctkmDto.maSanPham = maSP;
                    ctkmDto.donViGiam = donViGiam;
                    ctkmDto.giaTriGiam = giaTriGiam;
                    if (ctkmBus.themChiTietKhuyenMai(ctkmDto))
                    {
                        // Thêm thành công, hiển thị thông báo
                        MessageBox.Show("Thêm thành công!");
                        dataGridView2.DataSource = this.ctkmBus.getChiTietKhuyenMai();
                        comboBox2.Text = string.Empty;
                        comboBox1.Text = string.Empty;
                        textBox5.Text = string.Empty;
                        textBox6.Text = string.Empty;


                    }else
                    {
                        MessageBox.Show("Thêm thất bại");
                    }
                }
            }


        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            ctkmDto = new ChiTietKhuyenMaiDTO();
            string maKMStr = comboBox2.Text;
            string maSP = comboBox1.Text;
            string donViGiamStr = textBox5.Text;
            string giaTriGiamStr = textBox6.Text;
            int maKM = 0;
            int donViGiam = 0;
            int giaTriGiam = 0;
            if (ValidateDiscountUnit(donViGiamStr) && ValidateDiscountValue(giaTriGiamStr))
            {
                if (int.TryParse(maKMStr, out maKM) && int.TryParse(donViGiamStr, out donViGiam) && int.TryParse(giaTriGiamStr, out giaTriGiam))
                {
                    ctkmDto.maKhuyenMai = maKM;
                    ctkmDto.maSanPham = maSP;
                    ctkmDto.donViGiam = donViGiam;
                    ctkmDto.giaTriGiam = giaTriGiam;
                    if (ctkmBus.suaChiTietKhuyenMai(ctkmDto))
                    {
                        // Thêm thành công, hiển thị thông báo
                        MessageBox.Show("Sửa thành công!");
                        dataGridView2.DataSource = this.ctkmBus.getChiTietKhuyenMai();
                        comboBox2.Text = string.Empty;
                        comboBox1.Text = string.Empty;
                        textBox5.Text = string.Empty;
                        textBox6.Text = string.Empty;
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại");
                    }
                }
            }
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            string maKMStr = comboBox2.Text;
            int maKM;
            if (int.TryParse(maKMStr, out maKM))
                if (ctkmBus.xoaChiTietKhuyenMai(maKM))
                {
                    // Xóa thành công, hiển thị thông báo
                    ctkmBus.xoaChiTietKhuyenMai(maKM);
                    MessageBox.Show("Xóa thành công!");
                    dataGridView2.DataSource = this.ctkmBus.getChiTietKhuyenMai();
                    comboBox2.Text = string.Empty;
                    comboBox1.Text = string.Empty;
                    textBox5.Text = string.Empty;
                    textBox6.Text = string.Empty;
                }
        }
    }
}
