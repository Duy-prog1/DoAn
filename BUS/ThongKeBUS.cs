using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ThongKeBUS
    {
        ThongKeDAL thongKeDAL=new ThongKeDAL();
        public List<String> getDSLoaiSP()
        {
            thongKeDAL.getDSLoaiSP();
        }
    }
}
