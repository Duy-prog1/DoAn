using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{

    public class DatabaseConnect
    {
        private SqlDataAdapter dataTable;
        //ông nào muốn chạy thì mở phần comment của mình, không xóa các comment connect chung
        //protected SqlConnection _conn = new SqlConnection("Data Source=LAPTOP-1A0D861M\\TRANQUANGTRUONG;Initial Catalog=cSharp;Integrated Security=True");
        protected SqlConnection _conn = new SqlConnection("Data Source=DESKTOP-87V13PA\\SQLEXPRESS;Initial Catalog=cSharp;Integrated Security=True");


        //phần học tại lớp
        String strConnect = @"Data Source=DESKTOP-87V13PA\SQLEXPRESS;Initial Catalog=cSharp;Integrated Security=True";
        protected bool OpenDB()
        {
            if(_conn.State==ConnectionState.Open)
            {
                return true;
            }
            else
            { 
                return false; 
            }
        }
        DatabaseConnect databaseConnect = new DatabaseConnect();
        DataTable dt;
        public List<NhanVienDAL> getAll()
        {
            dt=new DataTable();
            List <NhanVienDAL> ls= new List<NhanVienDAL>();
            string sql = "select * from NhanVien";
            if (!databaseConnect.OpenDB()) return null;
            

            return ls;
        }
        
    }
}
