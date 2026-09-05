namespace GoMartApplication
{
    partial class PaymentForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.TextBox txtNumber;

        private System.Windows.Forms.GroupBox grpPaymentMethod;
        private System.Windows.Forms.RadioButton rbBkash;
        private System.Windows.Forms.RadioButton rbNagad;
        private System.Windows.Forms.RadioButton rbRocket;

        private System.Windows.Forms.Button BtnPay;
        private System.Windows.Forms.Button btnCancel;

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
            this.lblAmount = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblNumber = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();

            this.grpPaymentMethod = new System.Windows.Forms.GroupBox();
            this.rbBkash = new System.Windows.Forms.RadioButton();
            this.rbNagad = new System.Windows.Forms.RadioButton();
            this.rbRocket = new System.Windows.Forms.RadioButton();

            this.BtnPay = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            this.grpPaymentMethod.SuspendLayout();
            this.SuspendLayout();

            // =====================================================
            // lblTitle
            // =====================================================
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font(
                "Segoe UI",
                18F,
                System.Drawing.FontStyle.Bold);

            this.lblTitle.Location = new System.Drawing.Point(135, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(180, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Make Payment";

            // =====================================================
            // lblAmount
            // =====================================================
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font(
                "Segoe UI",
                10F);

            this.lblAmount.Location = new System.Drawing.Point(45, 85);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(108, 19);
            this.lblAmount.TabIndex = 1;
            this.lblAmount.Text = "Amount:";

            // =====================================================
            // txtAmount
            // =====================================================
            this.txtAmount.Font = new System.Drawing.Font(
                "Segoe UI",
                10F);

            this.txtAmount.Location = new System.Drawing.Point(165, 82);
            this.txtAmount.Name = "txtAmount";

            // IMPORTANT:
            // Amount textbox is editable.
            this.txtAmount.ReadOnly = false;
            this.txtAmount.Enabled = true;

            this.txtAmount.Size = new System.Drawing.Size(220, 25);
            this.txtAmount.TabIndex = 2;

            // =====================================================
            // lblNumber
            // =====================================================
            this.lblNumber.AutoSize = true;
            this.lblNumber.Font = new System.Drawing.Font(
                "Segoe UI",
                10F);

            this.lblNumber.Location = new System.Drawing.Point(45, 130);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(108, 19);
            this.lblNumber.TabIndex = 3;
            this.lblNumber.Text = "Mobile Number:";

            // =====================================================
            // txtNumber
            // =====================================================
            this.txtNumber.Font = new System.Drawing.Font(
                "Segoe UI",
                10F);

            this.txtNumber.Location = new System.Drawing.Point(165, 127);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(220, 25);
            this.txtNumber.TabIndex = 4;
            this.txtNumber.MaxLength = 15;

            // =====================================================
            // grpPaymentMethod
            // =====================================================
            this.grpPaymentMethod.Controls.Add(this.rbRocket);
            this.grpPaymentMethod.Controls.Add(this.rbNagad);
            this.grpPaymentMethod.Controls.Add(this.rbBkash);

            this.grpPaymentMethod.Font = new System.Drawing.Font(
                "Segoe UI",
                10F,
                System.Drawing.FontStyle.Bold);

            this.grpPaymentMethod.Location = new System.Drawing.Point(45, 175);
            this.grpPaymentMethod.Name = "grpPaymentMethod";
            this.grpPaymentMethod.Size = new System.Drawing.Size(340, 115);
            this.grpPaymentMethod.TabIndex = 5;
            this.grpPaymentMethod.TabStop = false;
            this.grpPaymentMethod.Text = "Payment Method";

            // =====================================================
            // rbBkash
            // =====================================================
            this.rbBkash.AutoSize = true;
            this.rbBkash.Font = new System.Drawing.Font(
                "Segoe UI",
                10F);

            this.rbBkash.Location = new System.Drawing.Point(25, 30);
            this.rbBkash.Name = "rbBkash";
            this.rbBkash.Size = new System.Drawing.Size(63, 23);
            this.rbBkash.TabIndex = 0;
            this.rbBkash.TabStop = true;
            this.rbBkash.Text = "bKash";
            this.rbBkash.UseVisualStyleBackColor = true;

            // =====================================================
            // rbNagad
            // =====================================================
            this.rbNagad.AutoSize = true;
            this.rbNagad.Font = new System.Drawing.Font(
                "Segoe UI",
                10F);

            this.rbNagad.Location = new System.Drawing.Point(125, 30);
            this.rbNagad.Name = "rbNagad";
            this.rbNagad.Size = new System.Drawing.Size(66, 23);
            this.rbNagad.TabIndex = 1;
            this.rbNagad.TabStop = true;
            this.rbNagad.Text = "Nagad";
            this.rbNagad.UseVisualStyleBackColor = true;

            // =====================================================
            // rbRocket
            // =====================================================
            this.rbRocket.AutoSize = true;
            this.rbRocket.Font = new System.Drawing.Font(
                "Segoe UI",
                10F);

            this.rbRocket.Location = new System.Drawing.Point(225, 30);
            this.rbRocket.Name = "rbRocket";
            this.rbRocket.Size = new System.Drawing.Size(70, 23);
            this.rbRocket.TabIndex = 2;
            this.rbRocket.TabStop = true;
            this.rbRocket.Text = "Rocket";
            this.rbRocket.UseVisualStyleBackColor = true;

            // =====================================================
            // BtnPay
            // =====================================================
            this.BtnPay.Font = new System.Drawing.Font(
                "Segoe UI",
                10F,
                System.Drawing.FontStyle.Bold);

            this.BtnPay.Location = new System.Drawing.Point(85, 320);
            this.BtnPay.Name = "BtnPay";
            this.BtnPay.Size = new System.Drawing.Size(125, 40);
            this.BtnPay.TabIndex = 6;
            this.BtnPay.Text = "Pay";
            this.BtnPay.UseVisualStyleBackColor = true;
            this.BtnPay.Click += new System.EventHandler(this.BtnPay_Click);

            // =====================================================
            // btnCancel
            // =====================================================
            this.btnCancel.Font = new System.Drawing.Font(
                "Segoe UI",
                10F,
                System.Drawing.FontStyle.Bold);

            this.btnCancel.Location = new System.Drawing.Point(220, 320);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(125, 40);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // =====================================================
            // PaymentForm
            // =====================================================
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(7F, 15F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(430, 400);

            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.BtnPay);
            this.Controls.Add(this.grpPaymentMethod);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblTitle);

            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.FixedSingle;

            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.Name = "PaymentForm";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text = "Payment";

            this.Load +=
                new System.EventHandler(this.PaymentForm_Load);

            this.grpPaymentMethod.ResumeLayout(false);
            this.grpPaymentMethod.PerformLayout();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}