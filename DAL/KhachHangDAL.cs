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

        public List<KhachHangDTO> getList()
        {
            try
            {
                _conn.Open();
                string sql = "select * from khachHang";
                List<KhachHangDTO> list = new List<KhachHangDTO>();
                SqlCommand cmd = new SqlCommand(sql, _conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    KhachHangDTO kh = new KhachHangDTO();
                    kh.maKh = reader.GetInt32(reader.GetOrdinal("maKH"));
                    kh.tenKh = reader["tenKH"].ToString();
                    kh.sdtKh = reader["sdt"].ToString();
                    kh.tichDiem = reader.GetInt32(reader.GetOrdinal("tichDiem"));
                    kh.tongChi = reader.GetDouble(reader.GetOrdinal("tongChi"));                
                    list.Add(kh);
                }

                reader.Close();
                _conn.Close();
                return list;

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;

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

        public bool suakhachHang(KhachHangDTO kh)
        {
            try
            {
                // Ket noi
                _conn.Open();

                // Query string to update the "tinhTrang" column to 'False' for the specified "maNV"
                string SQL = string.Format("UPDATE khachHang SET tenKH = @tenKH, sdt = @sdt, tichDiem = @tichDiem, tongChi = @tongChi  WHERE maKH = @maKH");

                // Create a SqlCommand object
                using (SqlCommand cmd = new SqlCommand(SQL, _conn))
                {
                    // Use parameters to safely pass values into the SQL statement
                    cmd.Parameters.AddWithValue("@maKH", kh.maKh);
                    cmd.Parameters.AddWithValue("@tenKH", kh.tenKh);
                    cmd.Parameters.AddWithValue("@sdt", kh.sdtKh);
                    cmd.Parameters.AddWithValue("@tichDiem", kh.tichDiem);
                    cmd.Parameters.AddWithValue("@tongChi", kh.tongChi);                 
                    // Execute the SQL UPDATE statement
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                        return true;
                }
            }
            catch (Exception e)
            {
                // Handle the exception here or log it.
            }
            finally
            {
                // Dong ket noi
                _conn.Close();
            }

            return false;
        }

    }
}
