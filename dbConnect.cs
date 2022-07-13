using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Pet_Clinic
{
    class dbConnect
    {
        SqlCommand cm = new SqlCommand();
        private SqlConnection sqlconnect = new SqlConnection(@"Data Source=FONTAINE;Initial Catalog=databasePetClinic;Integrated Security=True");
        
        public SqlConnection connect()
        {
            return sqlconnect;
        }
        public void open()
        {
            if (sqlconnect.State == System.Data.ConnectionState.Closed)
            {
                sqlconnect.Open();
            }
        }
        public void close()
        {
            if (sqlconnect.State == System.Data.ConnectionState.Open)
            {
                sqlconnect.Close();
            }
        }
        public void executeQuerry (string sql)
        {
            try
            {
                open();
                cm = new SqlCommand(sql,connect());
                cm.ExecuteNonQuery();
                close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Rồm Pet Clinic System");
            }
        }
    }
}
