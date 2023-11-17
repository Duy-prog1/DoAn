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
    public class LoaiSanPhamBUS
    {
        LoaiSanPhamDAL dalLoaiSanPham = new LoaiSanPhamDAL();
        public DataTable getAllLoaiSanPham()
        {
            return dalLoaiSanPham.getAllLoaiSanPham();
        }

        public DataTable getLoaiSanPham()
        {
            return dalLoaiSanPham.getLoaiSanPham();
        }

        public bool themLoaiSanPham(LoaiSanPhamDTO lsp)
        {
            return dalLoaiSanPham.themLoaiSanPham(lsp);
        }

        public bool suaLoaiSanPham(LoaiSanPhamDTO lsp)
        {
            return dalLoaiSanPham.suaLoaiSanPham(lsp);
        }

        public bool xoaLoaiSanPham(int maLoai)
        {
            return dalLoaiSanPham.xoaLoaiSanPham(maLoai);
        }

        public DataTable timLoaiSanPham(string text)
        {
            return dalLoaiSanPham.timLoaiSanPham(text);
        }
    }
}
