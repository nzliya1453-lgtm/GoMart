namespace GoMartApplication
{
    partial class FinancialDashboard
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTotalSales;
        private System.Windows.Forms.Label lblCommission;
        private System.Windows.Forms.Label lblSellerEarnings;
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTotalSales = new System.Windows.Forms.Label();
            this.lblCommission = new System.Windows.Forms.Label();
            this.lblSellerEarnings = new System.Windows.Forms.Label();
            this.btn0 = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // =====================================================
            // lblTitle
            // =====================================================

            this.lblTitle.AutoSize = true;

            this.lblTitle.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    20F,
                    System.Drawing.FontStyle.Bold,
                    System.Drawing.GraphicsUnit.Point);

            this.lblTitle.Location =
                new System.Drawing.Point(35, 30);

            this.lblTitle.Name =
                "lblTitle";

            this.lblTitle.Size =
                new System.Drawing.Size(241, 37);

            this.lblTitle.TabIndex = 0;

            this.lblTitle.Text =
                "Financial Dashboard";

            // =====================================================
            // lblTotalSales
            // =====================================================

            this.lblTotalSales.AutoSize = true;

            this.lblTotalSales.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    14F,
                    System.Drawing.FontStyle.Bold,
                    System.Drawing.GraphicsUnit.Point);

            this.lblTotalSales.Location =
                new System.Drawing.Point(60, 115);

            this.lblTotalSales.Name =
                "lblTotalSales";

            this.lblTotalSales.Size =
                new System.Drawing.Size(145, 25);

            this.lblTotalSales.TabIndex = 1;

            this.lblTotalSales.Text =
                "Total Sales: 0.00";

            // =====================================================
            // lblCommission
            // =====================================================

            this.lblCommission.AutoSize = true;

            this.lblCommission.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    14F,
                    System.Drawing.FontStyle.Bold,
                    System.Drawing.GraphicsUnit.Point);

            this.lblCommission.Location =
                new System.Drawing.Point(60, 175);

            this.lblCommission.Name =
                "lblCommission";

            this.lblCommission.Size =
                new System.Drawing.Size(238, 25);

            this.lblCommission.TabIndex = 2;

            this.lblCommission.Text =
                "GoMart Commission: 0.00";

            // =====================================================
            // lblSellerEarnings
            // =====================================================

            this.lblSellerEarnings.AutoSize = true;

            this.lblSellerEarnings.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    14F,
                    System.Drawing.FontStyle.Bold,
                    System.Drawing.GraphicsUnit.Point);

            this.lblSellerEarnings.Location =
                new System.Drawing.Point(60, 235);

            this.lblSellerEarnings.Name =
                "lblSellerEarnings";

            this.lblSellerEarnings.Size =
                new System.Drawing.Size(220, 25);

            this.lblSellerEarnings.TabIndex = 3;

            this.lblSellerEarnings.Text =
                "Seller Earnings: 0.00";

            // =====================================================
            // btn0 - REFRESH
            // =====================================================

            this.btn0.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F,
                    System.Drawing.FontStyle.Bold,
                    System.Drawing.GraphicsUnit.Point);

            this.btn0.Location =
                new System.Drawing.Point(60, 310);

            this.btn0.Name =
                "btn0";

            this.btn0.Size =
                new System.Drawing.Size(170, 45);

            this.btn0.TabIndex = 4;

            this.btn0.Text =
                "Refresh";

            this.btn0.UseVisualStyleBackColor = true;

            // =====================================================
            // FinancialDashboard FORM
            // =====================================================

            this.AutoScaleDimensions =
                new System.Drawing.SizeF(7F, 15F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(550, 420);

            this.Controls.Add(
                this.btn0);

            this.Controls.Add(
                this.lblSellerEarnings);

            this.Controls.Add(
                this.lblCommission);

            this.Controls.Add(
                this.lblTotalSales);

            this.Controls.Add(
                this.lblTitle);

            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.FixedSingle;

            this.MaximizeBox = false;

            this.MinimizeBox = false;

            this.Name =
                "FinancialDashboard";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text =
                "Financial Dashboard";

            // =====================================================
            // EVENTS
            // =====================================================

            this.Load +=
                new System.EventHandler(
                    this.FinancialDashboard_Load);

            this.FormClosing +=
                new System.Windows.Forms.FormClosingEventHandler(
                    this.FinancialDashboard_FormClosing);

            this.btn0.Click +=
                new System.EventHandler(
                    this.btn0_Click);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}