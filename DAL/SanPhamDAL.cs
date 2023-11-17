using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SanPhamDAL:DatabaseConnect
    {
        public DataTable getSanPham()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT maSP, tenSP, giaBan, soLuong, img, thoiGian, maLoai FROM sanPham WHERE tinhTrang = 1", _conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public bool themSanPham(SanPhamDTO sp)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO sanPham values(@maSP, @tenSP, @giaBan, @soLuong, @img, @thoiGian, @tinhTrang, @maLoai)", _conn);
                cmd.Parameters.AddWithValue("@maSP", sp.maSanPham);
                cmd.Parameters.AddWithValue("@tenSP", sp.tenSanPham);
                cmd.Parameters.AddWithValue("@giaBan", sp.giaBan);
                cmd.Parameters.AddWithValue("@soLuong", sp.soLuong);
                cmd.Parameters.AddWithValue("@img", sp.img);
                cmd.Parameters.AddWithValue("@thoiGian", sp.thoiGianBaoHanh);
                cmd.Parameters.AddWithValue("@tinhTrang", sp.tinhTrang);
                cmd.Parameters.AddWithValue("@maLoai", sp.maLoai);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception ex) { }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        public bool suaSanPham(SanPhamDTO sp)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE sanPham SET tenSP = @tenSP, giaBan = @giaBan, soLuong = @soLuong, img = @img, thoiGian = @thoiGian, tinhTrang = @tinhTrang, maLoai = @maLoai Where maSP = @maSP", _conn);
                cmd.Parameters.AddWithValue("@maSP", sp.maSanPham);
                cmd.Parameters.AddWithValue("@tenSP", sp.tenSanPham);
                cmd.Parameters.AddWithValue("@giaBan", sp.giaBan);
                cmd.Parameters.AddWithValue("@soLuong", sp.soLuong);
                cmd.Parameters.AddWithValue("@img", sp.img);
                cmd.Parameters.AddWithValue("@thoiGian", sp.thoiGianBaoHanh);
                cmd.Parameters.AddWithValue("@tinhTrang", sp.tinhTrang);
                cmd.Parameters.AddWithValue("@maLoai", sp.maLoai);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception ex) { }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        public bool xoaSanPham(string maSP)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE sanPham SET tinhTrang = 'false' Where maSP = @maSP", _conn);
                cmd.Parameters.AddWithValue("@maSP", maSP);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception ex) { }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        public DataTable timSanPham(string text)
        {
            SqlDataAdapter da = new SqlDataAdapter($"SELECT maSP, tenSP, giaBan, soLuong, img, thoiGian, maLoai FROM sanPham WHERE tinhTrang = 1 AND (maSP LIKE '%{text}%' OR tenSP LIKE '%{text}%')", _conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
