namespace GoMartApplication
{
    partial class frmCategory
    {
        private System.ComponentModel.IContainer components = null;

        // =====================================================
        // CONTROLS
        // =====================================================

        private System.Windows.Forms.DataGridView dataGridViewCategory;

        private System.Windows.Forms.Label lblCategoryName;
        private System.Windows.Forms.Label lblDescription;

        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.TextBox txtDescription;

        private System.Windows.Forms.Button btn0;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn3;


        // =====================================================
        // DISPOSE
        // =====================================================

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }


        // =====================================================
        // INITIALIZE COMPONENTS
        // =====================================================

        private void InitializeComponent()
        {
            this.components =
                new System.ComponentModel.Container();

            this.dataGridViewCategory =
                new System.Windows.Forms.DataGridView();

            this.lblCategoryName =
                new System.Windows.Forms.Label();

            this.lblDescription =
                new System.Windows.Forms.Label();

            this.txtCategoryName =
                new System.Windows.Forms.TextBox();

            this.txtDescription =
                new System.Windows.Forms.TextBox();

            this.btn0 =
                new System.Windows.Forms.Button();

            this.btn1 =
                new System.Windows.Forms.Button();

            this.btn2 =
                new System.Windows.Forms.Button();

            this.btn3 =
                new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)
                (this.dataGridViewCategory)).BeginInit();

            this.SuspendLayout();


            // =====================================================
            // FORM
            // =====================================================

            this.AutoScaleDimensions =
                new System.Drawing.SizeF(8F, 16F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(1100, 700);

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text =
                "GoMart - Category Management";

            this.Name =
                "frmCategory";

            this.Load +=
                new System.EventHandler(
                    this.frmCategory_Load);


            // =====================================================
            // CATEGORY NAME LABEL
            // =====================================================

            this.lblCategoryName.AutoSize =
                true;

            this.lblCategoryName.Location =
                new System.Drawing.Point(25, 25);

            this.lblCategoryName.Name =
                "lblCategoryName";

            this.lblCategoryName.Size =
                new System.Drawing.Size(108, 16);

            this.lblCategoryName.TabIndex =
                0;

            this.lblCategoryName.Text =
                "Category Name:";


            // =====================================================
            // CATEGORY NAME TEXTBOX
            // =====================================================

            this.txtCategoryName.Location =
                new System.Drawing.Point(150, 20);

            this.txtCategoryName.Name =
                "txtCategoryName";

            this.txtCategoryName.Size =
                new System.Drawing.Size(300, 22);

            this.txtCategoryName.TabIndex =
                1;


            // =====================================================
            // DESCRIPTION LABEL
            // =====================================================

            this.lblDescription.AutoSize =
                true;

            this.lblDescription.Location =
                new System.Drawing.Point(25, 65);

            this.lblDescription.Name =
                "lblDescription";

            this.lblDescription.Size =
                new System.Drawing.Size(82, 16);

            this.lblDescription.TabIndex =
                2;

            this.lblDescription.Text =
                "Description:";


            // =====================================================
            // DESCRIPTION TEXTBOX
            // =====================================================

            this.txtDescription.Location =
                new System.Drawing.Point(150, 60);

            this.txtDescription.Multiline =
                true;

            this.txtDescription.Name =
                "txtDescription";

            this.txtDescription.ScrollBars =
                System.Windows.Forms.ScrollBars.Vertical;

            this.txtDescription.Size =
                new System.Drawing.Size(300, 60);

            this.txtDescription.TabIndex =
                3;


            // =====================================================
            // ADD BUTTON
            // =====================================================

            this.btn0.Location =
                new System.Drawing.Point(500, 20);

            this.btn0.Name =
                "btn0";

            this.btn0.Size =
                new System.Drawing.Size(130, 40);

            this.btn0.TabIndex =
                4;

            this.btn0.Text =
                "Add";

            this.btn0.UseVisualStyleBackColor =
                true;

            this.btn0.Click +=
                new System.EventHandler(
                    this.btn0_Click);


            // =====================================================
            // UPDATE BUTTON
            // =====================================================

            this.btn1.Location =
                new System.Drawing.Point(645, 20);

            this.btn1.Name =
                "btn1";

            this.btn1.Size =
                new System.Drawing.Size(130, 40);

            this.btn1.TabIndex =
                5;

            this.btn1.Text =
                "Update";

            this.btn1.UseVisualStyleBackColor =
                true;

            this.btn1.Click +=
                new System.EventHandler(
                    this.btn1_Click);


            // =====================================================
            // DELETE BUTTON
            // =====================================================

            this.btn2.Location =
                new System.Drawing.Point(790, 20);

            this.btn2.Name =
                "btn2";

            this.btn2.Size =
                new System.Drawing.Size(130, 40);

            this.btn2.TabIndex =
                6;

            this.btn2.Text =
                "Delete";

            this.btn2.UseVisualStyleBackColor =
                true;

            this.btn2.Click +=
                new System.EventHandler(
                    this.btn2_Click);


            // =====================================================
            // REFRESH BUTTON
            // =====================================================

            this.btn3.Location =
                new System.Drawing.Point(935, 20);

            this.btn3.Name =
                "btn3";

            this.btn3.Size =
                new System.Drawing.Size(130, 40);

            this.btn3.TabIndex =
                7;

            this.btn3.Text =
                "Refresh";

            this.btn3.UseVisualStyleBackColor =
                true;

            this.btn3.Click +=
                new System.EventHandler(
                    this.btn3_Click);


            // =====================================================
            // CATEGORY DATA GRID
            // =====================================================

            this.dataGridViewCategory.AllowUserToAddRows =
                false;

            this.dataGridViewCategory.AllowUserToDeleteRows =
                false;

            this.dataGridViewCategory.AllowUserToResizeRows =
                false;

            this.dataGridViewCategory.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.dataGridViewCategory.BackgroundColor =
                System.Drawing.SystemColors.Window;

            this.dataGridViewCategory.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.dataGridViewCategory.Location =
                new System.Drawing.Point(25, 150);

            this.dataGridViewCategory.MultiSelect =
                false;

            this.dataGridViewCategory.Name =
                "dataGridViewCategory";

            this.dataGridViewCategory.ReadOnly =
                true;

            this.dataGridViewCategory.RowHeadersVisible =
                false;

            this.dataGridViewCategory.RowTemplate.Height =
                30;

            this.dataGridViewCategory.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.dataGridViewCategory.Size =
                new System.Drawing.Size(1040, 490);

            this.dataGridViewCategory.TabIndex =
                8;

            this.dataGridViewCategory.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(
                    this.dataGridViewCategory_CellClick);


            // =====================================================
            // ADD CONTROLS
            // =====================================================

            this.Controls.Add(
                this.lblCategoryName);

            this.Controls.Add(
                this.txtCategoryName);

            this.Controls.Add(
                this.lblDescription);

            this.Controls.Add(
                this.txtDescription);

            this.Controls.Add(
                this.btn0);

            this.Controls.Add(
                this.btn1);

            this.Controls.Add(
                this.btn2);

            this.Controls.Add(
                this.btn3);

            this.Controls.Add(
                this.dataGridViewCategory);


            // =====================================================
            // RESUME FORM
            // =====================================================

            ((System.ComponentModel.ISupportInitialize)
                (this.dataGridViewCategory)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}