
namespace GoMartApplication
{
    partial class ManageOffer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.components = new System.ComponentModel.Container();

            this.dataGridViewOffer = new System.Windows.Forms.DataGridView();

            this.btn0 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();

            this.lblTitle = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOffer)).BeginInit();
            this.SuspendLayout();

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font(
                "Segoe UI",
                20F,
                System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point);

            this.lblTitle.Location = new System.Drawing.Point(38, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(215, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Manage Offers";

            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font(
                "Segoe UI",
                10F,
                System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point);

            this.lblInfo.ForeColor = System.Drawing.Color.DimGray;
            this.lblInfo.Location = new System.Drawing.Point(40, 70);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(355, 19);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "Add, update, delete and manage your store offers.";

            // 
            // dataGridViewOffer
            // 
            this.dataGridViewOffer.AllowUserToAddRows = false;
            this.dataGridViewOffer.AllowUserToDeleteRows = false;
            this.dataGridViewOffer.AllowUserToResizeRows = false;

            this.dataGridViewOffer.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.dataGridViewOffer.BackgroundColor =
                System.Drawing.Color.White;

            this.dataGridViewOffer.BorderStyle =
                System.Windows.Forms.BorderStyle.Fixed3D;

            this.dataGridViewOffer.ColumnHeadersDefaultCellStyle =
                new System.Windows.Forms.DataGridViewCellStyle
                {
                    Font = new System.Drawing.Font(
                        "Segoe UI",
                        10F,
                        System.Drawing.FontStyle.Bold,
                        System.Drawing.GraphicsUnit.Point)
                };

            this.dataGridViewOffer.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.dataGridViewOffer.Location =
                new System.Drawing.Point(40, 110);

            this.dataGridViewOffer.MultiSelect = false;

            this.dataGridViewOffer.Name =
                "dataGridViewOffer";

            this.dataGridViewOffer.ReadOnly = true;

            this.dataGridViewOffer.RowHeadersVisible = false;

            this.dataGridViewOffer.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.dataGridViewOffer.Size =
                new System.Drawing.Size(820, 330);

            this.dataGridViewOffer.TabIndex = 2;

            this.dataGridViewOffer.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(
                    this.dataGridViewOffer_CellClick);

            // 
            // btn0 - ADD
            // 
            this.btn0.BackColor =
                System.Drawing.Color.SeaGreen;

            this.btn0.FlatAppearance.BorderSize = 0;

            this.btn0.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btn0.Font = new System.Drawing.Font(
                "Segoe UI",
                10F,
                System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point);

            this.btn0.ForeColor =
                System.Drawing.Color.White;

            this.btn0.Location =
                new System.Drawing.Point(40, 465);

            this.btn0.Name =
                "btn0";

            this.btn0.Size =
                new System.Drawing.Size(180, 45);

            this.btn0.TabIndex = 3;

            this.btn0.Text =
                "Add Offer";

            this.btn0.UseVisualStyleBackColor =
                false;

            this.btn0.Click +=
                new System.EventHandler(this.btn0_Click);

            // 
            // btn1 - UPDATE
            // 
            this.btn1.BackColor =
                System.Drawing.Color.RoyalBlue;

            this.btn1.FlatAppearance.BorderSize = 0;

            this.btn1.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btn1.Font = new System.Drawing.Font(
                "Segoe UI",
                10F,
                System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point);

            this.btn1.ForeColor =
                System.Drawing.Color.White;

            this.btn1.Location =
                new System.Drawing.Point(253, 465);

            this.btn1.Name =
                "btn1";

            this.btn1.Size =
                new System.Drawing.Size(180, 45);

            this.btn1.TabIndex = 4;

            this.btn1.Text =
                "Update Offer";

            this.btn1.UseVisualStyleBackColor =
                false;

            this.btn1.Click +=
                new System.EventHandler(this.btn1_Click);

            // 
            // btn2 - DELETE
            // 
            this.btn2.BackColor =
                System.Drawing.Color.Firebrick;

            this.btn2.FlatAppearance.BorderSize = 0;

            this.btn2.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btn2.Font = new System.Drawing.Font(
                "Segoe UI",
                10F,
                System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point);

            this.btn2.ForeColor =
                System.Drawing.Color.White;

            this.btn2.Location =
                new System.Drawing.Point(466, 465);

            this.btn2.Name =
                "btn2";

            this.btn2.Size =
                new System.Drawing.Size(180, 45);

            this.btn2.TabIndex = 5;

            this.btn2.Text =
                "Delete Offer";

            this.btn2.UseVisualStyleBackColor =
                false;

            this.btn2.Click +=
                new System.EventHandler(this.btn2_Click);

            // 
            // btn3 - REFRESH
            // 
            this.btn3.BackColor =
                System.Drawing.Color.DimGray;

            this.btn3.FlatAppearance.BorderSize = 0;

            this.btn3.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btn3.Font = new System.Drawing.Font(
                "Segoe UI",
                10F,
                System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point);

            this.btn3.ForeColor =
                System.Drawing.Color.White;

            this.btn3.Location =
                new System.Drawing.Point(679, 465);

            this.btn3.Name =
                "btn3";

            this.btn3.Size =
                new System.Drawing.Size(181, 45);

            this.btn3.TabIndex = 6;

            this.btn3.Text =
                "Refresh";

            this.btn3.UseVisualStyleBackColor =
                false;

            this.btn3.Click +=
                new System.EventHandler(this.btn3_Click);

            // 
            // ManageOffer
            // 
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(7F, 15F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.BackColor =
                System.Drawing.Color.White;

            this.ClientSize =
                new System.Drawing.Size(900, 550);

            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.btn0);
            this.Controls.Add(this.dataGridViewOffer);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblTitle);

            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.FixedSingle;

            this.MaximizeBox = false;

            this.Name =
                "ManageOffer";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text =
                "GoMart - Manage Offers";

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOffer)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        // =========================================================
        // CONTROLS
        // =========================================================

        private System.Windows.Forms.DataGridView dataGridViewOffer;

        private System.Windows.Forms.Button btn0;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn3;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblInfo;
    }
}

