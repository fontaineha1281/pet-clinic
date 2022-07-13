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
    public partial class ManageProductType : Form
    {
        SqlCommand sqlcommand = new SqlCommand();
        dbConnect dbconnect = new dbConnect();
        String title = "Rồm Pet Clinic System";
        Setting setting;
        public ManageProductType(Setting set)
        {
            InitializeComponent();
            setting = set;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn đăng ký cho hàng hoá này?", "Đăng Ký Hàng Hoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sqlcommand = new SqlCommand("INSERT INTO tbProductType(name,type)VALUES(@name,@type)", dbconnect.connect());
                    sqlcommand.Parameters.AddWithValue("@name", textNameProduct.Text);
                    sqlcommand.Parameters.AddWithValue("@type", comboRoleAnimal.Text);
                    dbconnect.open();
                    sqlcommand.ExecuteNonQuery();
                    dbconnect.close();
                    MessageBox.Show("Hàng hoá đã được tạo thành công", title);
                    clear();
                    setting.loadProduct();
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

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn sửa thông tin cho hàng hoá này?", "Sửa Thông Tin Hàng Hoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sqlcommand = new SqlCommand("UPDATE tbProductType SET name=@name,type=@type WHERE id=@id", dbconnect.connect());
                    sqlcommand.Parameters.AddWithValue("@id", labelPid.Text);
                    sqlcommand.Parameters.AddWithValue("@name", textNameProduct.Text);
                    sqlcommand.Parameters.AddWithValue("@type", comboRoleAnimal.Text);
                    dbconnect.open();
                    sqlcommand.ExecuteNonQuery();
                    dbconnect.close();
                    MessageBox.Show("Hàng hoá đã được sửa thông tin thành công", title);
                    clear();
                    setting.loadProduct();
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title);
            }
        }

        public void clear ()
        {
            textNameProduct.Clear();
            buttonSave.Enabled = true;
            buttonUpdate.Enabled = false;
        }
    }
}
