using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data.Sql;

namespace QLTN
{
    class DAO
    {
        public static SqlConnection con;
        public static string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuanLyThueNha_BTL;Integrated Security=True";
        public static void OpenConnection()
        {
            con = new SqlConnection();
            con.ConnectionString = connectionString;
            if (con.State == System.Data.ConnectionState.Closed)
                try
                {
                    con.Open();
                    //MessageBox.Show("Mo ket noi thanh cong");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
        }

        public static void CloseConnection()
        {
            if (con.State == System.Data.ConnectionState.Open)
                try
                {
                    con.Close();
                    //MessageBox.Show("Dong ket noi thanh cong");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
        }

        public static bool CheckKeyExit(string sql)
        {
            bool kq = false;

            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            DataTable tbl = new DataTable();
            adapter.Fill(tbl);
            if (tbl.Rows.Count > 0)
            {
                kq = true;
            }
            return kq;
        }
        public static string GetFieldValues(string sql)
        {
            DAO.OpenConnection();
            string ma = "";
            SqlCommand cmd = new SqlCommand(sql, DAO.con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ma = reader.GetValue(0).ToString();
            }
            reader.Close();
            return ma;
        }

        public static void FillCombo(string sql, ComboBox cmb, string ma, string ten)
        {
            SqlDataAdapter adap = new SqlDataAdapter(sql, DAO.con);
            DataTable table = new DataTable();
            adap.Fill(table);
            cmb.DataSource = table;
            cmb.ValueMember = ma;    
            cmb.DisplayMember = ten;   
        }

        public static string ConvertDateTime(string d)
        {
            string[] parts = d.Split('/');
            string dt = String.Format("{1}/{0}/{2}", parts[1], parts[0], parts[2]);
            return dt;
        }

        public static DataTable GetDataToTable(string sql)
        {
            SqlDataAdapter Mydata = new SqlDataAdapter(sql, DAO.con);
            DataTable table = new DataTable();
            Mydata.Fill(table);
            return table;
        }
        public static string ConvertTimeTo24(string hour)
        {
            string h = "";
            switch (hour)
            {
                case "1":
                    h = "13";
                    break;
                case "2":
                    h = "14";
                    break;
                case "3":
                    h = "15";
                    break;
                case "4":
                    h = "16";
                    break;
                case "5":
                    h = "17";
                    break;
                case "6":
                    h = "18";
                    break;
                case "7":
                    h = "19";
                    break;
                case "8":
                    h = "20";
                    break;
                case "9":
                    h = "21";
                    break;
                case "10":
                    h = "22";
                    break;
                case "11":
                    h = "23";
                    break;
                case "12":
                    h = "0";
                    break;
            }
            return h;
        }

        public static string CreateKey(string tiento)
        {
            string key = tiento;
            string[] partsDay;
            partsDay = DateTime.Now.ToShortDateString().Split('/');
            //Ví dụ 07/08/2009
            string d = String.Format("{0}{1}{2}", partsDay[0], partsDay[1], partsDay[2]);
            key = key + d;
            string[] partsTime;
            partsTime = DateTime.Now.ToLongTimeString().Split(':');
            //Ví dụ 7:08:03 PM hoặc 7:08:03 AM
            if (partsTime[2].Substring(3, 2) == "PM")
                partsTime[0] = ConvertTimeTo24(partsTime[0]);
            if (partsTime[2].Substring(3, 2) == "AM")
                if (partsTime[0].Length == 1)
                    partsTime[0] = "0" + partsTime[0];
            //Xóa ký tự trắng và PM hoặc AM
            partsTime[2] = partsTime[2].Remove(2, 3);
            string t;
            t = String.Format("_{0}{1}{2}", partsTime[0], partsTime[1], partsTime[2]);
            key = key + t;
            return key;
        }
        public static void FillDataToCombo(string sql, ComboBox combo, string ValueField, string DisplayField)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            DataTable mytable = new DataTable();
            adapter.Fill(mytable);
            combo.DataSource = mytable;
            combo.ValueMember = ValueField;
            combo.DisplayMember = DisplayField;
        }

        public static void RunSql(string sql)
        {
            SqlCommand cmd;		                // Khai báo đối tượng SqlCommand
            cmd = new SqlCommand();	         // Khởi tạo đối tượng
            cmd.Connection = DAO.con;	  // Gán kết nối
            cmd.CommandText = sql;			  // Gán câu lệnh SQL
            try
            {
                cmd.ExecuteNonQuery();		  // Thực hiện câu lệnh SQL
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();
            cmd = null;
        }

        public static DataTable DocBang(string sql)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Mydata = new SqlDataAdapter();
            Mydata.SelectCommand = new SqlCommand();
            DAO.OpenConnection();
            Mydata.SelectCommand.Connection = con;
            Mydata.SelectCommand.CommandText = sql;
            Mydata.Fill(dt);
            DAO.CloseConnection();
            return dt;
        }


    }
}
