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
    public class ChiTietKhuyenMaiDAL:DatabaseConnect
    {
        public DataTable getChiTietKhuyenMai()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT maKM, maSP, donViGiam, giaTriGiam FROM CT_khuyenMai ", _conn);
            DataTable dtChiTietKhuyenMai = new DataTable();
            adapter.Fill(dtChiTietKhuyenMai);
            return dtChiTietKhuyenMai;
        }
        public DataTable getAllMaKhuyenMai()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT maKM FROM khuyenMai", _conn);
            DataTable dtMaKM = new DataTable();
            adapter.Fill(dtMaKM);
            return dtMaKM;
        }

        public DataTable getAllMaSanPham()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT maSP FROM sanPham", _conn);
            DataTable dtMaSP = new DataTable();
            adapter.Fill(dtMaSP);
            return dtMaSP;
        }

        public float getGiaBanByID(string maSP)
        {
            float giaBan = 0;

            try
            {
              
                _conn.Open();

             
                string SQL = string.Format("SELECT giaBan FROM sanPham WHERE maSP = '{0}'", maSP);

             
                SqlCommand cmd = new SqlCommand(SQL, _conn);

           
                var result = cmd.ExecuteScalar();

             
                if (result != null)
                {
                    giaBan = Convert.ToSingle(result);
                }
            }
            catch (Exception ex)
            {
         
            }
            finally
            {
                _conn.Close();
            }

            return giaBan;
        }
        public bool ThemChiTietKhuyenMai(ChiTietKhuyenMaiDTO ctkm)
        {
            try
            {
                _conn.Open();
                string SQL = string.Format("INSERT INTO CT_KhuyenMai (maKM, maSP, donViGiam, giaTriGiam) VALUES ('{0}', '{1}', N'{2}', {3})",
                    ctkm.maKhuyenMai, ctkm.maSanPham, ctkm.donViGiam, ctkm.giaTriGiam);
                SqlCommand cmd = new SqlCommand(SQL, _conn);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception e)
            {
             
            }
            finally
            {
             
                _conn.Close();
            }

            return false;
        }

        public bool SuaChiTietKhuyenMai(ChiTietKhuyenMaiDTO ctkm)
        {
            try
            {
                _conn.Open();
                string SQL = "UPDATE CT_KhuyenMai SET  maSP = @maSP, donViGiam = @donViGiam, giaTriGiam = @giaTriGiam WHERE maKM = @maKM";
                using (SqlCommand cmd = new SqlCommand(SQL, _conn))
                {
                    cmd.Parameters.AddWithValue("@maKM", ctkm.maKhuyenMai);
                    cmd.Parameters.AddWithValue("@maSP", ctkm.maSanPham);
                    cmd.Parameters.AddWithValue("@donViGiam", ctkm.donViGiam);
                    cmd.Parameters.AddWithValue("@giaTriGiam", ctkm.giaTriGiam);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        return true;
                }
            }
            catch (Exception e)
            {
               
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        public bool XoaChiTietKhuyenMai(int maKM)
        {
            try
            {
                _conn.Open();
                string SQL = string.Format("DELETE FROM CT_KhuyenMai WHERE maKM = '{0}'", maKM);
                SqlCommand cmd = new SqlCommand(SQL, _conn);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception e)
            {
               
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
    }
}
