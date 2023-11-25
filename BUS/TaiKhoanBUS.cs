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
        // lấy mã nhân viên
        // lấy mã nhân viên
        public string LayMaNhanVien(string tenDangNhap, string matKhau)
        {
            return dal.LayMaNhanVien(tenDangNhap, matKhau);
        }
        // lấy tên đăng nhập theo mã nhân viên
        public string LayTenNhanVien(string tenDangNhap,string matKhau)
        {
            return dal.LayTenNhanVien(tenDangNhap,matKhau);
        }

        public TaiKhoanDTO getTk(string maNv)
        {
            return dal.getTk(maNv);
        }

        public bool xoaNhanVien(string maNv)
        {
            return dal.xoaNhanVien(maNv);
        }

        public List<bool> getDSQuyen(int maQuyen)
        {
            return dal.getDSQuyen(maQuyen);
        }

        public bool suaTk(TaiKhoanDTO tk)
        {
            return dal.suaTk(tk);
        }
    }
}
