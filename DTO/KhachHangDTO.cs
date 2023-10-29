using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHangDTO
    {
        public int maKh { get; set; }
        public string tenKh { get; set; }
        public string sdtKh { get; set; }
        //public string diaChi { get; set; }
        public int tichDiem { get; set; }
        public double tongChi { get; set; }

        public KhachHangDTO(int maKh, string tenKh, string sdtKh, int tichDiem, double tongChi)
        {
            this.maKh = maKh;
            this.tenKh = tenKh;
            this.sdtKh = sdtKh;
            this.tichDiem = tichDiem;
            this.tongChi = tongChi;
        }
    }
}
