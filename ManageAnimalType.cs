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
    public partial class ManageAnimalType : Form
    {
        SqlCommand sqlcommand = new SqlCommand();
        dbConnect dbconnect = new dbConnect();
        String title = "Rồm Pet Clinic System";
        Setting setting;
        public ManageAnimalType(Setting set)
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
                if (MessageBox.Show("Bạn có muốn đăng ký cho thú cưng này?", "Đăng Ký Thú Cưng", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sqlcommand = new SqlCommand("INSERT INTO tbAnimalType(name,type)VALUES(@name,@type)", dbconnect.connect());
                    sqlcommand.Parameters.AddWithValue("@name", textNameAnimal.Text);
                    sqlcommand.Parameters.AddWithValue("@type", comboRoleAnimal.Text);
                    dbconnect.open();
                    sqlcommand.ExecuteNonQuery();
                    dbconnect.close();
                    MessageBox.Show("Thú cưng đã được tạo thành công", title);
                    clear();
                    setting.loadAnimal();
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
                if (MessageBox.Show("Bạn có muốn sửa thông tin cho thú cưng này?", "Sửa Thông Tin Thú Cưng", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sqlcommand = new SqlCommand("UPDATE tbAnimalType SET name=@name,type=@type WHERE id=@id", dbconnect.connect());
                    sqlcommand.Parameters.AddWithValue("@id", labelAid.Text);
                    sqlcommand.Parameters.AddWithValue("@name", textNameAnimal.Text);
                    sqlcommand.Parameters.AddWithValue("@type", comboRoleAnimal.Text);
                    dbconnect.open();
                    sqlcommand.ExecuteNonQuery();
                    dbconnect.close();
                    MessageBox.Show("Thú cưng đã được sửa thông tin thành công", title);
                    clear();
                    setting.loadAnimal();
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title);
            }
        }
    
        

        private void comboRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        public void clear()
        {
            textNameAnimal.Clear();
            comboRoleAnimal.SelectedIndex = 0;
            buttonSave.Enabled = true;
            buttonUpdate.Enabled = false;
        }
    }
}
