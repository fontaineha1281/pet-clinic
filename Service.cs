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
    public partial class Service : Form
    {
        SqlCommand sqlcommand = new SqlCommand();
        dbConnect dbconnect = new dbConnect();
        SqlDataReader dr;
        String title = "Rồm Pet Clinic System";
        public Service()
        {
            InitializeComponent();
            loadService();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ServiceModule module = new ServiceModule(this);
            module.buttonUpdate.Enabled = true;
            module.ShowDialog();
        }
        private void dgvService_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvService.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                ServiceModule module = new ServiceModule(this);
                module.labelSid.Text = dgvService.Rows[e.RowIndex].Cells[1].Value.ToString();
                module.textNameService.Text = dgvService.Rows[e.RowIndex].Cells[2].Value.ToString();
                module.textTypeService.Text = dgvService.Rows[e.RowIndex].Cells[3].Value.ToString();
                module.comboService.Text = dgvService.Rows[e.RowIndex].Cells[4].Value.ToString();
                module.textQuality.Text = dgvService.Rows[e.RowIndex].Cells[5].Value.ToString();
                module.textPrice.Text = dgvService.Rows[e.RowIndex].Cells[6].Value.ToString();
                module.buttonSave.Enabled = false;
                module.ShowDialog();
            }
            else if (colName == "Delete")
            {
                try
                {
                    if (MessageBox.Show("Bạn muốn xoá thông tin về dịch vụ này?", "Xoá Thông Tin Dịch Vụ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        sqlcommand = new SqlCommand("DELETE FROM tbService WHERE id LIKE'" + dgvService.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", dbconnect.connect());
                        dbconnect.open();
                        sqlcommand.ExecuteNonQuery();
                        dbconnect.close();
                        MessageBox.Show("Dữ liệu đã được xoá thành công!", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, title);
                }
            }
            loadService();
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
                sqlcommand = new SqlCommand("SELECT * FROM tbService WHERE CONCAT (name,type,category) LIKE '%" + txtSearchCustomer.Text + "%'", dbconnect.connect());
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
