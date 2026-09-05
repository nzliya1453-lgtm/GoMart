namespace GoMartApplication
{
    partial class ProductFilter
    {
        private System.ComponentModel.IContainer components = null;

        // =====================================================
        // CONTROLS
        // =====================================================

        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Button btn0;
        private System.Windows.Forms.Button btn1;


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

            this.dgvProducts =
                new System.Windows.Forms.DataGridView();

            this.btn0 =
                new System.Windows.Forms.Button();

            this.btn1 =
                new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvProducts)).BeginInit();

            this.SuspendLayout();


            // =====================================================
            // FORM
            // =====================================================

            this.AutoScaleDimensions =
                new System.Drawing.SizeF(8F, 16F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(1100, 650);

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text =
                "Product Filter";

            this.Name =
                "ProductFilter";

            this.Load +=
                new System.EventHandler(
                    this.ProductFilter_Load);

            this.FormClosing +=
                new System.Windows.Forms.FormClosingEventHandler(
                    this.ProductFilter_FormClosing);


            // =====================================================
            // DATA GRID VIEW
            // =====================================================

            this.dgvProducts.AllowUserToAddRows =
                false;

            this.dgvProducts.AllowUserToDeleteRows =
                false;

            this.dgvProducts.AllowUserToResizeRows =
                false;

            this.dgvProducts.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.dgvProducts.BackgroundColor =
                System.Drawing.SystemColors.Window;

            this.dgvProducts.BorderStyle =
                System.Windows.Forms.BorderStyle.Fixed3D;

            this.dgvProducts.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.dgvProducts.Location =
                new System.Drawing.Point(20, 20);

            this.dgvProducts.MultiSelect =
                false;

            this.dgvProducts.Name =
                "dgvProducts";

            this.dgvProducts.ReadOnly =
                true;

            this.dgvProducts.RowHeadersVisible =
                false;

            this.dgvProducts.RowTemplate.Height =
                28;

            this.dgvProducts.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.dgvProducts.Size =
                new System.Drawing.Size(1060, 500);

            this.dgvProducts.TabIndex =
                0;


            // =====================================================
            // LOAD PRODUCTS BUTTON
            // =====================================================

            this.btn0.Location =
                new System.Drawing.Point(20, 550);

            this.btn0.Name =
                "btn0";

            this.btn0.Size =
                new System.Drawing.Size(180, 45);

            this.btn0.TabIndex =
                1;

            this.btn0.Text =
                "Refresh Products";

            this.btn0.UseVisualStyleBackColor =
                true;

            this.btn0.Click +=
                new System.EventHandler(
                    this.btn0_Click);


            // =====================================================
            // ADD TO CART BUTTON
            // =====================================================

            this.btn1.Location =
                new System.Drawing.Point(220, 550);

            this.btn1.Name =
                "btn1";

            this.btn1.Size =
                new System.Drawing.Size(180, 45);

            this.btn1.TabIndex =
                2;

            this.btn1.Text =
                "Add to Cart";

            this.btn1.UseVisualStyleBackColor =
                true;

            this.btn1.Click +=
                new System.EventHandler(
                    this.btn1_Click);


            // =====================================================
            // ADD CONTROLS TO FORM
            // =====================================================

            this.Controls.Add(
                this.dgvProducts);

            this.Controls.Add(
                this.btn0);

            this.Controls.Add(
                this.btn1);


            // =====================================================
            // RESUME FORM
            // =====================================================

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvProducts)).EndInit();

            this.ResumeLayout(false);
        }
    }
}