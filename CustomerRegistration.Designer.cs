
namespace GoMartApplication
{
    partial class CustomerRegistration
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblAddress;

        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtAddress;

        private System.Windows.Forms.Button btn0;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.lblTitle = new System.Windows.Forms.Label();

            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();

            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();

            this.btn0 = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font(
                "Segoe UI",
                20F,
                System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point);

            this.lblTitle.Location =
                new System.Drawing.Point(105, 25);

            this.lblTitle.Name =
                "lblTitle";

            this.lblTitle.Size =
                new System.Drawing.Size(295, 37);

            this.lblTitle.TabIndex = 0;

            this.lblTitle.Text =
                "Customer Registration";

            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font(
                "Segoe UI",
                10F,
                System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point);

            this.lblUserName.Location =
                new System.Drawing.Point(45, 95);

            this.lblUserName.Name =
                "lblUserName";

            this.lblUserName.Size =
                new System.Drawing.Size(78, 19);

            this.lblUserName.TabIndex = 1;

            this.lblUserName.Text =
                "Username:";

            // 
            // txtUserName
            // 
            this.txtUserName.Location =
                new System.Drawing.Point(145, 92);

            this.txtUserName.Name =
                "txtUserName";

            this.txtUserName.Size =
                new System.Drawing.Size(300, 23);

            this.txtUserName.TabIndex = 2;

            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font(
                "Segoe UI",
                10F,
                System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point);

            this.lblPassword.Location =
                new System.Drawing.Point(45, 135);

            this.lblPassword.Name =
                "lblPassword";

            this.lblPassword.Size =
                new System.Drawing.Size(70, 19);

            this.lblPassword.TabIndex = 3;

            this.lblPassword.Text =
                "Password:";

            // 
            // txtPassword
            // 
            this.txtPassword.Location =
                new System.Drawing.Point(145, 132);

            this.txtPassword.Name =
                "txtPassword";

            this.txtPassword.Size =
                new System.Drawing.Size(300, 23);

            this.txtPassword.TabIndex = 4;

            this.txtPassword.UseSystemPasswordChar = true;

            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font(
                "Segoe UI",
                10F,
                System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point);

            this.lblFullName.Location =
                new System.Drawing.Point(45, 175);

            this.lblFullName.Name =
                "lblFullName";

            this.lblFullName.Size =
                new System.Drawing.Size(73, 19);

            this.lblFullName.TabIndex = 5;

            this.lblFullName.Text =
                "Full Name:";

            // 
            // txtFullName
            // 
            this.txtFullName.Location =
                new System.Drawing.Point(145, 172);

            this.txtFullName.Name =
                "txtFullName";

            this.txtFullName.Size =
                new System.Drawing.Size(300, 23);

            this.txtFullName.TabIndex = 6;

            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font(
                "Segoe UI",
                10F,
                System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point);

            this.lblPhone.Location =
                new System.Drawing.Point(45, 215);

            this.lblPhone.Name =
                "lblPhone";

            this.lblPhone.Size =
                new System.Drawing.Size(48, 19);

            this.lblPhone.TabIndex = 7;

            this.lblPhone.Text =
                "Phone:";

            // 
            // txtPhone
            // 
            this.txtPhone.Location =
                new System.Drawing.Point(145, 212);

            this.txtPhone.Name =
                "txtPhone";

            this.txtPhone.Size =
                new System.Drawing.Size(300, 23);

            this.txtPhone.TabIndex = 8;

            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font(
                "Segoe UI",
                10F,
                System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point);

            this.lblEmail.Location =
                new System.Drawing.Point(45, 255);

            this.lblEmail.Name =
                "lblEmail";

            this.lblEmail.Size =
                new System.Drawing.Size(45, 19);

            this.lblEmail.TabIndex = 9;

            this.lblEmail.Text =
                "Email:";

            // 
            // txtEmail
            // 
            this.txtEmail.Location =
                new System.Drawing.Point(145, 252);

            this.txtEmail.Name =
                "txtEmail";

            this.txtEmail.Size =
                new System.Drawing.Size(300, 23);

            this.txtEmail.TabIndex = 10;

            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font(
                "Segoe UI",
                10F,
                System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point);

            this.lblAddress.Location =
                new System.Drawing.Point(45, 295);

            this.lblAddress.Name =
                "lblAddress";

            this.lblAddress.Size =
                new System.Drawing.Size(59, 19);

            this.lblAddress.TabIndex = 11;

            this.lblAddress.Text =
                "Address:";

            // 
            // txtAddress
            // 
            this.txtAddress.Location =
                new System.Drawing.Point(145, 292);

            this.txtAddress.Multiline = true;

            this.txtAddress.Name =
                "txtAddress";

            this.txtAddress.ScrollBars =
                System.Windows.Forms.ScrollBars.Vertical;

            this.txtAddress.Size =
                new System.Drawing.Size(300, 70);

            this.txtAddress.TabIndex = 12;

            // 
            // btn0
            // 
            this.btn0.BackColor =
                System.Drawing.Color.SeaGreen;

            this.btn0.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btn0.Font = new System.Drawing.Font(
                "Segoe UI",
                11F,
                System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point);

            this.btn0.ForeColor =
                System.Drawing.Color.White;

            this.btn0.Location =
                new System.Drawing.Point(145, 390);

            this.btn0.Name =
                "btn0";

            this.btn0.Size =
                new System.Drawing.Size(300, 45);

            this.btn0.TabIndex = 13;

            this.btn0.Text =
                "Register";

            this.btn0.UseVisualStyleBackColor = false;

            this.btn0.Click +=
                new System.EventHandler(this.btn0_Click);

            // 
            // CustomerRegistration
            // 
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(7F, 15F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(510, 480);

            this.Controls.Add(this.lblTitle);

            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.txtUserName);

            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);

            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.txtFullName);

            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtPhone);

            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);

            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtAddress);

            this.Controls.Add(this.btn0);

            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.FixedSingle;

            this.MaximizeBox = false;

            this.Name =
                "CustomerRegistration";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text =
                "Customer Registration";

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}