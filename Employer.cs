using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Pet_Clinic
{
    public partial class Employer : Form
    {
        SqlCommand cm = new SqlCommand();
        dbConnect dbconnect = new dbConnect();
        SqlDataReader dr;
        String title = "Rồm Pet Clinic System";
        public Employer()
        {
            InitializeComponent();
            loadEmployer();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            EmployerModule module = new EmployerModule(this);
            module.buttonUpdate.Enabled = false;
            module.ShowDialog();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            loadEmployer();
        }
        private void dgvEmployer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvEmployer.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                EmployerModule module = new EmployerModule(this);
                module.labelEid.Text = dgvEmployer.Rows[e.RowIndex].Cells[1].Value.ToString();
                module.textHoTen.Text = dgvEmployer.Rows[e.RowIndex].Cells[2].Value.ToString();
                module.textPhone.Text = dgvEmployer.Rows[e.RowIndex].Cells[3].Value.ToString();
                module.textAddress.Text = dgvEmployer.Rows[e.RowIndex].Cells[4].Value.ToString();
                module.dateBirth.Text = dgvEmployer.Rows[e.RowIndex].Cells[5].Value.ToString();
                module.buttonMale.Checked = dgvEmployer.Rows[e.RowIndex].Cells[6].Value.ToString() == "Nam" ? true : false;//like if condition
                module.comboRole.Text = dgvEmployer.Rows[e.RowIndex].Cells[7].Value.ToString();
                module.textSalary.Text = dgvEmployer.Rows[e.RowIndex].Cells[8].Value.ToString();
                module.textPass.Text = dgvEmployer.Rows[e.RowIndex].Cells[9].Value.ToString();
                module.buttonSave.Enabled = false;
                module.ShowDialog();
            }
            else if (colName == "Delete") {
                try
                {
                    if (MessageBox.Show("Bạn có muốn xoá nhân viên này?", "Xoá nhân viên", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cm = new SqlCommand("DELETE FROM tbEmployer WHERE id LIKE'" + dgvEmployer.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", dbconnect.connect());
                        dbconnect.open();
                        cm.ExecuteNonQuery();
                        dbconnect.close();
                        MessageBox.Show("Xoá thành công nhân viên!", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, title);
                }
            }
            loadEmployer();
        }
        public void loadEmployer()
        {
            try
            {
                int i = 0; // to show number for employer list
                dgvEmployer.Rows.Clear();
                cm = new SqlCommand("SELECT * FROM tbEmployer WHERE CONCAT (name,address,role) LIKE '%" + txtSearch.Text + "%'", dbconnect.connect());
                dbconnect.open();
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    // to add data to the datagridview from the database
                    dgvEmployer.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), DateTime.Parse(dr[4].ToString()).ToShortDateString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString());
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
