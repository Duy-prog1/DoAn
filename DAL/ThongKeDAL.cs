using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace DAL
{
    public class ThongKeDAL:DatabaseConnect
    {
        //string[] words = "hello-world-csharp".Split('-');
        public List<String> getDSLoaiSP()
        {
            List<String> list = new List<String>();
            String sSql = "select tenLoai from loaisp";
            _conn.Open();
            if (_conn.State==ConnectionState.Closed)
            {
                return null;
            }
            SqlCommand sqlCommand = _conn.CreateCommand();
            sqlCommand.CommandText = sSql;
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                list.Add(reader.GetString(0));
            }
            reader.Close();
            _conn.Close();
            return list;
        }

        public List<DataPoint> getPointTKSoLuong(List<String> listSP, String thoiGian, DateTime batDau, DateTime ketThuc)
        {

            return null;
        }
        public List<DataPoint> getPointTKDoanhThu(List<String> listSP, String thoiGian, DateTime batDau, DateTime ketThuc)
        {

            return null;
        }
        public String getTongThu(List<String> listSP, String thoiGian, DateTime batDau, DateTime ketThuc)
        {
            return null;

        }
        public String getTongChi(List<String> listSP, String thoiGian, DateTime batDau, DateTime ketThuc)
        {

            return null;
        }
        public String getLoiNhuan(List<String> listSP, String thoiGian, DateTime batDau, DateTime ketThuc)
        {

            return null;
        }

    }
}
