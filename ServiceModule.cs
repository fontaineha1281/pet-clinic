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
    public partial class ServiceModule : Form
    {
        SqlCommand sqlcommand = new SqlCommand();
        dbConnect dbconnect = new dbConnect();
        SqlDataReader dr;
        String title = "Rồm Pet Clinic System";
        Service service;
        public ServiceModule(Service ser)
        {
            InitializeComponent();
            service = ser;
        }

        private void textPriceService_KeyPress(object sender, KeyPressEventArgs e)
        {
            // only allow digit number
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal 
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (textNameService.Text == "" || textTypeService.Text == "")
                {
                    MessageBox.Show("Hãy điền đầy đủ thông tin!", "Warning");
                    return; // return to the data field and form
                }
                if (MessageBox.Show("Bạn có muốn thêm dịch vụ này vào danh sách?", "Đăng Ký Dịch Vụ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sqlcommand = new SqlCommand("INSERT INTO tbService(name,type,category,quantity,price)VALUES(@name,@type,@category,@quantity,@price)", dbconnect.connect());
                    sqlcommand.Parameters.AddWithValue("@name", textNameService.Text);
                    sqlcommand.Parameters.AddWithValue("@type", textTypeService.Text);
                    sqlcommand.Parameters.AddWithValue("@category", comboService.Text);
                    sqlcommand.Parameters.AddWithValue("@quantity", int.Parse(textQuality.Text));
                    sqlcommand.Parameters.AddWithValue("@price",double.Parse(textPrice.Text));

                    dbconnect.open();// to open connection
                    sqlcommand.ExecuteNonQuery();
                    dbconnect.close();// to close connection
                    MessageBox.Show("Dịch vụ được thêm vào danh sách thành công!", title);
                    clear();//to clear data field, after data inserted into the database
                    service.loadService();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (textNameService.Text == "" || textTypeService.Text == "")
                {
                    MessageBox.Show("Hãy điền đầy đủ thông tin!", "Warning");
                    return; // return to the data field and form
                }
                if (MessageBox.Show("Bạn có muốn sửa thông tin dịch vụ này?", "Sửa thông tin dịch vụ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sqlcommand = new SqlCommand("UPDATE tbService SET name=@name, type=@type,category=@category,quantity=@quantity ,price=@price WHERE id=@id", dbconnect.connect());
                    sqlcommand.Parameters.AddWithValue("@id", labelSid.Text);
                    sqlcommand.Parameters.AddWithValue("@name", textNameService.Text);
                    sqlcommand.Parameters.AddWithValue("@type", textTypeService.Text);
                    sqlcommand.Parameters.AddWithValue("@category", comboService.Text);
                    sqlcommand.Parameters.AddWithValue("@quantity", int.Parse(textQuality.Text));
                    sqlcommand.Parameters.AddWithValue("@price", double.Parse(textPrice.Text));

                    dbconnect.open();// to open connection
                    sqlcommand.ExecuteNonQuery();
                    dbconnect.close();// to close connection
                    MessageBox.Show("Thông tin dịch vụ được sửa thành công!", title);
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            clear();
        }

        public void clear()
        {
            textNameService.Clear();
            textTypeService.Clear();
            textPrice.Clear();
            textQuality.Clear();
            comboService.SelectedIndex = 0;
            buttonSave.Enabled = true;
            buttonUpdate.Enabled = false;
        }

        private void textQuality_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
