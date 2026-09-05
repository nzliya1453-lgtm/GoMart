namespace GoMartApplication
{
    partial class OfferManagement
    {
        private System.ComponentModel.IContainer components = null;

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
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.nudDiscount = new System.Windows.Forms.NumericUpDown();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.chkActive = new System.Windows.Forms.CheckBox();

            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();

            this.dgvOffers = new System.Windows.Forms.DataGridView();

            this.grpOfferDetails = new System.Windows.Forms.GroupBox();
            this.grpOffersList = new System.Windows.Forms.GroupBox();

            ((System.ComponentModel.ISupportInitialize)(this.nudDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOffers)).BeginInit();

            this.grpOfferDetails.SuspendLayout();
            this.grpOffersList.SuspendLayout();
            this.SuspendLayout();

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(25, 35);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(70, 15);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Offer Title:";

            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(130, 31);
            this.txtTitle.MaxLength = 200;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(545, 23);
            this.txtTitle.TabIndex = 1;

            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(25, 78);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(91, 15);
            this.lblDiscount.TabIndex = 2;
            this.lblDiscount.Text = "Discount (%):";

            // 
            // nudDiscount
            // 
            this.nudDiscount.DecimalPlaces = 2;
            this.nudDiscount.Increment = 1;
            this.nudDiscount.Location = new System.Drawing.Point(130, 74);
            this.nudDiscount.Maximum = 100;
            this.nudDiscount.Name = "nudDiscount";
            this.nudDiscount.Size = new System.Drawing.Size(150, 23);
            this.nudDiscount.TabIndex = 3;
            this.nudDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(25, 121);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(64, 15);
            this.lblStartDate.TabIndex = 4;
            this.lblStartDate.Text = "Start Date:";

            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd-MMM-yyyy hh:mm tt";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(130, 117);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.ShowUpDown = true;
            this.dtpStartDate.Size = new System.Drawing.Size(220, 23);
            this.dtpStartDate.TabIndex = 5;

            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(380, 121);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(60, 15);
            this.lblEndDate.TabIndex = 6;
            this.lblEndDate.Text = "End Date:";

            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd-MMM-yyyy hh:mm tt";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(455, 117);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.ShowUpDown = true;
            this.dtpEndDate.Size = new System.Drawing.Size(220, 23);
            this.dtpEndDate.TabIndex = 7;

            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(310, 77);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(59, 19);
            this.chkActive.TabIndex = 8;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;

            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(25, 165);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(110, 38);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Add Offer";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(145, 165);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(110, 38);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(265, 165);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(110, 38);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Deactivate";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(385, 165);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(110, 38);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(505, 165);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(110, 38);
            this.btnRefresh.TabIndex = 13;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // 
            // dgvOffers
            // 
            this.dgvOffers.AllowUserToAddRows = false;
            this.dgvOffers.AllowUserToDeleteRows = false;
            this.dgvOffers.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOffers.BackgroundColor =
                System.Drawing.SystemColors.Window;
            this.dgvOffers.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOffers.Dock =
                System.Windows.Forms.DockStyle.Fill;
            this.dgvOffers.Location =
                new System.Drawing.Point(3, 19);
            this.dgvOffers.MultiSelect = false;
            this.dgvOffers.Name = "dgvOffers";
            this.dgvOffers.ReadOnly = true;
            this.dgvOffers.RowHeadersVisible = false;
            this.dgvOffers.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOffers.Size =
                new System.Drawing.Size(704, 275);
            this.dgvOffers.TabIndex = 0;
            this.dgvOffers.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(
                    this.dgvOffers_CellClick);

            // 
            // grpOfferDetails
            // 
            this.grpOfferDetails.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;

            this.grpOfferDetails.Controls.Add(this.lblTitle);
            this.grpOfferDetails.Controls.Add(this.txtTitle);
            this.grpOfferDetails.Controls.Add(this.lblDiscount);
            this.grpOfferDetails.Controls.Add(this.nudDiscount);
            this.grpOfferDetails.Controls.Add(this.lblStartDate);
            this.grpOfferDetails.Controls.Add(this.dtpStartDate);
            this.grpOfferDetails.Controls.Add(this.lblEndDate);
            this.grpOfferDetails.Controls.Add(this.dtpEndDate);
            this.grpOfferDetails.Controls.Add(this.chkActive);
            this.grpOfferDetails.Controls.Add(this.btnAdd);
            this.grpOfferDetails.Controls.Add(this.btnUpdate);
            this.grpOfferDetails.Controls.Add(this.btnDelete);
            this.grpOfferDetails.Controls.Add(this.btnClear);
            this.grpOfferDetails.Controls.Add(this.btnRefresh);

            this.grpOfferDetails.Location =
                new System.Drawing.Point(15, 15);

            this.grpOfferDetails.Name =
                "grpOfferDetails";

            this.grpOfferDetails.Size =
                new System.Drawing.Size(710, 225);

            this.grpOfferDetails.TabIndex = 14;
            this.grpOfferDetails.TabStop = false;
            this.grpOfferDetails.Text = "Offer Details";

            // 
            // grpOffersList
            // 
            this.grpOffersList.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;

            this.grpOffersList.Controls.Add(this.dgvOffers);

            this.grpOffersList.Location =
                new System.Drawing.Point(15, 250);

            this.grpOffersList.Name =
                "grpOffersList";

            this.grpOffersList.Size =
                new System.Drawing.Size(710, 297);

            this.grpOffersList.TabIndex = 15;
            this.grpOffersList.TabStop = false;
            this.grpOffersList.Text = "Offers List";

            // 
            // OfferManagement
            // 
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(7F, 15F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(740, 565);

            this.Controls.Add(this.grpOffersList);
            this.Controls.Add(this.grpOfferDetails);

            this.MinimumSize =
                new System.Drawing.Size(756, 604);

            this.Name =
                "OfferManagement";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text =
                "GoMart - Offer Management";

            this.Load +=
                new System.EventHandler(this.OfferManagement_Load);

            this.FormClosing +=
                new System.Windows.Forms.FormClosingEventHandler(
                    this.OfferManagement_FormClosing);

            this.grpOfferDetails.ResumeLayout(false);
            this.grpOfferDetails.PerformLayout();

            this.grpOffersList.ResumeLayout(false);

            ((System.ComponentModel.ISupportInitialize)(this.nudDiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOffers)).EndInit();

            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTitle;

        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.NumericUpDown nudDiscount;

        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;

        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;

        private System.Windows.Forms.CheckBox chkActive;

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnRefresh;

        private System.Windows.Forms.DataGridView dgvOffers;

        private System.Windows.Forms.GroupBox grpOfferDetails;
        private System.Windows.Forms.GroupBox grpOffersList;
    }
}