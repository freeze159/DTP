using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace WinFormProJect
{
    public class DataBase
    {
        string strConn;
        SqlConnection conn;
        SqlDataAdapter da;
        public DataBase(string strConn)
        {
            this.strConn = strConn;

        }
        public DataTable ReadData(string strSql)
        {
            conn = new SqlConnection(strConn);
            da = new SqlDataAdapter(strSql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Dispose();
            return dt;
        }
        public void UpdateData(DataTable dt, string strSql)
        {
            conn = new SqlConnection(strConn);
            da = new SqlDataAdapter(strSql, conn);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);//insert,delete,update
            da.Update(dt);
            conn.Dispose();
        }
    }
}
