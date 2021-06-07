using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QUANLYPHONGHOC
{
    class LopDungChung
    {
        string chuoiketnoi = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Tien Tai\Documents\HocLapTrinhC#\QUANLYPHONGHOC\QUANLYPHONGHOC\DataBase\QuanLy.mdf;Integrated Security=True";
        SqlConnection conn;

        public LopDungChung()
        {
            conn = new SqlConnection(chuoiketnoi);
        }

        public void Mo()
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
        }

        public void Dong()
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Close();
            }
        }

        public int ThemSuaXoa(string sql)
        {
            SqlCommand comm = new SqlCommand(sql, conn);
            Mo();
            int ketqua = comm.ExecuteNonQuery();
            Dong();
            return ketqua;
        }

        public DataTable LayBang(string sql)
        {
            SqlDataAdapter data = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            data.Fill(dt);
            return dt;
        }
    }
}
