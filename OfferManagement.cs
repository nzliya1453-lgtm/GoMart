using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GoMartApplication
{
    public partial class OfferManagement : Form
    {
        // =========================================================
        // DATABASE CONNECTION
        // =========================================================

        private readonly DBConnect dbCon = new DBConnect();

        // Currently selected offer
        private int selectedOfferID = 0;

        // =========================================================
        // CONSTRUCTOR
        // =========================================================

        public OfferManagement()
        {
            InitializeComponent();

            // Event handlers
            this.Load += OfferManagement_Load;
            this.FormClosing += OfferManagement_FormClosing;

            dgvOffers.CellClick += dgvOffers_CellClick;

            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnClear.Click += btnClear_Click;
            btnRefresh.Click += btnRefresh_Click;
        }

        // =========================================================
        // FORM LOAD
        // =========================================================

        private void OfferManagement_Load(object sender, EventArgs e)
        {
            try
            {
                // SECURITY CHECK
                if (!AppSession.IsAdmin && !AppSession.IsSuperAdmin)
                {
                    MessageBox.Show(
                        "You are not authorized to manage offers.",
                        "Access Denied",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    BeginInvoke(new Action(Close));
                    return;
                }

                ConfigureGrid();
                ClearFields();
                LoadOffers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading Offer Management.\n\n" + ex.Message,
                    "Offer Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // CONFIGURE GRID
        // =========================================================

        private void ConfigureGrid()
        {
            dgvOffers.AutoGenerateColumns = true;
            dgvOffers.AllowUserToAddRows = false;
            dgvOffers.AllowUserToDeleteRows = false;
            dgvOffers.AllowUserToResizeRows = false;

            dgvOffers.ReadOnly = true;
            dgvOffers.MultiSelect = false;

            dgvOffers.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvOffers.RowHeadersVisible = false;

            dgvOffers.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        // =========================================================
        // LOAD OFFERS
        // =========================================================

        private void LoadOffers()
        {
            try
            {
                dbCon.OpenCon();

                const string query = @"
                    SELECT
                        OfferID,
                        OfferTitle,
                        DiscountPercent,
                        StartDate,
                        EndDate,
                        IsActive
                    FROM dbo.tblOffer
                    ORDER BY OfferID DESC;";

                using (SqlCommand cmd =
                    new SqlCommand(query, dbCon.GetCon()))
                {
                    using (SqlDataAdapter adapter =
                        new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();

                        adapter.Fill(dt);

                        dgvOffers.DataSource = null;
                        dgvOffers.DataSource = dt;
                    }
                }

                FormatGrid();
                dgvOffers.ClearSelection();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Unable to load offers from the database.\n\n" +
                    ex.Message,
                    "Database Error",
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
                CloseConnection();
            }
        }

        // =========================================================
        // FORMAT GRID
        // =========================================================

        private void FormatGrid()
        {
            try
            {
                if (dgvOffers.Columns.Contains("OfferID"))
                {
                    dgvOffers.Columns["OfferID"].HeaderText = "Offer ID";
                    dgvOffers.Columns["OfferID"].FillWeight = 60;
                }

                if (dgvOffers.Columns.Contains("OfferTitle"))
                {
                    dgvOffers.Columns["OfferTitle"].HeaderText = "Offer Title";
                    dgvOffers.Columns["OfferTitle"].FillWeight = 150;
                }

                if (dgvOffers.Columns.Contains("DiscountPercent"))
                {
                    dgvOffers.Columns["DiscountPercent"].HeaderText =
                        "Discount %";

                    dgvOffers.Columns["DiscountPercent"]
                        .DefaultCellStyle.Format = "0.00";

                    dgvOffers.Columns["DiscountPercent"].FillWeight = 80;
                }

                if (dgvOffers.Columns.Contains("StartDate"))
                {
                    dgvOffers.Columns["StartDate"].HeaderText =
                        "Start Date";

                    dgvOffers.Columns["StartDate"]
                        .DefaultCellStyle.Format =
                        "dd-MMM-yyyy hh:mm tt";

                    dgvOffers.Columns["StartDate"].FillWeight = 120;
                }

                if (dgvOffers.Columns.Contains("EndDate"))
                {
                    dgvOffers.Columns["EndDate"].HeaderText =
                        "End Date";

                    dgvOffers.Columns["EndDate"]
                        .DefaultCellStyle.Format =
                        "dd-MMM-yyyy hh:mm tt";

                    dgvOffers.Columns["EndDate"].FillWeight = 120;
                }

                if (dgvOffers.Columns.Contains("IsActive"))
                {
                    dgvOffers.Columns["IsActive"].HeaderText = "Active";
                    dgvOffers.Columns["IsActive"].FillWeight = 60;
                }
            }
            catch
            {
                // Grid formatting errors should not stop the form.
            }
        }

        // =========================================================
        // ADD OFFER
        // =========================================================

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateOffer())
                return;

            try
            {
                dbCon.OpenCon();

                using (SqlCommand cmd =
                    new SqlCommand(
                        "dbo.spInsertOffer",
                        dbCon.GetCon()))
                {
                    cmd.CommandType =
                        CommandType.StoredProcedure;

                    // Offer Title
                    cmd.Parameters.Add(
                        "@OfferTitle",
                        SqlDbType.NVarChar,
                        200).Value =
                        txtTitle.Text.Trim();

                    // Discount
                    SqlParameter discountParameter =
                        cmd.Parameters.Add(
                            "@DiscountPercent",
                            SqlDbType.Decimal);

                    discountParameter.Precision = 5;
                    discountParameter.Scale = 2;
                    discountParameter.Value =
                        nudDiscount.Value;

                    // Start Date
                    cmd.Parameters.Add(
                        "@StartDate",
                        SqlDbType.DateTime).Value =
                        dtpStartDate.Value;

                    // End Date
                    cmd.Parameters.Add(
                        "@EndDate",
                        SqlDbType.DateTime).Value =
                        dtpEndDate.Value;

                    using (SqlDataReader reader =
                        cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            MessageBox.Show(
                                "The database did not return a result.",
                                "Offer",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return;
                        }

                        int success = 0;

                        if (reader["Success"] != DBNull.Value)
                        {
                            success =
                                Convert.ToInt32(reader["Success"]);
                        }

                        string message =
                            reader["Message"] == DBNull.Value
                                ? "Unknown database response."
                                : reader["Message"].ToString();

                        if (success == 1)
                        {
                            MessageBox.Show(
                                message,
                                "GoMart",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            ClearFields();
                            LoadOffers();
                        }
                        else
                        {
                            MessageBox.Show(
                                message,
                                "Offer",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Unable to add offer.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to add offer.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                CloseConnection();
            }
        }

        // =========================================================
        // UPDATE OFFER
        // =========================================================

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedOfferID <= 0)
            {
                MessageBox.Show(
                    "Please select an offer first.",
                    "Offer",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (!ValidateOffer())
                return;

            try
            {
                dbCon.OpenCon();

                const string query = @"
                    UPDATE dbo.tblOffer
                    SET
                        OfferTitle = @OfferTitle,
                        DiscountPercent = @DiscountPercent,
                        StartDate = @StartDate,
                        EndDate = @EndDate,
                        IsActive = @IsActive
                    WHERE OfferID = @OfferID;";

                using (SqlCommand cmd =
                    new SqlCommand(
                        query,
                        dbCon.GetCon()))
                {
                    // Offer ID
                    cmd.Parameters.Add(
                        "@OfferID",
                        SqlDbType.Int).Value =
                        selectedOfferID;

                    // Title
                    cmd.Parameters.Add(
                        "@OfferTitle",
                        SqlDbType.NVarChar,
                        200).Value =
                        txtTitle.Text.Trim();

                    // Discount
                    SqlParameter discountParameter =
                        cmd.Parameters.Add(
                            "@DiscountPercent",
                            SqlDbType.Decimal);

                    discountParameter.Precision = 5;
                    discountParameter.Scale = 2;
                    discountParameter.Value =
                        nudDiscount.Value;

                    // Dates
                    cmd.Parameters.Add(
                        "@StartDate",
                        SqlDbType.DateTime).Value =
                        dtpStartDate.Value;

                    cmd.Parameters.Add(
                        "@EndDate",
                        SqlDbType.DateTime).Value =
                        dtpEndDate.Value;

                    // Active
                    cmd.Parameters.Add(
                        "@IsActive",
                        SqlDbType.Bit).Value =
                        chkActive.Checked;

                    int rowsAffected =
                        cmd.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        MessageBox.Show(
                            "The selected offer no longer exists.",
                            "Update",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        ClearFields();
                        LoadOffers();

                        return;
                    }
                }

                MessageBox.Show(
                    "Offer updated successfully.",
                    "GoMart",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ClearFields();
                LoadOffers();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Unable to update offer.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to update offer.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                CloseConnection();
            }
        }

        // =========================================================
        // DEACTIVATE OFFER
        // =========================================================

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedOfferID <= 0)
            {
                MessageBox.Show(
                    "Please select an offer first.",
                    "Offer",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result =
                MessageBox.Show(
                    "Are you sure you want to deactivate this offer?",
                    "Deactivate Offer",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                dbCon.OpenCon();

                const string query = @"
                    UPDATE dbo.tblOffer
                    SET IsActive = 0
                    WHERE OfferID = @OfferID;";

                using (SqlCommand cmd =
                    new SqlCommand(
                        query,
                        dbCon.GetCon()))
                {
                    cmd.Parameters.Add(
                        "@OfferID",
                        SqlDbType.Int).Value =
                        selectedOfferID;

                    int rowsAffected =
                        cmd.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        MessageBox.Show(
                            "The selected offer no longer exists.",
                            "Deactivate",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        ClearFields();
                        LoadOffers();

                        return;
                    }
                }

                MessageBox.Show(
                    "Offer deactivated successfully.",
                    "GoMart",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ClearFields();
                LoadOffers();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Unable to deactivate offer.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to deactivate offer.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                CloseConnection();
            }
        }

        // =========================================================
        // GRID CELL CLICK
        // =========================================================

        private void dgvOffers_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvOffers.Rows.Count == 0)
                return;

            try
            {
                DataGridViewRow row =
                    dgvOffers.Rows[e.RowIndex];

                // =====================================================
                // OFFER ID
                // =====================================================

                object idValue =
                    row.Cells["OfferID"].Value;

                if (idValue == null ||
                    idValue == DBNull.Value)
                {
                    ClearFields();
                    return;
                }

                selectedOfferID =
                    Convert.ToInt32(idValue);

                // =====================================================
                // OFFER TITLE
                // =====================================================

                object titleValue =
                    row.Cells["OfferTitle"].Value;

                txtTitle.Text =
                    titleValue == null ||
                    titleValue == DBNull.Value
                        ? string.Empty
                        : titleValue.ToString();

                // =====================================================
                // DISCOUNT
                // =====================================================

                object discountValue =
                    row.Cells["DiscountPercent"].Value;

                if (discountValue != null &&
                    discountValue != DBNull.Value)
                {
                    decimal discount =
                        Convert.ToDecimal(discountValue);

                    if (discount < nudDiscount.Minimum)
                        discount = nudDiscount.Minimum;

                    if (discount > nudDiscount.Maximum)
                        discount = nudDiscount.Maximum;

                    nudDiscount.Value = discount;
                }
                else
                {
                    nudDiscount.Value = 0;
                }

                // =====================================================
                // START DATE
                // =====================================================

                object startValue =
                    row.Cells["StartDate"].Value;

                if (startValue != null &&
                    startValue != DBNull.Value)
                {
                    DateTime startDate =
                        Convert.ToDateTime(startValue);

                    if (startDate < dtpStartDate.MinDate)
                        startDate = dtpStartDate.MinDate;

                    if (startDate > dtpStartDate.MaxDate)
                        startDate = dtpStartDate.MaxDate;

                    dtpStartDate.Value = startDate;
                }

                // =====================================================
                // END DATE
                // =====================================================

                object endValue =
                    row.Cells["EndDate"].Value;

                if (endValue != null &&
                    endValue != DBNull.Value)
                {
                    DateTime endDate =
                        Convert.ToDateTime(endValue);

                    if (endDate < dtpEndDate.MinDate)
                        endDate = dtpEndDate.MinDate;

                    if (endDate > dtpEndDate.MaxDate)
                        endDate = dtpEndDate.MaxDate;

                    dtpEndDate.Value = endDate;
                }

                // =====================================================
                // ACTIVE
                // =====================================================

                object activeValue =
                    row.Cells["IsActive"].Value;

                if (activeValue != null &&
                    activeValue != DBNull.Value)
                {
                    chkActive.Checked =
                        Convert.ToBoolean(activeValue);
                }
                else
                {
                    chkActive.Checked = false;
                }

                UpdateButtonState();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to select offer.\n\n" +
                    ex.Message,
                    "Offer",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // VALIDATE OFFER
        // =========================================================

        private bool ValidateOffer()
        {
            // =====================================================
            // TITLE
            // =====================================================

            string title =
                txtTitle.Text.Trim();

            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show(
                    "Please enter an offer title.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTitle.Focus();
                return false;
            }

            if (title.Length > 200)
            {
                MessageBox.Show(
                    "Offer title cannot exceed 200 characters.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTitle.Focus();
                return false;
            }

            // =====================================================
            // DISCOUNT
            // =====================================================

            decimal discount =
                nudDiscount.Value;

            if (discount < 0 || discount > 100)
            {
                MessageBox.Show(
                    "Discount must be between 0 and 100 percent.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                nudDiscount.Focus();
                return false;
            }

            // =====================================================
            // START DATE
            // =====================================================

            DateTime startDate =
                dtpStartDate.Value;

            DateTime endDate =
                dtpEndDate.Value;

            // =====================================================
            // END DATE
            // =====================================================

            if (endDate < startDate)
            {
                MessageBox.Show(
                    "End date cannot be earlier than the start date.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                dtpEndDate.Focus();
                return false;
            }

            return true;
        }

        // =========================================================
        // CLEAR BUTTON
        // =========================================================

        private void btnClear_Click(
            object sender,
            EventArgs e)
        {
            ClearFields();
        }

        // =========================================================
        // REFRESH BUTTON
        // =========================================================

        private void btnRefresh_Click(
            object sender,
            EventArgs e)
        {
            ClearFields();
            LoadOffers();
        }

        // =========================================================
        // CLEAR FIELDS
        // =========================================================

        private void ClearFields()
        {
            selectedOfferID = 0;

            txtTitle.Clear();

            // Reset discount
            if (nudDiscount.Value != nudDiscount.Minimum)
            {
                nudDiscount.Value =
                    nudDiscount.Minimum;
            }

            // Reset dates
            DateTime now = DateTime.Now;

            if (now < dtpStartDate.MinDate)
                now = dtpStartDate.MinDate;

            if (now > dtpStartDate.MaxDate)
                now = dtpStartDate.MaxDate;

            dtpStartDate.Value = now;

            DateTime endDate =
                now.AddDays(30);

            if (endDate < dtpEndDate.MinDate)
                endDate = dtpEndDate.MinDate;

            if (endDate > dtpEndDate.MaxDate)
                endDate = dtpEndDate.MaxDate;

            dtpEndDate.Value = endDate;

            // New offers are active by default
            chkActive.Checked = true;

            // Clear grid selection
            if (dgvOffers.Rows.Count > 0)
            {
                dgvOffers.ClearSelection();
            }

            UpdateButtonState();
        }

        // =========================================================
        // BUTTON STATE
        // =========================================================

        private void UpdateButtonState()
        {
            bool selected =
                selectedOfferID > 0;

            btnUpdate.Enabled = selected;
            btnDelete.Enabled = selected;
        }

        // =========================================================
        // CLOSE DATABASE CONNECTION
        // =========================================================

        private void CloseConnection()
        {
            try
            {
                dbCon.CloseCon();
            }
            catch
            {
                // Ignore connection close errors.
            }
        }

        // =========================================================
        // FORM CLOSING
        // =========================================================

        private void OfferManagement_FormClosing(
            object sender,
            FormClosingEventArgs e)
        {
            CloseConnection();
        }
    }
}