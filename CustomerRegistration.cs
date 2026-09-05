using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GoMartApplication
{
    public partial class CustomerRegistration : Form
    {
        private string connectionString =
            @"Data Source=.\SQLEXPRESS;Initial Catalog=GoMartDB;Integrated Security=True";

        public CustomerRegistration()
        {
            InitializeComponent();
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            Register();
        }

        private void Register()
        {
            try
            {
                string userName = txtUserName.Text.Trim();
                string password = txtPassword.Text.Trim();
                string fullName = txtFullName.Text.Trim();
                string phone = txtPhone.Text.Trim();
                string email = txtEmail.Text.Trim();
                string address = txtAddress.Text.Trim();

                if (string.IsNullOrEmpty(userName))
                {
                    MessageBox.Show(
                        "Please enter a username.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    txtUserName.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(password))
                {
                    MessageBox.Show(
                        "Please enter a password.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    txtPassword.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(fullName))
                {
                    MessageBox.Show(
                        "Please enter your full name.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    txtFullName.Focus();
                    return;
                }

                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd =
                        new SqlCommand("spCustomerRegister", con))
                    {
                        cmd.CommandType =
                            CommandType.StoredProcedure;

                        cmd.Parameters.Add(
                            "@UserName",
                            SqlDbType.NVarChar,
                            50).Value = userName;

                        cmd.Parameters.Add(
                            "@Password",
                            SqlDbType.NVarChar,
                            100).Value = password;

                        cmd.Parameters.Add(
                            "@FullName",
                            SqlDbType.NVarChar,
                            100).Value = fullName;

                        cmd.Parameters.Add(
                            "@Phone",
                            SqlDbType.NVarChar,
                            20).Value =
                                string.IsNullOrEmpty(phone)
                                ? (object)DBNull.Value
                                : phone;

                        cmd.Parameters.Add(
                            "@Email",
                            SqlDbType.NVarChar,
                            100).Value =
                                string.IsNullOrEmpty(email)
                                ? (object)DBNull.Value
                                : email;

                        cmd.Parameters.Add(
                            "@Address",
                            SqlDbType.NVarChar,
                            250).Value =
                                string.IsNullOrEmpty(address)
                                ? (object)DBNull.Value
                                : address;

                        con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Customer registration successful.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ClearFields();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Registration failed:\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An error occurred:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            txtUserName.Clear();
            txtPassword.Clear();
            txtFullName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtAddress.Clear();

            txtUserName.Focus();
        }
    }
}