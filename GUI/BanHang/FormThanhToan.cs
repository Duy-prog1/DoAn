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
    public partial class FormThanhToan : Form
    {


        public string MaKhachHang { get; set; }
        public string MaGiamGia { get; set; }
        public string tenNhanVien {  get; set; }
        public decimal SoTienGiam { get; set; }
        public decimal ThanhTien { get; set; }
        public DataTable GioHang { get; set; }

        public FormThanhToan()
        {

            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            richTextBox1.AllowDrop = true;
            richTextBox1.DragEnter += richTextBox1_DragEnter;
            richTextBox1.DragDrop += richTextBox1_DragDrop;

        }
        private void richTextBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        // Event handler for handling the dropped data
        private void richTextBox1_DragDrop(object sender, DragEventArgs e)
        {
            string droppedText = e.Data.GetData(DataFormats.Text).ToString();
            richTextBox1.AppendText(droppedText);
        }
        private void FormThanhToan_Load(object sender, EventArgs e)
        {
            string invoiceText = "Tên nhân viên: "+tenNhanVien;
            invoiceText += "Ngày lập: ";
            invoiceText += "Mã khách hàng: " + MaKhachHang + "\n";
            invoiceText += "Mã giảm giá: " + MaGiamGia + "\n";
            invoiceText += "Số tiền giảm: " + SoTienGiam.ToString("C") + "\n\n";

            // Add a table header
            invoiceText += "Mã SP\tTên SP\tĐơn giá\tSố lượng\tThành tiền\n";
            invoiceText += "-----------------------------------------------------------\n";

            // Iterate through the shopping cart and add item details to the invoice
            foreach (DataRow item in GioHang.Rows)
            {
                string maSP = item["MaSP"].ToString();
                string tenSP = item["TenSP"].ToString();
                decimal giaBan = (decimal)item["GiaBan"];
                int soLuong = (int)item["SoLuong"];
                decimal thanhTienItem = (decimal)item["ThanhTien"];

                // Add item details to the invoice text
                invoiceText += $"{maSP}\t{tenSP}\t{giaBan:C}\t{soLuong}\t{thanhTienItem:C}\n";
            }

            // Add a line for the total cost
            invoiceText += "-----------------------------------------------------------\n";
            invoiceText += "Tổng cộng: " + ThanhTien.ToString("C") + "\n";

            // Display the invoice in the RichTextBox
            richTextBox1.Text = invoiceText;


        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }




}
