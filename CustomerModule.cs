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
    public partial class CustomerModule : Form
    {
        SqlCommand sqlcommand = new SqlCommand();
        dbConnect dbconnect = new dbConnect();
        String title = "Rồm Pet Clinic System";
        bool check = false;
        public int cid = 0;
        Customer customer;
        public CustomerModule(Customer cust)
        {
            InitializeComponent();
            customer = cust;
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonSaveCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                checkField();
                if (check)
                {
                    if (MessageBox.Show("Bạn có muốn đăng ký cho khách hàng này?", "Đăng Ký Khách Hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        sqlcommand = new SqlCommand("INSERT INTO tbCustomer (customerid,name,phone,namepet,colorhair,weight,note,address)VALUES(@customerid,@name,@phone,@namepet,@colorhair,@weight,@note,@address)", dbconnect.connect());
                        sqlcommand.Parameters.AddWithValue("@customerid", comboAniCustomer.SelectedValue);
                        sqlcommand.Parameters.AddWithValue("@name", textHoTenCustomer.Text);
                        sqlcommand.Parameters.AddWithValue("@phone", textPhoneCustomer.Text);
                        sqlcommand.Parameters.AddWithValue("@namepet", textThuCungCustomer.Text);
                        sqlcommand.Parameters.AddWithValue("@colorhair", textHairColor.Text);
                        sqlcommand.Parameters.AddWithValue("@weight", textWeight.Text);
                        sqlcommand.Parameters.AddWithValue("@note", textNote.Text);
                        sqlcommand.Parameters.AddWithValue("@address", textDiaChi.Text);

                        dbconnect.open();
                        sqlcommand.ExecuteNonQuery();
                        dbconnect.close();
                        MessageBox.Show("Khách hàng đã được tạo thành công", title);
                        check = false;
                        clear();
                        
                    }
                }
                customer.loadCustomer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title);
            }
        }

        private void buttonUpdateCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                checkField();
                if (check)
                {
                    if (MessageBox.Show("Bạn có muốn sửa thông tin cho khách hàng này?", "Sửa Thông Tin Khách Hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        sqlcommand = new SqlCommand("UPDATE tbCustomer SET customerid=@customerid,name=@name,phone=@phone,namepet=@namepet,colorhair=@colorhair,weight=@weight,note=@note,address=@address WHERE id=@id", dbconnect.connect());
                        sqlcommand.Parameters.AddWithValue("@id", labelCid.Text);
                        sqlcommand.Parameters.AddWithValue("@customerid", comboAniCustomer.SelectedValue);
                        sqlcommand.Parameters.AddWithValue("@name", textHoTenCustomer.Text);
                        sqlcommand.Parameters.AddWithValue("@phone", textPhoneCustomer.Text);
                        sqlcommand.Parameters.AddWithValue("@namepet", textThuCungCustomer.Text);
                        sqlcommand.Parameters.AddWithValue("@colorhair", textHairColor.Text);
                        sqlcommand.Parameters.AddWithValue("@weight", textWeight.Text);
                        sqlcommand.Parameters.AddWithValue("@note", textNote.Text);
                        sqlcommand.Parameters.AddWithValue("@address", textDiaChi.Text);

                        dbconnect.open();
                        sqlcommand.ExecuteNonQuery();
                        dbconnect.close();
                        MessageBox.Show("Dữ liệu của khách hàng đã được cập nhật thành công", title);
                        clear();
                        this.Dispose();

                    }
                }
                customer.loadCustomer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title);
            }
        }

        private void buttonCancelCustomer_Click(object sender, EventArgs e)
        {

        }
        private void CustomerModule_Load(object sender, EventArgs e)
        {
            comboAniCustomer.DataSource = animalType();
            comboAniCustomer.DisplayMember = "name";
            comboAniCustomer.ValueMember = "id";
            if (cid > 0)
                comboAniCustomer.SelectedValue = cid;
        }
        public DataTable animalType ()
        {
            sqlcommand = new SqlCommand("SELECT * FROM tbAnimalType",dbconnect.connect());
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();
            adapter.SelectCommand = sqlcommand;
            adapter.Fill(dataTable);
            return dataTable;
        }

        public void clear()
        {
            textHoTenCustomer.Clear();
            textPhoneCustomer.Clear();
            textThuCungCustomer.Clear();
            comboAniCustomer.SelectedIndex = 0;
            buttonSaveCustomer.Enabled = true;
            buttonUpdateCustomer.Enabled = false;
        }

        public void checkField()
        {
            if (textWeight.Text == "" || textHoTenCustomer.Text == "" || textPhoneCustomer.Text == "" || textThuCungCustomer.Text == "")
            {
                MessageBox.Show("Hãy điền đầy đủ thông tin!", "Warning");
                return; // return to the data field and form
            }
            check = true;
        }

    }
}
