
namespace GoMartApplication
{
    partial class SuperAdminDashboard
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button btn0;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btn6;
        private System.Windows.Forms.Button btn7;

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
            this.btn0 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btn7 = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // 
            // btn0
            // 
            this.btn0.Location = new System.Drawing.Point(30, 50);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(270, 38);
            this.btn0.Text = "Add SuperAdmin";
            this.btn0.UseVisualStyleBackColor = true;
            this.btn0.Click += new System.EventHandler(this.btn0_Click);

            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(30, 95);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(270, 38);
            this.btn1.Text = "Seller Requests";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);

            // 
            // btn2
            // 
            this.btn2.Location = new System.Drawing.Point(30, 140);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(270, 38);
            this.btn2.Text = "Manage Sellers";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.btn2_Click);

            // 
            // btn3
            // 
            this.btn3.Location = new System.Drawing.Point(30, 185);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(270, 38);
            this.btn3.Text = "Manage Customers";
            this.btn3.UseVisualStyleBackColor = true;
            this.btn3.Click += new System.EventHandler(this.btn3_Click);

            // 
            // btn4
            // 
            this.btn4.Location = new System.Drawing.Point(30, 230);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(270, 38);
            this.btn4.Text = "Reviews";
            this.btn4.UseVisualStyleBackColor = true;
            this.btn4.Click += new System.EventHandler(this.btn4_Click);

            // 
            // btn5
            // 
            this.btn5.Location = new System.Drawing.Point(30, 275);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(270, 38);
            this.btn5.Text = "Offers";
            this.btn5.UseVisualStyleBackColor = true;
            this.btn5.Click += new System.EventHandler(this.btn5_Click);

            // 
            // btn6
            // 
            this.btn6.Location = new System.Drawing.Point(30, 320);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(270, 38);
            this.btn6.Text = "Financial Dashboard";
            this.btn6.UseVisualStyleBackColor = true;
            this.btn6.Click += new System.EventHandler(this.btn6_Click);

            // 
            // btn7
            // 
            this.btn7.Location = new System.Drawing.Point(30, 365);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(270, 38);
            this.btn7.Text = "Logout";
            this.btn7.UseVisualStyleBackColor = true;
            this.btn7.Click += new System.EventHandler(this.btn7_Click);

            // 
            // SuperAdminDashboard
            // 
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(7F, 15F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(330, 450);

            this.Controls.Add(this.btn0);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.btn5);
            this.Controls.Add(this.btn6);
            this.Controls.Add(this.btn7);

            this.Name = "SuperAdminDashboard";
            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text = "GoMart SuperAdmin Dashboard";

            this.ResumeLayout(false);
        }
    }
}