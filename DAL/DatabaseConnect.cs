using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DatabaseConnect
    {
        protected SqlConnection _conn = new SqlConnection("Data Source=LAPTOP-1A0D861M\\TRANQUANGTRUONG;Initial Catalog=cSharp;Integrated Security=True");
    }
}
