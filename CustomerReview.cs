using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GoMartApplication
{
    public partial class CustomerReview : Form
    {
        // =====================================================
        // DATABASE CONNECTION
        // =====================================================

        private readonly string connectionString =
            @"Data Source=.\SQLEXPRESS;" +
            "Initial Catalog=GoMartDB;" +
            "Integrated Security=True;" +
            "Connect Timeout=5;" +
            "TrustServerCertificate=True;";


        // =====================================================
        // CUSTOMER ID
        // =====================================================

        private readonly int _customerID;


        // =====================================================
        // CONSTRUCTOR
        // =====================================================

        public CustomerReview(int customerID)
        {
            InitializeComponent();

            _customerID = customerID;

            // Load event is connected from Designer.cs.
        }


        // =====================================================
        // FORM LOAD
        // =====================================================

        private void CustomerReview_Load(object sender, EventArgs e)
        {
            if (!ValidateCustomerSession())
            {
                return;
            }

            LoadReviews();
        }


        // =====================================================
        // VALIDATE CUSTOMER SESSION
        // =====================================================

        private bool ValidateCustomerSession()
        {
            try
            {
                if (_customerID <= 0 ||
                    !Session.IsUserLoggedIn() ||
                    !Session.IsCustomer() ||
                    Session.CustomerID != _customerID)
                {
                    MessageBox.Show(
                        "Your customer session is invalid.\n\n" +
                        "Please login again.",
                        "Login Required",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    Session.Logout();

                    Close();

                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to validate customer session.\n\n" +
                    ex.Message,
                    "Session Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
        }


        // =====================================================
        // SUBMIT REVIEW BUTTON
        // =====================================================

        private void btn0_Click(object sender, EventArgs e)
        {
            if (!ValidateCustomerSession())
            {
                return;
            }

            SubmitReview();
        }


        // =====================================================
        // REFRESH BUTTON
        // =====================================================

        private void btn1_Click(object sender, EventArgs e)
        {
            if (!ValidateCustomerSession())
            {
                return;
            }

            LoadReviews();
        }


        // =====================================================
        // SUBMIT REVIEW
        // =====================================================

        private void SubmitReview()
        {
            int productID;
            int rating;

            // -------------------------------------------------
            // VALIDATE PRODUCT ID
            // -------------------------------------------------

            if (!int.TryParse(
                txtProductID.Text.Trim(),
                out productID) ||
                productID <= 0)
            {
                MessageBox.Show(
                    "Please enter a valid Product ID.",
                    "Invalid Product ID",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtProductID.Focus();

                return;
            }


            // -------------------------------------------------
            // VALIDATE RATING
            // -------------------------------------------------

            if (!int.TryParse(
                txtRating.Text.Trim(),
                out rating) ||
                rating < 1 ||
                rating > 5)
            {
                MessageBox.Show(
                    "Rating must be between 1 and 5.",
                    "Invalid Rating",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtRating.Focus();

                return;
            }


            // -------------------------------------------------
            // VALIDATE COMMENT
            // -------------------------------------------------

            string comment = txtComment.Text.Trim();

            if (string.IsNullOrWhiteSpace(comment))
            {
                MessageBox.Show(
                    "Please enter a comment.",
                    "Comment Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtComment.Focus();

                return;
            }


            // -------------------------------------------------
            // CHECK COMMENT LENGTH
            // -------------------------------------------------

            if (comment.Length > 1000)
            {
                MessageBox.Show(
                    "Comment cannot be longer than 1000 characters.",
                    "Comment Too Long",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtComment.Focus();

                return;
            }


            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    con.Open();


                    // =================================================
                    // CHECK PRODUCT
                    // =================================================

                    string productQuery = @"
                        SELECT
                            ProdID
                        FROM dbo.tblProduct
                        WHERE ProdID = @ProdID
                          AND IsActive = 1;";


                    using (SqlCommand productCmd =
                        new SqlCommand(productQuery, con))
                    {
                        productCmd.Parameters.Add(
                            "@ProdID",
                            SqlDbType.Int).Value =
                            productID;


                        object result =
                            productCmd.ExecuteScalar();


                        if (result == null ||
                            result == DBNull.Value)
                        {
                            MessageBox.Show(
                                "The selected product does not exist or is inactive.",
                                "Invalid Product",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return;
                        }
                    }


                    // =================================================
                    // CHECK DUPLICATE REVIEW
                    // =================================================

                    string duplicateQuery = @"
                        SELECT COUNT(*)
                        FROM dbo.tblReview
                        WHERE CustomerID = @CustomerID
                          AND ProdID = @ProdID;";


                    using (SqlCommand duplicateCmd =
                        new SqlCommand(
                            duplicateQuery,
                            con))
                    {
                        duplicateCmd.Parameters.Add(
                            "@CustomerID",
                            SqlDbType.Int).Value =
                            _customerID;

                        duplicateCmd.Parameters.Add(
                            "@ProdID",
                            SqlDbType.Int).Value =
                            productID;


                        int count =
                            Convert.ToInt32(
                                duplicateCmd.ExecuteScalar());


                        if (count > 0)
                        {
                            MessageBox.Show(
                                "You have already reviewed this product.",
                                "Review Already Exists",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            return;
                        }
                    }


                    // =================================================
                    // INSERT REVIEW
                    // =================================================
                    //
                    // IMPORTANT:
                    // tblReview does NOT contain SellerID.
                    //
                    // Actual columns:
                    // CustomerID
                    // ProdID
                    // Rating
                    // Comment
                    //
                    // SellerID is obtained from tblProduct when
                    // displaying the review.
                    // =================================================

                    string insertQuery = @"
                        INSERT INTO dbo.tblReview
                        (
                            CustomerID,
                            ProdID,
                            Rating,
                            Comment
                        )
                        VALUES
                        (
                            @CustomerID,
                            @ProdID,
                            @Rating,
                            @Comment
                        );";


                    using (SqlCommand cmd =
                        new SqlCommand(
                            insertQuery,
                            con))
                    {
                        cmd.Parameters.Add(
                            "@CustomerID",
                            SqlDbType.Int).Value =
                            _customerID;

                        cmd.Parameters.Add(
                            "@ProdID",
                            SqlDbType.Int).Value =
                            productID;

                        cmd.Parameters.Add(
                            "@Rating",
                            SqlDbType.Int).Value =
                            rating;

                        cmd.Parameters.Add(
                            "@Comment",
                            SqlDbType.NVarChar,
                            1000).Value =
                            comment;


                        int rowsAffected =
                            cmd.ExecuteNonQuery();


                        if (rowsAffected <= 0)
                        {
                            MessageBox.Show(
                                "Review could not be submitted.",
                                "Review Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return;
                        }
                    }
                }


                // =================================================
                // SUCCESS
                // =================================================

                MessageBox.Show(
                    "Review submitted successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);


                ClearFields();

                LoadReviews();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Database error while submitting review.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to submit review.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =====================================================
        // LOAD CUSTOMER REVIEWS
        // =====================================================

        private void LoadReviews()
        {
            if (_customerID <= 0)
            {
                return;
            }


            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT
                            r.ReviewID,
                            r.CustomerID,
                            c.CustomerName,
                            p.SellerID,
                            r.ProdID,
                            p.ProdName AS ProductName,
                            r.Rating,
                            r.Comment,
                            r.ReviewDate

                        FROM dbo.tblReview r

                        LEFT JOIN dbo.tblCustomer c
                            ON r.CustomerID = c.CustomerID

                        LEFT JOIN dbo.tblProduct p
                            ON r.ProdID = p.ProdID

                        WHERE r.CustomerID = @CustomerID

                        ORDER BY r.ReviewDate DESC;";


                    using (SqlCommand cmd =
                        new SqlCommand(
                            query,
                            con))
                    {
                        cmd.Parameters.Add(
                            "@CustomerID",
                            SqlDbType.Int).Value =
                            _customerID;


                        using (SqlDataAdapter adapter =
                            new SqlDataAdapter(cmd))
                        {
                            DataTable dt =
                                new DataTable();


                            adapter.Fill(dt);


                            dataGridViewReviews.DataSource =
                                dt;
                        }
                    }
                }


                ConfigureReviewGrid();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Database error while loading reviews.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load reviews.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =====================================================
        // CONFIGURE REVIEW GRID
        // =====================================================

        private void ConfigureReviewGrid()
        {
            if (dataGridViewReviews == null)
            {
                return;
            }


            if (dataGridViewReviews.Columns.Count == 0)
            {
                return;
            }


            // -------------------------------------------------
            // GENERAL SETTINGS
            // -------------------------------------------------

            dataGridViewReviews.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dataGridViewReviews.ReadOnly = true;

            dataGridViewReviews.AllowUserToAddRows = false;

            dataGridViewReviews.AllowUserToDeleteRows = false;

            dataGridViewReviews.AllowUserToResizeRows = false;

            dataGridViewReviews.MultiSelect = false;

            dataGridViewReviews.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dataGridViewReviews.RowHeadersVisible = false;


            // -------------------------------------------------
            // REVIEW ID
            // -------------------------------------------------

            if (dataGridViewReviews.Columns.Contains(
                "ReviewID"))
            {
                dataGridViewReviews.Columns["ReviewID"]
                    .HeaderText = "Review ID";
            }


            // -------------------------------------------------
            // CUSTOMER ID
            // -------------------------------------------------

            if (dataGridViewReviews.Columns.Contains(
                "CustomerID"))
            {
                dataGridViewReviews.Columns["CustomerID"]
                    .Visible = false;
            }


            // -------------------------------------------------
            // CUSTOMER NAME
            // -------------------------------------------------

            if (dataGridViewReviews.Columns.Contains(
                "CustomerName"))
            {
                dataGridViewReviews.Columns["CustomerName"]
                    .HeaderText = "Customer";
            }


            // -------------------------------------------------
            // SELLER ID
            // -------------------------------------------------
            //
            // SellerID comes from tblProduct, NOT tblReview.
            // -------------------------------------------------

            if (dataGridViewReviews.Columns.Contains(
                "SellerID"))
            {
                dataGridViewReviews.Columns["SellerID"]
                    .HeaderText = "Seller ID";
            }


            // -------------------------------------------------
            // PRODUCT ID
            // -------------------------------------------------

            if (dataGridViewReviews.Columns.Contains(
                "ProdID"))
            {
                dataGridViewReviews.Columns["ProdID"]
                    .HeaderText = "Product ID";
            }


            // -------------------------------------------------
            // PRODUCT NAME
            // -------------------------------------------------

            if (dataGridViewReviews.Columns.Contains(
                "ProductName"))
            {
                dataGridViewReviews.Columns["ProductName"]
                    .HeaderText = "Product";
            }


            // -------------------------------------------------
            // RATING
            // -------------------------------------------------

            if (dataGridViewReviews.Columns.Contains(
                "Rating"))
            {
                dataGridViewReviews.Columns["Rating"]
                    .HeaderText = "Rating";
            }


            // -------------------------------------------------
            // COMMENT
            // -------------------------------------------------

            if (dataGridViewReviews.Columns.Contains(
                "Comment"))
            {
                dataGridViewReviews.Columns["Comment"]
                    .HeaderText = "Comment";

                dataGridViewReviews.Columns["Comment"]
                    .FillWeight = 200;
            }


            // -------------------------------------------------
            // REVIEW DATE
            // -------------------------------------------------

            if (dataGridViewReviews.Columns.Contains(
                "ReviewDate"))
            {
                dataGridViewReviews.Columns["ReviewDate"]
                    .HeaderText = "Review Date";

                dataGridViewReviews.Columns["ReviewDate"]
                    .DefaultCellStyle.Format =
                    "dd-MMM-yyyy hh:mm tt";
            }


            dataGridViewReviews.ClearSelection();
        }


        // =====================================================
        // CLEAR FIELDS
        // =====================================================

        private void ClearFields()
        {
            txtProductID.Clear();

            txtRating.Clear();

            txtComment.Clear();


            // -------------------------------------------------
            // Seller ID textbox is no longer required.
            // Keep this only if txtSellerID exists in Designer.
            // -------------------------------------------------

            if (txtSellerID != null)
            {
                txtSellerID.Clear();
            }


            txtProductID.Focus();
        }


        // =====================================================
        // FORM CLOSING
        // =====================================================

        private void CustomerReview_FormClosing(
            object sender,
            FormClosingEventArgs e)
        {
            // Do not logout here.
            //
            // CustomerDashboard/Loginfrom controls the session.
        }
    }
}