
namespace GoMartApplication
{
    partial class AddAdmin
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblEmail;

        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtEmail;

        private System.Windows.Forms.Button btn0;
        private System.Windows.Forms.Button btnClear;

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
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();

            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();

            this.btn0 = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font(
                "Segoe UI",
                20F,
                System.Drawing.FontStyle.Bold);

            this.lblTitle.Location =
                new System.Drawing.Point(105, 25);

            this.lblTitle.Name = "lblTitle";

            this.lblTitle.Size =
                new System.Drawing.Size(190, 37);

            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Add Admin";

            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;

            this.lblUserName.Location =
                new System.Drawing.Point(45, 95);

            this.lblUserName.Name =
                "lblUserName";

            this.lblUserName.Size =
                new System.Drawing.Size(54, 15);

            this.lblUserName.TabIndex = 1;

            // Database field is AdminID
            this.lblUserName.Text = "Admin ID:";

            // 
            // txtUserName
            // 
            this.txtUserName.Location =
                new System.Drawing.Point(150, 92);

            this.txtUserName.Name =
                "txtUserName";

            this.txtUserName.Size =
                new System.Drawing.Size(230, 23);

            this.txtUserName.TabIndex = 1;

            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;

            this.lblPassword.Location =
                new System.Drawing.Point(45, 135);

            this.lblPassword.Name =
                "lblPassword";

            this.lblPassword.Size =
                new System.Drawing.Size(60, 15);

            this.lblPassword.TabIndex = 2;

            this.lblPassword.Text = "Password:";

            // 
            // txtPassword
            // 
            this.txtPassword.Location =
                new System.Drawing.Point(150, 132);

            this.txtPassword.Name =
                "txtPassword";

            this.txtPassword.Size =
                new System.Drawing.Size(230, 23);

            this.txtPassword.TabIndex = 2;

            this.txtPassword.UseSystemPasswordChar = true;

            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;

            this.lblFullName.Location =
                new System.Drawing.Point(45, 175);

            this.lblFullName.Name =
                "lblFullName";

            this.lblFullName.Size =
                new System.Drawing.Size(65, 15);

            this.lblFullName.TabIndex = 3;

            this.lblFullName.Text = "Full Name:";

            // 
            // txtFullName
            // 
            this.txtFullName.Location =
                new System.Drawing.Point(150, 172);

            this.txtFullName.Name =
                "txtFullName";

            this.txtFullName.Size =
                new System.Drawing.Size(230, 23);

            this.txtFullName.TabIndex = 3;

            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;

            this.lblPhone.Location =
                new System.Drawing.Point(45, 215);

            this.lblPhone.Name =
                "lblPhone";

            this.lblPhone.Size =
                new System.Drawing.Size(45, 15);

            this.lblPhone.TabIndex = 4;

            this.lblPhone.Text = "Phone:";

            // 
            // txtPhone
            // 
            this.txtPhone.Location =
                new System.Drawing.Point(150, 212);

            this.txtPhone.Name =
                "txtPhone";

            this.txtPhone.Size =
                new System.Drawing.Size(230, 23);

            this.txtPhone.TabIndex = 4;

            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;

            this.lblEmail.Location =
                new System.Drawing.Point(45, 255);

            this.lblEmail.Name =
                "lblEmail";

            this.lblEmail.Size =
                new System.Drawing.Size(39, 15);

            this.lblEmail.TabIndex = 5;

            this.lblEmail.Text = "Email:";

            // 
            // txtEmail
            // 
            this.txtEmail.Location =
                new System.Drawing.Point(150, 252);

            this.txtEmail.Name =
                "txtEmail";

            this.txtEmail.Size =
                new System.Drawing.Size(230, 23);

            this.txtEmail.TabIndex = 5;

            // 
            // btn0
            // 
            this.btn0.Font = new System.Drawing.Font(
                "Segoe UI",
                10F,
                System.Drawing.FontStyle.Bold);

            this.btn0.Location =
                new System.Drawing.Point(90, 310);

            this.btn0.Name =
                "btn0";

            this.btn0.Size =
                new System.Drawing.Size(120, 40);

            this.btn0.TabIndex = 6;

            this.btn0.Text =
                "Add Admin";

            this.btn0.UseVisualStyleBackColor =
                true;

            this.btn0.Click +=
                new System.EventHandler(this.btn0_Click);

            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font(
                "Segoe UI",
                10F,
                System.Drawing.FontStyle.Bold);

            this.btnClear.Location =
                new System.Drawing.Point(230, 310);

            this.btnClear.Name =
                "btnClear";

            this.btnClear.Size =
                new System.Drawing.Size(120, 40);

            this.btnClear.TabIndex = 7;

            this.btnClear.Text =
                "Clear";

            this.btnClear.UseVisualStyleBackColor =
                true;

            this.btnClear.Click +=
                new System.EventHandler(this.btnClear_Click);

            // 
            // AddAdmin
            // 
            this.AcceptButton = this.btn0;

            this.AutoScaleDimensions =
                new System.Drawing.SizeF(7F, 15F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.CancelButton = this.btnClear;

            this.ClientSize =
                new System.Drawing.Size(430, 400);

            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btn0);

            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);

            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserName);

            this.Controls.Add(this.lblTitle);

            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.FixedSingle;

            this.MaximizeBox = false;
            this.MinimizeBox = true;

            this.Name =
                "AddAdmin";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text =
                "GoMart - Add Admin";

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        // ==========================================
        // CLEAR BUTTON
        // ==========================================

        private void btnClear_Click(
            object sender,
            System.EventArgs e)
        {
            ClearFields();
        }
    }
}

