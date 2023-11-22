using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TaiKhoanDAL:DatabaseConnect
    {
        public bool themTaiKhoan(TaiKhoanDTO dto)
        {
            try
            {
                _conn.Open();
                string SQL = "INSERT INTO taiKhoan(tenDangNhap, matKhau, email,tinhTrang) VALUES (@tenDangNhap, @matKhau, @email,@tinhTrang)";
                SqlCommand cmd = new SqlCommand(SQL, _conn);
                // Sử dụng tham số
                cmd.Parameters.AddWithValue("@tenDangNhap", dto.tenDangNhap);
                cmd.Parameters.AddWithValue("@matKhau", dto.matKhau);
                cmd.Parameters.AddWithValue("@email", dto.email);
                cmd.Parameters.AddWithValue("@tinhTrang", 1);
                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine("Lỗi: " + e.Message);
                return false;
            }
            finally
            {
                _conn.Close();
            }
        }

        // 2 -- kiểm tra trùng username
        public bool kiemTraTenTrungLap(string tenDangNhap)
        {
            try
            {
                _conn.Open();
                string SQL = "SELECT COUNT(*) FROM taiKhoan WHERE tenDangNhap = @tenDangNhap";
                SqlCommand cmd = new SqlCommand(SQL, _conn);
                cmd.Parameters.AddWithValue("@tenDangNhap", tenDangNhap);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
   

        // lấy mã nhân viên
        public string LayMaNhanVien(string tenDangNhap, string matKhau)
        {
            string maNV = null;

            try
            {
                _conn.Open();

                using (var cmd = new SqlCommand("SELECT maNV FROM taiKhoan WHERE tenDangNhap = @tenDangNhap AND matKhau = @matKhau", _conn))
                {
                    cmd.Parameters.AddWithValue("@tenDangNhap", tenDangNhap);
                    cmd.Parameters.AddWithValue("@matKhau", matKhau);

                    var result = cmd.ExecuteScalar();
                    maNV = result != null ? result.ToString() : null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                // Xử lý ngoại lệ theo cách phù hợp, ví dụ: ghi log hoặc ném lại ngoại lệ
            }
            finally
            {
                _conn.Close();
            }

            return maNV;
        }
        // lấy  tên nhân viên
        // Lấy tên nhân viên
        public string LayTenNhanVien(string tenDangNhap, string matKhau)
        {
            string tenNV = null;

            try
            {
                _conn.Open();

                // Sử dụng JOIN để lấy tên nhân viên từ bảng nhanVien
                using (var cmd = new SqlCommand("SELECT n.tenNV FROM taiKhoan AS tk JOIN nhanVien AS n ON tk.maNV = n.maNV WHERE tk.tenDangNhap = @tenDangNhap AND tk.matKhau = @matKhau", _conn))
                {
                    cmd.Parameters.AddWithValue("@tenDangNhap", tenDangNhap);
                    cmd.Parameters.AddWithValue("@matKhau", matKhau);

                    var result = cmd.ExecuteScalar();
                    tenNV = result != null ? result.ToString() : null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                // Xử lý ngoại lệ theo cách phù hợp, ví dụ: ghi log hoặc ném lại ngoại lệ
            }
            finally
            {
                _conn.Close();
            }

            return tenNV;
        }

        public TaiKhoanDTO getTk(string maNv)
        {
            TaiKhoanDTO tk = null;

            try
            {
                _conn.Open();
                string sql = "SELECT * FROM taiKhoan WHERE tinhTrang = @tinhTrang AND maNV = @maNV";

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@tinhTrang", true);
                cmd.Parameters.AddWithValue("@maNV", maNv);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    tk = new TaiKhoanDTO();
                    tk.maNhanVien = reader["maNV"].ToString();
                    tk.maQuyen = reader.GetInt32(reader.GetOrdinal("maQuyen"));
                    tk.tenDangNhap = reader["tenDangNhap"].ToString();
                    tk.matKhau = reader["matKhau"].ToString();                  
                }

                reader.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();
            }

            return tk;
        }

        public bool xoaNhanVien(string maNV)
        {
            try
            {
                // Ket noi
                _conn.Open();

                // Query string to update the "tinhTrang" column to 'False' for the specified "maNV"
                string SQL = string.Format("UPDATE taiKhoan SET tinhTrang = 'False' WHERE maNV = @MaNV");

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

        public List<bool> getDSQuyen(int maQuyen)
        {
            List<bool> list = new List<bool>();
            try
            {
                _conn.Open();

                using (var cmd = new SqlCommand("select *\r\nfrom phanQuyen\r\nwhere maQuyen=@maQuyen", _conn))
                {
                    cmd.Parameters.AddWithValue("@maQuyen", maQuyen);

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        for(int i=1;i<reader.FieldCount;i++)
                        {
                            list.Add(reader.GetBoolean(i));
                        }
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                // Xử lý ngoại lệ theo cách phù hợp, ví dụ: ghi log hoặc ném lại ngoại lệ
            }
            finally
            {
                _conn.Close();
            }

            return list;
        }

    }
}

