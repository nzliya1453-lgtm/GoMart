
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GoMartApplication
{
    public partial class formMain : Form
    {
        // =====================================================
        // DATABASE
        // =====================================================

        private readonly DBConnect dbCon = new DBConnect();

        // Low-stock threshold
        private const int LOW_STOCK_LEVEL = 5;


        // =====================================================
        // CONSTRUCTOR
        // =====================================================

        public formMain()
        {
            InitializeComponent();

            // Form Load event
            this.Load += formMain_Load;
        }


        // =====================================================
        // FORM LOAD
        // =====================================================

        private void formMain_Load(object sender, EventArgs e)
        {
            // -------------------------------------------------
            // CHECK LOGIN
            // -------------------------------------------------

            if (!Session.IsUserLoggedIn())
            {
                MessageBox.Show(
                    "No user is currently logged in.",
                    "Access Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                this.Close();
                return;
            }


            // -------------------------------------------------
            // DISPLAY USER
            // -------------------------------------------------

            lblUser.Text =
                Session.Username +
                " (" +
                Session.Role +
                ")";


            // -------------------------------------------------
            // DEFAULT BUTTON SETTINGS
            // -------------------------------------------------

            btnCategory.Enabled = false;
            btnProduct.Enabled = false;
            btnSeller.Enabled = false;
            btnAdmin.Enabled = false;
            btnSell.Enabled = false;


            // -------------------------------------------------
            // SELLER
            // -------------------------------------------------

            if (Session.IsSeller())
            {
                btnSell.Enabled = true;
            }


            // -------------------------------------------------
            // CUSTOMER
            // -------------------------------------------------

            else if (Session.IsCustomer())
            {
                btnSell.Enabled = true;
            }


            // -------------------------------------------------
            // ADMIN
            // -------------------------------------------------

            else if (Session.IsAdmin())
            {
                btnCategory.Enabled = true;
                btnProduct.Enabled = true;
                btnSeller.Enabled = true;
                btnAdmin.Enabled = true;
                btnSell.Enabled = true;

                // Check low stock only for Admin
                CheckLowStock();
            }


            // -------------------------------------------------
            // SUPER ADMIN
            // -------------------------------------------------

            else if (Session.IsSuperAdmin())
            {
                MessageBox.Show(
                    "Super Admin should use the Super Admin Dashboard.",
                    "Access",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Session.Logout();

                this.Close();
                return;
            }


            // -------------------------------------------------
            // UNKNOWN ROLE
            // -------------------------------------------------

            else
            {
                MessageBox.Show(
                    "Invalid user session.",
                    "Session Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                Session.Logout();

                this.Close();
                return;
            }
        }


        // =====================================================
        // LOW STOCK CHECK
        // =====================================================

        private void CheckLowStock()
        {
            if (!Session.IsAdmin())
            {
                return;
            }

            try
            {
                dbCon.OpenCon();

                string query = @"
                    SELECT COUNT(*)
                    FROM dbo.tblProduct
                    WHERE ProdQty <= @LowStockLevel
                      AND IsActive = 1;
                ";

                using (SqlCommand cmd =
                       new SqlCommand(query, dbCon.GetCon()))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(
                        "@LowStockLevel",
                        SqlDbType.Int).Value =
                        LOW_STOCK_LEVEL;

                    object result = cmd.ExecuteScalar();

                    int lowStockCount = 0;

                    if (result != null && result != DBNull.Value)
                    {
                        lowStockCount = Convert.ToInt32(result);
                    }

                    if (lowStockCount > 0)
                    {
                        DialogResult answer =
                            MessageBox.Show(
                                "LOW STOCK ALERT!\n\n" +
                                lowStockCount +
                                " product(s) have stock of " +
                                LOW_STOCK_LEVEL +
                                " or less.\n\n" +
                                "Do you want to open Product Management?",
                                "Low Stock Warning",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning);

                        if (answer == DialogResult.Yes)
                        {
                            OpenProductForm();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Unable to check product stock.\n\n" +
                    ex.Message,
                    "Stock Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An error occurred while checking stock.\n\n" +
                    ex.Message,
                    "Stock Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                dbCon.CloseCon();
            }
        }


        // =====================================================
        // OPEN PRODUCT FORM
        // =====================================================

        private void OpenProductForm()
        {
            try
            {
                using (AddProduct productForm = new AddProduct())
                {
                    productForm.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to open Product form.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =====================================================
        // CATEGORY
        // =====================================================

        private void btnCategory_Click(object sender, EventArgs e)
        {
            if (!Session.IsAdmin())
            {
                MessageBox.Show(
                    "You do not have permission to access Category.",
                    "Access Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                using (frmCategory categoryForm =
                       new frmCategory())
                {
                    categoryForm.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to open Category form.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =====================================================
        // PRODUCT
        // =====================================================

        private void btnProduct_Click(object sender, EventArgs e)
        {
            if (!Session.IsAdmin())
            {
                MessageBox.Show(
                    "You do not have permission to access Product.",
                    "Access Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            OpenProductForm();
        }


        // =====================================================
        // SELLER
        // =====================================================

        private void btnSeller_Click(object sender, EventArgs e)
        {
            if (!Session.IsAdmin())
            {
                MessageBox.Show(
                    "You do not have permission to manage Sellers.",
                    "Access Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                using (AddNewSeller sellerForm =
                       new AddNewSeller())
                {
                    sellerForm.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to open Seller form.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =====================================================
        // ADMIN
        // =====================================================

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            if (!Session.IsAdmin() &&
                !Session.IsSuperAdmin())
            {
                MessageBox.Show(
                    "You do not have permission to manage Admins.",
                    "Access Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                using (AddAdmin adminForm =
                       new AddAdmin())
                {
                    adminForm.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to open Admin form.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =====================================================
        // SELL / SHOPPING
        // =====================================================

        private void btnSell_Click(object sender, EventArgs e)
        {
            // -------------------------------------------------
            // LOGIN CHECK
            // -------------------------------------------------

            if (!Session.IsUserLoggedIn())
            {
                MessageBox.Show(
                    "Please login first.",
                    "Access Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            // -------------------------------------------------
            // ROLE CHECK
            // -------------------------------------------------

            if (!Session.IsCustomer() &&
                !Session.IsSeller() &&
                !Session.IsAdmin())
            {
                MessageBox.Show(
                    "You do not have permission to access Selling.",
                    "Access Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            // -------------------------------------------------
            // OPEN SELLING FORM
            // -------------------------------------------------

            try
            {
                using (SellingForm sellingForm =
                       new SellingForm())
                {
                    sellingForm.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to open Selling form.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =====================================================
        // LOGOUT
        // =====================================================

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result =
                MessageBox.Show(
                    "Are you sure you want to logout?",
                    "Logout",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                return;
            }


            // -------------------------------------------------
            // CLEAR SESSION
            // -------------------------------------------------

            Session.Logout();


            // -------------------------------------------------
            // CLOSE MAIN FORM
            // -------------------------------------------------

            this.Close();
        }
    }
}

