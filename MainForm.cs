using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pet_Clinic
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonDashBoard_Click(object sender, EventArgs e)
        {
            panelSlide.Height = buttonDashBoard.Height;
            panelSlide.Top = buttonDashBoard.Top;
        }

        private void buttonCustomer_Click(object sender, EventArgs e)
        {
            panelSlide.Height = buttonCustomer.Height;
            panelSlide.Top = buttonCustomer.Top;
            openChildForm(new Customer());
        }

        private void buttonService_Click(object sender, EventArgs e)
        {
            panelSlide.Height = buttonService.Height;
            panelSlide.Top = buttonService.Top;
            openChildForm(new Service());
        }

        private void buttonFinace_Click(object sender, EventArgs e)
        {

            panelSlide.Height = buttonFinace.Height;
            panelSlide.Top = buttonFinace.Top;
            openChildForm(new Cash());
        }

        private void buttonHangHoa_Click(object sender, EventArgs e)
        {
            panelSlide.Height = buttonHangHoa.Height;
            panelSlide.Top = buttonHangHoa.Top;
        }

        private void buttonSetting_Click(object sender, EventArgs e)
        {
            panelSlide.Height = buttonSetting.Height;
            panelSlide.Top = buttonSetting.Top;
            openChildForm(new Setting());
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {

        }

        #region
        private Form activeForm = null;
        public void openChildForm (Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
                activeForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                panelChild.Controls.Add(childForm);
                panelChild.Tag=childForm;
                childForm.BringToFront();
                childForm.Show();
        }

        #endregion

        
    }
}
