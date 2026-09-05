using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GoMartApplication
{
    public partial class ManageCustomer : Form
    {
        private readonly string connectionString =
            @"Data Source=.\SQLEXPRESS;" +
            "Initial Catalog=GoMartDB;" +
            "Integrated Security=True;" +
            "TrustServerCertificate=True;" +
            "Connect Timeout=5";

        public ManageCustomer()
        {
            InitializeComponent();
        }

        // =========================================================
        // FORM LOAD
        // =========================================================

        private void ManageCustomer_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        // =========================================================
        // REFRESH BUTTON
        // =========================================================

        private void btn0_Click(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        // =========================================================
        // DELETE BUTTON
        // =========================================================

        private void btn1_Click(object sender, EventArgs e)
        {
            DeleteSelected();
        }

        // =========================================================
        // LOAD CUSTOMERS
        // =========================================================

        private void LoadCustomers()
        {
            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT
                            CustomerID,
                            CustomerName,
                            CustomerEmail,
                            CustomerPhone,
                            CustomerAddress,
                            IsActive,
                            CreatedDate
                        FROM dbo.tblCustomer
                        ORDER BY CustomerID DESC";

                    using (SqlDataAdapter adapter =
                        new SqlDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();

                        adapter.Fill(dt);

                        dataGridViewCustomers.DataSource = dt;
                    }
                }

                ConfigureGrid();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Database error while loading customers:\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading customers:\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // CONFIGURE GRID
        // =========================================================

        private void ConfigureGrid()
        {
            if (dataGridViewCustomers.Columns.Count == 0)
                return;

            if (dataGridViewCustomers.Columns.Contains("CustomerID"))
            {
                dataGridViewCustomers.Columns["CustomerID"]
                    .HeaderText = "Customer ID";
            }

            if (dataGridViewCustomers.Columns.Contains("CustomerName"))
            {
                dataGridViewCustomers.Columns["CustomerName"]
                    .HeaderText = "Customer Name";
            }

            if (dataGridViewCustomers.Columns.Contains("CustomerEmail"))
            {
                dataGridViewCustomers.Columns["CustomerEmail"]
                    .HeaderText = "Email";
            }

            if (dataGridViewCustomers.Columns.Contains("CustomerPhone"))
            {
                dataGridViewCustomers.Columns["CustomerPhone"]
                    .HeaderText = "Phone";
            }

            if (dataGridViewCustomers.Columns.Contains("CustomerAddress"))
            {
                dataGridViewCustomers.Columns["CustomerAddress"]
                    .HeaderText = "Address";
            }

            if (dataGridViewCustomers.Columns.Contains("IsActive"))
            {
                dataGridViewCustomers.Columns["IsActive"]
                    .HeaderText = "Active";
            }

            if (dataGridViewCustomers.Columns.Contains("CreatedDate"))
            {
                dataGridViewCustomers.Columns["CreatedDate"]
                    .HeaderText = "Created Date";

                dataGridViewCustomers.Columns["CreatedDate"]
                    .DefaultCellStyle.Format =
                    "dd-MMM-yyyy HH:mm";
            }

            dataGridViewCustomers.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dataGridViewCustomers.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dataGridViewCustomers.MultiSelect = false;

            dataGridViewCustomers.ReadOnly = true;

            dataGridViewCustomers.AllowUserToAddRows = false;

            dataGridViewCustomers.AllowUserToDeleteRows = false;

            dataGridViewCustomers.RowHeadersVisible = false;
        }

        // =========================================================
        // DELETE SELECTED CUSTOMER
        // =========================================================

        private void DeleteSelected()
        {
            if (dataGridViewCustomers.CurrentRow == null)
            {
                MessageBox.Show(
                    "Please select a customer first.",
                    "No Customer Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (!dataGridViewCustomers.Columns.Contains("CustomerID"))
            {
                MessageBox.Show(
                    "Customer ID column was not found.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            object idValue =
                dataGridViewCustomers.CurrentRow
                    .Cells["CustomerID"].Value;

            if (idValue == null ||
                idValue == DBNull.Value ||
                !int.TryParse(idValue.ToString(), out int customerID) ||
                customerID <= 0)
            {
                MessageBox.Show(
                    "Invalid customer ID.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            string customerName = "Selected Customer";

            if (dataGridViewCustomers.Columns.Contains("CustomerName"))
            {
                object nameValue =
                    dataGridViewCustomers.CurrentRow
                        .Cells["CustomerName"].Value;

                if (nameValue != null &&
                    nameValue != DBNull.Value)
                {
                    customerName = nameValue.ToString();
                }
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to deactivate this customer?\n\n" +
                "Customer: " + customerName +
                "\nCustomer ID: " + customerID,
                "Confirm Deactivation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    // Soft delete.
                    // This keeps orders/reviews/history safe.
                    string query = @"
                        UPDATE dbo.tblCustomer
                        SET IsActive = 0
                        WHERE CustomerID = @CustomerID";

                    using (SqlCommand cmd =
                        new SqlCommand(query, con))
                    {
                        cmd.Parameters.Add(
                            "@CustomerID",
                            SqlDbType.Int).Value = customerID;

                        con.Open();

                        int rowsAffected =
                            cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show(
                                "Customer deactivated successfully.",
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            LoadCustomers();
                        }
                        else
                        {
                            MessageBox.Show(
                                "Customer could not be deactivated.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Database error while deactivating customer:\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error deactivating customer:\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // FORM CLOSING
        // =========================================================

        private void ManageCustomer_FormClosing(
            object sender,
            FormClosingEventArgs e)
        {
            // No Session.Logout() here.
            // The login/main-form workflow handles the session.
        }
    }
}