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
    public partial class Payment : Form
    {
        SqlCommand sqlcommand = new SqlCommand();
        dbConnect dbconnect = new dbConnect();
        SqlDataReader dr;
        String title = "Rồm Pet Clinic System";
        Cash cash;
        public Payment(Cash cashform)
        {
            InitializeComponent();
            cash = cashform;
        }

        private void txtCash_TextChanged(object sender, EventArgs e)
        {
            double charge;
            try
            {
                if (double.Parse(textGiamGia.Text) > 0)
                {
                    //double giamgia = double.Parse(txtSale.Text) + (double.Parse(txtSale.Text) * double.Parse(textGiamGia.Text) / 100);
                    charge = double.Parse(txtCash.Text) - double.Parse(txtSale.Text) + (double.Parse(txtSale.Text) * double.Parse(textGiamGia.Text) / 100); 
                }
                else
                {
                    charge = double.Parse(txtCash.Text) - double.Parse(txtSale.Text);
                }
                txtChange.Text = charge.ToString("#,##0.00");
            }
            catch (Exception)
            {
                txtChange.Text = "0.00";
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (double.Parse(txtChange.Text) < 0 || txtCash.Text.Equals(""))
                {
                    MessageBox.Show("Hãy nhập đúng số tiền", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    double price = double.Parse(cash.lblTotal.Text);
                    for (int i = 0; i < cash.dgvCash.Rows.Count; i++)
                    {
                        dbconnect.executeQuerry("UPDATE tbCash SET status='Sold',total='" + cash.dgvCash.Rows[i].Cells[7].Value.ToString() + "' WHERE id='" + cash.dgvCash.Rows[i].Cells[1].Value.ToString() + "'");
                        string qualityExec = "UPDATE tbService SET quantity = quantity - " + int.Parse(cash.dgvCash.Rows[i].Cells[5].Value.ToString()) + " WHERE id LIKE " + cash.dgvCash.Rows[i].Cells[2].Value.ToString() + "";
                        dbconnect.executeQuerry(qualityExec); 
                        /*
                        if (price > 100000.00)
                        {
                            dbconnect.executeQuerry("UPDATE tbCustomer SET point += " + 1 + " WHERE id = '" + cash.customerId + "'");
                        }    
                        */
                    }
                    cash.loadCash();
                    this.Dispose();
                    cash.btnAddCustomer.Enabled = true;
                    cash.buttonService.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title);
            }
        }

        private void Payment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonEnter.PerformClick();// action click enter button
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }
    }
}
