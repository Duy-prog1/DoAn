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
    public class HoaDonDAL : DatabaseConnect
    {
        // 1 -- hiển thị danh sách hóa đơn
        public DataTable getDSHD()
        {
            var cmd = new SqlCommand("SELECT hd.*, kh.tenKH  FROM hoaDon hd join khachHang kh on hd.maKH=kh.maKH ", _conn);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        // tạo hóa đơn
        public bool TaoHoaDon(HoaDonDTO hoaDon)
        {
            try
            {
                using (var cmd = new SqlCommand("INSERT INTO hoaDon (maNV, maKH, ngayLap, tongTien) VALUES (@maNV, @maKH, @ngayLap, @tongTien)", _conn))
                {
                    cmd.Parameters.AddWithValue("@maNV", hoaDon.maNV);
                    cmd.Parameters.AddWithValue("@maKH", hoaDon.maKH);
                    cmd.Parameters.AddWithValue("@ngayLap", hoaDon.ngayLap);
                    cmd.Parameters.AddWithValue("@tongTien", hoaDon.tongTien);

                    _conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
           
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                _conn.Close();
            }
        }
        // lấy mã hóa đơn mới nhất
        public int GetMaHoaDonMoiNhat()
        {
            try
            {
                using (var cmd = new SqlCommand("SELECT TOP 1 maHD FROM hoaDon ORDER BY maHD DESC", _conn))
                {
                    _conn.Open();
                    var result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToInt32(result);
                    }

                
                    return -1;
                }
            }
            catch (Exception ex)
            {
            
                Console.WriteLine(ex.Message);
                return -1;
            }
            finally
            {
                _conn.Close();
            }
        }
        // tìm kiếm hóa đơn theo ngày 

        public DataTable TimKiemHoaDonTheoKhoangNgay(DateTime fromDate, DateTime toDate)
        {
            try
            {
                using (var cmd = new SqlCommand("SELECT hd.*, kh.tenKH FROM hoaDon hd JOIN khachHang kh ON hd.maKH=kh.maKH WHERE ngayLap >= @fromDate AND ngayLap <= @toDate", _conn))
                {
                    cmd.Parameters.AddWithValue("@fromDate", fromDate);
                    cmd.Parameters.AddWithValue("@toDate", toDate);
                    var da = new SqlDataAdapter(cmd);
                    var dt = new DataTable();
                    da.Fill(dt);

                    return dt;
                }
            }
            catch (Exception ex)
            {
               
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                _conn.Close();
            }
        }


    }
}
