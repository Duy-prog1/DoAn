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
    public partial class MenuGUI : Form
    {
        private List<PictureBox> pictureBoxes = new List<PictureBox>();
        public MenuGUI()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void MenuGUI_Load(object sender, EventArgs e)
        {
            // Thêm tất cả các PictureBox vào danh sách và gán sự kiện Click
            pictureBoxes.Add(pictureBox1);
            pictureBoxes.Add(pictureBox2);
            pictureBoxes.Add(pictureBox3);
            pictureBoxes.Add(pictureBox4);
            pictureBoxes.Add(pictureBox5);
            pictureBoxes.Add(pictureBox6);
            pictureBoxes.Add(pictureBox7);
            pictureBoxes.Add(pictureBox8);

            foreach (PictureBox pictureBox in pictureBoxes)
            {
                pictureBox.Click += PictureBox_Click;
            }
          
            //ShowChildForm(childFormToShow, tableLayoutPanel5);
        }
        private void ShowChildForm(Form childForm, Control container)
        {
            if (container.Controls.Count > 0)
            {
                container.Controls[0].Dispose(); // Loại bỏ form con hiện tại (nếu có)
            }

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            container.Controls.Add(childForm);
            container.Tag = childForm; // Lưu trữ form con cho việc loại bỏ sau này
            childForm.Show();
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox clickedPictureBox = sender as PictureBox;

            // Đặt lại màu cho tất cả các PictureBox
            foreach (PictureBox pictureBox in pictureBoxes)
            {
                pictureBox.BackColor = Color.DodgerBlue; // Đổi màu về màu ban đầu
            }

            // Đặt màu cho PictureBox được bấm
            clickedPictureBox.BackColor = Color.OrangeRed; // Đổi màu

            // Hiển thị form con tương ứng
            Form childFormToShow = null;
            //Home
            if (clickedPictureBox == pictureBox1) 
            {
                childFormToShow = new BanHangGUI();

            }
            //Ban Hang
            else if (clickedPictureBox == pictureBox2)
            {
              
            }
            //San Pham
            else if (clickedPictureBox == pictureBox3)
            {
               
            }
            //Nhan Vien
            else if (clickedPictureBox == pictureBox4)
            {
                childFormToShow = new NhanVienGUI();
            }
            //khach hang
            else if (clickedPictureBox == pictureBox5)
            {
                
            }
            //khuyen mai
            else if (clickedPictureBox == pictureBox6)
            {
                
            }
            //nhap hang
            else if (clickedPictureBox == pictureBox7)
            {
                
            }
            //thong ke
            else if (clickedPictureBox == pictureBox8)
            {
                childFormToShow = new ThongKeGUI();
            }
          

            childFormToShow.Dock = DockStyle.Fill;
            // Thêm các else if tương ứng cho các PictureBox khác

            if (childFormToShow != null)
            {
                ShowChildForm(childFormToShow, tableLayoutPanel5);
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
