using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class KhachHangDAL : DatabaseConnect
    {
        public DataTable getKhachHang()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT maKH, tenKH, sdt, tichDiem, tongChi FROM khachHang ", _conn);
            DataTable dtKhachHang = new DataTable();

            da.Fill(dtKhachHang);
            return dtKhachHang;
        }

        public DataTable getFindKhachHang(string key)
        {
            DataTable dtKhachHang = new DataTable();
            using (SqlConnection connection = new SqlConnection(_conn.ConnectionString))
            {
                connection.Open();
                string sqlQuery = "SELECT   maKH, tenKH, sdt, tichDiem, tongChi FROM khachHang Where maKH LIKE @key OR tenKH LIKE @key OR sdt LIKE @key OR tichDiem LIKE @key OR tongChi LIKE @key ";
                SqlDataAdapter da;
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@key", "%" + key + "%");
                    da = new SqlDataAdapter(command);

                }
                da.Fill(dtKhachHang);
            }

            return dtKhachHang;
        }

    }
}
