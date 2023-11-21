using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class PhanQuyenBUS
    {
        PhanQuyenDAL dal = new PhanQuyenDAL();
        public void phanQuyen(String maNv)
        {
            dal.phanQuyen(maNv);
        }
    }
}
