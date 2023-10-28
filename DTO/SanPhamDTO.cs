using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    internal class SanPhamDTO
    {
        private string maSanPham { get; set; }
        private string tenSanPham { get; set; }
        private float giaBan { get; set; }
        private int soLuong { get; set; }
        private string img { get; set; }
        private int thoiGianBaoHanh { get; set; }
        private int tinhTrang { get; set; }
        private int maLoai { get; set; }
        public SanPhamDTO() { }
        public SanPhamDTO(string maSanPham, string tenSanPham, float giaBan, int soLuong, string img, int thoiGianBaoHanh, int tinhTrang, int maLoai)
        {
            this.maSanPham = maSanPham;
            this.tenSanPham = tenSanPham;
            this.giaBan = giaBan;
            this.soLuong = soLuong;
            this.img = img;
            this.thoiGianBaoHanh = thoiGianBaoHanh;
            this.tinhTrang = tinhTrang;
            this.maLoai = maLoai;
        }
    }
}
