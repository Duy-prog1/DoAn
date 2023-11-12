using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BanHangBUS
    {
        BanHangDAL dal = new BanHangDAL();
        public DataTable getDSSP()
        {
            return dal.getDSSP();
        }
        public List<SanPhamDTO> GetDanhSachSanPham()
        {
         
            List<SanPhamDTO> productList = dal.DanhSachSanPham();
            return productList;
        }
        // tìm kiếm sản phẩm
        public DataTable TimKiemSanPham(string keyword)
        {
       
            return dal.TimKiemSanPham(keyword);
        }
        // lấy ra số lượng sản phẩm
        // cập nhật số lượng
        public bool CapNhatSoLuongSPTrongDB(string maSP,int soLuongCapNhat)
        {
            return dal.CapNhatSoLuongSPTrongDB(maSP,soLuongCapNhat);
        }
    }
}
