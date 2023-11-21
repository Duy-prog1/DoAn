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
    public class LoaiSanPhamDAL:DatabaseConnect
    {
        public DataTable getAllLoaiSanPham()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT maLoai, tenLoai FROM loaiSP", _conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable getLoaiSanPham()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT maLoai, tenLoai FROM loaiSP WHERE tinhTrang = 1", _conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public bool themLoaiSanPham(LoaiSanPhamDTO lsp)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO loaiSP(maLoai, tenLoai, tinhTrang) values(@maLoai, @tenLoai, @tinhTrang)", _conn);
                cmd.Parameters.AddWithValue("@maLoai", lsp.maLoai);
                cmd.Parameters.AddWithValue("@tenLoai", lsp.tenLoai);
                cmd.Parameters.AddWithValue("@tinhTrang", lsp.tinhTrang);

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

        public bool suaLoaiSanPham(LoaiSanPhamDTO lsp)
        {
            try
            {
                _conn.Open();

                // Query string to update the "tinhTrang" column to 'False' for the specified "maNV"
                string SQL = string.Format("UPDATE loaiSP SET tenLoai = @tenLoai, tinhTrang = @tinhTrang  WHERE maLoai = @maLoai");

                // Create a SqlCommand object
                using (SqlCommand cmd = new SqlCommand(SQL, _conn))
                {
                    // Use parameters to safely pass values into the SQL statement
                    cmd.Parameters.AddWithValue("@tenLoai", lsp.tenLoai);
                    cmd.Parameters.AddWithValue("@tinhTrang", lsp.tinhTrang);
                    cmd.Parameters.AddWithValue("@maLoai", lsp.maLoai);

                    // Execute the SQL UPDATE statement
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                        return true;
                }
            }
            catch (Exception ex) { }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        public bool xoaLoaiSanPham(int maLoai)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE loaiSP SET tinhTrang = 'false' Where maLoai = @maLoai", _conn);
                cmd.Parameters.AddWithValue("@maLoai", maLoai);
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

        public DataTable timLoaiSanPham(string text)
        {
            SqlDataAdapter da = new SqlDataAdapter($"SELECT maLoai, tenLoai FROM loaiSP WHERE tinhTrang = 1 AND (maLoai LIKE '%{text}%' OR tenLoai LIKE '%{text}%')", _conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
