using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
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

        public List<DataPoint> getPointTKSoLuong(List<String> listSP,String thoiGian,DateTime batDau, DateTime ketThuc)
        {
            return thongKeDAL.getPointTKSoLuong(listSP, thoiGian, batDau, ketThuc);
        }
        public List<DataPoint> getPointTKDoanhThu(List<String> listSP, String thoiGian, DateTime batDau, DateTime ketThuc)
        {
            return thongKeDAL.getPointTKDoanhThu(listSP, thoiGian, batDau, ketThuc);
        }
        public String getTongThu(List<String> listSP, String thoiGian, DateTime batDau, DateTime ketThuc)
        {
            return thongKeDAL.getTongThu(listSP, thoiGian, batDau, ketThuc);
        }
        public String getTongChi(List<String> listSP, String thoiGian, DateTime batDau, DateTime ketThuc)
        {
            return thongKeDAL.getTongChi(listSP, thoiGian, batDau, ketThuc);
        }
        public String getLoiNhuan(List<String> listSP, String thoiGian, DateTime batDau, DateTime ketThuc)
        {
            return thongKeDAL.getLoiNhuan(listSP, thoiGian, batDau, ketThuc);
        }

    }
}
