using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DAL
{
    //    Khối lệnh xửlýlỗi:
    //try
    //{
    //  <khối lệnh có thể xẩy ra lỗi>
    //} catch (SqlException mySqlException)
    //{
    //  < xử lý lỗi sinh ra do cơ sở dữ liệu >
    //}
    //Các thuộc tính cơ bản của lớp SqlException:
    //Number: Số hiệu lỗi.
    //Message: Xâu chứa thông báo lỗi.
    //StackTrace: Vị trí sinh ra lỗi gồm dòng lệnh và phương thức sinh ra lỗi.

    //SqlException: Một số mã lỗi của đối tượng lớp SqlException:
    //53: Tên máy chủ cơ sở dữ liệu sai.
    //4060: Không đúng tên cơ sở dữ liệu.
    //18456: Không đúng tên và/hoặc mật khẩu truy nhập

    //String conStr = "Data Source=DESKTOP-87V13PA\\SQLEXPRESS;Initial Catalog=cSharp;Integrated Security=True";
    //SqlConnection mySqlConnection = new SqlConnection(conStr);
    //mySqlConnection.Open();
    //String sSql = "select tenLoai from loaisp";
    //SqlCommand mySqlCommand = new SqlCommand(sSql, mySqlConnection);
    //mySqlCommand.ExecuteNonQuery();

//ExecuteNonQuery() : Dùng để thực hiện một lệnh INSERT, UPDATE, DELETE
//hoặc một thủ tục không trả về kết quả.
//ExecuteReader(): Dùng để thực hiện lệnh SELECT hoặc các thủ tục với kết quả
//trả về là một đối tượng lớp DataReader.
//ExecuteScalar(): Dùng để thực hiện lệnh SELECT với kết quả trả về là một giá
//trị vô hướng như hàm count(), sum().

//    Các thuộc tính thường dùng của SqlDataReader:
//      FieldCount: Số cột của dòng hiện thời
//      IsClosed: Có/không đối tượng đã đóng.
//    Các phương thức thường dùng của SqlDataReader:
//      Read(): Di chuyển con trỏ để đọc dòng tiếp theo.
//      Close(): Đóng đối tượng.
//      HasRows(): cho biết có dòng dữ liệu nào hay không
//    Phương thức Load() của đối tượng DataTable:
//      Load(): Chuyển dữ liệu đối tượng SqlDataReader vào đối tượng DataTable.

//    1. Tạo đối tượng lớp SqlCommand:
//      string sSql = "INSERT INTO Publishers (PublisherName, Description) " +
//                      "VALUES (@PublisherName, @Description")
//      SqlCommand mySqlCommand = new mySqlCommand(sSql, mySqlConnection);
//    2. Định nghĩa và gán giá trị tham số cho đối tượng lớp SqlCommand:
//      mySqlCommand.Parameters.Add("@PublisherName"
//                                  ,SqlDbType.NVarChar,50).Value = “x”;
//      mySqlCommand.Parameters.Add("@Description"
//                                  ,SqlDbType.NVarChar,250).Value = “y”;
//    3. Thực hiện phương thức ExecuteNonQuery() :
//      mySqlCommand.ExecuteNonQuery();
    public class ThongKeDAL:DatabaseConnect
    {
        //string[] words = "hello-world-csharp".Split('-');
        public List<String> getDSLoaiSP()
        {
            List<String> list = new List<String>();
            String sSql = "select tenLoai from loaisp order by tenLoai";
            _conn.Open();
            if (_conn.State==ConnectionState.Closed)
            {
                MessageBox.Show("Không thể kết nối DATABASE");
                return null;
            }
            SqlCommand sqlCommand = new SqlCommand(sSql, _conn);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                list.Add(reader.GetString(0));
            }
            reader.Close();
            _conn.Close();
            return list;
        }

        public void getPointAllTK(List<String> listSP, String thoiGian, DateTime batDau, DateTime ketThuc, List<Series> series1, List<Series> series2)
        {
            _conn.Open();
            if (_conn.State == ConnectionState.Closed)
            {
                MessageBox.Show("Không thể kết nối DATABASE");
                return;
            }
            SqlCommand command = _conn.CreateCommand();
            String sSql;
            SqlDataReader reader;
            //bien dem tang theo tuan hoac thang hoac quy
            int countThoiGian = 1; //cotThuN
            int countSPInColumn = 1; //dongThuN
            //tao bien tempEnd de chay vong lap co begin va end
            DateTime dateTempEnd;

            //quy doi thoiGian ra int
            switch (thoiGian)
            {
                case "tuần":
                    {
                        //tang dateTempEnd len 7 ngay
                        dateTempEnd = batDau.AddDays(7);
                    }
                    break;
                case "tháng":
                    {
                        //tang dateTempEnd len 1 thang
                        dateTempEnd = batDau.AddMonths(1);
                    }
                    break;
                case "quý":
                    {
                        //tang dateTempEnd len 3 thang
                        dateTempEnd = batDau.AddMonths(3);
                    }
                    break;
                default:
                    {
                        //tang dateTempEnd len 7 ngay
                        dateTempEnd = batDau.AddDays(7);
                    }
                    break;
            }

            //bat dau vong lap de tao dataPoint
            for (DateTime i = batDau; i <=  ketThuc;){
                { //tinh tong soLuong
                    bool breakTemp = false;
                    sSql = "select tenLoai,sum(cthd.soluong) as soLuong\r\nfrom hoaDon as hd join CT_HoaDon as cthd on hd.maHD=cthd.maHD\r\n\t\t\t\tjoin sanPham as sp on cthd.maSP=sp.maSP\r\n\t\t\t\tjoin loaiSP as lsp on lsp.maLoai=sp.maLoai\r\nwhere ngayLap > @begin and ngayLap < @end\r\ngroup by tenLoai\r\norder by tenLoai";
                    command.CommandText = sSql;

                    command.Parameters.Add("@begin", SqlDbType.DateTime).Value = i;
                    command.Parameters.Add("@end", SqlDbType.DateTime).Value = dateTempEnd;

                    reader = command.ExecuteReader();

                    //ex:  List    reader           or List reader
                    //      a         b                 c      a  
                    //      b         d                 d      b
                    //      c                                  c
                    //      d                                  d

                    while (reader.Read()) //da order by nên chỉ cần quan tâm từ trên xuống dưới
                    {
                        while (!listSP[countSPInColumn - 1].ToString().Equals(reader.GetString(0).ToString()))
                        {
                            if (listSP[countSPInColumn - 1].CompareTo(reader.GetString(0)) < 0)
                                countSPInColumn = (countSPInColumn % listSP.Count) + 1; //count tu 1->listSP.Count, soLuongSP trong 1 column
                            else
                            {
                                if (!reader.Read())
                                {
                                    countSPInColumn = 1; //neu da het reader, tra ve 1
                                    breakTemp = true;
                                    break;
                                }
                            }

                        }

                        if (breakTemp)
                        {
                            break;
                        }


                        if (listSP[countSPInColumn - 1].ToString().Equals(reader.GetString(0).ToString())) //nếu listSP trùng với listData thì thêm vào point; listSP bắt đầu=0, còn countThoiGian bắt đầu=1
                        {
                            Int32 sumSoLuong = reader.GetInt32(1);    //bat buộc get int32 ########

                            DataPoint temp = new DataPoint(countThoiGian, sumSoLuong);
                            temp.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                            temp.Label = countSPInColumn.ToString();
                            series1[countSPInColumn - 1].Points.Add(temp);
                        }
                    }

                    reader.Close();




                }
                countSPInColumn = 1;
                { //tinh doanhThu
                    bool breakTemp = false;
                    sSql = "select tenLoai,sum(cthd.tongTien) as tongTien\r\nfrom hoaDon as hd join CT_HoaDon as cthd on hd.maHD=cthd.maHD\r\n\tjoin sanPham as sp on cthd.maSP=sp.maSP\r\n\tjoin loaiSP as lsp on lsp.maLoai=sp.maLoai\r\nwhere ngayLap > @begin and ngayLap < @end \r\ngroup by tenLoai\r\norder by tenLoai";
                    command.CommandText = sSql;

                    reader = command.ExecuteReader();

                    while (reader.Read()) //da order by nên chỉ cần quan tâm từ trên xuống dưới
                    {
                        while (!listSP[countSPInColumn - 1].ToString().Equals(reader.GetString(0).ToString()))
                        {
                            if (listSP[countSPInColumn - 1].CompareTo(reader.GetString(0)) < 0)
                                countSPInColumn = (countSPInColumn % listSP.Count) + 1; //count tu 1->listSP.Count, soLuongSP trong 1 column
                            else
                            {
                                if (!reader.Read())
                                {
                                    countSPInColumn = 1; //neu da het reader, tra ve 1
                                    breakTemp = true;
                                    break;
                                }
                            }

                        }

                        if (breakTemp)
                        {
                            break;
                        }


                        if (listSP[countSPInColumn - 1].ToString().Equals(reader.GetString(0).ToString())) //nếu listSP trùng với listData thì thêm vào point; listSP bắt đầu=0, còn countThoiGian bắt đầu=1
                        {
                            double sumTongTien =  Convert.ToDouble(reader.GetDouble(1));    //get float

                            DataPoint temp = new DataPoint(countThoiGian, sumTongTien);
                            temp.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                            temp.Label = countSPInColumn.ToString() + "---";
                            series2[countSPInColumn - 1].Points.Add(temp);
                        }
                    }
                    reader.Close();
                }

                command.Parameters.RemoveAt(0);
                command.Parameters.RemoveAt(0);

                //quy doi thoiGian ra int
                switch (thoiGian)
                {
                    case "tuần":
                        {
                            i = i.AddDays(7);
                            //tang dateTempEnd len 7 ngay
                            dateTempEnd = dateTempEnd.AddDays(7);
                        }
                        break;
                    case "tháng":
                        {
                            i = i.AddMonths(1);
                            //tang dateTempEnd len 7 ngay
                            dateTempEnd = dateTempEnd.AddMonths(1);
                        }
                        break;
                    case "quý":
                        {
                            i = i.AddMonths(3);
                            //tang dateTempEnd len 7 ngay
                            dateTempEnd = dateTempEnd.AddMonths(3);
                        }
                        break;
                    default:
                        {
                            i = i.AddDays(7);
                            //tang dateTempEnd len 7 ngay
                            dateTempEnd = dateTempEnd.AddDays(7);
                        }
                        break;
                }
                countThoiGian++;
            }
            _conn.Close();
        }
        public String getTongThu(DateTime batDau, DateTime ketThuc)
        {
            double tongThu=0;
            _conn.Open();
            if (_conn.State == ConnectionState.Closed)
            {
                MessageBox.Show("Không thể kết nối DATABASE");
                return null;
            }
            String sSql = "select sum(tongTien)\r\nfrom hoaDon\r\nwhere ngayLap >= @begin and ngayLap < @end";
            SqlCommand cmd = _conn.CreateCommand();
            cmd.CommandText = sSql;
            cmd.Parameters.Add("@begin", SqlDbType.DateTime).Value = batDau;
            cmd.Parameters.Add("@end", SqlDbType.DateTime).Value = ketThuc;
            SqlDataReader reader=cmd.ExecuteReader();
            if (reader.Read())
            {
                tongThu=reader.GetDouble(0);
            }
            return tongThu.ToString();
        }
        public String getTongChi(string tongThu, DateTime batDau, DateTime ketThuc)
        {
            double tongChi=Convert.ToDouble(tongThu)*100/110; //loi nhuan 10% san pham
            _conn.Open();
            if (_conn.State == ConnectionState.Closed)
            {
                MessageBox.Show("Không thể kết nối DATABASE");
                return null;
            }
            String sSql = "select sum(tongTien)\r\nfrom hoaDon\r\nwhere ngayLap >= @begin and ngayLap < @end";
            SqlCommand cmd = _conn.CreateCommand();
            cmd.CommandText = sSql;
            cmd.Parameters.Add("@begin", SqlDbType.DateTime).Value = batDau;
            cmd.Parameters.Add("@end", SqlDbType.DateTime).Value = ketThuc;
            SqlDataReader reader=cmd.ExecuteReader();
            if (reader.Read())
            {
                tongChi+=reader.GetDouble(0);
            }
            return tongChi.ToString();
        }
        public String getLoiNhuan(List<String> listSP, String thoiGian, DateTime batDau, DateTime ketThuc)
        {

            return null;
        }

    }
}
