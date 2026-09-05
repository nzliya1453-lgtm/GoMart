namespace GoMartApplication
{
    partial class OrderDetails
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblOrder;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnPay;
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
            this.lblOrder = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnPay = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1))
                .BeginInit();

            this.SuspendLayout();

            // =====================================================
            // lblOrder
            // =====================================================

            this.lblOrder.AutoSize = true;

            this.lblOrder.Font = new System.Drawing.Font(
                "Segoe UI",
                18F,
                System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point);

            this.lblOrder.Location = new System.Drawing.Point(30, 25);

            this.lblOrder.Name = "lblOrder";

            this.lblOrder.Size = new System.Drawing.Size(130, 32);

            this.lblOrder.TabIndex = 0;

            this.lblOrder.Text = "Order #0";

            // =====================================================
            // dataGridView1
            // =====================================================

            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;

            this.dataGridView1.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.dataGridView1.BackgroundColor =
                System.Drawing.SystemColors.Window;

            this.dataGridView1.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.dataGridView1.Location =
                new System.Drawing.Point(30, 85);

            this.dataGridView1.MultiSelect = false;

            this.dataGridView1.Name = "dataGridView1";

            this.dataGridView1.ReadOnly = true;

            this.dataGridView1.RowHeadersVisible = false;

            this.dataGridView1.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.dataGridView1.Size =
                new System.Drawing.Size(940, 400);

            this.dataGridView1.TabIndex = 1;

            // =====================================================
            // btnPay
            // =====================================================

            this.btnPay.Font = new System.Drawing.Font(
                "Segoe UI",
                10F,
                System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point);

            this.btnPay.Location =
                new System.Drawing.Point(620, 515);

            this.btnPay.Name = "btnPay";

            this.btnPay.Size =
                new System.Drawing.Size(150, 45);

            this.btnPay.TabIndex = 2;

            this.btnPay.Text = "Make Payment";

            this.btnPay.UseVisualStyleBackColor = true;

            // =====================================================
            // btnClose
            // =====================================================

            this.btnClose.Font = new System.Drawing.Font(
                "Segoe UI",
                10F,
                System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point);

            this.btnClose.Location =
                new System.Drawing.Point(800, 515);

            this.btnClose.Name = "btnClose";

            this.btnClose.Size =
                new System.Drawing.Size(150, 45);

            this.btnClose.TabIndex = 3;

            this.btnClose.Text = "Close";

            this.btnClose.UseVisualStyleBackColor = true;

            // =====================================================
            // OrderDetails
            // =====================================================

            this.AutoScaleDimensions =
                new System.Drawing.SizeF(7F, 15F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(1000, 600);

            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblOrder);

            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.FixedSingle;

            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.Name = "OrderDetails";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text = "Order Details";

            // =====================================================
            // EVENTS
            // =====================================================

            this.Load += new System.EventHandler(
                this.OrderDetails_Load);

            this.btnPay.Click += new System.EventHandler(
                this.btnPay_Click);

            this.btnClose.Click += new System.EventHandler(
                this.btnClose_Click);

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1))
                .EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}