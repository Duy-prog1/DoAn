using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DangNhapDAL:DatabaseConnect
    {
        public bool KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            try
            {
                _conn.Open();
                string SQL = "SELECT COUNT(*) FROM taiKhoan WHERE tenDangNhap=@tenDangNhap AND matKhau=@matKhau AND tinhTrang=1";
                SqlCommand cmd = new SqlCommand(SQL, _conn);
                cmd.Parameters.AddWithValue("@tenDangNhap", tenDangNhap);
                cmd.Parameters.AddWithValue("@matKhau", matKhau);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
    }
}
