using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DAL
{
    public class NhanVienDAL:DatabaseConnect
    {

        public List<NhanVienDTO> getList()
        {
            try
            {
                _conn.Open();
                string sql = "select * from nhanVien";
                List<NhanVienDTO> list = new List<NhanVienDTO>();
                SqlCommand cmd = new SqlCommand(sql, _conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    NhanVienDTO nv = new NhanVienDTO();
                    nv.maNv = reader["maNV"].ToString();
                    nv.tenNv = reader["tenNV"].ToString();
                    nv.gioiTinhNv = reader.GetBoolean(reader.GetOrdinal("gioiTinh"));
                    nv.sdtNv = reader["sdt"].ToString();
                  //  nv.DIACHI = reader["DIACHI"].ToString();
                    nv.chucVu = reader["chucVu"].ToString();
                    nv.ngaySinhNv = reader["ngaySinh"].ToString();
                    nv.trangThai = reader.GetBoolean(reader.GetOrdinal("tinhTrang"));
                    list.Add(nv);
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

        public DataTable getNhanVien()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT maNV, tenNV, gioiTinh, sdt, chucVu, ngaySinh FROM nhanVien WHERE tinhTrang = 1", _conn);
            DataTable dtThanhvien = new DataTable();

            da.Fill(dtThanhvien);
            return dtThanhvien;
        }

        public DataTable getFindThanhVien(string key)
        {
            DataTable dtThanhvien = new DataTable();
            using (SqlConnection connection = new SqlConnection(_conn.ConnectionString))
            {
                connection.Open();
                string sqlQuery = "SELECT  maNV, tenNV, gioiTinh, sdt, chucVu, ngaySinh FROM nhanVien WHERE tinhTrang = 1 AND (maNV LIKE @key OR tenNV LIKE @key OR sdt LIKE @key OR chucVu LIKE @key OR ngaySinh @key )";
                SqlDataAdapter da;
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@key", "%" + key + "%");
                    da = new SqlDataAdapter(command);

                }
                da.Fill(dtThanhvien);
            }

            return dtThanhvien;
        }

        public bool themNhanVien(NhanVienDTO tv)
        {
            try
            {
                // Ket noi
                _conn.Open();

                // Query string - vì mình để TV_ID là identity (giá trị tự tăng dần) nên ko cần fải insert ID
                string SQL = string.Format("INSERT INTO nhanVien( maNV, tenNV, gioiTinh, sdt, chucVu, ngaySinh, tinhTrang) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", tv.maNv, tv.tenNv, tv.sdtNv, tv.chucVu, tv.ngaySinhNv, tv.gioiTinhNv, tv.trangThai);

                // Command (mặc định command type = text nên chúng ta khỏi fải làm gì nhiều).
                SqlCommand cmd = new SqlCommand(SQL, _conn);

                // Query và kiểm tra
                if (cmd.ExecuteNonQuery() > 0)
                    return true;

            }
            catch (Exception e)
            {

            }
            finally
            {
                // Dong ket noi
                _conn.Close();
            }

            return false;
        }

        public bool suaNhanVien(NhanVienDTO nv)
        {
            try
            {
                // Ket noi
                _conn.Open();

                // Query string to update the "tinhTrang" column to 'False' for the specified "maNV"
                string SQL = string.Format("UPDATE nhanVien SET tenNV = @tenNV, gioiTinh = @gioiTinh, sdt = @sdt, chucVu =@chucVu, ngaySinh = @ngaySinh  WHERE maNV = @MaNV");

                // Create a SqlCommand object
                using (SqlCommand cmd = new SqlCommand(SQL, _conn))
                {
                    // Use parameters to safely pass values into the SQL statement
                    cmd.Parameters.AddWithValue("@MaNV", nv.maNv);
                    cmd.Parameters.AddWithValue("@tenNV", nv.tenNv);
                    cmd.Parameters.AddWithValue("@gioiTinh", nv.gioiTinhNv);
                    cmd.Parameters.AddWithValue("@sdt", nv.sdtNv);
                    cmd.Parameters.AddWithValue("@chucVu", nv.chucVu);
                    cmd.Parameters.AddWithValue("@ngaySinh", nv.ngaySinhNv);
                   
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

        public bool xoaNhanVien(string maNV)
        {
            try
            {
                // Ket noi
                _conn.Open();

                // Query string to update the "tinhTrang" column to 'False' for the specified "maNV"
                string SQL = string.Format("UPDATE nhanVien SET tinhTrang = 'False' WHERE maNV = @MaNV");

                // Create a SqlCommand object
                using (SqlCommand cmd = new SqlCommand(SQL, _conn))
                {
                    // Use parameters to safely pass values into the SQL statement
                    cmd.Parameters.AddWithValue("@MaNV", maNV);

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
