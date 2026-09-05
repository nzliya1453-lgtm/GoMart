
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GoMartApplication
{
    public partial class ManageOffer : Form
    {
        // =========================================================
        // DATABASE CONNECTION
        // =========================================================

        private readonly string connectionString =
            @"Data Source=.\SQLEXPRESS;Initial Catalog=GoMartDB;Integrated Security=True";


        // =========================================================
        // CONSTRUCTOR
        // =========================================================

        public ManageOffer()
        {
            InitializeComponent();

            LoadOffers();
        }


        // =========================================================
        // BUTTON 0 - ADD OFFER
        // =========================================================

        private void btn0_Click(object sender, EventArgs e)
        {
            AddOffer();
        }


        // =========================================================
        // BUTTON 1 - UPDATE OFFER
        // =========================================================

        private void btn1_Click(object sender, EventArgs e)
        {
            UpdateOffer();
        }


        // =========================================================
        // BUTTON 2 - DELETE OFFER
        // =========================================================

        private void btn2_Click(object sender, EventArgs e)
        {
            DeleteOffer();
        }


        // =========================================================
        // BUTTON 3 - REFRESH
        // =========================================================

        private void btn3_Click(object sender, EventArgs e)
        {
            LoadOffers();
        }


        // =========================================================
        // LOAD ACTIVE OFFERS
        // =========================================================

        private void LoadOffers()
        {
            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT
                            OfferID,
                            Title,
                            Description,
                            DiscountPercent,
                            StartDate,
                            EndDate,
                            IsActive
                        FROM dbo.tblOffer
                        WHERE IsActive = 1
                        ORDER BY OfferID DESC";

                    using (SqlDataAdapter adapter =
                        new SqlDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();

                        adapter.Fill(dt);

                        dataGridViewOffer.DataSource = dt;
                    }
                }

                // Format discount column
                if (dataGridViewOffer.Columns.Contains("DiscountPercent"))
                {
                    dataGridViewOffer.Columns["DiscountPercent"]
                        .DefaultCellStyle.Format = "N2";
                }

                // Format dates
                if (dataGridViewOffer.Columns.Contains("StartDate"))
                {
                    dataGridViewOffer.Columns["StartDate"]
                        .DefaultCellStyle.Format = "dd-MM-yyyy HH:mm";
                }

                if (dataGridViewOffer.Columns.Contains("EndDate"))
                {
                    dataGridViewOffer.Columns["EndDate"]
                        .DefaultCellStyle.Format = "dd-MM-yyyy HH:mm";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading offers:\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =========================================================
        // ADD OFFER
        // =========================================================

        private void AddOffer()
        {
            try
            {
                // ---------------------------------------------
                // OFFER TITLE
                // ---------------------------------------------

                string title = ShowInputDialog(
                    "Enter offer title:",
                    "Add Offer");

                if (string.IsNullOrWhiteSpace(title))
                {
                    MessageBox.Show(
                        "Offer title is required.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                title = title.Trim();


                // ---------------------------------------------
                // DISCOUNT
                // ---------------------------------------------

                string discountText = ShowInputDialog(
                    "Enter discount percentage:",
                    "Add Offer");

                if (!decimal.TryParse(
                    discountText,
                    out decimal discount))
                {
                    MessageBox.Show(
                        "Please enter a valid discount.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (discount < 0 || discount > 100)
                {
                    MessageBox.Show(
                        "Discount must be between 0 and 100.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }


                // ---------------------------------------------
                // DESCRIPTION
                // ---------------------------------------------

                string description = ShowInputDialog(
                    "Enter offer description:",
                    "Add Offer");

                description = description == null
                    ? ""
                    : description.Trim();


                // ---------------------------------------------
                // START DATE
                // ---------------------------------------------

                string startDateText = ShowInputDialog(
                    "Enter start date (yyyy-MM-dd):",
                    "Add Offer");

                DateTime startDate;

                if (string.IsNullOrWhiteSpace(startDateText))
                {
                    startDate = DateTime.Now;
                }
                else if (!DateTime.TryParse(
                    startDateText,
                    out startDate))
                {
                    MessageBox.Show(
                        "Please enter a valid start date.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }


                // ---------------------------------------------
                // END DATE
                // ---------------------------------------------

                string endDateText = ShowInputDialog(
                    "Enter end date (yyyy-MM-dd):",
                    "Add Offer");

                DateTime endDate;

                if (string.IsNullOrWhiteSpace(endDateText))
                {
                    endDate = startDate.AddDays(30);
                }
                else if (!DateTime.TryParse(
                    endDateText,
                    out endDate))
                {
                    MessageBox.Show(
                        "Please enter a valid end date.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }


                // ---------------------------------------------
                // CHECK DATE
                // ---------------------------------------------

                if (endDate < startDate)
                {
                    MessageBox.Show(
                        "End date cannot be earlier than start date.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }


                // ---------------------------------------------
                // DATABASE
                // ---------------------------------------------

                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    con.Open();


                    // -----------------------------------------
                    // CHECK DUPLICATE TITLE
                    // -----------------------------------------

                    string checkQuery = @"
                        SELECT COUNT(*)
                        FROM dbo.tblOffer
                        WHERE Title = @Title
                          AND IsActive = 1";

                    using (SqlCommand checkCmd =
                        new SqlCommand(checkQuery, con))
                    {
                        checkCmd.Parameters.Add(
                            "@Title",
                            SqlDbType.NVarChar,
                            150).Value = title;

                        int count =
                            Convert.ToInt32(
                                checkCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show(
                                "An offer with this title already exists.",
                                "Duplicate Offer",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return;
                        }
                    }


                    // -----------------------------------------
                    // INSERT OFFER
                    // -----------------------------------------

                    string insertQuery = @"
                        INSERT INTO dbo.tblOffer
                        (
                            Title,
                            Description,
                            DiscountPercent,
                            StartDate,
                            EndDate,
                            IsActive
                        )
                        VALUES
                        (
                            @Title,
                            @Description,
                            @DiscountPercent,
                            @StartDate,
                            @EndDate,
                            1
                        )";

                    using (SqlCommand cmd =
                        new SqlCommand(insertQuery, con))
                    {
                        cmd.Parameters.Add(
                            "@Title",
                            SqlDbType.NVarChar,
                            150).Value = title;

                        cmd.Parameters.Add(
                            "@Description",
                            SqlDbType.NVarChar,
                            500).Value =
                                string.IsNullOrWhiteSpace(description)
                                ? (object)DBNull.Value
                                : description;

                        SqlParameter discountParameter =
                            cmd.Parameters.Add(
                                "@DiscountPercent",
                                SqlDbType.Decimal);

                        discountParameter.Precision = 5;
                        discountParameter.Scale = 2;
                        discountParameter.Value = discount;

                        cmd.Parameters.Add(
                            "@StartDate",
                            SqlDbType.DateTime).Value = startDate;

                        cmd.Parameters.Add(
                            "@EndDate",
                            SqlDbType.DateTime).Value = endDate;

                        cmd.ExecuteNonQuery();
                    }
                }


                MessageBox.Show(
                    "Offer added successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadOffers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error adding offer:\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =========================================================
        // UPDATE OFFER
        // =========================================================

        private void UpdateOffer()
        {
            try
            {
                if (dataGridViewOffer.CurrentRow == null)
                {
                    MessageBox.Show(
                        "Please select an offer to update.",
                        "No Offer Selected",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }


                // ---------------------------------------------
                // GET OFFER ID
                // ---------------------------------------------

                object idValue =
                    dataGridViewOffer.CurrentRow
                        .Cells["OfferID"].Value;

                if (idValue == null ||
                    idValue == DBNull.Value)
                {
                    MessageBox.Show(
                        "Invalid offer selected.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                int offerID =
                    Convert.ToInt32(idValue);


                // ---------------------------------------------
                // CURRENT TITLE
                // ---------------------------------------------

                string currentTitle =
                    Convert.ToString(
                        dataGridViewOffer.CurrentRow
                            .Cells["Title"].Value);


                // ---------------------------------------------
                // NEW TITLE
                // ---------------------------------------------

                string title = ShowInputDialog(
                    "Enter new offer title:",
                    "Update Offer");

                if (string.IsNullOrWhiteSpace(title))
                {
                    title = currentTitle;
                }

                title = title.Trim();


                // ---------------------------------------------
                // CURRENT DISCOUNT
                // ---------------------------------------------

                string currentDiscount =
                    Convert.ToString(
                        dataGridViewOffer.CurrentRow
                            .Cells["DiscountPercent"].Value);


                // ---------------------------------------------
                // NEW DISCOUNT
                // ---------------------------------------------

                string discountText = ShowInputDialog(
                    "Enter new discount percentage:",
                    "Update Offer");

                if (string.IsNullOrWhiteSpace(discountText))
                {
                    discountText = currentDiscount;
                }

                if (!decimal.TryParse(
                    discountText,
                    out decimal discount))
                {
                    MessageBox.Show(
                        "Please enter a valid discount.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (discount < 0 || discount > 100)
                {
                    MessageBox.Show(
                        "Discount must be between 0 and 100.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }


                // ---------------------------------------------
                // CURRENT DESCRIPTION
                // ---------------------------------------------

                string currentDescription =
                    Convert.ToString(
                        dataGridViewOffer.CurrentRow
                            .Cells["Description"].Value);


                // ---------------------------------------------
                // NEW DESCRIPTION
                // ---------------------------------------------

                string description = ShowInputDialog(
                    "Enter new description:",
                    "Update Offer");

                if (string.IsNullOrWhiteSpace(description))
                {
                    description = currentDescription;
                }

                description = description == null
                    ? ""
                    : description.Trim();


                // ---------------------------------------------
                // CURRENT START DATE
                // ---------------------------------------------

                DateTime currentStartDate =
                    Convert.ToDateTime(
                        dataGridViewOffer.CurrentRow
                            .Cells["StartDate"].Value);


                // ---------------------------------------------
                // NEW START DATE
                // ---------------------------------------------

                string startDateText = ShowInputDialog(
                    "Enter new start date (yyyy-MM-dd):",
                    "Update Offer");

                DateTime startDate;

                if (string.IsNullOrWhiteSpace(startDateText))
                {
                    startDate = currentStartDate;
                }
                else if (!DateTime.TryParse(
                    startDateText,
                    out startDate))
                {
                    MessageBox.Show(
                        "Please enter a valid start date.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }


                // ---------------------------------------------
                // CURRENT END DATE
                // ---------------------------------------------

                DateTime currentEndDate =
                    Convert.ToDateTime(
                        dataGridViewOffer.CurrentRow
                            .Cells["EndDate"].Value);


                // ---------------------------------------------
                // NEW END DATE
                // ---------------------------------------------

                string endDateText = ShowInputDialog(
                    "Enter new end date (yyyy-MM-dd):",
                    "Update Offer");

                DateTime endDate;

                if (string.IsNullOrWhiteSpace(endDateText))
                {
                    endDate = currentEndDate;
                }
                else if (!DateTime.TryParse(
                    endDateText,
                    out endDate))
                {
                    MessageBox.Show(
                        "Please enter a valid end date.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }


                // ---------------------------------------------
                // CHECK DATE
                // ---------------------------------------------

                if (endDate < startDate)
                {
                    MessageBox.Show(
                        "End date cannot be earlier than start date.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }


                // ---------------------------------------------
                // UPDATE DATABASE
                // ---------------------------------------------

                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    con.Open();


                    // -----------------------------------------
                    // CHECK DUPLICATE TITLE
                    // -----------------------------------------

                    string checkQuery = @"
                        SELECT COUNT(*)
                        FROM dbo.tblOffer
                        WHERE Title = @Title
                          AND OfferID <> @OfferID
                          AND IsActive = 1";

                    using (SqlCommand checkCmd =
                        new SqlCommand(checkQuery, con))
                    {
                        checkCmd.Parameters.Add(
                            "@Title",
                            SqlDbType.NVarChar,
                            150).Value = title;

                        checkCmd.Parameters.Add(
                            "@OfferID",
                            SqlDbType.Int).Value = offerID;

                        int count =
                            Convert.ToInt32(
                                checkCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show(
                                "Another active offer with this title already exists.",
                                "Duplicate Offer",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return;
                        }
                    }


                    // -----------------------------------------
                    // UPDATE
                    // -----------------------------------------

                    string query = @"
                        UPDATE dbo.tblOffer
                        SET
                            Title = @Title,
                            Description = @Description,
                            DiscountPercent = @DiscountPercent,
                            StartDate = @StartDate,
                            EndDate = @EndDate
                        WHERE OfferID = @OfferID
                          AND IsActive = 1";

                    using (SqlCommand cmd =
                        new SqlCommand(query, con))
                    {
                        cmd.Parameters.Add(
                            "@Title",
                            SqlDbType.NVarChar,
                            150).Value = title;

                        cmd.Parameters.Add(
                            "@Description",
                            SqlDbType.NVarChar,
                            500).Value =
                                string.IsNullOrWhiteSpace(description)
                                ? (object)DBNull.Value
                                : description;

                        SqlParameter discountParameter =
                            cmd.Parameters.Add(
                                "@DiscountPercent",
                                SqlDbType.Decimal);

                        discountParameter.Precision = 5;
                        discountParameter.Scale = 2;
                        discountParameter.Value = discount;

                        cmd.Parameters.Add(
                            "@StartDate",
                            SqlDbType.DateTime).Value = startDate;

                        cmd.Parameters.Add(
                            "@EndDate",
                            SqlDbType.DateTime).Value = endDate;

                        cmd.Parameters.Add(
                            "@OfferID",
                            SqlDbType.Int).Value = offerID;

                        int rowsAffected =
                            cmd.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            MessageBox.Show(
                                "Offer could not be updated.",
                                "Update Failed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return;
                        }
                    }
                }


                MessageBox.Show(
                    "Offer updated successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadOffers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error updating offer:\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =========================================================
        // DELETE OFFER
        // =========================================================
        // Uses soft delete:
        // IsActive = 0
        // =========================================================

        private void DeleteOffer()
        {
            try
            {
                if (dataGridViewOffer.CurrentRow == null)
                {
                    MessageBox.Show(
                        "Please select an offer to delete.",
                        "No Offer Selected",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }


                // ---------------------------------------------
                // GET OFFER ID
                // ---------------------------------------------

                object idValue =
                    dataGridViewOffer.CurrentRow
                        .Cells["OfferID"].Value;

                if (idValue == null ||
                    idValue == DBNull.Value)
                {
                    MessageBox.Show(
                        "Invalid offer selected.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                int offerID =
                    Convert.ToInt32(idValue);


                // ---------------------------------------------
                // GET TITLE
                // ---------------------------------------------

                string title =
                    Convert.ToString(
                        dataGridViewOffer.CurrentRow
                            .Cells["Title"].Value);


                // ---------------------------------------------
                // CONFIRM DELETE
                // ---------------------------------------------

                DialogResult result =
                    MessageBox.Show(
                        "Are you sure you want to delete this offer?\n\n" +
                        title,
                        "Confirm Delete",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                {
                    return;
                }


                // ---------------------------------------------
                // SOFT DELETE
                // ---------------------------------------------

                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    string query = @"
                        UPDATE dbo.tblOffer
                        SET IsActive = 0
                        WHERE OfferID = @OfferID
                          AND IsActive = 1";

                    using (SqlCommand cmd =
                        new SqlCommand(query, con))
                    {
                        cmd.Parameters.Add(
                            "@OfferID",
                            SqlDbType.Int).Value = offerID;

                        con.Open();

                        int rowsAffected =
                            cmd.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            MessageBox.Show(
                                "Offer could not be deleted.",
                                "Delete Failed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return;
                        }
                    }
                }


                MessageBox.Show(
                    "Offer deleted successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadOffers();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "The offer could not be deleted.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error deleting offer:\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =========================================================
        // GRID CELL CLICK
        // =========================================================

        private void dataGridViewOffer_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                {
                    return;
                }

                DataGridViewRow row =
                    dataGridViewOffer.Rows[e.RowIndex];

                // Selected row is automatically used
                // by UpdateOffer() and DeleteOffer().
            }
            catch
            {
                // Ignore invalid row selections.
            }
        }


        // =========================================================
        // CUSTOM INPUT DIALOG
        // =========================================================

        private string ShowInputDialog(
            string message,
            string title)
        {
            using (Form prompt = new Form())
            {
                prompt.Width = 400;
                prompt.Height = 180;
                prompt.FormBorderStyle =
                    FormBorderStyle.FixedDialog;
                prompt.Text = title;
                prompt.StartPosition =
                    FormStartPosition.CenterParent;
                prompt.MinimizeBox = false;
                prompt.MaximizeBox = false;
                prompt.ShowInTaskbar = false;

                Label textLabel = new Label()
                {
                    Left = 20,
                    Top = 20,
                    Width = 340,
                    Height = 25,
                    Text = message
                };

                TextBox textBox = new TextBox()
                {
                    Left = 20,
                    Top = 50,
                    Width = 340
                };

                Button confirmation = new Button()
                {
                    Text = "OK",
                    Left = 200,
                    Top = 90,
                    Width = 75,
                    Height = 30,
                    DialogResult = DialogResult.OK
                };

                Button cancel = new Button()
                {
                    Text = "Cancel",
                    Left = 285,
                    Top = 90,
                    Width = 75,
                    Height = 30,
                    DialogResult = DialogResult.Cancel
                };

                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(textBox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(cancel);

                prompt.AcceptButton = confirmation;
                prompt.CancelButton = cancel;

                prompt.Shown += (sender, e) =>
                {
                    textBox.Focus();
                    textBox.SelectAll();
                };

                DialogResult result =
                    prompt.ShowDialog(this);

                if (result == DialogResult.OK)
                {
                    return textBox.Text;
                }

                return "";
            }
        }
    }
}

