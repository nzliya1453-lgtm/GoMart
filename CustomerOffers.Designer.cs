
namespace GoMartApplication
{
    partial class CustomerOffers
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvOffers = new System.Windows.Forms.DataGridView();
            this.btnTakeOffer = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvOffers)).BeginInit();
            this.SuspendLayout();

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font(
                "Segoe UI",
                18F,
                System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point,
                ((byte)(0)));

            this.lblTitle.Location =
                new System.Drawing.Point(30, 25);

            this.lblTitle.Name = "lblTitle";

            this.lblTitle.Size =
                new System.Drawing.Size(220, 32);

            this.lblTitle.TabIndex = 0;

            this.lblTitle.Text =
                "Available Offers";

            // 
            // dgvOffers
            // 
            this.dgvOffers.AllowUserToAddRows = false;

            this.dgvOffers.AllowUserToDeleteRows = false;

            this.dgvOffers.AllowUserToResizeRows = false;

            this.dgvOffers.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.dgvOffers.BackgroundColor =
                System.Drawing.SystemColors.Window;

            this.dgvOffers.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.dgvOffers.Location =
                new System.Drawing.Point(30, 80);

            this.dgvOffers.MultiSelect = false;

            this.dgvOffers.Name =
                "dgvOffers";

            this.dgvOffers.ReadOnly = true;

            this.dgvOffers.RowHeadersVisible = false;

            this.dgvOffers.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.dgvOffers.Size =
                new System.Drawing.Size(740, 350);

            this.dgvOffers.TabIndex = 1;

            // 
            // btnTakeOffer
            // 
            this.btnTakeOffer.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Bold,
                    System.Drawing.GraphicsUnit.Point,
                    ((byte)(0)));

            this.btnTakeOffer.Location =
                new System.Drawing.Point(30, 455);

            this.btnTakeOffer.Name =
                "btnTakeOffer";

            this.btnTakeOffer.Size =
                new System.Drawing.Size(160, 42);

            this.btnTakeOffer.TabIndex = 2;

            this.btnTakeOffer.Text =
                "Take Offer";

            this.btnTakeOffer.UseVisualStyleBackColor = true;

            this.btnTakeOffer.Click +=
                new System.EventHandler(
                    this.btnTakeOffer_Click);

            // 
            // btnRefresh
            // 
            this.btnRefresh.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Bold,
                    System.Drawing.GraphicsUnit.Point,
                    ((byte)(0)));

            this.btnRefresh.Location =
                new System.Drawing.Point(210, 455);

            this.btnRefresh.Name =
                "btnRefresh";

            this.btnRefresh.Size =
                new System.Drawing.Size(120, 42);

            this.btnRefresh.TabIndex = 3;

            this.btnRefresh.Text =
                "Refresh";

            this.btnRefresh.UseVisualStyleBackColor = true;

            this.btnRefresh.Click +=
                new System.EventHandler(
                    this.btnRefresh_Click);

            // 
            // CustomerOffers
            // 
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(7F, 15F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(810, 530);

            this.Controls.Add(
                this.btnRefresh);

            this.Controls.Add(
                this.btnTakeOffer);

            this.Controls.Add(
                this.dgvOffers);

            this.Controls.Add(
                this.lblTitle);

            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.FixedSingle;

            this.MaximizeBox = false;

            this.Name =
                "CustomerOffers";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text =
                "Customer Offers";

            this.Load +=
                new System.EventHandler(
                    this.CustomerOffers_Load);

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvOffers)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvOffers;
        private System.Windows.Forms.Button btnTakeOffer;
        private System.Windows.Forms.Button btnRefresh;
    }
}