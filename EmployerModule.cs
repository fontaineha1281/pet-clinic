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
    public partial class EmployerModule : Form
    {
        SqlCommand sqlcommand = new SqlCommand();
        dbConnect dbconnect = new dbConnect();
        String title = "Rồm Pet Clinic System";
        bool check = false;
        Employer employer;
        public EmployerModule(Employer emp)
        {
            InitializeComponent();
            employer = emp;
            comboRole.SelectedIndex = 1;
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
                    if (MessageBox.Show("Bạn có muốn đăng ký cho nhân viên này?", "Đăng Ký Nhân Viên", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        sqlcommand = new SqlCommand("INSERT INTO tbEmployer(name,phone,address,dateofbirth,gender,role,salary,password)VALUES(@name,@phone,@address,@dateofbirth,@gender,@role,@salary,@password)", dbconnect.connect());
                        sqlcommand.Parameters.AddWithValue("@name", textHoTen.Text);
                        sqlcommand.Parameters.AddWithValue("@phone", textPhone.Text);
                        sqlcommand.Parameters.AddWithValue("@address", textAddress.Text);
                        sqlcommand.Parameters.AddWithValue("@dateofbirth", dateBirth.Value);
                        sqlcommand.Parameters.AddWithValue("@gender", buttonMale.Checked ? "Nam" : "Nữ");
                        sqlcommand.Parameters.AddWithValue("@role", comboRole.Text);
                        sqlcommand.Parameters.AddWithValue("@salary", textSalary.Text);
                        sqlcommand.Parameters.AddWithValue("@password", textPass.Text);

                        dbconnect.open();
                        sqlcommand.ExecuteNonQuery();
                        dbconnect.close();
                        MessageBox.Show("Nhân viên đã được tạo thành công", title);
                        clear();
                        check = false;
                        employer.loadEmployer();
                    }
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
                checkField();
                if (check)
                {
                    if (MessageBox.Show("Bạn có muốn cập nhật thông tin cho nhân viên này?", "Cập Nhật Thông Tin Nhân Viên", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        sqlcommand = new SqlCommand("UPDATE tbEmployer SET name=@name,phone=@phone,address=@address,dateofbirth=@dateofbirth,gender=@gender,role=@role,salary=@salary,password=@password WHERE id=@id", dbconnect.connect());
                        sqlcommand.Parameters.AddWithValue("@id", labelEid.Text);
                        sqlcommand.Parameters.AddWithValue("@name", textHoTen.Text);
                        sqlcommand.Parameters.AddWithValue("@phone", textPhone.Text);
                        sqlcommand.Parameters.AddWithValue("@address", textAddress.Text);
                        sqlcommand.Parameters.AddWithValue("@dateofbirth", dateBirth.Value);
                        sqlcommand.Parameters.AddWithValue("@gender", buttonMale.Checked ? "Nam" : "Nữ");
                        sqlcommand.Parameters.AddWithValue("@role", comboRole.Text);
                        sqlcommand.Parameters.AddWithValue("@salary", textSalary.Text);
                        sqlcommand.Parameters.AddWithValue("@password", textPass.Text);

                        dbconnect.open();
                        sqlcommand.ExecuteNonQuery();
                        dbconnect.close();
                        MessageBox.Show("Nhân viên đã được tạo thành công", title);
                        clear();
                        this.Dispose();
                        employer.loadEmployer();
                    }
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
            buttonUpdate.Enabled = false;
            buttonSave.Enabled = true;
        }

         private void textSalary_KeyPress(object sender, KeyPressEventArgs e)
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

        public void clear()
        {
            textHoTen.Clear();
            textAddress.Clear();
            textPhone.Clear();
            textSalary.Clear();
            textPass.Clear();
            dateBirth.Value = DateTime.Now;
            comboRole.SelectedIndex = 1; //default choose
        }


        public void checkField()
        {
            if (textAddress.Text == "" || textHoTen.Text == "" || textPhone.Text == "" || textSalary.Text == "")
            {
                MessageBox.Show("Hãy điền đầy đủ thông tin", "Warning");
                return; // return to the data field and form
            }

            if (checkAge(dateBirth.Value) < 18)
            {
                MessageBox.Show("Nhân viên phải trên 18 tuổi", "Warning");
                return;
            }
            check = true;
        }


        private static int checkAge(DateTime dateofBirth)
        {
            int age = DateTime.Now.Year - dateofBirth.Year;
            if (DateTime.Now.DayOfYear < dateofBirth.DayOfYear)
                age = age - 1;
            return age;
        }
    }
}
