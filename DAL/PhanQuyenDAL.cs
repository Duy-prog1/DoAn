using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PhanQuyenDAL: DatabaseConnect
    {
       NhanVienDAL nvDal = new NhanVienDAL();

        public void phanQuyen(String maNv)
        {
            NhanVienDTO nv = nvDal.timNv(maNv);
            Console.WriteLine(nv.tenNv.ToString());
        }

        
    }
}
