using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    internal class TaiKhoanDTO
    {
        private string maNhanVien { get; set; }
        private int maQuyen { get; set; }
        private string tenDangNhap { get; set; }
        private string matKhau { get; set; }
        private int tinhTrang { get; set; }
       
        TaiKhoanDTO() { }
        TaiKhoanDTO(string maNhanVien, int maQuyen, string tenDangNhap, string matKhau, int tinhTrang)
        {
            this.maNhanVien = maNhanVien;
            this.maQuyen = maQuyen;
            this.tenDangNhap = tenDangNhap;
            this.matKhau = matKhau;
            this.tinhTrang = tinhTrang;
        }
    }
}
