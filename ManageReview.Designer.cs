namespace GoMartApplication
{
    partial class ManageReview
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvReviews;
        private System.Windows.Forms.Button btn0;
        private System.Windows.Forms.Button btn1;

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
            this.dgvReviews = new System.Windows.Forms.DataGridView();
            this.btn0 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvReviews))
                .BeginInit();

            this.SuspendLayout();

            // =====================================================
            // dgvReviews
            // =====================================================

            this.dgvReviews.AllowUserToAddRows = false;
            this.dgvReviews.AllowUserToDeleteRows = false;
            this.dgvReviews.AllowUserToResizeRows = false;

            this.dgvReviews.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.dgvReviews.BackgroundColor =
                System.Drawing.SystemColors.Window;

            this.dgvReviews.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.dgvReviews.Location =
                new System.Drawing.Point(25, 25);

            this.dgvReviews.MultiSelect = false;

            this.dgvReviews.Name = "dgvReviews";

            this.dgvReviews.ReadOnly = true;

            this.dgvReviews.RowHeadersVisible = false;

            this.dgvReviews.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.dgvReviews.Size =
                new System.Drawing.Size(950, 450);

            this.dgvReviews.TabIndex = 0;

            // =====================================================
            // btn0 - REFRESH
            // =====================================================

            this.btn0.Font = new System.Drawing.Font(
                "Segoe UI",
                10F,
                System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point);

            this.btn0.Location =
                new System.Drawing.Point(25, 500);

            this.btn0.Name = "btn0";

            this.btn0.Size =
                new System.Drawing.Size(150, 45);

            this.btn0.TabIndex = 1;

            this.btn0.Text = "Refresh";

            this.btn0.UseVisualStyleBackColor = true;

            // =====================================================
            // btn1 - DELETE
            // =====================================================

            this.btn1.Font = new System.Drawing.Font(
                "Segoe UI",
                10F,
                System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point);

            this.btn1.Location =
                new System.Drawing.Point(195, 500);

            this.btn1.Name = "btn1";

            this.btn1.Size =
                new System.Drawing.Size(150, 45);

            this.btn1.TabIndex = 2;

            this.btn1.Text = "Delete Review";

            this.btn1.UseVisualStyleBackColor = true;

            // =====================================================
            // ManageReview
            // =====================================================

            this.AutoScaleDimensions =
                new System.Drawing.SizeF(7F, 15F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(1000, 580);

            this.Controls.Add(this.btn1);
            this.Controls.Add(this.btn0);
            this.Controls.Add(this.dgvReviews);

            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.FixedSingle;

            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.Name = "ManageReview";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text = "Manage Reviews";

            // =====================================================
            // EVENTS
            // =====================================================

            this.Load += new System.EventHandler(
                this.ManageReview_Load);

            this.FormClosing +=
                new System.Windows.Forms.FormClosingEventHandler(
                    this.ManageReview_FormClosing);

            this.btn0.Click += new System.EventHandler(
                this.btn0_Click);

            this.btn1.Click += new System.EventHandler(
                this.btn1_Click);

            ((System.ComponentModel.ISupportInitialize)(this.dgvReviews))
                .EndInit();

            this.ResumeLayout(false);
        }

        #endregion
    }
}