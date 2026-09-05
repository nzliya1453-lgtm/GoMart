using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GoMartApplication
{
    public partial class CustomerOffers : Form
    {
        // =========================================================
        // DATABASE CONNECTION
        // =========================================================

        private readonly DBConnect dbCon = new DBConnect();

        // =========================================================
        // CONSTRUCTOR
        // =========================================================

        public CustomerOffers()
        {
            InitializeComponent();
        }

        // =========================================================
        // FORM LOAD
        // =========================================================

        private void CustomerOffers_Load(object sender, EventArgs e)
        {
            if (!ValidateCustomerSession())
                return;

            LoadOffers();
        }

        // =========================================================
        // VALIDATE CUSTOMER SESSION
        // =========================================================

        private bool ValidateCustomerSession()
        {
            if (!Session.IsUserLoggedIn() ||
                !Session.IsCustomer() ||
                Session.CustomerID <= 0)
            {
                MessageBox.Show(
                    "Your customer session is invalid.\n\n" +
                    "Please login again.",
                    "Session Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                Session.Logout();

                if (!IsDisposed)
                    Close();

                return false;
            }

            return true;
        }

        // =========================================================
        // LOAD ACTIVE OFFERS
        // =========================================================

        private void LoadOffers()
        {
            if (!ValidateCustomerSession())
                return;

            try
            {
                dbCon.OpenCon();

                // =================================================
                // spGetActiveOffers has NO PARAMETERS
                // =================================================

                using (SqlCommand cmd = new SqlCommand(
                    "dbo.spGetActiveOffers",
                    dbCon.GetCon()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter =
                        new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();

                        adapter.Fill(dt);

                        dgvOffers.DataSource = dt;
                    }
                }

                ConfigureOfferGrid();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Database error while loading offers.\n\n" +
                    ex.Message,
                    "Offers",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load offers.\n\n" +
                    ex.Message,
                    "Offers",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                dbCon.CloseCon();
            }
        }

        // =========================================================
        // CONFIGURE OFFER GRID
        // =========================================================

        private void ConfigureOfferGrid()
        {
            if (dgvOffers.Columns.Count == 0)
                return;

            dgvOffers.ReadOnly = true;

            dgvOffers.AllowUserToAddRows = false;
            dgvOffers.AllowUserToDeleteRows = false;
            dgvOffers.AllowUserToResizeRows = false;

            dgvOffers.MultiSelect = false;

            dgvOffers.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvOffers.RowHeadersVisible = false;

            dgvOffers.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            // =================================================
            // OFFER ID
            // =================================================

            if (dgvOffers.Columns.Contains("OfferID"))
            {
                dgvOffers.Columns["OfferID"].Visible = false;
            }

            // =================================================
            // OFFER TITLE
            // =================================================

            if (dgvOffers.Columns.Contains("OfferTitle"))
            {
                dgvOffers.Columns["OfferTitle"].HeaderText =
                    "Offer";
            }

            // =================================================
            // DISCOUNT
            // =================================================

            if (dgvOffers.Columns.Contains("DiscountPercent"))
            {
                dgvOffers.Columns["DiscountPercent"].HeaderText =
                    "Discount (%)";

                dgvOffers.Columns["DiscountPercent"]
                    .DefaultCellStyle.Format = "0.##";
            }

            // =================================================
            // START DATE
            // =================================================

            if (dgvOffers.Columns.Contains("StartDate"))
            {
                dgvOffers.Columns["StartDate"].HeaderText =
                    "Starts";

                dgvOffers.Columns["StartDate"]
                    .DefaultCellStyle.Format =
                    "dd-MMM-yyyy hh:mm tt";
            }

            // =================================================
            // END DATE
            // =================================================

            if (dgvOffers.Columns.Contains("EndDate"))
            {
                dgvOffers.Columns["EndDate"].HeaderText =
                    "Ends";

                dgvOffers.Columns["EndDate"]
                    .DefaultCellStyle.Format =
                    "dd-MMM-yyyy hh:mm tt";
            }

            // =================================================
            // HIDE UNEXPECTED COLUMNS
            //
            // tblOffer does NOT contain Description.
            // =================================================

            if (dgvOffers.Columns.Contains("Description"))
            {
                dgvOffers.Columns["Description"].Visible = false;
            }

            if (dgvOffers.Columns.Contains("IsActive"))
            {
                dgvOffers.Columns["IsActive"].Visible = false;
            }
        }

        // =========================================================
        // TAKE OFFER
        // =========================================================

        private void btnTakeOffer_Click(object sender, EventArgs e)
        {
            // =================================================
            // CHECK SESSION
            // =================================================

            if (!ValidateCustomerSession())
                return;

            // =================================================
            // CHECK SELECTED ROW
            // =================================================

            if (dgvOffers.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select an offer first.",
                    "Take Offer",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            try
            {
                DataGridViewRow row =
                    dgvOffers.SelectedRows[0];

                // =================================================
                // CHECK OFFER ID COLUMN
                // =================================================

                if (!dgvOffers.Columns.Contains("OfferID"))
                {
                    MessageBox.Show(
                        "OfferID column was not found.",
                        "Take Offer",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                // =================================================
                // GET OFFER ID
                // =================================================

                object offerValue =
                    row.Cells["OfferID"].Value;

                if (offerValue == null ||
                    offerValue == DBNull.Value)
                {
                    MessageBox.Show(
                        "Invalid offer selected.",
                        "Take Offer",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                int offerID;

                if (!int.TryParse(
                    offerValue.ToString(),
                    out offerID) ||
                    offerID <= 0)
                {
                    MessageBox.Show(
                        "Invalid Offer ID.",
                        "Take Offer",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                // =================================================
                // GET OFFER TITLE
                // =================================================

                string title = "Selected Offer";

                if (dgvOffers.Columns.Contains("OfferTitle") &&
                    row.Cells["OfferTitle"].Value != null &&
                    row.Cells["OfferTitle"].Value != DBNull.Value)
                {
                    title =
                        row.Cells["OfferTitle"]
                           .Value
                           .ToString();
                }

                // =================================================
                // GET DISCOUNT
                // =================================================

                decimal discount = 0m;

                if (dgvOffers.Columns.Contains("DiscountPercent") &&
                    row.Cells["DiscountPercent"].Value != null &&
                    row.Cells["DiscountPercent"].Value != DBNull.Value)
                {
                    decimal.TryParse(
                        row.Cells["DiscountPercent"]
                            .Value
                            .ToString(),
                        out discount);
                }

                // =================================================
                // CONFIRM
                // =================================================

                DialogResult result = MessageBox.Show(
                    "Do you want to take this offer?\n\n" +
                    "Offer: " + title + "\n" +
                    "Discount: " + discount.ToString("0.##") + "%",
                    "Take Offer",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;

                // =================================================
                // TAKE OFFER
                //
                // dbo.spTakeCustomerOffer
                // Parameters:
                //     @CustomerID
                //     @OfferID
                // =================================================

                dbCon.OpenCon();

                using (SqlCommand cmd = new SqlCommand(
                    "dbo.spTakeCustomerOffer",
                    dbCon.GetCon()))
                {
                    cmd.CommandType =
                        CommandType.StoredProcedure;

                    cmd.Parameters.Add(
                        "@CustomerID",
                        SqlDbType.Int).Value =
                        Session.CustomerID;

                    cmd.Parameters.Add(
                        "@OfferID",
                        SqlDbType.Int).Value =
                        offerID;

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show(
                    "Offer taken successfully!\n\n" +
                    "You can use this offer during checkout.",
                    "Offer",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Unable to take offer.\n\n" +
                    ex.Message,
                    "Take Offer",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to take offer.\n\n" +
                    ex.Message,
                    "Take Offer",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                dbCon.CloseCon();
            }
        }

        // =========================================================
        // REFRESH BUTTON
        // =========================================================

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (!ValidateCustomerSession())
                return;

            LoadOffers();
        }

        // =========================================================
        // FORM CLOSING
        // =========================================================

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            dbCon.CloseCon();

            base.OnFormClosed(e);
        }
    }
}