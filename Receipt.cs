using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Pet_Clinic
{
    public partial class Receipt : Form
    {
        SqlCommand sqlcommand = new SqlCommand();
        dbConnect dbconnect = new dbConnect();
        SqlDataReader dr;
        String title = "Rồm Pet Clinic System";
        bool hasdetail = false;
        String imgLocation = "";
        String nameCompany, addressCompany,logo;
        public Receipt()
        {
            InitializeComponent();
        }

        private void Receipt_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
        public void loadCompany()
        {
                dbconnect.open();
                sqlcommand = new SqlCommand("SELECT * FROM tbCompany", dbconnect.connect());
                dr = sqlcommand.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    byte[] b = new byte[0];
                    hasdetail = true;
                    nameCompany = dr["name"].ToString();
                    addressCompany = dr["address"].ToString();
                    String testLogo = Convert.ToBase64String((byte[])dr["image"]);
                    logo = testLogo;

                }
                dr.Close();
                dbconnect.close();
        }
        public void loadReceipt(string tongtien, string tienkhachdua, string tienthoi, string giamgia)
        {
            ReportDataSource rpDataSoure;
            try
            {
                this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\Reports\ReportReceipt.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();
                DataSet dataset = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter();
                dbconnect.open();
                adapter.SelectCommand = new SqlCommand("SELECT * FROM tbCash AS cash");
            }
            catch (Exception ex)
            {

            }
        }
    }
}
