using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;

namespace BUS
{
    public class KhuyenMaiBUS
    {
        KhuyenMaiDAL khuyenMaiDal = new KhuyenMaiDAL();
        public List<KhuyenMaiDTO> getList()
        {
            return khuyenMaiDal.getList();
        }
        public DataTable getKhuyenMai()
        {
            return khuyenMaiDal.getKhuyenMai();
        }
        public bool themKhuyenMai(KhuyenMaiDTO km)
        {
            return khuyenMaiDal.ThemKhuyenMai(km);
        }

        public bool suaKhuyenMai(KhuyenMaiDTO km)
        {
            return khuyenMaiDal.SuaKhuyenMai(km);
        }

        public bool xoaKhuyenMai(int maKM)
        {
            return khuyenMaiDal.XoaKhuyenMai(maKM);
        }

    }
}
