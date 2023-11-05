using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietKhuyenMaiDTO
    {
        public int maKhuyenMai {  get; set; }
        public string maSanPham {  get; set; }
        public int donViGiam { get; set; }
        public int giaTriGiam {  get; set; }
        public ChiTietKhuyenMaiDTO() { }
        public ChiTietKhuyenMaiDTO(int maKhuyenMai, string maSanPham, int donViGiam, int giaTriGiam)
        {
            this.maKhuyenMai = maKhuyenMai;
            this.maSanPham = maSanPham;
            this.donViGiam = donViGiam;
            this.giaTriGiam = giaTriGiam;
        }
    }
}
