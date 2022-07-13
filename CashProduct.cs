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
    public partial class CashProduct : Form
    {
        SqlCommand sqlcommand = new SqlCommand();
        dbConnect dbconnect = new dbConnect();
        SqlDataReader dr;
        Cash cash;
        String title = "Rồm Pet Clinic System";
        public CashProduct(Cash cashform)
        {
            InitializeComponent();
            cash = cashform;
            loadProduct();
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvProduct.Columns[e.ColumnIndex].Name;
            if (colName == "Choose")
            {
                cash.customerId = int.Parse(dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString());
                cash.productTypeId = int.Parse(dgvProduct.Rows[e.RowIndex].Cells[2].Value.ToString());
            }
            else return;
            this.Dispose();
            cash.panelCash.Height = 1;
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            loadProduct();
        }

        public void loadProduct()
        {
            try
            {
                int i = 0; // to show number for customer list
                dgvProduct.Rows.Clear();
                sqlcommand = new SqlCommand("SELECT P.id,P.name,A.name,price FROM tbProduct AS P INNER JOIN tbProductType AS A ON P.pid = A.id WHERE CONCAT (P.name,A.name) LIKE '%" + textSearch.Text + "%'", dbconnect.connect());
                dbconnect.open();
                dr = sqlcommand.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    dgvProduct.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
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
