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
    public partial class Product : Form
    {
        SqlCommand sqlcommand = new SqlCommand();
        dbConnect dbconnect = new dbConnect();
        SqlDataReader dr;
        String title = "Rồm Pet Clinic System";
        public Product()
        {
            InitializeComponent();
            loadProduct();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProductModule module = new ProductModule(this);
            module.buttonUpdate.Enabled = false;
            module.ShowDialog();
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvProduct.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                //to sent employer data to the customer module 
                ProductModule module = new ProductModule(this);
                module.labelPid.Text = dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
                module.textNameProduct.Text = dgvProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
                module.pid = productIdbyName(dgvProduct.Rows[e.RowIndex].Cells[3].Value.ToString());

                module.buttonSave.Enabled = false;
                module.ShowDialog();

            }
            else if (colName == "Delete") // if you want to delete the record to click the delete icon on the datagridview
            {
                try
                {
                    if (MessageBox.Show("Bạn có muốn xoá dữ liệu hàng hoá này?", "Xoá Dữ Liệu Hàng Hoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        sqlcommand = new SqlCommand("DELETE FROM tbProduct WHERE id LIKE'" + dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", dbconnect.connect());
                        dbconnect.open();
                        sqlcommand.ExecuteNonQuery();
                        dbconnect.close();
                        MessageBox.Show("Dữ liệu hàng hoá đã được xoá thành công!", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, title);
                }
            }
            loadProduct();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            loadProduct();
        }

        public void loadProduct()
        {
            try
            {
                int i = 0; // to show number for customer list
                dgvProduct.Rows.Clear();
                sqlcommand = new SqlCommand("SELECT P.id,P.name,A.name,price FROM tbProduct AS P INNER JOIN tbProductType AS A ON P.pid = A.id WHERE CONCAT (P.name,A.name) LIKE '%" + txtSearch.Text + "%'", dbconnect.connect());
                dbconnect.open();
                dr = sqlcommand.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    // to add data to the datagridview from the database
                    dgvProduct.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
                }
                dbconnect.close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title);
            }
        }

        public int productIdbyName(string str)
        {
            int i = 0;
            sqlcommand = new SqlCommand("SELECT id FROM tbProductType WHERE name LIKE '" + str + "' ", dbconnect.connect());
            dbconnect.open();
            dr = sqlcommand.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                i = int.Parse(dr["id"].ToString());
            }
            dbconnect.close();
            return i;
        }

        
    }
}
