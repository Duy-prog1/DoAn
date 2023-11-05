using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhuyenMaiDTO
    {
        public int maKhuyenMai {  get; set; }
        public string tenKhuyenMai { get; set; }
        public DateTime ngayBatDau { get; set; }
        public DateTime ngayKetThuc {  get; set; }

        public KhuyenMaiDTO() { }
        public KhuyenMaiDTO(int maKhuyenMai, string tenKhuyenMai, DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            this.maKhuyenMai = maKhuyenMai;
            this.tenKhuyenMai = tenKhuyenMai;
            this.ngayBatDau = ngayBatDau;
            this.ngayKetThuc = ngayKetThuc;
        }
    }
}
