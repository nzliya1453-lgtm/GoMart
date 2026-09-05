namespace GoMartApplication
{
    partial class CustomerReview
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">
        /// true if managed resources should be disposed; otherwise false.
        /// </param>
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

            this.lblTitle = new System.Windows.Forms.Label();

            this.lblProductID = new System.Windows.Forms.Label();
            this.txtProductID = new System.Windows.Forms.TextBox();

            this.lblSellerID = new System.Windows.Forms.Label();
            this.txtSellerID = new System.Windows.Forms.TextBox();

            this.lblRating = new System.Windows.Forms.Label();
            this.txtRating = new System.Windows.Forms.TextBox();

            this.lblComment = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();

            this.btn0 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();

            this.dataGridViewReviews =
                new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)
                (this.dataGridViewReviews)).BeginInit();

            this.SuspendLayout();

            // =====================================================
            // lblTitle
            // =====================================================

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
                new System.Drawing.Size(190, 29);

            this.lblTitle.TabIndex = 0;

            this.lblTitle.Text =
                "Customer Reviews";


            // =====================================================
            // lblProductID
            // =====================================================

            this.lblProductID.AutoSize = true;

            this.lblProductID.Font =
                new System.Drawing.Font(
                    "Microsoft Sans Serif",
                    10F,
                    System.Drawing.FontStyle.Regular,
                    System.Drawing.GraphicsUnit.Point,
                    ((byte)(0)));

            this.lblProductID.Location =
                new System.Drawing.Point(25, 75);

            this.lblProductID.Name =
                "lblProductID";

            this.lblProductID.Size =
                new System.Drawing.Size(77, 17);

            this.lblProductID.TabIndex = 1;

            this.lblProductID.Text =
                "Product ID:";


            // =====================================================
            // txtProductID
            // =====================================================

            this.txtProductID.Location =
                new System.Drawing.Point(125, 72);

            this.txtProductID.Name =
                "txtProductID";

            this.txtProductID.Size =
                new System.Drawing.Size(150, 22);

            this.txtProductID.TabIndex = 2;


            // =====================================================
            // lblSellerID
            // =====================================================

            this.lblSellerID.AutoSize = true;

            this.lblSellerID.Location =
                new System.Drawing.Point(300, 75);

            this.lblSellerID.Name =
                "lblSellerID";

            this.lblSellerID.Size =
                new System.Drawing.Size(61, 16);

            this.lblSellerID.TabIndex = 3;

            this.lblSellerID.Text =
                "Seller ID:";


            // =====================================================
            // txtSellerID
            // =====================================================
            // Seller ID is no longer required for submitting
            // reviews. It is kept only for compatibility with
            // existing project code and is hidden.

            this.txtSellerID.Location =
                new System.Drawing.Point(380, 72);

            this.txtSellerID.Name =
                "txtSellerID";

            this.txtSellerID.Size =
                new System.Drawing.Size(150, 22);

            this.txtSellerID.TabIndex = 4;

            this.txtSellerID.Visible = false;

            this.lblSellerID.Visible = false;


            // =====================================================
            // lblRating
            // =====================================================

            this.lblRating.AutoSize = true;

            this.lblRating.Location =
                new System.Drawing.Point(300, 115);

            this.lblRating.Name =
                "lblRating";

            this.lblRating.Size =
                new System.Drawing.Size(52, 16);

            this.lblRating.TabIndex = 5;

            this.lblRating.Text =
                "Rating:";


            // =====================================================
            // txtRating
            // =====================================================

            this.txtRating.Location =
                new System.Drawing.Point(380, 112);

            this.txtRating.Name =
                "txtRating";

            this.txtRating.Size =
                new System.Drawing.Size(150, 22);

            this.txtRating.TabIndex = 6;


            // =====================================================
            // lblComment
            // =====================================================

            this.lblComment.AutoSize = true;

            this.lblComment.Location =
                new System.Drawing.Point(25, 115);

            this.lblComment.Name =
                "lblComment";

            this.lblComment.Size =
                new System.Drawing.Size(68, 16);

            this.lblComment.TabIndex = 7;

            this.lblComment.Text =
                "Comment:";


            // =====================================================
            // txtComment
            // =====================================================

            this.txtComment.Location =
                new System.Drawing.Point(125, 112);

            this.txtComment.Multiline = true;

            this.txtComment.Name =
                "txtComment";

            this.txtComment.ScrollBars =
                System.Windows.Forms.ScrollBars.Vertical;

            this.txtComment.Size =
                new System.Drawing.Size(150, 70);

            this.txtComment.TabIndex = 8;


            // =====================================================
            // btn0
            // =====================================================

            this.btn0.Location =
                new System.Drawing.Point(300, 155);

            this.btn0.Name =
                "btn0";

            this.btn0.Size =
                new System.Drawing.Size(110, 35);

            this.btn0.TabIndex = 9;

            this.btn0.Text =
                "Submit Review";

            this.btn0.UseVisualStyleBackColor =
                true;

            this.btn0.Click +=
                new System.EventHandler(
                    this.btn0_Click);


            // =====================================================
            // btn1
            // =====================================================

            this.btn1.Location =
                new System.Drawing.Point(425, 155);

            this.btn1.Name =
                "btn1";

            this.btn1.Size =
                new System.Drawing.Size(105, 35);

            this.btn1.TabIndex = 10;

            this.btn1.Text =
                "Refresh";

            this.btn1.UseVisualStyleBackColor =
                true;

            this.btn1.Click +=
                new System.EventHandler(
                    this.btn1_Click);


            // =====================================================
            // dataGridViewReviews
            // =====================================================

            this.dataGridViewReviews.AllowUserToAddRows =
                false;

            this.dataGridViewReviews.AllowUserToDeleteRows =
                false;

            this.dataGridViewReviews.AllowUserToResizeRows =
                false;

            this.dataGridViewReviews.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                ((((System.Windows.Forms.AnchorStyles.Top |
                    System.Windows.Forms.AnchorStyles.Bottom) |
                    System.Windows.Forms.AnchorStyles.Left) |
                    System.Windows.Forms.AnchorStyles.Right)));

            this.dataGridViewReviews.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.dataGridViewReviews.BackgroundColor =
                System.Drawing.SystemColors.Window;

            this.dataGridViewReviews.BorderStyle =
                System.Windows.Forms.BorderStyle.Fixed3D;

            this.dataGridViewReviews.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.dataGridViewReviews.Location =
                new System.Drawing.Point(25, 215);

            this.dataGridViewReviews.MultiSelect =
                false;

            this.dataGridViewReviews.Name =
                "dataGridViewReviews";

            this.dataGridViewReviews.ReadOnly =
                true;

            this.dataGridViewReviews.RowHeadersVisible =
                false;

            this.dataGridViewReviews.RowTemplate.Height =
                30;

            this.dataGridViewReviews.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.dataGridViewReviews.Size =
                new System.Drawing.Size(850, 285);

            this.dataGridViewReviews.TabIndex = 11;


            // =====================================================
            // CustomerReview
            // =====================================================

            this.AutoScaleDimensions =
                new System.Drawing.SizeF(8F, 16F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(900, 530);

            this.Controls.Add(
                this.dataGridViewReviews);

            this.Controls.Add(
                this.btn1);

            this.Controls.Add(
                this.btn0);

            this.Controls.Add(
                this.txtComment);

            this.Controls.Add(
                this.lblComment);

            this.Controls.Add(
                this.txtRating);

            this.Controls.Add(
                this.lblRating);

            this.Controls.Add(
                this.txtSellerID);

            this.Controls.Add(
                this.lblSellerID);

            this.Controls.Add(
                this.txtProductID);

            this.Controls.Add(
                this.lblProductID);

            this.Controls.Add(
                this.lblTitle);

            this.MinimumSize =
                new System.Drawing.Size(700, 450);

            this.Name =
                "CustomerReview";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text =
                "GoMart - Customer Reviews";

            this.Load +=
                new System.EventHandler(
                    this.CustomerReview_Load);

            this.FormClosing +=
                new System.Windows.Forms.FormClosingEventHandler(
                    this.CustomerReview_FormClosing);

            ((System.ComponentModel.ISupportInitialize)
                (this.dataGridViewReviews)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.Label lblProductID;
        private System.Windows.Forms.TextBox txtProductID;

        private System.Windows.Forms.Label lblSellerID;
        private System.Windows.Forms.TextBox txtSellerID;

        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.TextBox txtRating;

        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.TextBox txtComment;

        private System.Windows.Forms.Button btn0;
        private System.Windows.Forms.Button btn1;

        private System.Windows.Forms.DataGridView dataGridViewReviews;
    }
}