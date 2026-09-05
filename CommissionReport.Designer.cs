namespace GoMartApplication
{
    partial class CommissionReport
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTotalSales;
        private System.Windows.Forms.Label lblCommission;
        private System.Windows.Forms.Label lblSellerEarnings;

        private System.Windows.Forms.DataGridView dgvCommission;

        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClose;

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

            this.dgvCommission =
                new System.Windows.Forms.DataGridView();

            this.btnRefresh =
                new System.Windows.Forms.Button();

            this.btnClose =
                new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvCommission)).BeginInit();

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
                new System.Drawing.Point(30, 20);

            this.lblTitle.Name =
                "lblTitle";

            this.lblTitle.Size =
                new System.Drawing.Size(226, 37);

            this.lblTitle.TabIndex = 0;

            this.lblTitle.Text =
                "Commission Report";

            // =====================================================
            // lblTotalSales
            // =====================================================

            this.lblTotalSales.AutoSize = true;

            this.lblTotalSales.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F,
                    System.Drawing.FontStyle.Bold,
                    System.Drawing.GraphicsUnit.Point);

            this.lblTotalSales.Location =
                new System.Drawing.Point(30, 75);

            this.lblTotalSales.Name =
                "lblTotalSales";

            this.lblTotalSales.Size =
                new System.Drawing.Size(130, 20);

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
                    11F,
                    System.Drawing.FontStyle.Bold,
                    System.Drawing.GraphicsUnit.Point);

            this.lblCommission.Location =
                new System.Drawing.Point(270, 75);

            this.lblCommission.Name =
                "lblCommission";

            this.lblCommission.Size =
                new System.Drawing.Size(205, 20);

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
                    11F,
                    System.Drawing.FontStyle.Bold,
                    System.Drawing.GraphicsUnit.Point);

            this.lblSellerEarnings.Location =
                new System.Drawing.Point(590, 75);

            this.lblSellerEarnings.Name =
                "lblSellerEarnings";

            this.lblSellerEarnings.Size =
                new System.Drawing.Size(185, 20);

            this.lblSellerEarnings.TabIndex = 3;

            this.lblSellerEarnings.Text =
                "Seller Earnings: 0.00";

            // =====================================================
            // dgvCommission
            // =====================================================

            this.dgvCommission.AllowUserToAddRows = false;

            this.dgvCommission.AllowUserToDeleteRows = false;

            this.dgvCommission.AllowUserToResizeRows = false;

            this.dgvCommission.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.dgvCommission.BackgroundColor =
                System.Drawing.SystemColors.Window;

            this.dgvCommission.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.dgvCommission.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.dgvCommission.Location =
                new System.Drawing.Point(30, 115);

            this.dgvCommission.MultiSelect = false;

            this.dgvCommission.Name =
                "dgvCommission";

            this.dgvCommission.ReadOnly = true;

            this.dgvCommission.RowHeadersVisible = false;

            this.dgvCommission.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.dgvCommission.Size =
                new System.Drawing.Size(1140, 430);

            this.dgvCommission.TabIndex = 4;

            // =====================================================
            // btnRefresh
            // =====================================================

            this.btnRefresh.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Bold,
                    System.Drawing.GraphicsUnit.Point);

            this.btnRefresh.Location =
                new System.Drawing.Point(30, 570);

            this.btnRefresh.Name =
                "btnRefresh";

            this.btnRefresh.Size =
                new System.Drawing.Size(140, 45);

            this.btnRefresh.TabIndex = 5;

            this.btnRefresh.Text =
                "Refresh";

            this.btnRefresh.UseVisualStyleBackColor = true;

            // =====================================================
            // btnClose
            // =====================================================

            this.btnClose.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Bold,
                    System.Drawing.GraphicsUnit.Point);

            this.btnClose.Location =
                new System.Drawing.Point(190, 570);

            this.btnClose.Name =
                "btnClose";

            this.btnClose.Size =
                new System.Drawing.Size(140, 45);

            this.btnClose.TabIndex = 6;

            this.btnClose.Text =
                "Close";

            this.btnClose.UseVisualStyleBackColor = true;

            // =====================================================
            // CommissionReport FORM
            // =====================================================

            this.AutoScaleDimensions =
                new System.Drawing.SizeF(7F, 15F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(1200, 650);

            this.Controls.Add(
                this.btnClose);

            this.Controls.Add(
                this.btnRefresh);

            this.Controls.Add(
                this.dgvCommission);

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
                "CommissionReport";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text =
                "Commission Report";

            // =====================================================
            // EVENTS
            // =====================================================

            this.Load +=
                new System.EventHandler(
                    this.CommissionReport_Load);

            this.FormClosing +=
                new System.Windows.Forms.FormClosingEventHandler(
                    this.CommissionReport_FormClosing);

            this.btnRefresh.Click +=
                new System.EventHandler(
                    this.btnRefresh_Click);

            this.btnClose.Click +=
                new System.EventHandler(
                    this.btnClose_Click);

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvCommission)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}