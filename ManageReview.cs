using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GoMartApplication
{
    public partial class ManageReview : Form
    {
        // =====================================================
        // DATABASE CONNECTION
        // =====================================================

        private readonly DBConnect dbCon = new DBConnect();


        // =====================================================
        // CONSTRUCTOR
        // =====================================================

        public ManageReview()
        {
            InitializeComponent();

            // Do NOT manually add the Load event here.
            // ManageReview.Designer.cs should connect the event.
        }


        // =====================================================
        // FORM LOAD
        // =====================================================

        private void ManageReview_Load(
            object sender,
            EventArgs e)
        {
            LoadReviews();
        }


        // =====================================================
        // REFRESH BUTTON
        // =====================================================

        private void btn0_Click(
            object sender,
            EventArgs e)
        {
            LoadReviews();
        }


        // =====================================================
        // DELETE BUTTON
        // =====================================================

        private void btn1_Click(
            object sender,
            EventArgs e)
        {
            DeleteSelected();
        }


        // =====================================================
        // LOAD REVIEWS
        // =====================================================

        private void LoadReviews()
        {
            try
            {
                dbCon.OpenCon();

                // -------------------------------------------------
                // spGetReviews is not in the known stored procedure
                // list, so load the reviews directly from tblReview.
                // -------------------------------------------------

                string query = @"
                    SELECT *
                    FROM dbo.tblReview
                    ORDER BY ReviewID DESC;";

                using (SqlCommand cmd =
                    new SqlCommand(
                        query,
                        dbCon.GetCon()))
                {
                    cmd.CommandType =
                        CommandType.Text;

                    using (SqlDataAdapter adapter =
                        new SqlDataAdapter(cmd))
                    {
                        DataTable dt =
                            new DataTable();

                        adapter.Fill(dt);

                        dgvReviews.DataSource = dt;
                    }
                }

                ConfigureReviewGrid();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Database error while loading reviews.\n\n" +
                    ex.Message,
                    "Manage Reviews",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading reviews.\n\n" +
                    ex.Message,
                    "Manage Reviews",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                dbCon.CloseCon();
            }
        }


        // =====================================================
        // CONFIGURE REVIEW GRID
        // =====================================================

        private void ConfigureReviewGrid()
        {
            if (dgvReviews == null)
            {
                return;
            }

            // -------------------------------------------------
            // GENERAL GRID SETTINGS
            // -------------------------------------------------

            dgvReviews.AllowUserToAddRows = false;
            dgvReviews.AllowUserToDeleteRows = false;
            dgvReviews.AllowUserToResizeRows = false;

            dgvReviews.ReadOnly = true;
            dgvReviews.MultiSelect = false;

            dgvReviews.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvReviews.RowHeadersVisible = false;

            dgvReviews.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;


            // -------------------------------------------------
            // REVIEW ID
            // -------------------------------------------------

            if (dgvReviews.Columns.Contains("ReviewID"))
            {
                dgvReviews.Columns["ReviewID"]
                    .HeaderText = "Review ID";

                dgvReviews.Columns["ReviewID"]
                    .Width = 80;
            }


            // -------------------------------------------------
            // CUSTOMER ID
            // -------------------------------------------------

            if (dgvReviews.Columns.Contains("CustomerID"))
            {
                dgvReviews.Columns["CustomerID"]
                    .HeaderText = "Customer ID";
            }


            // -------------------------------------------------
            // PRODUCT ID
            // -------------------------------------------------

            if (dgvReviews.Columns.Contains("ProdID"))
            {
                dgvReviews.Columns["ProdID"]
                    .HeaderText = "Product ID";
            }


            // -------------------------------------------------
            // RATING
            // -------------------------------------------------

            if (dgvReviews.Columns.Contains("Rating"))
            {
                dgvReviews.Columns["Rating"]
                    .HeaderText = "Rating";
            }


            // -------------------------------------------------
            // REVIEW COMMENT
            // -------------------------------------------------

            if (dgvReviews.Columns.Contains("ReviewComment"))
            {
                dgvReviews.Columns["ReviewComment"]
                    .HeaderText = "Comment";
            }

            // Support alternative column name if used.
            if (dgvReviews.Columns.Contains("Comment"))
            {
                dgvReviews.Columns["Comment"]
                    .HeaderText = "Comment";
            }


            // -------------------------------------------------
            // REVIEW DATE
            // -------------------------------------------------

            if (dgvReviews.Columns.Contains("ReviewDate"))
            {
                dgvReviews.Columns["ReviewDate"]
                    .HeaderText = "Review Date";

                dgvReviews.Columns["ReviewDate"]
                    .DefaultCellStyle.Format =
                    "dd/MM/yyyy HH:mm";
            }


            // -------------------------------------------------
            // CREATED DATE
            // -------------------------------------------------

            if (dgvReviews.Columns.Contains("CreatedDate"))
            {
                dgvReviews.Columns["CreatedDate"]
                    .HeaderText = "Created Date";

                dgvReviews.Columns["CreatedDate"]
                    .DefaultCellStyle.Format =
                    "dd/MM/yyyy HH:mm";
            }


            dgvReviews.ClearSelection();
        }


        // =====================================================
        // DELETE SELECTED REVIEW
        // =====================================================

        private void DeleteSelected()
        {
            try
            {
                // -------------------------------------------------
                // CHECK SELECTION
                // -------------------------------------------------

                if (dgvReviews.SelectedRows.Count == 0)
                {
                    MessageBox.Show(
                        "Please select a review first.",
                        "Manage Reviews",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }


                // -------------------------------------------------
                // CHECK REVIEW ID COLUMN
                // -------------------------------------------------

                if (!dgvReviews.Columns.Contains("ReviewID"))
                {
                    MessageBox.Show(
                        "ReviewID column was not found.",
                        "Manage Reviews",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }


                // -------------------------------------------------
                // GET REVIEW ID
                // -------------------------------------------------

                DataGridViewRow selectedRow =
                    dgvReviews.SelectedRows[0];

                object reviewValue =
                    selectedRow.Cells["ReviewID"].Value;

                if (reviewValue == null ||
                    reviewValue == DBNull.Value)
                {
                    MessageBox.Show(
                        "Invalid Review ID.",
                        "Manage Reviews",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }


                // -------------------------------------------------
                // CONVERT REVIEW ID
                // -------------------------------------------------

                int reviewId;

                if (!int.TryParse(
                    reviewValue.ToString(),
                    out reviewId) ||
                    reviewId <= 0)
                {
                    MessageBox.Show(
                        "Invalid Review ID.",
                        "Manage Reviews",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }


                // -------------------------------------------------
                // GET OPTIONAL PRODUCT ID
                // -------------------------------------------------

                string productInfo = "";

                if (dgvReviews.Columns.Contains("ProdID"))
                {
                    object productValue =
                        selectedRow.Cells["ProdID"].Value;

                    if (productValue != null &&
                        productValue != DBNull.Value)
                    {
                        productInfo =
                            "\nProduct ID: " +
                            productValue.ToString();
                    }
                }


                // -------------------------------------------------
                // CONFIRM DELETE
                // -------------------------------------------------

                DialogResult result =
                    MessageBox.Show(
                        "Are you sure you want to delete " +
                        "Review ID " + reviewId + "?" +
                        productInfo,
                        "Confirm Delete",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                {
                    return;
                }


                // -------------------------------------------------
                // DELETE REVIEW
                // -------------------------------------------------

                dbCon.OpenCon();

                string query = @"
                    DELETE FROM dbo.tblReview
                    WHERE ReviewID = @ReviewID;";

                using (SqlCommand cmd =
                    new SqlCommand(
                        query,
                        dbCon.GetCon()))
                {
                    cmd.Parameters.Add(
                        "@ReviewID",
                        SqlDbType.Int).Value =
                        reviewId;

                    int rowsAffected =
                        cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show(
                            "Review deleted successfully.",
                            "Manage Reviews",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(
                            "Review was not found.",
                            "Manage Reviews",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Database error while deleting review.\n\n" +
                    ex.Message,
                    "Manage Reviews",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error deleting review.\n\n" +
                    ex.Message,
                    "Manage Reviews",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                dbCon.CloseCon();
            }


            // -------------------------------------------------
            // REFRESH GRID
            // -------------------------------------------------

            LoadReviews();
        }


        // =====================================================
        // FORM CLOSING
        // =====================================================

        private void ManageReview_FormClosing(
            object sender,
            FormClosingEventArgs e)
        {
            // Do not logout here.
            // The parent/admin session remains active.
        }
    }
}