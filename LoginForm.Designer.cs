
namespace Pet_Clinic
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.label1 = new System.Windows.Forms.Label();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.textUser = new Guna.UI2.WinForms.Guna2TextBox();
            this.textPass = new Guna.UI2.WinForms.Guna2TextBox();
            this.buttonLogin = new Guna.UI2.WinForms.Guna2Button();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonClose = new Guna.UI2.WinForms.Guna2Button();
            this.buttonForgetPassword = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Roboto", 32.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(413, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(636, 52);
            this.label1.TabIndex = 4;
            this.label1.Text = "WELCOME TO THE RỒM CLINIC";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CirclePictureBox1.Image = global::Pet_Clinic.Properties.Resources.logo;
            this.guna2CirclePictureBox1.ImageRotate = 0F;
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(607, 199);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.ShadowDecoration.Parent = this.guna2CirclePictureBox1;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(226, 222);
            this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2CirclePictureBox1.TabIndex = 3;
            this.guna2CirclePictureBox1.TabStop = false;
            // 
            // textUser
            // 
            this.textUser.BackColor = System.Drawing.Color.Transparent;
            this.textUser.BorderColor = System.Drawing.Color.Transparent;
            this.textUser.BorderRadius = 15;
            this.textUser.BorderThickness = 0;
            this.textUser.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textUser.DefaultText = "";
            this.textUser.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textUser.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textUser.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textUser.DisabledState.Parent = this.textUser;
            this.textUser.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textUser.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textUser.FocusedState.Parent = this.textUser;
            this.textUser.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textUser.ForeColor = System.Drawing.Color.Black;
            this.textUser.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textUser.HoverState.Parent = this.textUser;
            this.textUser.IconLeft = global::Pet_Clinic.Properties.Resources.user;
            this.textUser.IconLeftSize = new System.Drawing.Size(40, 40);
            this.textUser.Location = new System.Drawing.Point(555, 480);
            this.textUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textUser.Name = "textUser";
            this.textUser.PasswordChar = '\0';
            this.textUser.PlaceholderForeColor = System.Drawing.Color.Black;
            this.textUser.PlaceholderText = "Username";
            this.textUser.SelectedText = "";
            this.textUser.ShadowDecoration.Parent = this.textUser;
            this.textUser.Size = new System.Drawing.Size(348, 53);
            this.textUser.TabIndex = 6;
            this.textUser.TextOffset = new System.Drawing.Point(10, 0);
            // 
            // textPass
            // 
            this.textPass.BackColor = System.Drawing.Color.Transparent;
            this.textPass.BorderColor = System.Drawing.Color.Transparent;
            this.textPass.BorderRadius = 15;
            this.textPass.BorderThickness = 0;
            this.textPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textPass.DefaultText = "";
            this.textPass.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textPass.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textPass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textPass.DisabledState.Parent = this.textPass;
            this.textPass.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textPass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textPass.FocusedState.Parent = this.textPass;
            this.textPass.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textPass.ForeColor = System.Drawing.Color.Black;
            this.textPass.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textPass.HoverState.Parent = this.textPass;
            this.textPass.IconLeft = global::Pet_Clinic.Properties.Resources.password;
            this.textPass.IconLeftSize = new System.Drawing.Size(40, 40);
            this.textPass.Location = new System.Drawing.Point(555, 573);
            this.textPass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textPass.Name = "textPass";
            this.textPass.PasswordChar = '●';
            this.textPass.PlaceholderForeColor = System.Drawing.Color.Black;
            this.textPass.PlaceholderText = "Password";
            this.textPass.SelectedText = "";
            this.textPass.ShadowDecoration.Parent = this.textPass;
            this.textPass.Size = new System.Drawing.Size(348, 53);
            this.textPass.TabIndex = 7;
            this.textPass.TextOffset = new System.Drawing.Point(10, 0);
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.Color.Transparent;
            this.buttonLogin.BorderRadius = 15;
            this.buttonLogin.CheckedState.Parent = this.buttonLogin;
            this.buttonLogin.CustomImages.Parent = this.buttonLogin;
            this.buttonLogin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonLogin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.buttonLogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.buttonLogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.buttonLogin.DisabledState.Parent = this.buttonLogin;
            this.buttonLogin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(147)))), ((int)(((byte)(147)))));
            this.buttonLogin.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogin.ForeColor = System.Drawing.Color.White;
            this.buttonLogin.HoverState.Parent = this.buttonLogin;
            this.buttonLogin.Location = new System.Drawing.Point(616, 729);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.ShadowDecoration.Parent = this.buttonLogin;
            this.buttonLogin.Size = new System.Drawing.Size(238, 50);
            this.buttonLogin.TabIndex = 8;
            this.buttonLogin.Text = "Đăng nhập";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(664, 968);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Make with 100% love";
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.Transparent;
            this.buttonClose.CheckedState.Parent = this.buttonClose;
            this.buttonClose.CustomImages.Parent = this.buttonClose;
            this.buttonClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.buttonClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.buttonClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.buttonClose.DisabledState.Parent = this.buttonClose;
            this.buttonClose.FillColor = System.Drawing.Color.Transparent;
            this.buttonClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonClose.ForeColor = System.Drawing.Color.White;
            this.buttonClose.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.buttonClose.HoverState.ForeColor = System.Drawing.Color.Transparent;
            this.buttonClose.HoverState.Image = global::Pet_Clinic.Properties.Resources.Close;
            this.buttonClose.HoverState.Parent = this.buttonClose;
            this.buttonClose.Image = global::Pet_Clinic.Properties.Resources.Close2;
            this.buttonClose.ImageSize = new System.Drawing.Size(40, 40);
            this.buttonClose.Location = new System.Drawing.Point(1391, -2);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.ShadowDecoration.Parent = this.buttonClose;
            this.buttonClose.Size = new System.Drawing.Size(51, 45);
            this.buttonClose.TabIndex = 13;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonForgetPassword
            // 
            this.buttonForgetPassword.BackColor = System.Drawing.Color.Transparent;
            this.buttonForgetPassword.CheckedState.Parent = this.buttonForgetPassword;
            this.buttonForgetPassword.CustomImages.Parent = this.buttonForgetPassword;
            this.buttonForgetPassword.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonForgetPassword.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.buttonForgetPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.buttonForgetPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.buttonForgetPassword.DisabledState.Parent = this.buttonForgetPassword;
            this.buttonForgetPassword.FillColor = System.Drawing.Color.Transparent;
            this.buttonForgetPassword.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonForgetPassword.ForeColor = System.Drawing.Color.White;
            this.buttonForgetPassword.HoverState.BorderColor = System.Drawing.Color.Transparent;
            this.buttonForgetPassword.HoverState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.buttonForgetPassword.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.buttonForgetPassword.HoverState.Parent = this.buttonForgetPassword;
            this.buttonForgetPassword.Location = new System.Drawing.Point(646, 655);
            this.buttonForgetPassword.Name = "buttonForgetPassword";
            this.buttonForgetPassword.ShadowDecoration.Parent = this.buttonForgetPassword;
            this.buttonForgetPassword.Size = new System.Drawing.Size(187, 35);
            this.buttonForgetPassword.TabIndex = 14;
            this.buttonForgetPassword.Text = "Quên mật khẩu?";
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 15;
            this.guna2Elipse1.TargetControl = this;
            // 
            // LoginForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::Pet_Clinic.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(1440, 1024);
            this.ControlBox = false;
            this.Controls.Add(this.buttonForgetPassword);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.textPass);
            this.Controls.Add(this.textUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guna2CirclePictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập RỒM CLINIC SYSTEM";
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private Guna.UI2.WinForms.Guna2TextBox textUser;
        private Guna.UI2.WinForms.Guna2TextBox textPass;
        private Guna.UI2.WinForms.Guna2Button buttonLogin;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button buttonClose;
        private Guna.UI2.WinForms.Guna2Button buttonForgetPassword;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
    }
}