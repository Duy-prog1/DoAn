using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TaiKhoanDTO
    {
        public string maNhanVien { get; set; }
        public int maQuyen { get; set; }
        public string tenDangNhap { get; set; }
        public string matKhau { get; set; }
        public int tinhTrang { get; set; }
        public string email { get; set; }
        public TaiKhoanDTO() { }
        public TaiKhoanDTO(string tenDangNhap, string matKhau, string email)
        {
            this.tenDangNhap = tenDangNhap;
            this.matKhau = matKhau;
            this.email = email;
        }
        public TaiKhoanDTO(string maNhanVien, int maQuyen, string tenDangNhap, string matKhau, int tinhTrang)
        {
            this.maNhanVien = maNhanVien;
            this.maQuyen = maQuyen;
            this.tenDangNhap = tenDangNhap;
            this.matKhau = matKhau;
            this.tinhTrang = tinhTrang;
        }
    }
}
