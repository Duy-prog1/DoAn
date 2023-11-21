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
    public class SanPhamBUS
    {
        SanPhamDAL dalSanPham = new SanPhamDAL();
        public DataTable getSanPham()
        {
            return dalSanPham.getSanPham();
        }

        public bool themSanPham(SanPhamDTO sp)
        {
            return dalSanPham.themSanPham(sp);
        }

        public bool suaSanPham(SanPhamDTO sp)
        {
            return dalSanPham.suaSanPham(sp);
        }

        public bool xoaSanPham(string maSP)
        {
            return dalSanPham.xoaSanPham(maSP);
        }

        public DataTable timSanPham(string text)
        {
            return dalSanPham.timSanPham(text);
        }
    }
}
