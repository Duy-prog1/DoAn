using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace BUS
{
    public class ThongKeBUS
    {
        ThongKeDAL thongKeDAL=new ThongKeDAL();
        public List<String> getDSLoaiSP()
        {
            return thongKeDAL.getDSLoaiSP();
        }

        public void getPointAllTK(List<String> listSP,String thoiGian,DateTime batDau, DateTime ketThuc,List<Series> series1, List<Series> series2)
        {
            thongKeDAL.getPointAllTK(listSP, thoiGian, batDau, ketThuc,series1,series2);
        }
        public String getTongThu(DateTime batDau, DateTime ketThuc)
        {
            return thongKeDAL.getTongThu(batDau, ketThuc);
        }
        public String getTongChi(string tongThu, DateTime batDau, DateTime ketThuc)
        {
            return thongKeDAL.getTongChi(tongThu, batDau, ketThuc);
        }
        public String getLoiNhuan(List<String> listSP, String thoiGian, DateTime batDau, DateTime ketThuc)
        {
            return thongKeDAL.getLoiNhuan(listSP, thoiGian, batDau, ketThuc);
        }

    }
}
