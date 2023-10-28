using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    internal class PhanQuyenDTO
    {
        private int maQuyen { get; set; }
        private int quanLyNhanVien { get; set; }
        private int quanLySanPham { get; set; }
        private int quanLyKhachHang { get; set; }
        private int quanLyNhanHang { get; set; }
        private int thongKe { get; set; }
        PhanQuyenDTO() { }
        PhanQuyenDTO(int maQuyen, int quanLyNhanVien, int quanLySanPham, int quanLyKhachHang, int quanLyNhanHang, int thongKe)
        {
            this.maQuyen = maQuyen;
            this.quanLyNhanVien = quanLyNhanVien;
            this.quanLySanPham = quanLySanPham;
            this.quanLyKhachHang = quanLyKhachHang;
            this.quanLyNhanHang = quanLyNhanHang;
            this.thongKe = thongKe;
        }
    }
}
