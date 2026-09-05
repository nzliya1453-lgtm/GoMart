namespace GoMartApplication
{
    partial class Cart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise false.</param>
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

            this.dataGridViewCart = new System.Windows.Forms.DataGridView();

            this.btn0 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();

            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCart)).BeginInit();

            this.SuspendLayout();

            // 
            // dataGridViewCart
            // 
            this.dataGridViewCart.AllowUserToAddRows = false;
            this.dataGridViewCart.AllowUserToDeleteRows = false;
            this.dataGridViewCart.AllowUserToResizeRows = false;
            this.dataGridViewCart.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                ((((System.Windows.Forms.AnchorStyles.Top |
                    System.Windows.Forms.AnchorStyles.Bottom) |
                    System.Windows.Forms.AnchorStyles.Left) |
                    System.Windows.Forms.AnchorStyles.Right)));

            this.dataGridViewCart.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.dataGridViewCart.BackgroundColor =
                System.Drawing.SystemColors.Window;

            this.dataGridViewCart.BorderStyle =
                System.Windows.Forms.BorderStyle.Fixed3D;

            this.dataGridViewCart.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.dataGridViewCart.Location =
                new System.Drawing.Point(25, 75);

            this.dataGridViewCart.MultiSelect = false;

            this.dataGridViewCart.Name =
                "dataGridViewCart";

            this.dataGridViewCart.ReadOnly = true;

            this.dataGridViewCart.RowHeadersVisible = false;

            this.dataGridViewCart.RowTemplate.Height = 30;

            this.dataGridViewCart.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.dataGridViewCart.Size =
                new System.Drawing.Size(850, 380);

            this.dataGridViewCart.TabIndex = 0;

            // 
            // btn0
            // 
            this.btn0.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                (System.Windows.Forms.AnchorStyles.Bottom |
                 System.Windows.Forms.AnchorStyles.Left));

            this.btn0.Location =
                new System.Drawing.Point(25, 480);

            this.btn0.Name =
                "btn0";

            this.btn0.Size =
                new System.Drawing.Size(120, 40);

            this.btn0.TabIndex = 1;

            this.btn0.Text =
                "Refresh";

            this.btn0.UseVisualStyleBackColor =
                true;

            this.btn0.Click +=
                new System.EventHandler(this.btn0_Click);

            // 
            // btn1
            // 
            this.btn1.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                (System.Windows.Forms.AnchorStyles.Bottom |
                 System.Windows.Forms.AnchorStyles.Right));

            this.btn1.Location =
                new System.Drawing.Point(755, 480);

            this.btn1.Name =
                "btn1";

            this.btn1.Size =
                new System.Drawing.Size(120, 40);

            this.btn1.TabIndex = 2;

            this.btn1.Text =
                "Checkout";

            this.btn1.UseVisualStyleBackColor =
                true;

            this.btn1.Click +=
                new System.EventHandler(this.btn1_Click);

            // 
            // btn2
            // 
            this.btn2.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                (System.Windows.Forms.AnchorStyles.Bottom |
                 System.Windows.Forms.AnchorStyles.Right));

            this.btn2.Location =
                new System.Drawing.Point(615, 480);

            this.btn2.Name =
                "btn2";

            this.btn2.Size =
                new System.Drawing.Size(120, 40);

            this.btn2.TabIndex = 3;

            this.btn2.Text =
                "Remove";

            this.btn2.UseVisualStyleBackColor =
                true;

            this.btn2.Click +=
                new System.EventHandler(this.btn2_Click);

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;

            this.lblTitle.Font =
                new System.Drawing.Font(
                    "Microsoft Sans Serif",
                    18F,
                    System.Drawing.FontStyle.Bold,
                    System.Drawing.GraphicsUnit.Point,
                    ((byte)(0)));

            this.lblTitle.Location =
                new System.Drawing.Point(25, 20);

            this.lblTitle.Name =
                "lblTitle";

            this.lblTitle.Size =
                new System.Drawing.Size(80, 29);

            this.lblTitle.TabIndex = 4;

            this.lblTitle.Text =
                "My Cart";

            // 
            // lblTotal
            // 
            this.lblTotal.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                (System.Windows.Forms.AnchorStyles.Bottom |
                 System.Windows.Forms.AnchorStyles.Left));

            this.lblTotal.AutoSize = true;

            this.lblTotal.Font =
                new System.Drawing.Font(
                    "Microsoft Sans Serif",
                    11F,
                    System.Drawing.FontStyle.Bold,
                    System.Drawing.GraphicsUnit.Point,
                    ((byte)(0)));

            this.lblTotal.Location =
                new System.Drawing.Point(175, 492);

            this.lblTotal.Name =
                "lblTotal";

            this.lblTotal.Size =
                new System.Drawing.Size(0, 18);

            this.lblTotal.TabIndex = 5;

            // 
            // Cart
            // 
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(8F, 16F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(900, 550);

            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.btn0);
            this.Controls.Add(this.dataGridViewCart);

            this.MinimumSize =
                new System.Drawing.Size(700, 450);

            this.Name =
                "Cart";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text =
                "GoMart - Shopping Cart";

            this.Load +=
                new System.EventHandler(this.Cart_Load);

            this.FormClosing +=
                new System.Windows.Forms.FormClosingEventHandler(
                    this.Cart_FormClosing);

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCart)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewCart;

        private System.Windows.Forms.Button btn0;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn2;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTotal;
    }
}