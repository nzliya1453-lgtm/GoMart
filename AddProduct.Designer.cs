namespace GoMartApplication
{
    partial class AddProduct
    {
        private System.ComponentModel.IContainer components = null;


    private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblProdName;
        private System.Windows.Forms.Label lblProdPrice;
        private System.Windows.Forms.Label lblProdQty;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblDescription;

        private System.Windows.Forms.TextBox txtProdName;
        private System.Windows.Forms.TextBox txtProdPrice;
        private System.Windows.Forms.TextBox txtProdQty;
        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.TextBox txtDescription;

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

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();

            this.lblProdName = new System.Windows.Forms.Label();
            this.lblProdPrice = new System.Windows.Forms.Label();
            this.lblProdQty = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();

            this.txtProdName = new System.Windows.Forms.TextBox();
            this.txtProdPrice = new System.Windows.Forms.TextBox();
            this.txtProdQty = new System.Windows.Forms.TextBox();
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();

            this.btn0 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // ==========================================
            // lblTitle
            // ==========================================

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font(
                "Segoe UI",
                18F,
                System.Drawing.FontStyle.Bold);

            this.lblTitle.Location =
                new System.Drawing.Point(125, 20);

            this.lblTitle.Name = "lblTitle";

            this.lblTitle.Size =
                new System.Drawing.Size(180, 32);

            this.lblTitle.Text =
                "Add Product";

            // ==========================================
            // lblProdName
            // ==========================================

            this.lblProdName.AutoSize = true;

            this.lblProdName.Location =
                new System.Drawing.Point(40, 80);

            this.lblProdName.Name =
                "lblProdName";

            this.lblProdName.Size =
                new System.Drawing.Size(85, 15);

            this.lblProdName.Text =
                "Product Name";

            // ==========================================
            // txtProdName
            // ==========================================

            this.txtProdName.Location =
                new System.Drawing.Point(160, 77);

            this.txtProdName.Name =
                "txtProdName";

            this.txtProdName.Size =
                new System.Drawing.Size(250, 23);

            // ==========================================
            // lblProdPrice
            // ==========================================

            this.lblProdPrice.AutoSize = true;

            this.lblProdPrice.Location =
                new System.Drawing.Point(40, 120);

            this.lblProdPrice.Name =
                "lblProdPrice";

            this.lblProdPrice.Size =
                new System.Drawing.Size(72, 15);

            this.lblProdPrice.Text =
                "Price";

            // ==========================================
            // txtProdPrice
            // ==========================================

            this.txtProdPrice.Location =
                new System.Drawing.Point(160, 117);

            this.txtProdPrice.Name =
                "txtProdPrice";

            this.txtProdPrice.Size =
                new System.Drawing.Size(250, 23);

            // ==========================================
            // lblProdQty
            // ==========================================

            this.lblProdQty.AutoSize = true;

            this.lblProdQty.Location =
                new System.Drawing.Point(40, 160);

            this.lblProdQty.Name =
                "lblProdQty";

            this.lblProdQty.Size =
                new System.Drawing.Size(53, 15);

            this.lblProdQty.Text =
                "Quantity";

            // ==========================================
            // txtProdQty
            // ==========================================

            this.txtProdQty.Location =
                new System.Drawing.Point(160, 157);

            this.txtProdQty.Name =
                "txtProdQty";

            this.txtProdQty.Size =
                new System.Drawing.Size(250, 23);

            // ==========================================
            // lblCategory
            // ==========================================

            this.lblCategory.AutoSize = true;

            this.lblCategory.Location =
                new System.Drawing.Point(40, 200);

            this.lblCategory.Name =
                "lblCategory";

            this.lblCategory.Size =
                new System.Drawing.Size(60, 15);

            this.lblCategory.Text =
                "Category";

            // ==========================================
            // txtCategoryName
            // ==========================================

            this.txtCategoryName.Location =
                new System.Drawing.Point(160, 197);

            this.txtCategoryName.Name =
                "txtCategoryName";

            this.txtCategoryName.Size =
                new System.Drawing.Size(250, 23);

            // ==========================================
            // lblDescription
            // ==========================================

            this.lblDescription.AutoSize = true;

            this.lblDescription.Location =
                new System.Drawing.Point(40, 240);

            this.lblDescription.Name =
                "lblDescription";

            this.lblDescription.Size =
                new System.Drawing.Size(75, 15);

            this.lblDescription.Text =
                "Description";

            // ==========================================
            // txtDescription
            // ==========================================

            this.txtDescription.Location =
                new System.Drawing.Point(160, 237);

            this.txtDescription.Multiline = true;

            this.txtDescription.Name =
                "txtDescription";

            this.txtDescription.Size =
                new System.Drawing.Size(250, 60);

            // ==========================================
            // btn0 - ADD
            // ==========================================

            this.btn0.Location =
                new System.Drawing.Point(160, 320);

            this.btn0.Name =
                "btn0";

            this.btn0.Size =
                new System.Drawing.Size(110, 35);

            this.btn0.Text =
                "Add Product";

            this.btn0.UseVisualStyleBackColor =
                true;

            this.btn0.Click +=
                new System.EventHandler(
                    this.btn0_Click);

            // ==========================================
            // btn1 - CLEAR
            // ==========================================

            this.btn1.Location =
                new System.Drawing.Point(280, 320);

            this.btn1.Name =
                "btn1";

            this.btn1.Size =
                new System.Drawing.Size(100, 35);

            this.btn1.Text =
                "Clear";

            this.btn1.UseVisualStyleBackColor =
                true;

            this.btn1.Click +=
                new System.EventHandler(
                    this.btn1_Click);

            // ==========================================
            // AddProduct FORM
            // ==========================================

            this.AutoScaleDimensions =
                new System.Drawing.SizeF(7F, 15F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(460, 390);

            this.Controls.Add(this.lblTitle);

            this.Controls.Add(this.lblProdName);
            this.Controls.Add(this.txtProdName);

            this.Controls.Add(this.lblProdPrice);
            this.Controls.Add(this.txtProdPrice);

            this.Controls.Add(this.lblProdQty);
            this.Controls.Add(this.txtProdQty);

            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.txtCategoryName);

            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);

            this.Controls.Add(this.btn0);
            this.Controls.Add(this.btn1);

            this.Name =
                "AddProduct";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text =
                "GoMart - Add Product";

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }


}
