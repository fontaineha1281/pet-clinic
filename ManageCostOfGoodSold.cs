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
    public partial class ManageCostOfGoodSold : Form
    {
        SqlCommand sqlcommand = new SqlCommand();
        dbConnect dbconnect = new dbConnect();
        String title = "Rồm Pet Clinic System";
        Setting setting;
        public ManageCostOfGoodSold(Setting set)
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
                if (MessageBox.Show("Bạn có muốn đăng ký cho giá vốn hàng bán này?", "Đăng Ký Giá Vốn Hàng Bán", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sqlcommand = new SqlCommand("INSERT INTO tbCostGood(costname,cost,date)VALUES(@costname,@cost,@date)", dbconnect.connect());
                    sqlcommand.Parameters.AddWithValue("@costname", textNameCost.Text);
                    sqlcommand.Parameters.AddWithValue("@cost", textCostGood.Text);
                    sqlcommand.Parameters.AddWithValue("@date", dateCostGood.Value);
                    dbconnect.open();
                    sqlcommand.ExecuteNonQuery();
                    dbconnect.close();
                    MessageBox.Show("Giá vốn cửa hàng đã được tạo thành công", title);
                    clear();
                    setting.loadCostGood();
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
                if (MessageBox.Show("Bạn có muốn sửa thông tin cho giá vốn hàng hoá này?", "Sửa Thông Tin Giá Vốn", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sqlcommand = new SqlCommand("UPDATE tbCostGood SET costname=@costname,cost=@cost,date=@date WHERE id=@id", dbconnect.connect());
                    sqlcommand.Parameters.AddWithValue("@id", labelCid.Text);
                    sqlcommand.Parameters.AddWithValue("@costname", textNameCost.Text);
                    sqlcommand.Parameters.AddWithValue("@cost", textCostGood.Text);
                    sqlcommand.Parameters.AddWithValue("@date", dateCostGood.Value);

                    dbconnect.open();
                    sqlcommand.ExecuteNonQuery();
                    dbconnect.close();
                    MessageBox.Show("Giá vốn hàng hoá đang chọn đã được sửa thông tin thành công", title);
                    clear();
                    setting.loadCostGood();
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
            textNameCost.Clear();
            textCostGood.Clear();
            dateCostGood.Value = DateTime.Now;
            buttonSave.Enabled = true;
            buttonUpdate.Enabled = false;
        }

        private void textCostGood_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
