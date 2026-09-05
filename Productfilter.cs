using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GoMartApplication
{
    public partial class ProductFilter : Form
    {
        // =====================================================
        // DATABASE CONNECTION
        // =====================================================

        private readonly DBConnect dbCon = new DBConnect();

        // =====================================================
        // CUSTOMER ID
        // =====================================================

        private readonly int _customerID;

        // =====================================================
        // CONSTRUCTOR
        // =====================================================

        public ProductFilter(int customerID)
        {
            InitializeComponent();

            _customerID = customerID;

            this.Load += ProductFilter_Load;
            this.FormClosing += ProductFilter_FormClosing;
        }

        // =====================================================
        // FORM LOAD
        // =====================================================

        private void ProductFilter_Load(object sender, EventArgs e)
        {
            if (!ValidateCustomerSession())
            {
                return;
            }

            LoadProducts();
        }

        // =====================================================
        // VALIDATE CUSTOMER SESSION
        // =====================================================

        private bool ValidateCustomerSession()
        {
            try
            {
                if (_customerID <= 0)
                {
                    MessageBox.Show(
                        "Invalid customer ID.",
                        "Session Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return false;
                }

                if (!Session.IsUserLoggedIn())
                {
                    MessageBox.Show(
                        "Your session has expired. Please login again.",
                        "Login Required",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return false;
                }

                if (!Session.IsCustomer())
                {
                    MessageBox.Show(
                        "Only customers can access the product section.",
                        "Access Denied",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return false;
                }

                if (Session.CustomerID != _customerID)
                {
                    MessageBox.Show(
                        "Customer session mismatch. Please login again.",
                        "Session Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to validate customer session.\n\n" +
                    ex.Message,
                    "Session Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
        }

        // =====================================================
        // LOAD PRODUCTS BUTTON
        // =====================================================

        private void btn0_Click(object sender, EventArgs e)
        {
            if (!ValidateCustomerSession())
            {
                return;
            }

            LoadProducts();
        }

        // =====================================================
        // ADD TO CART BUTTON
        // =====================================================

        private void btn1_Click(object sender, EventArgs e)
        {
            if (!ValidateCustomerSession())
            {
                return;
            }

            AddSelected();
        }

        // =====================================================
        // LOAD PRODUCTS
        // =====================================================

        private void LoadProducts()
        {
            try
            {
                dbCon.OpenCon();

                string query = @"
                    SELECT
                        p.ProdID AS ProductID,
                        p.ProdName AS ProductName,
                        p.ProdPrice AS Price,
                        p.ProdQty AS AvailableStock,
                        p.CategoryID AS CategoryID,
                        c.CategoryName AS CategoryName,
                        s.SellerName AS SellerName,
                        p.ProdDescription AS Description
                    FROM dbo.tblProduct p

                    INNER JOIN dbo.tblCategory c
                        ON p.CategoryID = c.CategoryID

                    LEFT JOIN dbo.tblSeller s
                        ON p.SellerID = s.SellerID

                    WHERE p.IsActive = 1
                      AND c.IsActive = 1
                      AND p.ProdQty > 0

                    ORDER BY p.ProdID DESC;";

                using (SqlCommand cmd =
                    new SqlCommand(
                        query,
                        dbCon.GetCon()))
                {
                    cmd.CommandTimeout = 15;

                    using (SqlDataAdapter adapter =
                        new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();

                        adapter.Fill(dt);

                        dgvProducts.DataSource = dt;
                    }
                }

                // =================================================
                // GRID SETTINGS
                // =================================================

                if (dgvProducts.Columns.Contains("ProductID"))
                {
                    dgvProducts.Columns["ProductID"].HeaderText =
                        "Product ID";
                }

                if (dgvProducts.Columns.Contains("ProductName"))
                {
                    dgvProducts.Columns["ProductName"].HeaderText =
                        "Product Name";
                }

                if (dgvProducts.Columns.Contains("Price"))
                {
                    dgvProducts.Columns["Price"].HeaderText =
                        "Price";

                    dgvProducts.Columns["Price"]
                        .DefaultCellStyle.Format = "N2";
                }

                if (dgvProducts.Columns.Contains("AvailableStock"))
                {
                    dgvProducts.Columns["AvailableStock"].HeaderText =
                        "Available Stock";
                }

                if (dgvProducts.Columns.Contains("CategoryID"))
                {
                    dgvProducts.Columns["CategoryID"].HeaderText =
                        "Category ID";
                }

                if (dgvProducts.Columns.Contains("CategoryName"))
                {
                    dgvProducts.Columns["CategoryName"].HeaderText =
                        "Category";
                }

                if (dgvProducts.Columns.Contains("SellerName"))
                {
                    dgvProducts.Columns["SellerName"].HeaderText =
                        "Seller";
                }

                if (dgvProducts.Columns.Contains("Description"))
                {
                    dgvProducts.Columns["Description"].HeaderText =
                        "Description";
                }

                dgvProducts.ClearSelection();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Unable to load products from database.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load products.\n\n" +
                    ex.Message,
                    "Product Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                dbCon.CloseCon();
            }
        }

        // =====================================================
        // ADD SELECTED PRODUCT TO CART
        // =====================================================

        private void AddSelected()
        {
            // =================================================
            // CHECK CUSTOMER LOGIN
            // =================================================

            if (!ValidateCustomerSession())
            {
                return;
            }

            // =================================================
            // CHECK PRODUCT SELECTION
            // =================================================

            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select a product first.",
                    "Product",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                DataGridViewRow selectedRow =
                    dgvProducts.SelectedRows[0];

                // =================================================
                // GET PRODUCT ID
                // =================================================

                object productValue =
                    selectedRow.Cells["ProductID"].Value;

                if (productValue == null ||
                    productValue == DBNull.Value)
                {
                    MessageBox.Show(
                        "Product ID not found.",
                        "Product",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                int productId;

                if (!int.TryParse(
                    productValue.ToString(),
                    out productId) ||
                    productId <= 0)
                {
                    MessageBox.Show(
                        "Invalid Product ID.",
                        "Product",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                // =================================================
                // CHECK AVAILABLE STOCK
                // =================================================

                object stockValue =
                    selectedRow.Cells["AvailableStock"].Value;

                int availableStock = 0;

                if (stockValue != null &&
                    stockValue != DBNull.Value)
                {
                    if (!int.TryParse(
                        stockValue.ToString(),
                        out availableStock))
                    {
                        MessageBox.Show(
                            "Unable to determine available stock.",
                            "Product",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        return;
                    }
                }

                if (availableStock <= 0)
                {
                    MessageBox.Show(
                        "This product is currently out of stock.",
                        "Out of Stock",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                // =================================================
                // DEFAULT QUANTITY
                // =================================================

                int quantity = 1;

                // =================================================
                // ADD TO CART
                // =================================================

                dbCon.OpenCon();

                using (SqlCommand cmd =
                    new SqlCommand(
                        "dbo.spAddToCart",
                        dbCon.GetCon()))
                {
                    cmd.CommandType =
                        CommandType.StoredProcedure;

                    cmd.CommandTimeout = 15;

                    // Customer ID
                    cmd.Parameters.Add(
                        "@CustomerID",
                        SqlDbType.Int).Value =
                        _customerID;

                    // Product ID
                    cmd.Parameters.Add(
                        "@ProdID",
                        SqlDbType.Int).Value =
                        productId;

                    // Quantity
                    cmd.Parameters.Add(
                        "@Quantity",
                        SqlDbType.Int).Value =
                        quantity;

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show(
                    "Product added to cart successfully.",
                    "Cart",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Refresh stock after adding
                LoadProducts();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Cart Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to add product to cart.\n\n" +
                    ex.Message,
                    "Cart Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                dbCon.CloseCon();
            }
        }

        // =====================================================
        // FORM CLOSING
        // =====================================================

        private void ProductFilter_FormClosing(
            object sender,
            FormClosingEventArgs e)
        {
            dbCon.CloseCon();
        }
    }
}