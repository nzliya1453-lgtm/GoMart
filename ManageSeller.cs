
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GoMartApplication
{
    public partial class ManageSeller : Form
    {
        private readonly DBConnect dbCon = new DBConnect();

        public ManageSeller()
        {
            InitializeComponent();

            // Load sellers when the form opens
            this.Load += ManageSeller_Load;
        }

        // =========================================================
        // FORM LOAD
        // =========================================================
        private void ManageSeller_Load(object sender, EventArgs e)
        {
            LoadSellers();
        }

        // =========================================================
        // REFRESH BUTTON
        // =========================================================
        private void btn0_Click(object sender, EventArgs e)
        {
            LoadSellers();
        }

        // =========================================================
        // DELETE BUTTON
        // =========================================================
        private void btn1_Click(object sender, EventArgs e)
        {
            DeleteSelected();
        }

        // =========================================================
        // LOAD ALL ACTIVE SELLERS
        // =========================================================
        private void LoadSellers()
        {
            try
            {
                dbCon.OpenCon();

                using (SqlCommand cmd = new SqlCommand(
                    "dbo.spGetAllSeller",
                    dbCon.GetCon()))
                {
                    // Tell SQL Server that this is a stored procedure
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();

                        adapter.Fill(dt);

                        // Display data in DataGridView
                        dgvSellers.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading sellers:\n\n" + ex.Message,
                    "Manage Sellers",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                dbCon.CloseCon();
            }
        }

        // =========================================================
        // DELETE SELECTED SELLER
        // =========================================================
        private void DeleteSelected()
        {
            try
            {
                // Check whether a row is selected
                if (dgvSellers.SelectedRows.Count == 0)
                {
                    MessageBox.Show(
                        "Please select a seller first.",
                        "Manage Sellers",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                // Get SellerID from selected row
                object sellerIdValue =
                    dgvSellers.SelectedRows[0]
                    .Cells["SellerID"]
                    .Value;

                if (sellerIdValue == null ||
                    sellerIdValue == DBNull.Value)
                {
                    MessageBox.Show(
                        "Unable to find the selected seller ID.",
                        "Manage Sellers",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                int sellerId = Convert.ToInt32(sellerIdValue);

                // Get SellerName
                string sellerName = "";

                if (dgvSellers.Columns.Contains("SellerName"))
                {
                    object sellerNameValue =
                        dgvSellers.SelectedRows[0]
                        .Cells["SellerName"]
                        .Value;

                    if (sellerNameValue != null &&
                        sellerNameValue != DBNull.Value)
                    {
                        sellerName = sellerNameValue.ToString();
                    }
                }

                // Confirmation message
                string message;

                if (!string.IsNullOrWhiteSpace(sellerName))
                {
                    message =
                        "Are you sure you want to delete seller \"" +
                        sellerName +
                        "\"?\n\nSeller ID: " +
                        sellerId;
                }
                else
                {
                    message =
                        "Are you sure you want to delete Seller ID " +
                        sellerId +
                        "?";
                }

                DialogResult result = MessageBox.Show(
                    message,
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result != DialogResult.Yes)
                {
                    return;
                }

                // Open database connection
                dbCon.OpenCon();

                // Use stored procedure
                using (SqlCommand cmd = new SqlCommand(
                    "dbo.spDeleteSeller",
                    dbCon.GetCon()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add SellerID parameter
                    cmd.Parameters.Add(
                        "@SellerID",
                        SqlDbType.Int
                    ).Value = sellerId;

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show(
                            "Seller deleted successfully.",
                            "Manage Sellers",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    else
                    {
                        MessageBox.Show(
                            "Seller was not found or has already been deleted.",
                            "Manage Sellers",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error deleting seller:\n\n" + ex.Message,
                    "Manage Sellers",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                dbCon.CloseCon();
            }

            // Refresh DataGridView
            LoadSellers();
        }
    }
}

