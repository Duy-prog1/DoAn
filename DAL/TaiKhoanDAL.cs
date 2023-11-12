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



    }
}

