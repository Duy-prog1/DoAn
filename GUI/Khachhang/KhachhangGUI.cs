using BUS;
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
    public partial class KhachhangGUI : Form
    {
        KhachHangBUS khBus = new KhachHangBUS();
        public KhachhangGUI()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string key = textBox1.Text;

            dataGridView1.DataSource = khBus.getFindKhachHang(key);
        }

        private void KhachhangGUI_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = this.khBus.getKhachHang();
        }
    }
}
