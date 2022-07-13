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
    public partial class ProductModule : Form
    {
        SqlCommand sqlcommand = new SqlCommand();
        dbConnect dbconnect = new dbConnect();
        String title = "Rồm Pet Clinic System";
        bool check = false;
        public int pid = 0;
        Product product;
        public ProductModule(Product prod)
        {
            InitializeComponent();
            product = prod;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                checkField();
                if (check)
                {
                    if (MessageBox.Show("Bạn có muốn đăng ký cho hàng hoá này?", "Đăng Ký Hàng Hoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        sqlcommand = new SqlCommand("INSERT INTO tbProduct (pid,name,price)VALUES(@pid,@name,@price)", dbconnect.connect());
                        sqlcommand.Parameters.AddWithValue("@pid", comboTypeProduct.SelectedValue);
                        sqlcommand.Parameters.AddWithValue("@name", textNameProduct.Text);
                        sqlcommand.Parameters.AddWithValue("@price", textPriceProduct.Text);

                        dbconnect.open();
                        sqlcommand.ExecuteNonQuery();
                        dbconnect.close();
                        MessageBox.Show("Hàng hoá đã được tạo thành công", title);
                        check = false;
                        clear();

                    }
                }
                product.loadProduct();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void ProductModule_Load(object sender, EventArgs e)
        {
            comboTypeProduct.DataSource = typeProduct();
            comboTypeProduct.DisplayMember = "name";
            comboTypeProduct.ValueMember = "id";
            if (pid > 0)
                comboTypeProduct.SelectedValue = pid;
        }

        public DataTable typeProduct()
        {
            sqlcommand = new SqlCommand("SELECT * FROM tbProductType", dbconnect.connect());
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();
            adapter.SelectCommand = sqlcommand;
            adapter.Fill(dataTable);
            return dataTable;
        }

        public void clear()
        {
            textNameProduct.Clear();
            textPriceProduct.Clear();
            comboTypeProduct.SelectedIndex = 0;
            buttonSave.Enabled = true;
            buttonUpdate.Enabled = false;
        }

        public void checkField()
        {
            if (textNameProduct.Text == "" || textPriceProduct.Text == "" )
            {
                MessageBox.Show("Hãy điền đầy đủ thông tin!", "Warning");
                return; // return to the data field and form
            }
            check = true;
        }



    }
}
