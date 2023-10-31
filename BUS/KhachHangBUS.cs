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
    public class KhachHangBUS
    {
        KhachHangDAL dalKhachHang = new KhachHangDAL();

       
        public DataTable getKhachHang()
        {
            return dalKhachHang.getKhachHang();
        }

        public DataTable getFindKhachHang(string key)
        {
            return dalKhachHang.getFindKhachHang(key);
        }

        
    }
}
