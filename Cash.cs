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
    public partial class Cash : Form
    {
        SqlConnection cn = new SqlConnection("Data Source=FONTAINE;Initial Catalog=databasePetClinic;Integrated Security=True ");
        SqlCommand sqlcommand = new SqlCommand();
        dbConnect dbconnect = new dbConnect();
        SqlDataReader dr;
        String title = "Rồm Pet Clinic System";
        public int customerId = 0, animalTypeId = 0,productTypeId = 0;
        public Cash()
        {
            InitializeComponent();
            getMaHoaDon();
            loadCash();
        }
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            openChildForm(new CashCustomer(this));
            buttonService.Enabled = true;
        }

        private void buttonService_Click(object sender, EventArgs e)
        {
            openChildForm(new CashService(this));
            btnAddCustomer.Enabled = false;
        }
        private void buttonCash_Click(object sender, EventArgs e)
        {
            Payment module = new Payment(this);
            module.txtSale.Text = lblTotal.Text;
            module.ShowDialog();
        }
        private Form activeForm = null;
        public void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelCash.Height = 200;
            panelCash.Controls.Add(childForm);
            panelCash.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void dgvCash_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        string colName = dgvCash.Columns[e.ColumnIndex].Name;
        removeitem:
            if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this cash?", "Delete Cash", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dbconnect.executeQuerry("DELETE FROM tbCash WHERE id LIKE '" + dgvCash.Rows[e.RowIndex].Cells[1].Value.ToString() + "'");
                    MessageBox.Show("Cash record has been successfully removed!", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (colName == "Increase")
            {
                int i = checkPqty(dgvCash.Rows[e.RowIndex].Cells[2].Value.ToString());
                if (int.Parse(dgvCash.Rows[e.RowIndex].Cells[5].Value.ToString()) < i)
                {
                    dbconnect.executeQuerry("UPDATE tbCash SET quantity = quantity + " + 1 + " WHERE id LIKE '" + dgvCash.Rows[e.RowIndex].Cells[1].Value.ToString() + "'");
                }
                else
                {
                    MessageBox.Show("Remaining quantity on hand is " + i + "!", "Out of Stock ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (colName == "Decrease")
            {
                if (int.Parse(dgvCash.Rows[e.RowIndex].Cells[5].Value.ToString()) == 1)
                {
                    colName = "Delete";
                    goto removeitem;
                }
                dbconnect.executeQuerry("UPDATE tbCash SET quantity = quantity - " + 1 + " WHERE id LIKE '" + dgvCash.Rows[e.RowIndex].Cells[1].Value.ToString() + "'");
            }
            loadCash();
        }
        public void getMaHoaDon()
        {
            try
            {
                string sdate = DateTime.Now.ToString("yyyyMMdd");
                int count;
                string mahoadon;
                dbconnect.open();
                sqlcommand = new SqlCommand("SELECT TOP 1 mahoadon FROM tbCash WHERE mahoadon LIKE '" + sdate + "%' ORDER BY id DESC", dbconnect.connect());
                dr = sqlcommand.ExecuteReader();
                dr.Read();

                if (dr.HasRows)
                {
                    mahoadon = dr[0].ToString();
                    count = int.Parse(mahoadon.Substring(8, 4));
                    lblTransno.Text = sdate + (count + 1);
                }
                else
                {
                    mahoadon = sdate + "1001";
                    lblTransno.Text = mahoadon;
                }

                dbconnect.close();
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title);
            }
        }


        public void loadCash()
        {
            int i = 0;
            double total = 0;
            String customer = string.Empty;
            dgvCash.Rows.Clear();
            sqlcommand = new SqlCommand("SELECT Cash.id,Cash.sid,Cash.mahoadon,Service.name + ' cho ' + Service.category AS phanloai,Cash.quantity,Cash.price,Cash.total,Cash.date,Customer.name FROM tbCash AS Cash LEFT JOIN tbCustomer AS Customer ON Cash.cid = Customer.id LEFT JOIN tbService AS Service ON Cash.sid = Service.id WHERE status LIKE 'Pending' AND Cash.mahoadon='" + lblTransno.Text+"'",dbconnect.connect());
            dbconnect.open();
            dr = sqlcommand.ExecuteReader();
            while (dr.Read())
            {
                i++;
                customer = dr[8].ToString();
                dgvCash.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString());
                total += double.Parse(dr[6].ToString());
            }
            dr.Close();
            dbconnect.close();
            lblTotal.Text = total.ToString("#,##0.00");
            labelKhachHang.Text = customer;
        }

        public int checkPqty(string sid)
        {
            int i = 0;
            try
            {
                cn.Open();
                sqlcommand = new SqlCommand("SELECT quantity FROM tbService WHERE id LIKE '" + sid + "'", cn);
                i = int.Parse(sqlcommand.ExecuteScalar().ToString());
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, title);
            }
            return i;
        }


    }
}
