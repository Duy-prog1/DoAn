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
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp1
{
    public partial class ThongKeGUI : Form
    {
        ThongKeBUS thongKeBUS = new ThongKeBUS();
        public ThongKeGUI()
        {
            InitializeComponent();
        }

        private void buttonThongKe_Click(object sender, EventArgs e)
        {
            //kiem tra da chon cac truong chưa
            if(comboDSSP.Items.Count==1 || comboThoiGian.SelectedIndex == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để thống kê và thời gian thống kê");
                return;
            }

            //loaiBo default
            int numOfSeries = chart1.Series.Count;
            for (int i= 0;i < numOfSeries;i++)
            {
                chart1.Series.RemoveAt(0);
            }
            for (int i= 0; i < numOfSeries; i++)
            {
                chart2.Series.RemoveAt(0);
            }
            /*
             cần có trong thống kê:
                points
                Series SP
                Thời gian
             */

            //lay ds loai SP
            //List<String> danhSachLoaiSP = thongKeBUS.getDSLoaiSP();

            //lay listSP
            List<String> listSP = new List<String>();
            for (int i = 1; i < comboDSSP.Items.Count; i++)
            {
                listSP.Add(comboDSSP.Items[i].ToString());
            }
            //sort lai list SP
            listSP.Sort();
            for(int i = 0; i < listSP.Count; i++)
            {
                Console.WriteLine(listSP[i]);
            }
            Console.WriteLine("guiok");

            //lay thoiGian
            String thoiGian = comboThoiGian.SelectedItem.ToString().Substring(5); //theo tuan,thang,quy
            //lay begin va end
            DateTime batDau = dateTimePicker1.Value.Date;
            DateTime ketThuc = dateTimePicker2.Value.Date;

            //get Series thống kê doanh thu
            List<Series> series1 = new List<Series>();
            List<Series> series2 = new List<Series>();

            for (int i = 0; i < listSP.Count; i++)
            {
                //series1
                series1.Insert(i, new Series());
                series1[i].ChartArea = "ChartArea1";
                series1[i].ChartType = SeriesChartType.Column;
                series1[i].Legend = "Legend1";
                series1[i].Name = listSP[i] + "(" + (i+1).ToString() + ")";
                //series2
                series2.Insert(i, new Series());
                series2[i].ChartArea = "ChartArea1";
                series2[i].ChartType = SeriesChartType.Line;
                series2[i].Legend = "Legend1";
                series2[i].Name = listSP[i] + "(" + (i + 1).ToString() + ")";
            }

            //add point trước khi thêm vào chart
            thongKeBUS.getPointAllTK(listSP, thoiGian, batDau, ketThuc, series1, series2);

            for (int i = 0; i < listSP.Count; i++)
            {
                //them vao chart1
                chart1.Series.Add(series1[i]);

                //them vao chart2
                chart2.Series.Add(series2[i]);
            }


            String tongThu = thongKeBUS.getTongThu(listSP, thoiGian, batDau, ketThuc);
            String tongChi = thongKeBUS.getTongChi(listSP, thoiGian, batDau, ketThuc);
            String loiNhuan=thongKeBUS.getLoiNhuan(listSP, thoiGian, batDau, ketThuc);
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
            int tempCount = comboSP.Items.Count;
            for(int i=0;i<tempCount;i++)
            {
                comboSP.Items.RemoveAt(0);
            }

            comboSP.Items.Add("Sản phẩm");
            List<String> tempList = thongKeBUS.getDSLoaiSP();
            for(int i=0;i< tempList.Count;i++)
            {
                comboSP.Items.Add(tempList[i]);
            }
            comboSP.Items.Add("Toàn bộ SP");


            //select default combobox
            comboSP.SelectedIndex = 0;
            comboDSSP.SelectedIndex = 0;
            comboThoiGian.SelectedIndex = 0;
        }


    }
}
