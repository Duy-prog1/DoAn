using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ChiTietHoaDonBUS
    {
        ChiTietHoaDonDAL chiTietHoaDonDAL =new ChiTietHoaDonDAL();
        public DataTable getDSCTHD()
        {
            return chiTietHoaDonDAL.getDSCTHD();
        }
        public DataTable GetChiTietHoaDon(int maHD)
        {
            return chiTietHoaDonDAL.GetChiTietHoaDon(maHD);
        }
        public bool ThemChiTietHoaDon(ChiTietHoaDonDTO chiTietHoaDon)
        {
            return chiTietHoaDonDAL.ThemChiTietHoaDon(chiTietHoaDon);
        }
    }
}
