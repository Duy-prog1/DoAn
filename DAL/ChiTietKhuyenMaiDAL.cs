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
                // Mở kết nối đến CSDL
                _conn.Open();

                // Tạo câu SQL để lấy giá bán từ bảng "sanPham"
                string SQL = string.Format("SELECT giaBan FROM sanPham WHERE maSP = '{0}'", maSP);

                // Tạo đối tượng SqlCommand
                SqlCommand cmd = new SqlCommand(SQL, _conn);

                // Sử dụng ExecuteScalar để lấy giá trị duy nhất
                var result = cmd.ExecuteScalar();

                // Kiểm tra nếu kết quả không null
                if (result != null)
                {
                    giaBan = Convert.ToSingle(result);
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ (exception) ở đây nếu cần
            }
            finally
            {
                // Đảm bảo đóng kết nối sau khi sử dụng
                _conn.Close();
            }

            return giaBan;
        }
        public bool ThemChiTietKhuyenMai(ChiTietKhuyenMaiDTO ctkm)
        {
            try
            {
                // Mở kết nối đến CSDL
                _conn.Open();

                // Tạo câu SQL để thêm dữ liệu vào bảng "CT_KhuyenMai"
                string SQL = string.Format("INSERT INTO CT_KhuyenMai (maKM, maSP, donViGiam, giaTriGiam) VALUES ('{0}', '{1}', N'{2}', {3})",
                    ctkm.maKhuyenMai, ctkm.maSanPham, ctkm.donViGiam, ctkm.giaTriGiam);

                // Tạo đối tượng SqlCommand
                SqlCommand cmd = new SqlCommand(SQL, _conn);

                // Thực thi câu lệnh SQL và kiểm tra
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception e)
            {
                // Xử lý lỗi (có thể in thông báo lỗi hoặc ghi vào file log)
            }
            finally
            {
                // Đóng kết nối CSDL
                _conn.Close();
            }

            return false;
        }

        public bool SuaChiTietKhuyenMai(ChiTietKhuyenMaiDTO ctkm)
        {
            try
            {
                // Mở kết nối đến CSDL
                _conn.Open();

                // Câu SQL để cập nhật thông tin chi tiết khuyến mãi
                string SQL = "UPDATE CT_KhuyenMai SET  maSP = @maSP, donViGiam = @donViGiam, giaTriGiam = @giaTriGiam WHERE maKM = @maKM";

                // Tạo đối tượng SqlCommand
                using (SqlCommand cmd = new SqlCommand(SQL, _conn))
                {
                    // Sử dụng tham số để an toàn truyền giá trị vào câu SQL
                    cmd.Parameters.AddWithValue("@maKM", ctkm.maKhuyenMai);
                    cmd.Parameters.AddWithValue("@maSP", ctkm.maSanPham);
                    cmd.Parameters.AddWithValue("@donViGiam", ctkm.donViGiam);
                    cmd.Parameters.AddWithValue("@giaTriGiam", ctkm.giaTriGiam);

                    // Thực hiện câu lệnh SQL UPDATE
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                        return true;
                }
            }
            catch (Exception e)
            {
                // Xử lý lỗi ở đây hoặc ghi vào file log.
            }
            finally
            {
                // Đóng kết nối CSDL
                _conn.Close();
            }

            return false;
        }

        public bool XoaChiTietKhuyenMai(int maKM)
        {
            try
            {
                // Mở kết nối đến CSDL
                _conn.Open();

                // Tạo câu SQL để xóa dữ liệu từ bảng "CT_KhuyenMai" dựa trên mã khuyến mãi
                string SQL = string.Format("DELETE FROM CT_KhuyenMai WHERE maKM = '{0}'", maKM);

                // Tạo đối tượng SqlCommand
                SqlCommand cmd = new SqlCommand(SQL, _conn);

                // Thực thi câu lệnh SQL và kiểm tra
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception e)
            {
                // Xử lý lỗi (có thể in thông báo lỗi hoặc ghi vào file log)
            }
            finally
            {
                // Đóng kết nối CSDL
                _conn.Close();
            }

            return false;
        }

    }

}
