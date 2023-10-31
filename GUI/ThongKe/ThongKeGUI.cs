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
    public partial class ThongKeGUI : Form
    {
        public ThongKeGUI()
        {
            InitializeComponent();
        }

        private void buttonThongKe_Click(object sender, EventArgs e)
        {

        }

        private void comboSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexSelected=comboSP.SelectedIndex;
            if(indexSelected != 0)
            {
                if(indexSelected == comboSP.Items.Count - 1)
                {
                    for(int i = comboSP.Items.Count-2; i > 0; i--) //0 -> n-1;
                    {
                        //lay index khac 0
                        String temp = comboSP.Items[i].ToString();
                        //move value to danh sach sp
                        comboSP.Items.RemoveAt(i);
                        comboDSSP.Items.Add(temp);
                        Console.WriteLine(comboSP.Items.Count - 1);
                    }
                }
                else
                {
                    //lay index khac 0
                    String temp = comboSP.SelectedItem.ToString();
                    //move value to danh sach sp
                    comboSP.Items.RemoveAt(indexSelected);
                    comboDSSP.Items.Add(temp);
                }
                comboSP.SelectedIndex = 0;
            }
        }

        private void comboDSSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexSelected = comboDSSP.SelectedIndex;
            if (indexSelected != 0)
            {
                //lay index khac 0
                String temp = comboDSSP.SelectedItem.ToString();
                //remove value in dssp
                comboDSSP.Items.RemoveAt(indexSelected);
                //lay toanBoSP ra
                comboSP.Items.RemoveAt(comboSP.Items.Count - 1);
                //them lai SP
                comboSP.Items.Add(temp);
                //them lai toanBoSP
                comboSP.Items.Add("Toàn bộ SP");
                //set select 0
                comboDSSP.SelectedIndex = 0;
            }
        }

        private void ThongKeGUI_Load(object sender, EventArgs e)
        {
            //select default combobox
            comboSP.SelectedIndex = 0;
            comboDSSP.SelectedIndex = 0;
            comboThoiGian.SelectedIndex = 0;
        }
    }
}
