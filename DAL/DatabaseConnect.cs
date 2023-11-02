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
        //ông nào muốn chạy thì mở phần comment của mình, không xóa các comment connect chung
        protected SqlConnection _conn = new SqlConnection("Data Source=LAPTOP-1A0D861M\\TRANQUANGTRUONG;Initial Catalog=cSharp;Integrated Security=True");
        //protected SqlConnection _conn = new SqlConnection("Data Source=DESKTOP-87V13PA\\SQLEXPRESS;Initial Catalog=cSharp;Integrated Security=True");
    }
}
