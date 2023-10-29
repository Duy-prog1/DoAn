using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVienDTO
    {
        public string maNv { get; set; }
        public string tenNv { get; set; }
        public bool gioiTinhNv { get; set; }    
        public string sdtNv { get; set; }
        public string chucVu { get; set; }
       // public string diaChiNv { get; set; }
        public string ngaySinhNv { get; set; }
        public bool trangThai { get; set; }

        public NhanVienDTO() { }
        public NhanVienDTO(string maNv, string tenNv, bool gioiTinhNv, string sdtNv, string chucVu, string ngaySinhNv, bool trangThai)
        {
            this.maNv = maNv;
            this.tenNv = tenNv;
            this.gioiTinhNv = gioiTinhNv;
            this.sdtNv = sdtNv;
            this.chucVu = chucVu;
            this.ngaySinhNv = ngaySinhNv;
            this.trangThai = trangThai;
        }
    }
}
