using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pet_Clinic
{
    public partial class CashService : Form
    {
        SqlCommand sqlcommand = new SqlCommand();
        dbConnect dbconnect = new dbConnect();
        SqlDataReader dr;
        Cash cash;
        String title = "Rồm Pet Clinic System";
        public CashService(Cash cashform)
        {
            InitializeComponent();
            cash = cashform;
            loadService();
        }

        private void dgvService_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCash_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow datagrid in dgvService.Rows)
            {
                bool checkbox = Convert.ToBoolean(datagrid.Cells["Choose"].Value);
                if (checkbox)
                {
                    try
                    {
                        sqlcommand = new SqlCommand("IF NOT EXISTS (SELECT * FROM tbCash WHERE sid=@sid AND mahoadon=@mahoadon) INSERT INTO tbCash(mahoadon,cid,sid,aid,quantity,price,date) VALUES(@mahoadon,@cid,@sid,@aid,@quantity,@price,@date)", dbconnect.connect());
                        sqlcommand.Parameters.AddWithValue("@mahoadon", cash.lblTransno.Text);
                        sqlcommand.Parameters.AddWithValue("@cid", cash.customerId);
                        sqlcommand.Parameters.AddWithValue("@sid", datagrid.Cells[1].Value.ToString());
                        sqlcommand.Parameters.AddWithValue("@aid", cash.animalTypeId);
                        sqlcommand.Parameters.AddWithValue("@quantity", 1);
                        sqlcommand.Parameters.AddWithValue("@price", Convert.ToDouble(datagrid.Cells[6].Value.ToString()));
                        sqlcommand.Parameters.AddWithValue("@date", DateTime.Now);

                        dbconnect.open();
                        sqlcommand.ExecuteNonQuery();
                        dbconnect.close();

                        cash.buttonCash.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, title);
                    }
                }
            }
            this.Dispose();
            cash.panelCash.Height = 1;
            cash.loadCash();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            loadService();
        }

        public void loadService()
        {
            try
            {
                int i = 0; // to show number for service list
                dgvService.Rows.Clear();
                sqlcommand = new SqlCommand("SELECT * FROM tbService WHERE CONCAT (name,type,category) LIKE '%" + txtSearch.Text + "%'", dbconnect.connect());
                dbconnect.open();
                dr = sqlcommand.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    // to add data to the datagridview from the database
                    dgvService.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
                }
                dbconnect.close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title);
            }
        }

       
    }
}
