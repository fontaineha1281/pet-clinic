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
    public partial class Customer : Form
    {
        SqlCommand sqlcommand = new SqlCommand();
        dbConnect dbconnect = new dbConnect();
        SqlDataReader dr;
        String title = "Rồm Pet Clinic System";
        //private static string ID;
        public Customer()
        {
            InitializeComponent();
            loadCustomer();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            CustomerModule module = new CustomerModule(this);
            module.buttonUpdateCustomer.Enabled = false;
            module.ShowDialog();
        }

        /*
        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvCustomer.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                //to sent employer data to the customer module 
                CustomerModule module = new CustomerModule(this);
                module.labelCid.Text = dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
                module.textHoTenCustomer.Text = dgvCustomer.Rows[e.RowIndex].Cells[2].Value.ToString();
                module.textDiaChi.Text= dgvCustomer.Rows[e.RowIndex].Cells[3].Value.ToString();
                module.textPhoneCustomer.Text = dgvCustomer.Rows[e.RowIndex].Cells[4].Value.ToString();
                module.textThuCungCustomer.Text = dgvCustomer.Rows[e.RowIndex].Cells[5].Value.ToString();
                module.cid = animalIdbyName(dgvCustomer.Rows[e.RowIndex].Cells[6].Value.ToString());
                module.textHairColor.Text = dgvCustomer.Rows[e.RowIndex].Cells[7].Value.ToString();
                module.textWeight.Text = dgvCustomer.Rows[e.RowIndex].Cells[8].Value.ToString();
                module.textNote.Text = dgvCustomer.Rows[e.RowIndex].Cells[9].Value.ToString();

                module.buttonSaveCustomer.Enabled = false;
                module.ShowDialog();

            }
            else if (colName == "Delete") // if you want to delete the record to click the delete icon on the datagridview
            {
                try
                {
                    if (MessageBox.Show("Bạn có muốn xoá dữ liệu khách hàng này?", "Xoá Dữ Liệu Khách Hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        sqlcommand = new SqlCommand("DELETE FROM tbCustomer WHERE id LIKE'" + dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", dbconnect.connect());
                        dbconnect.open();
                        sqlcommand.ExecuteNonQuery();
                        dbconnect.close();
                        MessageBox.Show("Dữ liệu khách hàng đã được xoá thành công!", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, title);
                }
            }
            loadCustomer();
        }
        */
        private void txtSearchCustomer_TextChanged(object sender, EventArgs e)
        {
            loadCustomer();
        }

        public void loadCustomer()
        {
            try
            {
                int i = 0; // to show number for customer list
                dgvCustomer.Rows.Clear();
                sqlcommand = new SqlCommand("SELECT C.id,C.name,address,phone,namepet,A.name,colorhair,weight,note FROM tbCustomer AS C INNER JOIN tbAnimalType AS A ON C.customerid = A.id WHERE CONCAT (C.name,namepet) LIKE '%" + txtSearchCustomer.Text + "%'", dbconnect.connect());
                dbconnect.open();
                dr = sqlcommand.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    // to add data to the datagridview from the database
                    dgvCustomer.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString());
                }
                dbconnect.close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title);
            }
        }
        public int animalIdbyName(string str)
        {
            int i = 0;
            sqlcommand = new SqlCommand("SELECT id FROM tbAnimalType WHERE name LIKE '" + str + "' ", dbconnect.connect());
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

        private void dgvCustomer_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

            }
            else
            {
                //ID = dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
                //this.menu.Show(dgvCustomer, e.Location);
                menu.Show(Cursor.Position);
            }
        }

        private void addCus_Click(object sender, EventArgs e)
        {
            CustomerModule module = new CustomerModule(this);
            module.buttonUpdateCustomer.Enabled = false;
            module.ShowDialog();
        }

        private void editCus_Click(object sender, EventArgs e)
        {
                //to sent employer data to the customer module 
                CustomerModule module = new CustomerModule(this);
                module.labelCid.Text = dgvCustomer.CurrentRow.Cells[1].Value.ToString();
                module.textHoTenCustomer.Text = dgvCustomer.CurrentRow.Cells[2].Value.ToString();
                module.textDiaChi.Text = dgvCustomer.CurrentRow.Cells[3].Value.ToString();
                module.textPhoneCustomer.Text = dgvCustomer.CurrentRow.Cells[4].Value.ToString();
                module.textThuCungCustomer.Text = dgvCustomer.CurrentRow.Cells[5].Value.ToString();
                module.cid = animalIdbyName(dgvCustomer.CurrentRow.Cells[6].Value.ToString());
                module.textHairColor.Text = dgvCustomer.CurrentRow.Cells[7].Value.ToString();
                module.textWeight.Text = dgvCustomer.CurrentRow.Cells[8].Value.ToString();
                module.textNote.Text = dgvCustomer.CurrentRow.Cells[9].Value.ToString();
                module.buttonSaveCustomer.Enabled = false;
                module.ShowDialog();
            }

        private void deleteCus_Click(object sender, EventArgs e)
        {

                if (MessageBox.Show("Bạn có muốn xoá dữ liệu khách hàng này?", "Xoá Dữ Liệu Khách Hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sqlcommand = new SqlCommand("DELETE FROM tbCustomer WHERE id LIKE'" + dgvCustomer.CurrentRow.Cells[1].Value.ToString() + "'", dbconnect.connect());
                    dbconnect.open();
                    sqlcommand.ExecuteNonQuery();
                    dbconnect.close();
                    MessageBox.Show("Dữ liệu khách hàng đã được xoá thành công!", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            loadCustomer();
        }

        private void xemHàngHoáKHĐãMuaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }     
 }



