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
using System.IO;

namespace Pet_Clinic
{
    public partial class Setting : Form
    {
        SqlCommand cm = new SqlCommand();
        dbConnect dbconnect = new dbConnect();
        SqlDataReader dr;
        String title = "Rồm Pet Clinic System";
        bool hasdetail = false;
        String imgLocation = "";
        public Setting()
        {
            InitializeComponent();
            loadAnimal();
            loadProduct();
            loadCostGood();
            loadCompany();
        }
        private void txtSearchAnimal_TextChanged(object sender, EventArgs e)
        {
            loadAnimal();
        }
        private void btnAddAnimal_Click(object sender, EventArgs e)
        {
            ManageAnimalType module = new ManageAnimalType(this);
            module.buttonUpdate.Enabled = false;
            module.ShowDialog();
        }
        private void dgvTypeAnimal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvTypeAnimal.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                ManageAnimalType module = new ManageAnimalType(this);
                module.labelAid.Text = dgvTypeAnimal.Rows[e.RowIndex].Cells[1].Value.ToString();
                module.textNameAnimal.Text = dgvTypeAnimal.Rows[e.RowIndex].Cells[2].Value.ToString();
                module.comboRoleAnimal.Text = dgvTypeAnimal.Rows[e.RowIndex].Cells[3].Value.ToString();
                module.buttonSave.Enabled = false;
                module.ShowDialog();
            }
            else if (colName == "Delete")
            {
                try
                {
                    if (MessageBox.Show("Bạn có muốn xoá thú cưng này?", "Xoá Thú Cưng", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cm = new SqlCommand("DELETE FROM tbAnimalType WHERE id LIKE'" + dgvTypeAnimal.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", dbconnect.connect());
                        dbconnect.open();
                        cm.ExecuteNonQuery();
                        dbconnect.close();
                        MessageBox.Show("Xoá thành công thú cưng!", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, title);
                }
            }
            loadAnimal();
        }

        public void loadAnimal()
        {
            try
            {
                int i = 0; // to show number for employer list
                dgvTypeAnimal.Rows.Clear();
                cm = new SqlCommand("SELECT * FROM tbAnimalType WHERE CONCAT (name,type) LIKE '%" + txtSearchAnimal.Text + "%'", dbconnect.connect());
                dbconnect.open();
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    // to add data to the datagridview from the database
                    dgvTypeAnimal.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
                }
                dbconnect.close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title);
            }
        }

        //Start Product
        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            loadProduct();
        }
        private void dgvProductType_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvProductType.Columns[e.ColumnIndex].Name;
            if (colName == "EditProduct")
            {
                ManageProductType module = new ManageProductType(this);
                module.labelPid.Text = dgvProductType.Rows[e.RowIndex].Cells[1].Value.ToString();
                module.textNameProduct.Text = dgvProductType.Rows[e.RowIndex].Cells[2].Value.ToString();
                module.comboRoleAnimal.Text = dgvProductType.Rows[e.RowIndex].Cells[3].Value.ToString();
                module.buttonSave.Enabled = false;
                module.ShowDialog();
            }
            else if (colName == "DeleteProduct")
            {
                try
                {
                    if (MessageBox.Show("Bạn có muốn xoá hàng hoá này?", "Xoá Hàng Hoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cm = new SqlCommand("DELETE FROM tbProductType WHERE id LIKE'" + dgvProductType.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", dbconnect.connect());
                        dbconnect.open();
                        cm.ExecuteNonQuery();
                        dbconnect.close();
                        MessageBox.Show("Xoá hàng hoá thú cưng!", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, title);
                }
            }
            loadProduct();
        }

        public void loadProduct ()
        {
            try
            {
                int i = 0; // to show number for employer list
                dgvProductType.Rows.Clear();
                cm = new SqlCommand("SELECT * FROM tbProductType WHERE CONCAT (name,type) LIKE '%" + txtSearchProduct.Text + "%'", dbconnect.connect());
                dbconnect.open();
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    // to add data to the datagridview from the database
                    dgvProductType.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
                }
                dbconnect.close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title);
            }
        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            ManageProductType module = new ManageProductType(this);
            module.buttonUpdate.Enabled = false;
            module.ShowDialog();
        }

        //End Product

        //Start Cost Of Good Sold
        private void txtSearchCost_TextChanged(object sender, EventArgs e)
        {
            loadCostGood();
        }

        private void buttonAddCost_Click(object sender, EventArgs e)
        {
            ManageCostOfGoodSold module = new ManageCostOfGoodSold(this);
            module.buttonUpdate.Enabled = false;
            module.ShowDialog();
        }

        private void dgvCostGood_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvCostGood.Columns[e.ColumnIndex].Name;
            if (colName == "EditCost")
            {
                ManageCostOfGoodSold module = new ManageCostOfGoodSold(this);
                module.labelCid.Text = dgvCostGood.Rows[e.RowIndex].Cells[1].Value.ToString();
                module.textNameCost.Text = dgvCostGood.Rows[e.RowIndex].Cells[2].Value.ToString();
                module.textCostGood.Text = dgvCostGood.Rows[e.RowIndex].Cells[3].Value.ToString();
                module.dateCostGood.Text = dgvCostGood.Rows[e.RowIndex].Cells[4].Value.ToString();
                module.buttonSave.Enabled = false;
                module.ShowDialog();
            }
            else if (colName == "DeleteCost")
            {
                try
                {
                    if (MessageBox.Show("Bạn có muốn xoá dữ liệu giá vốn hàng bán này?", "Xoá Dữ Liệu Giá Vốn", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cm = new SqlCommand("DELETE FROM tbCostGood WHERE id LIKE'" + dgvCostGood.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", dbconnect.connect());
                        dbconnect.open();
                        cm.ExecuteNonQuery();
                        dbconnect.close();
                        MessageBox.Show("Xoá thành công dữ liệu giá vốn hàng bán!", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, title);
                }
            }
            loadCostGood();
        }
        public void loadCostGood()
        {
            try
            {
                int i = 0; // to show number for employer list
                dgvCostGood.Rows.Clear();
                cm = new SqlCommand("SELECT * FROM tbCostGood WHERE CONCAT (costname,date) LIKE '%" + txtSearchCost.Text + "%'", dbconnect.connect());
                dbconnect.open();
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    // to add data to the datagridview from the database
                    dgvCostGood.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), DateTime.Parse(dr[3].ToString()).ToShortDateString());
                }
                dbconnect.close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title);
            }
        }
        //End Cost Of Good Sold

        //Start Company
        public void loadCompany()
        {
            try
            {
                dbconnect.open();
                cm = new SqlCommand("SELECT * FROM tbCompany", dbconnect.connect());
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    byte[] b = new byte[0];
                    hasdetail = true;
                    textNameCompany.Text = dr["name"].ToString();
                    textAddressCompany.Text = dr["address"].ToString();
                    b = (Byte[])dr["image"];
                    MemoryStream ms = new MemoryStream(b);
                    logo.Image = Image.FromStream(ms);
                }
                else
                {
                    textNameCompany.Clear();
                    textAddressCompany.Clear();
                }
                dr.Close();
                dbconnect.close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title);
            }
        }
        private void logo_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    imgLocation = ofd.FileName;
                    logo.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        private void buttonSaveCompany_Click(object sender, EventArgs e)
        {
            Image img = logo.Image;
            byte[] arr;
            ImageConverter convertImage = new ImageConverter();
            arr = (byte[])convertImage.ConvertTo(img, typeof(byte[]));
            try
            {
                if (MessageBox.Show("Bạn có muốn lưu thông tin cửa hàng","Xác Nhận",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    if (hasdetail)
                    {
                        cm = new SqlCommand("UPDATE tbCompany SET name=@name, address=@address,image=@image", dbconnect.connect());
                        cm.Parameters.AddWithValue("@name", textNameCompany.Text);
                        cm.Parameters.AddWithValue("@address", textAddressCompany.Text);
                        cm.Parameters.AddWithValue("@image", arr);
                    }
                    else
                    {
                        cm = new SqlCommand("INSERT INTO tbCompany (name,address,image)VALUES(@name,@address,@image)", dbconnect.connect());
                        cm.Parameters.AddWithValue("@name", textNameCompany.Text);
                        cm.Parameters.AddWithValue("@address", textAddressCompany.Text);
                        cm.Parameters.AddWithValue("@image", arr);
                        dbconnect.open();
                        cm.ExecuteNonQuery();
                        dbconnect.close();
                    }
                    MessageBox.Show("Thông tin cửa hàng đã được lưu thành công", "Lưu Thông Tin Cửa Hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title);
            }
        }

        private void buttonCancelCompany_Click(object sender, EventArgs e)
        {
            textNameCompany.Clear();
            textAddressCompany.Clear();
        }
        //End Company
    }
}
