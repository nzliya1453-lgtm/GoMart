
namespace GoMartApplication
{
    partial class ManageSeller
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvSellers;
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

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.dgvSellers = new System.Windows.Forms.DataGridView();
            this.btn0 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvSellers)).BeginInit();
            this.SuspendLayout();

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font(
                "Segoe UI",
                16F,
                System.Drawing.FontStyle.Bold
            );
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(180, 30);
            this.lblTitle.Text = "Manage Sellers";

            // 
            // dgvSellers
            // 
            this.dgvSellers.AllowUserToAddRows = false;
            this.dgvSellers.AllowUserToDeleteRows = false;
            this.dgvSellers.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSellers.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSellers.Location = new System.Drawing.Point(20, 60);
            this.dgvSellers.MultiSelect = false;
            this.dgvSellers.Name = "dgvSellers";
            this.dgvSellers.ReadOnly = true;
            this.dgvSellers.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSellers.Size = new System.Drawing.Size(650, 280);
            this.dgvSellers.TabIndex = 0;

            // 
            // btn0
            // 
            this.btn0.Location = new System.Drawing.Point(20, 360);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(150, 40);
            this.btn0.TabIndex = 1;
            this.btn0.Text = "Refresh Sellers";
            this.btn0.UseVisualStyleBackColor = true;
            this.btn0.Click += new System.EventHandler(this.btn0_Click);

            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(190, 360);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(150, 40);
            this.btn1.TabIndex = 2;
            this.btn1.Text = "Delete Selected";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);

            // 
            // ManageSeller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 430);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvSellers);
            this.Controls.Add(this.btn0);
            this.Controls.Add(this.btn1);
            this.Name = "ManageSeller";
            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Sellers";

            ((System.ComponentModel.ISupportInitialize)(this.dgvSellers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}