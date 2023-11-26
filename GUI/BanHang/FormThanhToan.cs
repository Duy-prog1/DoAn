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
    {

        public string MaKhachHang { get; set; }
        public string MaGiamGia { get; set; }
        public string tenKM {  get; set; }
        public string tenNhanVien { get; set; }
        public decimal SoTienGiam { get; set; }
        public decimal ThanhTien { get; set; }
        public DateTime ngayLap { get; set; }
        public DataTable GioHang { get; set; }
        public decimal TongTien { get; set; }
        public FormThanhToan()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
       
            float dpiX = this.CreateGraphics().DpiX;
            float dpiY = this.CreateGraphics().DpiY;

            float widthInPixels = 8.27f * dpiX / 25.4f;
            float heightInPixels = 11.69f * dpiY / 25.4f;

            this.Width = (int)Math.Round(widthInPixels);
            this.Height = (int)Math.Round(heightInPixels);
            this.Width = Screen.PrimaryScreen.Bounds.Width / 2;  // Chia đôi kích thước màn hình
            this.Height = Screen.PrimaryScreen.Bounds.Height / 2;

        }
        private void richTextBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }
       
        int CalculateColumnWidth(string header, IEnumerable<string> values)
        {
            int maxWidth = header.Length;
            foreach (var value in values)
            {
                int valueLength = value.Length;
                if (valueLength > maxWidth)
                {
                    maxWidth = valueLength;
                }
            }
            return maxWidth;
        }
        private void FormThanhToan_Load(object sender, EventArgs e)
        {
            XuLyHienThiHoaDon();
        }


        private void XuLyHienThiHoaDon()
        {
            DateTime now = DateTime.Now;
            // Bắt đầu xây dựng chuỗi HTML cho hóa đơn
            string hd = "<html><head><style>"
                + "table { border: 1px solid; border-bottom: none; }"
                + "tr { border-bottom: 1px solid; }"
                + "td { padding: 20px; }"
                + "th { font-size: 16pt; }"
                + "</style></head><body>";
            hd += "<h1 style='text-align:center;'>HOÁ ĐƠN THANH TOÁN</h1>";
            hd += "Nhân viên: " + tenNhanVien + "<br/>";
            hd += "Ngày lập: " + ngayLap + "<br/>";
            hd += "Khách hàng: " +MaKhachHang + "<br/>";
            hd += "<div style='text-align:center;'>==========================================</div><br/>";
            hd += "<div style='text-align:center'>";
            hd += "<table style='max-width:100%'>";
            hd += "<tr>"
                  + "<th>Mã SP</th>"
                  + "<th>Tên SP</th>"
                  + "<th>Số lượng</th>"
                  + "<th>Đơn giá</th>"
                  + "<th>Thành tiền</th>"
                   + "<th>Mã Giảm Giá</th>"
                  + "</tr>";

            // Thêm dòng cho từng sản phẩm trong giỏ hàng
            //DataRow item in GioHang.Rows
            foreach (DataRow vec in GioHang.Rows)
            {
                hd += "<tr>";
                hd += $"<td style='text-align:center;'>{vec[1]}</td>";
                hd += $"<td style='text-align:left;'>{vec[2]}</td>";
                hd += $"<td style='text-align:center;'>{vec[3]}</td>";
                hd += $"<td style='text-align:center;'>{vec[4]}</td>";
                hd += $"<td style='text-align:center;'>{vec[5]}</td>";
                hd += $"<td style='text-align:center;'>{vec[6]}</td>";
                hd += "</tr>";
            }
            hd += "<tr>";
            hd += "<td style='text-align:center;'></td>";
            hd += "<td style='text-align:left;'></td>";
            hd += "<td style='text-align:center;'></td>";
            hd += "<td style='text-align:center;font-weight:bold'>Tổng cộng</td>";
            hd += $"<td style='text-align:center;'>{TongTien}</td>";
            hd += "</tr>";

            hd += "<tr>";
            hd += "<td style='text-align:center;'></td>";
            hd += "<td style='text-align:left;'></td>";
            hd += "<td style='text-align:center;'></td>";
            hd += "<td style='text-align:center;font-weight:bold'>Số Tiền Giảm</td>";
            hd += $"<td style='text-align:center;'>-{SoTienGiam}</td>";
            hd += "</tr>";

            hd += "<tr>";
            hd += "<td style='text-align:center;'></td>";
            hd += "<td style='text-align:left;'></td>";
            hd += "<td style='text-align:center;'></td>";
            hd += "<td style='text-align:center;font-weight:bold'>Thành tiền</td>";
            hd += $"<td style='text-align:center;'>{ThanhTien}</td>";
            hd += "</tr>";

            hd += "</table>";
            hd += "</div>";
            hd += "<div style='text-align:center;'>==========================================</div><br/>";
            hd += "</body></html>";
            webBrowser1.DocumentText = hd;
        }

        // In hóa đơn
       /* private void button1_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }*/
       /* private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
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
        }*/
    }




}