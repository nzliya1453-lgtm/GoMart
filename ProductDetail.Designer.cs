namespace GoMartApplication
{
    partial class ProductDetail
    {
        private System.ComponentModel.IContainer components = null;

        // =========================================================
        // CONTROLS
        // =========================================================

        private System.Windows.Forms.DataGridView dataGridViewProduct;

        private System.Windows.Forms.Label lblProdName;
        private System.Windows.Forms.Label lblCategoryName;
        private System.Windows.Forms.Label lblProdPrice;
        private System.Windows.Forms.Label lblProdQty;
        private System.Windows.Forms.Label lblDescription;

        private System.Windows.Forms.TextBox txtProdName;
        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.TextBox txtProdPrice;
        private System.Windows.Forms.TextBox txtProdQty;
        private System.Windows.Forms.TextBox txtDescription;

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClear;


        // =========================================================
        // DISPOSE
        // =========================================================

        protected override void Dispose(bool disposing)
        {
            if (disposing &&
                (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }


        // =========================================================
        // INITIALIZE COMPONENTS
        // =========================================================

        private void InitializeComponent()
        {
            this.dataGridViewProduct =
                new System.Windows.Forms.DataGridView();

            this.lblProdName =
                new System.Windows.Forms.Label();

            this.lblCategoryName =
                new System.Windows.Forms.Label();

            this.lblProdPrice =
                new System.Windows.Forms.Label();

            this.lblProdQty =
                new System.Windows.Forms.Label();

            this.lblDescription =
                new System.Windows.Forms.Label();

            this.txtProdName =
                new System.Windows.Forms.TextBox();

            this.txtCategoryName =
                new System.Windows.Forms.TextBox();

            this.txtProdPrice =
                new System.Windows.Forms.TextBox();

            this.txtProdQty =
                new System.Windows.Forms.TextBox();

            this.txtDescription =
                new System.Windows.Forms.TextBox();

            this.btnAdd =
                new System.Windows.Forms.Button();

            this.btnUpdate =
                new System.Windows.Forms.Button();

            this.btnDelete =
                new System.Windows.Forms.Button();

            this.btnRefresh =
                new System.Windows.Forms.Button();

            this.btnClear =
                new System.Windows.Forms.Button();


            ((System.ComponentModel.ISupportInitialize)
                (this.dataGridViewProduct)).BeginInit();

            this.SuspendLayout();


            // =====================================================
            // dataGridViewProduct
            // =====================================================

            this.dataGridViewProduct.AllowUserToAddRows =
                false;

            this.dataGridViewProduct.AllowUserToDeleteRows =
                false;

            this.dataGridViewProduct.AllowUserToResizeRows =
                false;

            this.dataGridViewProduct.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.dataGridViewProduct.BackgroundColor =
                System.Drawing.SystemColors.Window;

            this.dataGridViewProduct.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.dataGridViewProduct.Location =
                new System.Drawing.Point(25, 250);

            this.dataGridViewProduct.MultiSelect =
                false;

            this.dataGridViewProduct.Name =
                "dataGridViewProduct";

            this.dataGridViewProduct.ReadOnly =
                true;

            this.dataGridViewProduct.RowHeadersVisible =
                false;

            this.dataGridViewProduct.RowTemplate.Height =
                28;

            this.dataGridViewProduct.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.dataGridViewProduct.Size =
                new System.Drawing.Size(1150, 390);

            this.dataGridViewProduct.TabIndex =
                0;


            // =====================================================
            // lblProdName
            // =====================================================

            this.lblProdName.AutoSize =
                true;

            this.lblProdName.Location =
                new System.Drawing.Point(25, 25);

            this.lblProdName.Name =
                "lblProdName";

            this.lblProdName.Size =
                new System.Drawing.Size(104, 20);

            this.lblProdName.TabIndex =
                1;

            this.lblProdName.Text =
                "Product Name";


            // =====================================================
            // txtProdName
            // =====================================================

            this.txtProdName.Location =
                new System.Drawing.Point(145, 20);

            this.txtProdName.Name =
                "txtProdName";

            this.txtProdName.Size =
                new System.Drawing.Size(250, 27);

            this.txtProdName.TabIndex =
                2;


            // =====================================================
            // lblCategoryName
            // =====================================================

            this.lblCategoryName.AutoSize =
                true;

            this.lblCategoryName.Location =
                new System.Drawing.Point(425, 25);

            this.lblCategoryName.Name =
                "lblCategoryName";

            this.lblCategoryName.Size =
                new System.Drawing.Size(72, 20);

            this.lblCategoryName.TabIndex =
                3;

            this.lblCategoryName.Text =
                "Category";


            // =====================================================
            // txtCategoryName
            // =====================================================

            this.txtCategoryName.Location =
                new System.Drawing.Point(510, 20);

            this.txtCategoryName.Name =
                "txtCategoryName";

            this.txtCategoryName.Size =
                new System.Drawing.Size(250, 27);

            this.txtCategoryName.TabIndex =
                4;


            // =====================================================
            // lblProdPrice
            // =====================================================

            this.lblProdPrice.AutoSize =
                true;

            this.lblProdPrice.Location =
                new System.Drawing.Point(790, 25);

            this.lblProdPrice.Name =
                "lblProdPrice";

            this.lblProdPrice.Size =
                new System.Drawing.Size(44, 20);

            this.lblProdPrice.TabIndex =
                5;

            this.lblProdPrice.Text =
                "Price";


            // =====================================================
            // txtProdPrice
            // =====================================================

            this.txtProdPrice.Location =
                new System.Drawing.Point(850, 20);

            this.txtProdPrice.Name =
                "txtProdPrice";

            this.txtProdPrice.Size =
                new System.Drawing.Size(150, 27);

            this.txtProdPrice.TabIndex =
                6;


            // =====================================================
            // lblProdQty
            // =====================================================

            this.lblProdQty.AutoSize =
                true;

            this.lblProdQty.Location =
                new System.Drawing.Point(25, 75);

            this.lblProdQty.Name =
                "lblProdQty";

            this.lblProdQty.Size =
                new System.Drawing.Size(69, 20);

            this.lblProdQty.TabIndex =
                7;

            this.lblProdQty.Text =
                "Quantity";


            // =====================================================
            // txtProdQty
            // =====================================================

            this.txtProdQty.Location =
                new System.Drawing.Point(145, 70);

            this.txtProdQty.Name =
                "txtProdQty";

            this.txtProdQty.Size =
                new System.Drawing.Size(250, 27);

            this.txtProdQty.TabIndex =
                8;


            // =====================================================
            // lblDescription
            // =====================================================

            this.lblDescription.AutoSize =
                true;

            this.lblDescription.Location =
                new System.Drawing.Point(425, 75);

            this.lblDescription.Name =
                "lblDescription";

            this.lblDescription.Size =
                new System.Drawing.Size(88, 20);

            this.lblDescription.TabIndex =
                9;

            this.lblDescription.Text =
                "Description";


            // =====================================================
            // txtDescription
            // =====================================================

            this.txtDescription.Location =
                new System.Drawing.Point(510, 70);

            this.txtDescription.Multiline =
                true;

            this.txtDescription.Name =
                "txtDescription";

            this.txtDescription.ScrollBars =
                System.Windows.Forms.ScrollBars.Vertical;

            this.txtDescription.Size =
                new System.Drawing.Size(490, 70);

            this.txtDescription.TabIndex =
                10;


            // =====================================================
            // btnAdd
            // =====================================================

            this.btnAdd.Location =
                new System.Drawing.Point(25, 170);

            this.btnAdd.Name =
                "btnAdd";

            this.btnAdd.Size =
                new System.Drawing.Size(130, 40);

            this.btnAdd.TabIndex =
                11;

            this.btnAdd.Text =
                "Add Product";

            this.btnAdd.UseVisualStyleBackColor =
                true;


            // =====================================================
            // btnUpdate
            // =====================================================

            this.btnUpdate.Location =
                new System.Drawing.Point(175, 170);

            this.btnUpdate.Name =
                "btnUpdate";

            this.btnUpdate.Size =
                new System.Drawing.Size(130, 40);

            this.btnUpdate.TabIndex =
                12;

            this.btnUpdate.Text =
                "Update";

            this.btnUpdate.UseVisualStyleBackColor =
                true;


            // =====================================================
            // btnDelete
            // =====================================================

            this.btnDelete.Location =
                new System.Drawing.Point(325, 170);

            this.btnDelete.Name =
                "btnDelete";

            this.btnDelete.Size =
                new System.Drawing.Size(130, 40);

            this.btnDelete.TabIndex =
                13;

            this.btnDelete.Text =
                "Delete";

            this.btnDelete.UseVisualStyleBackColor =
                true;


            // =====================================================
            // btnRefresh
            // =====================================================

            this.btnRefresh.Location =
                new System.Drawing.Point(475, 170);

            this.btnRefresh.Name =
                "btnRefresh";

            this.btnRefresh.Size =
                new System.Drawing.Size(130, 40);

            this.btnRefresh.TabIndex =
                14;

            this.btnRefresh.Text =
                "Refresh";

            this.btnRefresh.UseVisualStyleBackColor =
                true;


            // =====================================================
            // btnClear
            // =====================================================

            this.btnClear.Location =
                new System.Drawing.Point(625, 170);

            this.btnClear.Name =
                "btnClear";

            this.btnClear.Size =
                new System.Drawing.Size(130, 40);

            this.btnClear.TabIndex =
                15;

            this.btnClear.Text =
                "Clear";

            this.btnClear.UseVisualStyleBackColor =
                true;


            // =====================================================
            // FORM
            // =====================================================

            this.AutoScaleDimensions =
                new System.Drawing.SizeF(
                    8F,
                    20F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(
                    1200,
                    680);

            this.Controls.Add(
                this.btnClear);

            this.Controls.Add(
                this.btnRefresh);

            this.Controls.Add(
                this.btnDelete);

            this.Controls.Add(
                this.btnUpdate);

            this.Controls.Add(
                this.btnAdd);

            this.Controls.Add(
                this.txtDescription);

            this.Controls.Add(
                this.lblDescription);

            this.Controls.Add(
                this.txtProdQty);

            this.Controls.Add(
                this.lblProdQty);

            this.Controls.Add(
                this.txtProdPrice);

            this.Controls.Add(
                this.lblProdPrice);

            this.Controls.Add(
                this.txtCategoryName);

            this.Controls.Add(
                this.lblCategoryName);

            this.Controls.Add(
                this.txtProdName);

            this.Controls.Add(
                this.lblProdName);

            this.Controls.Add(
                this.dataGridViewProduct);

            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.FixedSingle;

            this.MaximizeBox =
                false;

            this.MinimizeBox =
                true;

            this.Name =
                "ProductDetail";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text =
                "GoMart - Product Details";


            // =====================================================
            // EVENTS
            // =====================================================

            this.Load +=
                new System.EventHandler(
                    this.ProductDetail_Load);

            this.btnAdd.Click +=
                new System.EventHandler(
                    this.btnAdd_Click);

            this.btnUpdate.Click +=
                new System.EventHandler(
                    this.btnUpdate_Click);

            this.btnDelete.Click +=
                new System.EventHandler(
                    this.btnDelete_Click);

            this.btnRefresh.Click +=
                new System.EventHandler(
                    this.btnRefresh_Click);

            this.btnClear.Click +=
                new System.EventHandler(
                    this.btnClear_Click);

            this.dataGridViewProduct.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(
                    this.dataGridViewProduct_CellClick);


            ((System.ComponentModel.ISupportInitialize)
                (this.dataGridViewProduct)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}