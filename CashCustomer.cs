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
    public partial class CashCustomer : Form
    {
        SqlCommand sqlcommand = new SqlCommand();
        dbConnect dbconnect = new dbConnect();
        SqlDataReader dr;
        Cash cash;
        String title = "Rồm Pet Clinic System";
        public CashCustomer(Cash cashform)
        {
            InitializeComponent();
            cash = cashform;
            loadCustomer();
        }

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvCustomer.Columns[e.ColumnIndex].Name;
            if (colName == "Choose")
            {
                cash.customerId = int.Parse(dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString());
                cash.animalTypeId = int.Parse(dgvCustomer.Rows[e.RowIndex].Cells[2].Value.ToString());
                
            }
            else return;
            this.Dispose();
            cash.panelCash.Height = 1;
        }

        private void textSearchCustomer_TextChanged(object sender, EventArgs e)
        {
            loadCustomer();
        }
        public void loadCustomer()
        {
            try
            {
                int i = 0; // to show number for customer list
                dgvCustomer.Rows.Clear();
                sqlcommand = new SqlCommand("SELECT * FROM tbCustomer WHERE CONCAT (name,phone) LIKE '%" + textSearchCustomer.Text + "%'", dbconnect.connect());
                dbconnect.open();
                dr = sqlcommand.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    dgvCustomer.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
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
