using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class TaiKhoanBUS
    {
        TaiKhoanDTO dto = new TaiKhoanDTO();
        TaiKhoanDAL dal = new TaiKhoanDAL();
        DangNhapDAL dAL = new DangNhapDAL();
        // thêm tài khoản
        public bool themTaiKhoan(TaiKhoanDTO dto)
        {
            if (!dal.kiemTraTenTrungLap(dto.tenDangNhap))
            {
                return dal.themTaiKhoan(dto);
            }
            return false;
        }
        // kiem tra dang nhap
        public bool dangNhap(string tenDangNhap, string matKhau)
        {
            return dAL.KiemTraDangNhap(tenDangNhap, matKhau);
        }


    }
}
