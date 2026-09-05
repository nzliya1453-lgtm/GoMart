namespace GoMartApplication
{
    partial class ManageCustomer
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dataGridViewCustomers;
        private System.Windows.Forms.Button btn0;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Label lblTitle;

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
            this.dataGridViewCustomers =
                new System.Windows.Forms.DataGridView();

            this.btn0 =
                new System.Windows.Forms.Button();

            this.btn1 =
                new System.Windows.Forms.Button();

            this.lblTitle =
                new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)
                (this.dataGridViewCustomers)).BeginInit();

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
                new System.Drawing.Size(239, 37);

            this.lblTitle.TabIndex = 0;

            this.lblTitle.Text =
                "Manage Customers";

            // =====================================================
            // dataGridViewCustomers
            // =====================================================

            this.dataGridViewCustomers.AllowUserToAddRows = false;

            this.dataGridViewCustomers.AllowUserToDeleteRows = false;

            this.dataGridViewCustomers.AllowUserToResizeRows = false;

            this.dataGridViewCustomers.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.dataGridViewCustomers.BackgroundColor =
                System.Drawing.SystemColors.Window;

            this.dataGridViewCustomers.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.dataGridViewCustomers.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.dataGridViewCustomers.Location =
                new System.Drawing.Point(30, 80);

            this.dataGridViewCustomers.MultiSelect = false;

            this.dataGridViewCustomers.Name =
                "dataGridViewCustomers";

            this.dataGridViewCustomers.ReadOnly = true;

            this.dataGridViewCustomers.RowHeadersVisible = false;

            this.dataGridViewCustomers.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.dataGridViewCustomers.Size =
                new System.Drawing.Size(1140, 470);

            this.dataGridViewCustomers.TabIndex = 1;

            // =====================================================
            // btn0 - Refresh
            // =====================================================

            this.btn0.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Bold,
                    System.Drawing.GraphicsUnit.Point);

            this.btn0.Location =
                new System.Drawing.Point(30, 575);

            this.btn0.Name =
                "btn0";

            this.btn0.Size =
                new System.Drawing.Size(140, 45);

            this.btn0.TabIndex = 2;

            this.btn0.Text =
                "Refresh";

            this.btn0.UseVisualStyleBackColor = true;

            // =====================================================
            // btn1 - Deactivate
            // =====================================================

            this.btn1.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Bold,
                    System.Drawing.GraphicsUnit.Point);

            this.btn1.Location =
                new System.Drawing.Point(190, 575);

            this.btn1.Name =
                "btn1";

            this.btn1.Size =
                new System.Drawing.Size(170, 45);

            this.btn1.TabIndex = 3;

            this.btn1.Text =
                "Deactivate Customer";

            this.btn1.UseVisualStyleBackColor = true;

            // =====================================================
            // ManageCustomer FORM
            // =====================================================

            this.AutoScaleDimensions =
                new System.Drawing.SizeF(7F, 15F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(1200, 650);

            this.Controls.Add(
                this.btn1);

            this.Controls.Add(
                this.btn0);

            this.Controls.Add(
                this.dataGridViewCustomers);

            this.Controls.Add(
                this.lblTitle);

            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.FixedSingle;

            this.MaximizeBox = false;

            this.MinimizeBox = false;

            this.Name =
                "ManageCustomer";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text =
                "Manage Customers";

            // =====================================================
            // EVENTS
            // =====================================================

            this.Load +=
                new System.EventHandler(
                    this.ManageCustomer_Load);

            this.FormClosing +=
                new System.Windows.Forms.FormClosingEventHandler(
                    this.ManageCustomer_FormClosing);

            this.btn0.Click +=
                new System.EventHandler(
                    this.btn0_Click);

            this.btn1.Click +=
                new System.EventHandler(
                    this.btn1_Click);

            ((System.ComponentModel.ISupportInitialize)
                (this.dataGridViewCustomers)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}