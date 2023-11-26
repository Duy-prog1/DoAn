using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlTypes;

namespace DAL
{
    public class ChiTietHoaDonDAL:DangNhapDAL
    {
        // 1 -- hiển thị danh sách hóa đơn
        public DataTable getDSCTHD()
        {
            var cmd = new SqlCommand("SELECT * FROM CT_HoaDon", _conn);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();

            da.Fill(dt);
            return dt;
        }
        public DataTable GetChiTietHoaDon(int maHD)
        {
            var cmd = new SqlCommand("SELECT HD.maHD, CTHD.maSP, SP.tenSP, CTHD.soLuong,CTHD.giaBan, CTHD.tongTien,CTHD.maKM FROM hoaDon HD JOIN CT_HoaDon CTHD ON HD.maHD = CTHD.maHD JOIN sanPham SP ON CTHD.maSP = SP.maSP WHERE HD.maHD = @maHD", _conn);
            
                cmd.Parameters.AddWithValue("@maHD", maHD);
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            
        }

        // thêm chi tiết hóa đơn
        public bool ThemChiTietHoaDon(ChiTietHoaDonDTO chiTietHoaDon)
        {
            try
            {
                _conn.Open();
                var cmd = new SqlCommand("INSERT INTO CT_HoaDon (maHD, maSP, giaBan, soLuong, tongTien,maKM) VALUES (@maHD, @maSP, @giaBan, @soLuong, @tongTien,@maKM)", _conn);

                cmd.Parameters.AddWithValue("@maHD", chiTietHoaDon.maHD);
                cmd.Parameters.AddWithValue("@maSP", chiTietHoaDon.maSP);
                cmd.Parameters.AddWithValue("@giaBan", chiTietHoaDon.giaBan);
                cmd.Parameters.AddWithValue("@soLuong", chiTietHoaDon.soLuong);
                cmd.Parameters.AddWithValue("@tongTien", chiTietHoaDon.tongTien);
            
              /*if (chiTietHoaDon.maKM == null)
                {
                    cmd.Parameters.AddWithValue("@maKM", SqlInt32.Null);
                    
                }
                else*/
               // {
                    cmd.Parameters.AddWithValue("@maKM", chiTietHoaDon.maKM);
                //}
                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                // Handle exception (log or throw)
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                _conn.Close();
            }
        }

    }
}
