using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormThanhToan : Form
    {   public string MaKhachHang { get; set; }
        public string MaGiamGia { get; set; }
        public string tenNhanVien {  get; set; }
        public decimal SoTienGiam { get; set; }
        public decimal ThanhTien { get; set; }
        public DateTime ngayLap { get; set; }
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
        private void richTextBox1_DragDrop(object sender, DragEventArgs e)
        {
            string droppedText = e.Data.GetData(DataFormats.Text).ToString();
            richTextBox1.AppendText(droppedText);
        }
        private void FormThanhToan_Load(object sender, EventArgs e)
        {
            string invoiceText = "Tên nhân viên: "+tenNhanVien+"\n";
            invoiceText += "Ngày lập: "+ngayLap+"\n";
            invoiceText += "Mã khách hàng: " + MaKhachHang + "\n"; 
            invoiceText += "Số tiền giảm: " + SoTienGiam.ToString("C") + "\n\n";
            invoiceText += "Mã SP\tTên SP\tĐơn giá\tSố lượng\tThành tiền\n";
            invoiceText += "-----------------------------------------------------------\n";
            foreach (DataRow item in GioHang.Rows)
            {
                string maSP = item["MaSP"].ToString();
                string tenSP = item["TenSP"].ToString();
                decimal giaBan = (decimal)item["GiaBan"];
                int soLuong = (int)item["SoLuong"];
                decimal thanhTienItem = (decimal)item["ThanhTien"];
                invoiceText += $"{maSP}\t{tenSP}\t{giaBan:C}\t{soLuong}\t{thanhTienItem:C}\n";
            }
            invoiceText += "-----------------------------------------------------------\n";
            invoiceText += "Tổng cộng: " + ThanhTien.ToString("C") + "\n";
            richTextBox1.Text = invoiceText;
        }
        // In hóa đơn
        private void button1_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            StringReader reader = new StringReader(richTextBox1.Text);
            float yPos = 0f;
            int count = 0;
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;
            string line = null;
            while (count < e.MarginBounds.Height / 12 && ((line = reader.ReadLine()) != null))
            {
                yPos = topMargin + count * 12;
                e.Graphics.DrawString(line, new Font("Arial", 10), Brushes.Black, leftMargin, yPos, new StringFormat());
                count++;
            }
            if (line != null)
                e.HasMorePages = true;
            else
                e.HasMorePages = false;
            reader.Close();
        }
    }




}
