
namespace GoMartApplication
{
    partial class Loginfrom
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();

            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();

            this.btnLogin = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();

            this.lblSignup = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font(
                "Segoe UI",
                22F,
                System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point);

            this.lblTitle.Location =
                new System.Drawing.Point(105, 30);

            this.lblTitle.Name = "lblTitle";

            this.lblTitle.Size =
                new System.Drawing.Size(230, 41);

            this.lblTitle.TabIndex = 0;

            this.lblTitle.Text = "GoMart Login";

            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;

            this.lblRole.Font = new System.Drawing.Font(
                "Segoe UI",
                10F,
                System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point);

            this.lblRole.Location =
                new System.Drawing.Point(45, 105);

            this.lblRole.Name = "lblRole";

            this.lblRole.Size =
                new System.Drawing.Size(34, 19);

            this.lblRole.TabIndex = 1;

            this.lblRole.Text = "Role:";

            // 
            // cmbRole
            // 
            this.cmbRole.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cmbRole.Font = new System.Drawing.Font(
                "Segoe UI",
                10F,
                System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point);

            this.cmbRole.FormattingEnabled = true;

            this.cmbRole.Location =
                new System.Drawing.Point(145, 101);

            this.cmbRole.Name = "cmbRole";

            this.cmbRole.Size =
                new System.Drawing.Size(245, 25);

            this.cmbRole.TabIndex = 2;

            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;

            this.lblUsername.Font = new System.Drawing.Font(
                "Segoe UI",
                10F,
                System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point);

            this.lblUsername.Location =
                new System.Drawing.Point(45, 150);

            this.lblUsername.Name = "lblUsername";

            this.lblUsername.Size =
                new System.Drawing.Size(75, 19);

            this.lblUsername.TabIndex = 3;

            this.lblUsername.Text = "Username:";

            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font(
                "Segoe UI",
                10F,
                System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point);

            this.txtUsername.Location =
                new System.Drawing.Point(145, 147);

            this.txtUsername.Name = "txtUsername";

            this.txtUsername.Size =
                new System.Drawing.Size(245, 25);

            this.txtUsername.TabIndex = 4;

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
                new System.Drawing.Point(45, 195);

            this.lblPassword.Name = "lblPassword";

            this.lblPassword.Size =
                new System.Drawing.Size(70, 19);

            this.lblPassword.TabIndex = 5;

            this.lblPassword.Text = "Password:";

            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font(
                "Segoe UI",
                10F,
                System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point);

            this.txtPassword.Location =
                new System.Drawing.Point(145, 192);

            this.txtPassword.Name = "txtPassword";

            this.txtPassword.Size =
                new System.Drawing.Size(245, 25);

            this.txtPassword.TabIndex = 6;

            this.txtPassword.UseSystemPasswordChar = true;

            this.txtPassword.KeyDown +=
                new System.Windows.Forms.KeyEventHandler(
                    this.txtPassword_KeyDown);

            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font(
                "Segoe UI",
                10F,
                System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point);

            this.btnLogin.Location =
                new System.Drawing.Point(145, 240);

            this.btnLogin.Name = "btnLogin";

            this.btnLogin.Size =
                new System.Drawing.Size(115, 40);

            this.btnLogin.TabIndex = 7;

            this.btnLogin.Text = "Login";

            this.btnLogin.UseVisualStyleBackColor = true;

            this.btnLogin.Click +=
                new System.EventHandler(
                    this.btnLogin_Click);

            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font(
                "Segoe UI",
                10F,
                System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point);

            this.btnClear.Location =
                new System.Drawing.Point(275, 240);

            this.btnClear.Name = "btnClear";

            this.btnClear.Size =
                new System.Drawing.Size(115, 40);

            this.btnClear.TabIndex = 8;

            this.btnClear.Text = "Clear";

            this.btnClear.UseVisualStyleBackColor = true;

            this.btnClear.Click +=
                new System.EventHandler(
                    this.btnClear_Click);

            // 
            // lblSignup
            // 
            this.lblSignup.AutoSize = true;

            this.lblSignup.Font = new System.Drawing.Font(
                "Segoe UI",
                9F,
                System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point);

            this.lblSignup.Location =
                new System.Drawing.Point(95, 315);

            this.lblSignup.Name = "lblSignup";

            this.lblSignup.Size =
                new System.Drawing.Size(140, 15);

            this.lblSignup.TabIndex = 9;

            this.lblSignup.Text =
                "Don't have an account?";

            // 
            // btnRegister
            // 
            this.btnRegister.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnRegister.Font = new System.Drawing.Font(
                "Segoe UI",
                9F,
                System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point);

            this.btnRegister.Location =
                new System.Drawing.Point(245, 307);

            this.btnRegister.Name = "btnRegister";

            this.btnRegister.Size =
                new System.Drawing.Size(100, 30);

            this.btnRegister.TabIndex = 10;

            this.btnRegister.Text = "Sign Up";

            this.btnRegister.UseVisualStyleBackColor = true;

            this.btnRegister.Click +=
                new System.EventHandler(
                    this.btnRegister_Click);

            // 
            // Loginfrom
            // 
            this.AcceptButton = this.btnLogin;

            this.AutoScaleDimensions =
                new System.Drawing.SizeF(7F, 15F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(440, 370);

            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.lblSignup);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.cmbRole);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.lblTitle);

            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.FixedSingle;

            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.Name = "Loginfrom";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text = "GoMart - Login";

            this.Load +=
                new System.EventHandler(
                    this.Loginfrom_Load);

            this.FormClosing +=
                new System.Windows.Forms.FormClosingEventHandler(
                    this.Loginfrom_Form);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        // =====================================================
        // CONTROLS
        // =====================================================

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;

        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnClear;

        private System.Windows.Forms.Label lblSignup;
        private System.Windows.Forms.Button btnRegister;
    }
}