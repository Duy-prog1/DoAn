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
    public class NhanVienBUS
    {
        NhanVienDAL dalNhanVien = new NhanVienDAL();

        public List<NhanVienDTO> getList()
        {
            return dalNhanVien.getList();
        }
        public DataTable getNhanVien()
        {
            return dalNhanVien.getNhanVien();
        }

        public DataTable getFindThanhVien(string key)
        {
            return dalNhanVien.getFindThanhVien(key);
        }

        public bool themNhanVien(NhanVienDTO tv)
        {
            return dalNhanVien.themNhanVien(tv);
        }

        public bool suaNhanVien(NhanVienDTO tv)
        {
            return dalNhanVien.suaNhanVien(tv);
        }
        public bool xoaNhanVien(string maNV)
        {
            return dalNhanVien.xoaNhanVien(maNV);
        }

        public int ThemDS()
        {
            return dalNhanVien.ThemDS();
        }

    }
}
