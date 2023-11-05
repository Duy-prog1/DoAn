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
    public class ChiTietKhuyenMaiBUS
    {
        ChiTietKhuyenMaiDAL chiTietKhuyenMaiDal = new ChiTietKhuyenMaiDAL();
        public DataTable getChiTietKhuyenMai()
        {
            return chiTietKhuyenMaiDal.getChiTietKhuyenMai();
        }

        public DataTable getAllMaKhuyenMai()
        {
            return chiTietKhuyenMaiDal.getAllMaKhuyenMai();
        }
        public DataTable getAllMaSanPham()
        {
            return chiTietKhuyenMaiDal.getAllMaSanPham();
        }
        public float getGiaBanByID(string maSP)
        {
            return chiTietKhuyenMaiDal.getGiaBanByID(maSP);
        }
        public bool themChiTietKhuyenMai(ChiTietKhuyenMaiDTO ctkm)
        {
            return chiTietKhuyenMaiDal.ThemChiTietKhuyenMai(ctkm);
        }
        public bool suaChiTietKhuyenMai(ChiTietKhuyenMaiDTO ctkm)
        {
            return chiTietKhuyenMaiDal.SuaChiTietKhuyenMai(ctkm);
        }
        public bool xoaChiTietKhuyenMai(int maKM)
        {
            return chiTietKhuyenMaiDal.XoaChiTietKhuyenMai(maKM);
        }
    }
}
