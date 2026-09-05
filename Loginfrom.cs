using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GoMartApplication
{
    public partial class Loginfrom : Form
    {
        // =====================================================
        // DATABASE
        // =====================================================

        private const string DatabaseName = "GoMartDB";

        private string connectionString = "";


        // =====================================================
        // CONSTRUCTOR
        // =====================================================

        public Loginfrom()
        {
            InitializeComponent();

            this.Load += Loginfrom_Load;
        }


        // =====================================================
        // FORM LOAD
        // =====================================================

        private void Loginfrom_Load(object sender, EventArgs e)
        {
            try
            {
                cmbRole.Items.Clear();

                cmbRole.Items.Add("Customer");
                cmbRole.Items.Add("Seller");
                cmbRole.Items.Add("Admin");
                cmbRole.Items.Add("Super Admin");

                cmbRole.SelectedIndex = 0;

                txtUsername.Clear();
                txtPassword.Clear();

                // Find GoMartDB automatically
                if (!FindDatabase())
                {
                    MessageBox.Show(
                        "GoMartDB could not be found on your SQL Server instances.\n\n" +
                        "Please make sure SQL Server is running and that the " +
                        "GoMartDB database was created.",
                        "Database Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                txtUsername.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to initialize Login form.\n\n" +
                    ex.Message,
                    "Login Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =====================================================
        // FIND DATABASE
        // =====================================================

        private bool FindDatabase()
        {
            string computerName = Environment.MachineName;

            string[] serverNames =
            {
                @"(localdb)\MSSQLLocalDB",
                @"(localdb)\ProjectsV13",
                @".\SQLEXPRESS",
                computerName + @"\SQLEXPRESS",
                computerName,
                @"localhost\SQLEXPRESS",
                @"localhost"
            };

            foreach (string serverName in serverNames)
            {
                try
                {
                    string testConnection =
                        "Data Source=" + serverName +
                        ";Initial Catalog=master;" +
                        "Integrated Security=True;" +
                        "TrustServerCertificate=True;" +
                        "Connect Timeout=3;";

                    using (SqlConnection connection =
                           new SqlConnection(testConnection))
                    {
                        connection.Open();

                        using (SqlCommand command =
                               new SqlCommand(
                                   "SELECT DB_ID(@DatabaseName)",
                                   connection))
                        {
                            command.Parameters.Add(
                                "@DatabaseName",
                                SqlDbType.NVarChar,
                                128).Value = DatabaseName;

                            object result =
                                command.ExecuteScalar();

                            if (result != null &&
                                result != DBNull.Value)
                            {
                                connectionString =
                                    "Data Source=" + serverName +
                                    ";Initial Catalog=" + DatabaseName +
                                    ";Integrated Security=True;" +
                                    "TrustServerCertificate=True;" +
                                    "Connect Timeout=10;";

                                return true;
                            }
                        }
                    }
                }
                catch
                {
                    // Try next SQL Server instance
                }
            }

            return false;
        }


        // =====================================================
        // CHECK DATABASE CONNECTION
        // =====================================================

        private bool CheckConnection()
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                if (!FindDatabase())
                {
                    MessageBox.Show(
                        "Cannot find GoMartDB.\n\n" +
                        "Please check that SQL Server is running " +
                        "and GoMartDB exists.",
                        "Database Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return false;
                }
            }

            try
            {
                using (SqlConnection connection =
                       new SqlConnection(connectionString))
                {
                    connection.Open();
                    return true;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Cannot connect to GoMartDB.\n\n" +
                    "Connection:\n" +
                    connectionString +
                    "\n\nSQL Error:\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Cannot connect to GoMartDB.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
        }


        // =====================================================
        // LOGIN BUTTON
        // =====================================================

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string role = cmbRole.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;


            // =================================================
            // VALIDATE ROLE
            // =================================================

            if (string.IsNullOrWhiteSpace(role))
            {
                MessageBox.Show(
                    "Please select a role.",
                    "Login",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbRole.Focus();
                return;
            }


            // =================================================
            // VALIDATE USERNAME / EMAIL
            // =================================================

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show(
                    "Please enter your email.",
                    "Login",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtUsername.Focus();
                return;
            }


            // =================================================
            // VALIDATE PASSWORD
            // =================================================

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show(
                    "Please enter your password.",
                    "Login",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPassword.Focus();
                return;
            }


            // =================================================
            // CHECK DATABASE
            // =================================================

            if (!CheckConnection())
            {
                return;
            }


            try
            {
                bool success = false;


                // =================================================
                // CUSTOMER
                // =================================================

                if (role.Equals(
                    "Customer",
                    StringComparison.OrdinalIgnoreCase))
                {
                    success = LoginCustomer(
                        username,
                        password);
                }


                // =================================================
                // SELLER
                // =================================================

                else if (role.Equals(
                    "Seller",
                    StringComparison.OrdinalIgnoreCase))
                {
                    success = LoginSeller(
                        username,
                        password);
                }


                // =================================================
                // ADMIN
                // =================================================

                else if (role.Equals(
                    "Admin",
                    StringComparison.OrdinalIgnoreCase))
                {
                    success = LoginAdmin(
                        username,
                        password);
                }


                // =================================================
                // SUPER ADMIN
                // =================================================

                else if (role.Equals(
                    "Super Admin",
                    StringComparison.OrdinalIgnoreCase))
                {
                    success = LoginSuperAdmin(
                        username,
                        password);
                }


                // =================================================
                // OPEN DASHBOARD
                // =================================================

                if (success)
                {
                    OpenMainForm();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "SQL Server error.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error occurred during login.\n\n" +
                    ex.Message,
                    "Login Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =====================================================
        // CUSTOMER LOGIN
        // =====================================================

        private bool LoginCustomer(
            string username,
            string password)
        {
            using (SqlConnection connection =
                   new SqlConnection(connectionString))
            {
                using (SqlCommand command =
                       new SqlCommand(
                           "dbo.spCustomerLogin",
                           connection))
                {
                    command.CommandType =
                        CommandType.StoredProcedure;


                    // IMPORTANT:
                    // spCustomerLogin expects
                    // @CustomerEmail
                    // @CustomerPassword

                    command.Parameters.Add(
                        "@CustomerEmail",
                        SqlDbType.NVarChar,
                        150).Value = username;

                    command.Parameters.Add(
                        "@CustomerPassword",
                        SqlDbType.NVarChar,
                        255).Value = password;


                    connection.Open();

                    using (SqlDataReader reader =
                           command.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            InvalidLogin();
                            return false;
                        }


                        int customerID =
                            Convert.ToInt32(
                                reader["CustomerID"]);

                        string customerName =
                            reader["CustomerName"].ToString();

                        string customerEmail =
                            reader["CustomerEmail"].ToString();


                        Session.LoginCustomer(
                            customerID,
                            customerEmail,
                            customerName);

                        return true;
                    }
                }
            }
        }


        // =====================================================
        // SELLER LOGIN
        // =====================================================

        private bool LoginSeller(
            string username,
            string password)
        {
            using (SqlConnection connection =
                   new SqlConnection(connectionString))
            {
                using (SqlCommand command =
                       new SqlCommand(
                           "dbo.spSellerLogin",
                           connection))
                {
                    command.CommandType =
                        CommandType.StoredProcedure;


                    // IMPORTANT:
                    // spSellerLogin expects
                    // @SellerEmail
                    // @SellerPassword

                    command.Parameters.Add(
                        "@SellerEmail",
                        SqlDbType.NVarChar,
                        150).Value = username;

                    command.Parameters.Add(
                        "@SellerPassword",
                        SqlDbType.NVarChar,
                        255).Value = password;


                    connection.Open();

                    using (SqlDataReader reader =
                           command.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            InvalidLogin();
                            return false;
                        }


                        int sellerID =
                            Convert.ToInt32(
                                reader["SellerID"]);

                        string sellerName =
                            reader["SellerName"].ToString();


                        Session.LoginSeller(
                            sellerID,
                            sellerName);

                        return true;
                    }
                }
            }
        }


        // =====================================================
        // ADMIN LOGIN
        // =====================================================

        private bool LoginAdmin(
            string username,
            string password)
        {
            using (SqlConnection connection =
                   new SqlConnection(connectionString))
            {
                using (SqlCommand command =
                       new SqlCommand(
                           "dbo.spAdminLogin",
                           connection))
                {
                    command.CommandType =
                        CommandType.StoredProcedure;


                    // =================================================
                    // VERY IMPORTANT
                    //
                    // spAdminLogin expects:
                    //
                    // @AdminEmail
                    // @AdminPassword
                    //
                    // NOT:
                    //
                    // @AdminID
                    // @Password
                    // =================================================

                    command.Parameters.Add(
                        "@AdminEmail",
                        SqlDbType.NVarChar,
                        150).Value = username;

                    command.Parameters.Add(
                        "@AdminPassword",
                        SqlDbType.NVarChar,
                        255).Value = password;


                    connection.Open();

                    using (SqlDataReader reader =
                           command.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            InvalidLogin();
                            return false;
                        }


                        string adminID =
                            reader["AdminID"].ToString();

                        string fullName =
                            reader["AdminName"].ToString();


                        Session.LoginAdmin(
                            adminID,
                            fullName);

                        return true;
                    }
                }
            }
        }


        // =====================================================
        // SUPER ADMIN LOGIN
        // =====================================================

        private bool LoginSuperAdmin(
            string username,
            string password)
        {
            using (SqlConnection connection =
                   new SqlConnection(connectionString))
            {
                using (SqlCommand command =
                       new SqlCommand(
                           "dbo.spSuperAdminLogin",
                           connection))
                {
                    command.CommandType =
                        CommandType.StoredProcedure;


                    // IMPORTANT:
                    // spSuperAdminLogin expects
                    // @SuperAdminEmail
                    // @SuperAdminPassword

                    command.Parameters.Add(
                        "@SuperAdminEmail",
                        SqlDbType.NVarChar,
                        150).Value = username;

                    command.Parameters.Add(
                        "@SuperAdminPassword",
                        SqlDbType.NVarChar,
                        255).Value = password;


                    connection.Open();

                    using (SqlDataReader reader =
                           command.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            InvalidLogin();
                            return false;
                        }


                        int superAdminID =
                            Convert.ToInt32(
                                reader["SuperAdminID"]);

                        string superAdminName =
                            reader["SuperAdminName"].ToString();

                        string superAdminEmail =
                            reader["SuperAdminEmail"].ToString();


                        Session.LoginSuperAdmin(
                            superAdminID,
                            superAdminEmail,
                            superAdminName);

                        return true;
                    }
                }
            }
        }


        // =====================================================
        // OPEN DASHBOARD
        // =====================================================

        private void OpenMainForm()
        {
            this.Hide();

            try
            {
                // =================================================
                // CUSTOMER
                // =================================================

                if (Session.IsCustomer())
                {
                    if (Session.CustomerID <= 0)
                    {
                        MessageBox.Show(
                            "Invalid customer ID.\n\n" +
                            "Please login again.",
                            "Customer Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        return;
                    }

                    using (CustomerDashboard dashboard =
                           new CustomerDashboard(
                               Session.CustomerID))
                    {
                        dashboard.ShowDialog();
                    }
                }


                // =================================================
                // SUPER ADMIN
                // =================================================

                else if (Session.IsSuperAdmin())
                {
                    using (SuperAdminDashboard dashboard =
                           new SuperAdminDashboard())
                    {
                        dashboard.ShowDialog();
                    }
                }


                // =================================================
                // SELLER
                // =================================================

                else if (Session.IsSeller())
                {
                    using (formMain mainForm =
                           new formMain())
                    {
                        mainForm.ShowDialog();
                    }
                }


                // =================================================
                // ADMIN
                // =================================================

                else if (Session.IsAdmin())
                {
                    using (formMain mainForm =
                           new formMain())
                    {
                        mainForm.ShowDialog();
                    }
                }


                // =================================================
                // INVALID SESSION
                // =================================================

                else
                {
                    MessageBox.Show(
                        "Invalid user session.\n\n" +
                        "Please login again.",
                        "Session Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to open the dashboard.\n\n" +
                    ex.Message,
                    "GoMart",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                // Clear session when dashboard closes
                Session.Logout();

                // Show login form again
                this.Show();

                txtUsername.Clear();
                txtPassword.Clear();

                txtUsername.Focus();
            }
        }


        // =====================================================
        // INVALID LOGIN
        // =====================================================

        private void InvalidLogin()
        {
            Session.Logout();

            MessageBox.Show(
                "Invalid email or password.",
                "Login Failed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            txtPassword.Clear();
            txtPassword.Focus();
        }


        // =====================================================
        // CLEAR BUTTON
        // =====================================================

        private void btnClear_Click(
            object sender,
            EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();

            if (cmbRole.Items.Count > 0)
            {
                cmbRole.SelectedIndex = 0;
            }

            txtUsername.Focus();
        }


        // =====================================================
        // REGISTER / SIGN UP
        // =====================================================

        private void btnRegister_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                using (CustomerRegistration registration =
                       new CustomerRegistration())
                {
                    registration.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to open Customer Registration.\n\n" +
                    ex.Message,
                    "Registration",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =====================================================
        // PASSWORD ENTER KEY
        // =====================================================

        private void txtPassword_KeyDown(
            object sender,
            KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;

                btnLogin.PerformClick();
            }
        }


        // =====================================================
        // FORM CLOSING
        // =====================================================

        private void Loginfrom_Form(
            object sender,
            FormClosingEventArgs e)
        {
            Session.Logout();
        }
    }
}