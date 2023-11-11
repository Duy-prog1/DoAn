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
    public class HoaDonBUS
    {
        HoaDonDTO dTO = new HoaDonDTO();
        HoaDonDAL dAL = new HoaDonDAL();
        public DataTable getDSHD()
        {
            return dAL.getDSHD();
        }
        public bool TaoHoaDon(HoaDonDTO hoaDon)
        {
            bool taoHoaDonThanhCong = dAL.TaoHoaDon(hoaDon);
            if (taoHoaDonThanhCong)
            {     
                int maHoaDonMoiNhat = dAL.GetMaHoaDonMoiNhat();
                return true;
            }
            else
            {
                return false;
            }
        }
        // get hóa đơn mới nhất
        public int GetMaHoaDonMoiNhat()
        {
            return dAL.GetMaHoaDonMoiNhat();
        }
        // tìm kiếm hóa đơn theo khoảng ngày
        public DataTable TimKiemHoaDonTheoKhoangNgay(DateTime fromDate, DateTime toDate)
        {
            return dAL.TimKiemHoaDonTheoKhoangNgay(fromDate, toDate);
        }
    }
}
