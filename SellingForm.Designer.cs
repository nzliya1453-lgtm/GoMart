
namespace GoMartApplication
{
    partial class SellingForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label label9;

        private System.Windows.Forms.ComboBox cmbCategory;

        private System.Windows.Forms.TextBox txtProductID;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtQty;

        private System.Windows.Forms.DataGridView dataGridView1_Order;
        private System.Windows.Forms.DataGridView dataGridView2_Product;
        private System.Windows.Forms.DataGridView dataGridView1;

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnAddOrder;
        private System.Windows.Forms.Button btnRefCat;
        private System.Windows.Forms.Button Add;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;

        protected override void Dispose(bool disposing)
        {
            if (disposing &&
                (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblDate = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();

            this.cmbCategory = new System.Windows.Forms.ComboBox();

            this.txtProductID = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtQty = new System.Windows.Forms.TextBox();

            this.dataGridView1_Order =
                new System.Windows.Forms.DataGridView();

            this.dataGridView2_Product =
                new System.Windows.Forms.DataGridView();

            this.dataGridView1 =
                new System.Windows.Forms.DataGridView();

            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnAddOrder = new System.Windows.Forms.Button();
            this.btnRefCat = new System.Windows.Forms.Button();
            this.Add = new System.Windows.Forms.Button();

            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)
                (this.dataGridView1_Order)).BeginInit();

            ((System.ComponentModel.ISupportInitialize)
                (this.dataGridView2_Product)).BeginInit();

            ((System.ComponentModel.ISupportInitialize)
                (this.dataGridView1)).BeginInit();

            this.SuspendLayout();

            // ========================================================
            // LABEL 1 - TITLE
            // ========================================================

            this.label1.AutoSize = true;
            this.label1.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    18F,
                    System.Drawing.FontStyle.Bold);

            this.label1.Location =
                new System.Drawing.Point(30, 20);

            this.label1.Name = "label1";
            this.label1.Size =
                new System.Drawing.Size(190, 32);

            this.label1.Text = "Selling Form";

            // ========================================================
            // DATE LABEL
            // ========================================================

            this.label2.AutoSize = true;
            this.label2.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Bold);

            this.label2.Location =
                new System.Drawing.Point(700, 30);

            this.label2.Name = "label2";
            this.label2.Size =
                new System.Drawing.Size(45, 19);

            this.label2.Text = "Date:";

            // ========================================================
            // DATE VALUE
            // ========================================================

            this.lblDate.AutoSize = true;
            this.lblDate.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);

            this.lblDate.Location =
                new System.Drawing.Point(755, 30);

            this.lblDate.Name = "lblDate";
            this.lblDate.Size =
                new System.Drawing.Size(75, 19);

            this.lblDate.Text = "00/00/0000";

            // ========================================================
            // CATEGORY LABEL
            // ========================================================

            this.label3.AutoSize = true;
            this.label3.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Bold);

            this.label3.Location =
                new System.Drawing.Point(30, 80);

            this.label3.Name = "label3";
            this.label3.Size =
                new System.Drawing.Size(72, 19);

            this.label3.Text = "Category:";

            // ========================================================
            // CATEGORY COMBOBOX
            // ========================================================

            this.cmbCategory.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cmbCategory.FormattingEnabled = true;

            this.cmbCategory.Location =
                new System.Drawing.Point(110, 78);

            this.cmbCategory.Name = "cmbCategory";

            this.cmbCategory.Size =
                new System.Drawing.Size(220, 23);

            // ========================================================
            // SEARCH BUTTON
            // ========================================================

            this.button3.Location =
                new System.Drawing.Point(345, 77);

            this.button3.Name = "button3";

            this.button3.Size =
                new System.Drawing.Size(90, 27);

            this.button3.Text = "Search";

            this.button3.UseVisualStyleBackColor = true;

            this.button3.Click +=
                new System.EventHandler(
                    this.button3_Click);

            // ========================================================
            // REFRESH BUTTON
            // ========================================================

            this.btnRefCat.Location =
                new System.Drawing.Point(445, 77);

            this.btnRefCat.Name = "btnRefCat";

            this.btnRefCat.Size =
                new System.Drawing.Size(90, 27);

            this.btnRefCat.Text = "Refresh";

            this.btnRefCat.UseVisualStyleBackColor = true;

            this.btnRefCat.Click +=
                new System.EventHandler(
                    this.btnRefCat_Click);

            // ========================================================
            // PRODUCT GRID
            // ========================================================

            this.dataGridView2_Product.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.dataGridView2_Product.Location =
                new System.Drawing.Point(30, 120);

            this.dataGridView2_Product.Name =
                "dataGridView2_Product";

            this.dataGridView2_Product.RowHeadersWidth = 51;

            this.dataGridView2_Product.Size =
                new System.Drawing.Size(600, 260);

            this.dataGridView2_Product.TabIndex = 0;

            this.dataGridView2_Product.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(
                    this.dataGridView2_Product_CellClick);

            this.dataGridView2_Product.DoubleClick +=
                new System.EventHandler(
                    this.dataGridView2_Product_DoubleClick);

            // ========================================================
            // PRODUCT ID LABEL
            // ========================================================

            this.label4.AutoSize = true;

            this.label4.Location =
                new System.Drawing.Point(660, 125);

            this.label4.Name = "label4";

            this.label4.Text = "Product ID:";

            // ========================================================
            // PRODUCT ID TEXTBOX
            // ========================================================

            this.txtProductID.Location =
                new System.Drawing.Point(750, 122);

            this.txtProductID.Name =
                "txtProductID";

            this.txtProductID.ReadOnly = true;

            this.txtProductID.Size =
                new System.Drawing.Size(190, 23);

            // ========================================================
            // PRODUCT NAME LABEL
            // ========================================================

            this.label5.AutoSize = true;

            this.label5.Location =
                new System.Drawing.Point(660, 165);

            this.label5.Name = "label5";

            this.label5.Text = "Product:";

            // ========================================================
            // PRODUCT NAME TEXTBOX
            // ========================================================

            this.txtProductName.Location =
                new System.Drawing.Point(750, 162);

            this.txtProductName.Name =
                "txtProductName";

            this.txtProductName.ReadOnly = true;

            this.txtProductName.Size =
                new System.Drawing.Size(190, 23);

            // ========================================================
            // PRICE LABEL
            // ========================================================

            this.label6.AutoSize = true;

            this.label6.Location =
                new System.Drawing.Point(660, 205);

            this.label6.Name = "label6";

            this.label6.Text = "Price:";

            // ========================================================
            // PRICE TEXTBOX
            // ========================================================

            this.txtPrice.Location =
                new System.Drawing.Point(750, 202);

            this.txtPrice.Name =
                "txtPrice";

            this.txtPrice.ReadOnly = true;

            this.txtPrice.Size =
                new System.Drawing.Size(190, 23);

            // ========================================================
            // QUANTITY LABEL
            // ========================================================

            this.label7.AutoSize = true;

            this.label7.Location =
                new System.Drawing.Point(660, 245);

            this.label7.Name = "label7";

            this.label7.Text = "Quantity:";

            // ========================================================
            // QUANTITY TEXTBOX
            // ========================================================

            this.txtQty.Location =
                new System.Drawing.Point(750, 242);

            this.txtQty.Name =
                "txtQty";

            this.txtQty.Size =
                new System.Drawing.Size(190, 23);

            this.txtQty.Text = "1";

            this.txtQty.TextChanged +=
                new System.EventHandler(
                    this.textBox4_TextChanged);

            // ========================================================
            // ADD ORDER BUTTON
            // ========================================================

            this.btnAddOrder.Location =
                new System.Drawing.Point(750, 285);

            this.btnAddOrder.Name =
                "btnAddOrder";

            this.btnAddOrder.Size =
                new System.Drawing.Size(190, 35);

            this.btnAddOrder.Text =
                "Add to Order";

            this.btnAddOrder.UseVisualStyleBackColor = true;

            this.btnAddOrder.Click +=
                new System.EventHandler(
                    this.btnAddOrder_Click);

            // ========================================================
            // ORDER LABEL
            // ========================================================

            this.label8.AutoSize = true;

            this.label8.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    12F,
                    System.Drawing.FontStyle.Bold);

            this.label8.Location =
                new System.Drawing.Point(30, 400);

            this.label8.Name = "label8";

            this.label8.Text =
                "Current Order";

            // ========================================================
            // ORDER GRID
            // ========================================================

            this.dataGridView1_Order.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.dataGridView1_Order.Location =
                new System.Drawing.Point(30, 435);

            this.dataGridView1_Order.Name =
                "dataGridView1_Order";

            this.dataGridView1_Order.RowHeadersWidth = 51;

            this.dataGridView1_Order.Size =
                new System.Drawing.Size(700, 180);

            this.dataGridView1_Order.TabIndex = 1;

            // ========================================================
            // REMOVE BUTTON
            // ========================================================

            this.button1.Location =
                new System.Drawing.Point(750, 435);

            this.button1.Name = "button1";

            this.button1.Size =
                new System.Drawing.Size(190, 35);

            this.button1.Text =
                "Remove Selected";

            this.button1.UseVisualStyleBackColor = true;

            this.button1.Click +=
                new System.EventHandler(
                    this.button1_Click);

            // ========================================================
            // CLEAR BUTTON
            // ========================================================

            this.button2.Location =
                new System.Drawing.Point(750, 480);

            this.button2.Name = "button2";

            this.button2.Size =
                new System.Drawing.Size(190, 35);

            this.button2.Text =
                "Clear Order";

            this.button2.UseVisualStyleBackColor = true;

            this.button2.Click +=
                new System.EventHandler(
                    this.button2_Click);

            // ========================================================
            // TOTAL LABEL
            // ========================================================

            this.label10.AutoSize = true;

            this.label10.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    12F,
                    System.Drawing.FontStyle.Bold);

            this.label10.Location =
                new System.Drawing.Point(750, 540);

            this.label10.Name = "label10";

            this.label10.Text =
                "Total:";

            // ========================================================
            // TOTAL VALUE
            // ========================================================

            this.label9.AutoSize = true;

            this.label9.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    12F,
                    System.Drawing.FontStyle.Bold);

            this.label9.Location =
                new System.Drawing.Point(805, 540);

            this.label9.Name = "label9";

            this.label9.Text =
                "Rs.0.00";

            // ========================================================
            // SAVE / ADD BUTTON
            // ========================================================

            this.Add.Location =
                new System.Drawing.Point(750, 575);

            this.Add.Name = "Add";

            this.Add.Size =
                new System.Drawing.Size(190, 40);

            this.Add.Text =
                "Confirm Order";

            this.Add.UseVisualStyleBackColor = true;

            this.Add.Click +=
                new System.EventHandler(
                    this.Add_Click);

            // ========================================================
            // BILL LIST LABEL
            // ========================================================

            this.label11.AutoSize = true;

            this.label11.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    12F,
                    System.Drawing.FontStyle.Bold);

            this.label11.Location =
                new System.Drawing.Point(30, 650);

            this.label11.Name = "label11";

            this.label11.Text =
                "Bill List";

            // ========================================================
            // BILL GRID
            // ========================================================

            this.dataGridView1.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.dataGridView1.Location =
                new System.Drawing.Point(30, 685);

            this.dataGridView1.Name =
                "dataGridView1";

            this.dataGridView1.RowHeadersWidth = 51;

            this.dataGridView1.Size =
                new System.Drawing.Size(910, 180);

            this.dataGridView1.TabIndex = 2;

            // ========================================================
            // FORM
            // ========================================================

            this.AutoScaleDimensions =
                new System.Drawing.SizeF(7F, 15F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(980, 900);

            this.Controls.Add(
                this.dataGridView1);

            this.Controls.Add(
                this.label11);

            this.Controls.Add(
                this.Add);

            this.Controls.Add(
                this.label9);

            this.Controls.Add(
                this.label10);

            this.Controls.Add(
                this.button2);

            this.Controls.Add(
                this.button1);

            this.Controls.Add(
                this.dataGridView1_Order);

            this.Controls.Add(
                this.label8);

            this.Controls.Add(
                this.btnAddOrder);

            this.Controls.Add(
                this.txtQty);

            this.Controls.Add(
                this.label7);

            this.Controls.Add(
                this.txtPrice);

            this.Controls.Add(
                this.label6);

            this.Controls.Add(
                this.txtProductName);

            this.Controls.Add(
                this.label5);

            this.Controls.Add(
                this.txtProductID);

            this.Controls.Add(
                this.label4);

            this.Controls.Add(
                this.dataGridView2_Product);

            this.Controls.Add(
                this.btnRefCat);

            this.Controls.Add(
                this.button3);

            this.Controls.Add(
                this.cmbCategory);

            this.Controls.Add(
                this.label3);

            this.Controls.Add(
                this.lblDate);

            this.Controls.Add(
                this.label2);

            this.Controls.Add(
                this.label1);

            this.Name =
                "SellingForm";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text =
                "GoMart - Selling";

            this.FormClosing +=
                new System.Windows.Forms.FormClosingEventHandler(
                    this.SellingForm_FormClosing);

            this.Load +=
                new System.EventHandler(
                    this.SellingForm_Load);

            ((System.ComponentModel.ISupportInitialize)
                (this.dataGridView1_Order)).EndInit();

            ((System.ComponentModel.ISupportInitialize)
                (this.dataGridView2_Product)).EndInit();

            ((System.ComponentModel.ISupportInitialize)
                (this.dataGridView1)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
