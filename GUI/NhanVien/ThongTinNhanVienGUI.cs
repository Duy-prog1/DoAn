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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ThongTinNhanVienGUI : Form
    {
        NhanVienDTO nvDto;
        NhanVienBUS nvBus = new NhanVienBUS();
       
        public ThongTinNhanVienGUI(NhanVienDTO nvDto)
        {
            InitializeComponent();
            this.nvDto = nvDto;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nvDto.maNv = capNhatId();
            nvDto.tenNv = tbTenNv.Text;
           // nvDto.gioiTinhNv = bool.Parse()


        }

        public string capNhatId()
        {
            String maNv = "";
            int soMaNv = 0;
            foreach (NhanVienDTO nv in nvBus.getList())
            {
                string temp = nv.maNv.ToString().Substring(2);
                int max = int.Parse(maNv);
                if(max < soMaNv)
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
    }
}
