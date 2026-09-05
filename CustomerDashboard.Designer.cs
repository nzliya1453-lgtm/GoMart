namespace GoMartApplication
{
    partial class CustomerDashboard
    {
        private System.ComponentModel.IContainer components = null;

        // =====================================================
        // CONTROLS
        // =====================================================

        private System.Windows.Forms.Button btn0;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btn6;


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

            this.btn0 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();

            this.SuspendLayout();


            // =====================================================
            // FORM
            // =====================================================

            this.AutoScaleDimensions =
                new System.Drawing.SizeF(8F, 16F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(900, 600);

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text =
                "GoMart - Customer Dashboard";

            this.Name =
                "CustomerDashboard";

            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.FixedSingle;

            this.MaximizeBox =
                false;

            this.Load +=
                new System.EventHandler(
                    this.CustomerDashboard_Load);

            this.FormClosing +=
                new System.Windows.Forms.FormClosingEventHandler(
                    this.CustomerDashboard_FormClosing);


            // =====================================================
            // BUTTON 0 - PRODUCTS
            // =====================================================

            this.btn0.Location =
                new System.Drawing.Point(100, 100);

            this.btn0.Name =
                "btn0";

            this.btn0.Size =
                new System.Drawing.Size(300, 65);

            this.btn0.TabIndex =
                0;

            this.btn0.Text =
                "Products";

            this.btn0.UseVisualStyleBackColor =
                true;

            this.btn0.Click +=
                new System.EventHandler(
                    this.btn0_Click);


            // =====================================================
            // BUTTON 1 - CART
            // =====================================================

            this.btn1.Location =
                new System.Drawing.Point(500, 100);

            this.btn1.Name =
                "btn1";

            this.btn1.Size =
                new System.Drawing.Size(300, 65);

            this.btn1.TabIndex =
                1;

            this.btn1.Text =
                "My Cart";

            this.btn1.UseVisualStyleBackColor =
                true;

            this.btn1.Click +=
                new System.EventHandler(
                    this.btn1_Click);


            // =====================================================
            // BUTTON 2 - MY ORDERS
            // =====================================================

            this.btn2.Location =
                new System.Drawing.Point(100, 200);

            this.btn2.Name =
                "btn2";

            this.btn2.Size =
                new System.Drawing.Size(300, 65);

            this.btn2.TabIndex =
                2;

            this.btn2.Text =
                "My Orders";

            this.btn2.UseVisualStyleBackColor =
                true;

            this.btn2.Click +=
                new System.EventHandler(
                    this.btn2_Click);


            // =====================================================
            // BUTTON 3 - REVIEWS
            // =====================================================

            this.btn3.Location =
                new System.Drawing.Point(500, 200);

            this.btn3.Name =
                "btn3";

            this.btn3.Size =
                new System.Drawing.Size(300, 65);

            this.btn3.TabIndex =
                3;

            this.btn3.Text =
                "My Reviews";

            this.btn3.UseVisualStyleBackColor =
                true;

            this.btn3.Click +=
                new System.EventHandler(
                    this.btn3_Click);


            // =====================================================
            // BUTTON 4 - OFFERS
            // =====================================================

            this.btn4.Location =
                new System.Drawing.Point(100, 300);

            this.btn4.Name =
                "btn4";

            this.btn4.Size =
                new System.Drawing.Size(300, 65);

            this.btn4.TabIndex =
                4;

            this.btn4.Text =
                "Offers";

            this.btn4.UseVisualStyleBackColor =
                true;

            this.btn4.Click +=
                new System.EventHandler(
                    this.btn4_Click);


            // =====================================================
            // BUTTON 5 - LOGOUT
            // =====================================================

            this.btn5.Location =
                new System.Drawing.Point(500, 400);

            this.btn5.Name =
                "btn5";

            this.btn5.Size =
                new System.Drawing.Size(300, 65);

            this.btn5.TabIndex =
                5;

            this.btn5.Text =
                "Logout";

            this.btn5.UseVisualStyleBackColor =
                true;

            this.btn5.Click +=
                new System.EventHandler(
                    this.btn5_Click);


            // =====================================================
            // BUTTON 6 - PAYMENT
            // =====================================================

            this.btn6.Location =
                new System.Drawing.Point(500, 300);

            this.btn6.Name =
                "btn6";

            this.btn6.Size =
                new System.Drawing.Size(300, 65);

            this.btn6.TabIndex =
                6;

            this.btn6.Text =
                "Payment";

            this.btn6.UseVisualStyleBackColor =
                true;

            this.btn6.Click +=
                new System.EventHandler(
                    this.btn6_Click);


            // =====================================================
            // ADD CONTROLS
            // =====================================================

            this.Controls.Add(
                this.btn0);

            this.Controls.Add(
                this.btn1);

            this.Controls.Add(
                this.btn2);

            this.Controls.Add(
                this.btn3);

            this.Controls.Add(
                this.btn4);

            this.Controls.Add(
                this.btn5);

            this.Controls.Add(
                this.btn6);


            // =====================================================
            // RESUME
            // =====================================================

            this.ResumeLayout(false);
        }
    }
}