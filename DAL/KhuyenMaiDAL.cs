using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class KhuyenMaiDAL : DatabaseConnect
    {
        public List<KhuyenMaiDTO> getList()
        {
            try
            {
                _conn.Open();
                string sql = "select * from khuyenMai";
                List<KhuyenMaiDTO> list = new List<KhuyenMaiDTO>();
                SqlCommand cmd = new SqlCommand(sql, _conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    KhuyenMaiDTO km = new KhuyenMaiDTO();
                    string MaKhuyenMaistr = reader["maKM"].ToString();
                    int MaKhuyenMai;
                    if (int.TryParse(MaKhuyenMaistr, out MaKhuyenMai))
                    {
                        km.maKhuyenMai = MaKhuyenMai;
                    }
                    km.tenKhuyenMai = reader["tenKM"].ToString();
                    string ngayBatDaustr = reader["ngayBD"].ToString();
                    string dateFormat = "dd/MM/yyyy"; // Định dạng ngày tháng
                    DateTime ngayBD;

                    if (DateTime.TryParseExact(ngayBatDaustr, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out ngayBD))
                    {
                        km.ngayBatDau = ngayBD;
                    }
                    string ngayKetThucstr = reader["ngayKT"].ToString();
                    DateTime ngayKT;

                    if (DateTime.TryParseExact(ngayKetThucstr, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out ngayKT))
                    {
                        km.ngayKetThuc = ngayBD;
                    }

                    list.Add(km);
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
        public DataTable getKhuyenMai()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT maKM, tenKM, ngayBD, ngayKT FROM khuyenMai ", _conn);
            DataTable dtKhuyenMai = new DataTable();
            adapter.Fill(dtKhuyenMai);
            return dtKhuyenMai;
        }

        public bool ThemKhuyenMai(KhuyenMaiDTO km)
        {
            try
            {
                // Mở kết nối đến CSDL
                _conn.Open();

                // Tạo câu SQL để thêm dữ liệu vào bảng "khuyenMai"
                string SQL = string.Format("INSERT INTO khuyenMai (maKM, tenKM, ngayBD, ngayKT) VALUES ('{0}', N'{1}', '{2}', '{3}')",
                    km.maKhuyenMai, km.tenKhuyenMai, km.ngayBatDau, km.ngayKetThuc);

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

        public bool SuaKhuyenMai(KhuyenMaiDTO khuyenMai)
        {
            try
            {
                // Mở kết nối đến CSDL
                _conn.Open();

                // Câu SQL để cập nhật thông tin khuyến mãi
                string SQL = "UPDATE khuyenMai SET tenKM = @tenKM, ngayBD = @ngayBD, ngayKT = @ngayKT WHERE maKM = @maKM";

                // Tạo đối tượng SqlCommand
                using (SqlCommand cmd = new SqlCommand(SQL, _conn))
                {
                    // Sử dụng tham số để an toàn truyền giá trị vào câu SQL
                    cmd.Parameters.AddWithValue("@maKM", khuyenMai.maKhuyenMai);
                    cmd.Parameters.AddWithValue("@tenKM", khuyenMai.tenKhuyenMai);
                    cmd.Parameters.AddWithValue("@ngayBD", khuyenMai.ngayBatDau);
                    cmd.Parameters.AddWithValue("@ngayKT", khuyenMai.ngayKetThuc);

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
        public bool XoaKhuyenMai(int maKhuyenMai)
        {
            try
            {
                // Mở kết nối đến CSDL
                _conn.Open();

                // Tạo câu SQL để xóa dữ liệu từ bảng "khuyenMai" dựa trên mã khuyến mãi
                string SQL = string.Format("DELETE FROM khuyenMai WHERE maKM = '{0}'", maKhuyenMai);

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
