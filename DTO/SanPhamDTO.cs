using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SanPhamDTO
    {
        public string maSanPham { get; set; }
        public string tenSanPham { get; set; }
        public float giaBan { get; set; }
        public int soLuong { get; set; }
        public byte[] img { get; set; }
        public int thoiGianBaoHanh { get; set; }
        public bool tinhTrang { get; set; }
        public int maLoai { get; set; }
        public SanPhamDTO() { }
        public SanPhamDTO(string maSanPham, string tenSanPham, float giaBan, int soLuong, byte[] img, int thoiGianBaoHanh, bool tinhTrang, int maLoai)
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
