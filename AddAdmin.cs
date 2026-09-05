
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GoMartApplication
{
    public partial class AddAdmin : Form
    {
        private readonly string connectionString =
            @"Data Source=.\SQLEXPRESS;Initial Catalog=GoMartDB;Integrated Security=True";

        public AddAdmin()
        {
            InitializeComponent();
        }

        // ==========================================
        // ADD ADMIN BUTTON
        // ==========================================

        private void btn0_Click(object sender, EventArgs e)
        {
            AddAdminAccount();
        }

        // ==========================================
        // ADD ADMIN
        // ==========================================

        private void AddAdminAccount()
        {
            try
            {
                string adminID = txtUserName.Text.Trim();
                string password = txtPassword.Text.Trim();
                string fullName = txtFullName.Text.Trim();

                // ==========================================
                // VALIDATION
                // ==========================================

                if (string.IsNullOrWhiteSpace(adminID))
                {
                    MessageBox.Show(
                        "Please enter an Admin ID.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtUserName.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show(
                        "Please enter a password.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtPassword.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(fullName))
                {
                    MessageBox.Show(
                        "Please enter the admin full name.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtFullName.Focus();
                    return;
                }

                // ==========================================
                // INSERT ADMIN
                // ==========================================

                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    string query = @"
                        INSERT INTO dbo.tblAdmin
                        (
                            AdminID,
                            [Password],
                            FullName
                        )
                        VALUES
                        (
                            @AdminID,
                            @Password,
                            @FullName
                        );";

                    using (SqlCommand cmd =
                        new SqlCommand(query, con))
                    {
                        cmd.Parameters.Add(
                            "@AdminID",
                            SqlDbType.NVarChar,
                            50).Value = adminID;

                        cmd.Parameters.Add(
                            "@Password",
                            SqlDbType.NVarChar,
                            100).Value = password;

                        cmd.Parameters.Add(
                            "@FullName",
                            SqlDbType.NVarChar,
                            100).Value = fullName;

                        con.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show(
                                "Admin account added successfully.",
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            ClearFields();
                        }
                        else
                        {
                            MessageBox.Show(
                                "Admin account could not be added.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Duplicate AdminID
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show(
                        "This Admin ID already exists.",
                        "Duplicate Admin ID",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtUserName.Focus();
                }
                else
                {
                    MessageBox.Show(
                        "Database error:\n\n" + ex.Message,
                        "Database Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An error occurred:\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // CLEAR FIELDS
        // ==========================================

        private void ClearFields()
        {
            txtUserName.Clear();
            txtPassword.Clear();
            txtFullName.Clear();

            // If these controls exist, clear them too.
            txtPhone.Clear();
            txtEmail.Clear();

            txtUserName.Focus();
        }
    }
}

