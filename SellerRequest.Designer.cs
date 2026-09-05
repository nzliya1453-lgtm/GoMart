namespace GoMartApplication
{
    partial class SellerRequest
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

        /// <summary>
        /// Required method for Designer support.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvRequests = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).BeginInit();
            this.SuspendLayout();

            // =========================================================
            // dgvRequests
            // =========================================================

            this.dgvRequests.AllowUserToAddRows = false;
            this.dgvRequests.AllowUserToDeleteRows = false;
            this.dgvRequests.AllowUserToResizeRows = false;

            this.dgvRequests.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.dgvRequests.BackgroundColor =
                System.Drawing.Color.White;

            this.dgvRequests.BorderStyle =
                System.Windows.Forms.BorderStyle.Fixed3D;

            this.dgvRequests.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.dgvRequests.Location =
                new System.Drawing.Point(25, 105);

            this.dgvRequests.MultiSelect = false;

            this.dgvRequests.Name = "dgvRequests";

            this.dgvRequests.ReadOnly = true;

            this.dgvRequests.RowHeadersVisible = false;

            this.dgvRequests.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.dgvRequests.Size =
                new System.Drawing.Size(900, 330);

            this.dgvRequests.TabIndex = 0;

            // =========================================================
            // btnRefresh
            // =========================================================

            this.btnRefresh.BackColor =
                System.Drawing.Color.SteelBlue;

            this.btnRefresh.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnRefresh.ForeColor =
                System.Drawing.Color.White;

            this.btnRefresh.Location =
                new System.Drawing.Point(25, 470);

            this.btnRefresh.Name =
                "btnRefresh";

            this.btnRefresh.Size =
                new System.Drawing.Size(130, 45);

            this.btnRefresh.TabIndex = 1;

            this.btnRefresh.Text =
                "Refresh";

            this.btnRefresh.UseVisualStyleBackColor = false;

            this.btnRefresh.Click +=
                new System.EventHandler(this.btnRefresh_Click);

            // =========================================================
            // btnApprove
            // =========================================================

            this.btnApprove.BackColor =
                System.Drawing.Color.SeaGreen;

            this.btnApprove.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnApprove.ForeColor =
                System.Drawing.Color.White;

            this.btnApprove.Location =
                new System.Drawing.Point(390, 470);

            this.btnApprove.Name =
                "btnApprove";

            this.btnApprove.Size =
                new System.Drawing.Size(150, 45);

            this.btnApprove.TabIndex = 2;

            this.btnApprove.Text =
                "Approve";

            this.btnApprove.UseVisualStyleBackColor = false;

            this.btnApprove.Click +=
                new System.EventHandler(this.btnApprove_Click);

            // =========================================================
            // btnDelete
            // =========================================================

            this.btnDelete.BackColor =
                System.Drawing.Color.Firebrick;

            this.btnDelete.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnDelete.ForeColor =
                System.Drawing.Color.White;

            this.btnDelete.Location =
                new System.Drawing.Point(745, 470);

            this.btnDelete.Name =
                "btnDelete";

            this.btnDelete.Size =
                new System.Drawing.Size(150, 45);

            this.btnDelete.TabIndex = 3;

            this.btnDelete.Text =
                "Reject";

            this.btnDelete.UseVisualStyleBackColor = false;

            this.btnDelete.Click +=
                new System.EventHandler(this.btnDelete_Click);

            // =========================================================
            // lblTitle
            // =========================================================

            this.lblTitle.AutoSize = true;

            this.lblTitle.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    20F,
                    System.Drawing.FontStyle.Bold,
                    System.Drawing.GraphicsUnit.Point
                );

            this.lblTitle.Location =
                new System.Drawing.Point(25, 20);

            this.lblTitle.Name =
                "lblTitle";

            this.lblTitle.Size =
                new System.Drawing.Size(271, 37);

            this.lblTitle.TabIndex = 4;

            this.lblTitle.Text =
                "Seller Requests";

            // =========================================================
            // lblInfo
            // =========================================================

            this.lblInfo.AutoSize = true;

            this.lblInfo.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Regular,
                    System.Drawing.GraphicsUnit.Point
                );

            this.lblInfo.ForeColor =
                System.Drawing.Color.DimGray;

            this.lblInfo.Location =
                new System.Drawing.Point(29, 70);

            this.lblInfo.Name =
                "lblInfo";

            this.lblInfo.Size =
                new System.Drawing.Size(500, 19);

            this.lblInfo.TabIndex = 5;

            this.lblInfo.Text =
                "Review, approve, or reject seller registration requests.";

            // =========================================================
            // SellerRequest
            // =========================================================

            this.AutoScaleDimensions =
                new System.Drawing.SizeF(7F, 15F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.BackColor =
                System.Drawing.Color.White;

            this.ClientSize =
                new System.Drawing.Size(950, 550);

            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvRequests);

            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.FixedSingle;

            this.MaximizeBox = false;

            this.Name =
                "SellerRequest";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text =
                "GoMart - Seller Requests";

            this.FormClosing +=
                new System.Windows.Forms.FormClosingEventHandler(
                    this.SellerRequest_FormClosing
                );

            this.Load +=
                new System.EventHandler(
                    this.SellerRequest_Load
                );

            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRequests;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblInfo;
    }
}