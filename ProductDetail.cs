using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GoMartApplication
{
    public partial class ProductDetail : Form
    {
        // =========================================================
        // DATABASE CONNECTION
        // =========================================================

        private readonly string connectionString =
            @"Data Source=.\SQLEXPRESS;" +
            "Initial Catalog=GoMartDB;" +
            "Integrated Security=True;" +
            "TrustServerCertificate=True";


        // =========================================================
        // SELECTED PRODUCT
        // =========================================================

        private int selectedProductID = 0;


        // =========================================================
        // CONSTRUCTOR
        // =========================================================

        public ProductDetail()
        {
            InitializeComponent();

            // Do NOT add Load event here if Designer.cs already
            // contains:
            // this.Load += ProductDetail_Load;
        }


        // =========================================================
        // FORM LOAD
        // =========================================================

        private void ProductDetail_Load(object sender, EventArgs e)
        {
            try
            {
                ClearFields();
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load Product Detail form.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =========================================================
        // LOAD PRODUCTS
        // =========================================================

        private void LoadProducts()
        {
            try
            {
                using (SqlConnection con =
                       new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT
                            p.ProdID,
                            p.ProdName,
                            c.CategoryName,
                            s.SellerName,
                            p.ProdPrice,
                            p.ProdQty,
                            p.ProdDescription,
                            p.IsActive
                        FROM dbo.tblProduct p
                        INNER JOIN dbo.tblCategory c
                            ON p.CategoryID = c.CategoryID
                        INNER JOIN dbo.tblSeller s
                            ON p.SellerID = s.SellerID
                        WHERE p.IsActive = 1
                        ORDER BY p.ProdID DESC;";

                    using (SqlDataAdapter adapter =
                           new SqlDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();

                        adapter.Fill(dt);

                        dataGridViewProduct.DataSource = dt;
                    }
                }

                ConfigureProductGrid();

                dataGridViewProduct.ClearSelection();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Database error while loading products.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error while loading products.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =========================================================
        // CONFIGURE PRODUCT GRID
        // =========================================================

        private void ConfigureProductGrid()
        {
            if (dataGridViewProduct.Columns.Contains("ProdID"))
            {
                dataGridViewProduct.Columns["ProdID"].HeaderText =
                    "Product ID";
            }

            if (dataGridViewProduct.Columns.Contains("ProdName"))
            {
                dataGridViewProduct.Columns["ProdName"].HeaderText =
                    "Product Name";
            }

            if (dataGridViewProduct.Columns.Contains("CategoryName"))
            {
                dataGridViewProduct.Columns["CategoryName"].HeaderText =
                    "Category";
            }

            if (dataGridViewProduct.Columns.Contains("SellerName"))
            {
                dataGridViewProduct.Columns["SellerName"].HeaderText =
                    "Seller";
            }

            if (dataGridViewProduct.Columns.Contains("ProdPrice"))
            {
                dataGridViewProduct.Columns["ProdPrice"].HeaderText =
                    "Price";

                dataGridViewProduct.Columns["ProdPrice"]
                    .DefaultCellStyle.Format = "N2";
            }

            if (dataGridViewProduct.Columns.Contains("ProdQty"))
            {
                dataGridViewProduct.Columns["ProdQty"].HeaderText =
                    "Quantity";
            }

            if (dataGridViewProduct.Columns.Contains("ProdDescription"))
            {
                dataGridViewProduct.Columns["ProdDescription"]
                    .HeaderText = "Description";
            }

            if (dataGridViewProduct.Columns.Contains("IsActive"))
            {
                dataGridViewProduct.Columns["IsActive"].HeaderText =
                    "Active";
            }
        }


        // =========================================================
        // GET CATEGORY ID
        // =========================================================

        private int GetCategoryID(
            SqlConnection con,
            string categoryName)
        {
            string query = @"
                SELECT CategoryID
                FROM dbo.tblCategory
                WHERE CategoryName = @CategoryName
                  AND IsActive = 1;";

            using (SqlCommand cmd =
                   new SqlCommand(query, con))
            {
                cmd.Parameters.Add(
                    "@CategoryName",
                    SqlDbType.NVarChar,
                    100).Value = categoryName;

                object result = cmd.ExecuteScalar();

                if (result == null ||
                    result == DBNull.Value)
                {
                    return 0;
                }

                return Convert.ToInt32(result);
            }
        }


        // =========================================================
        // GET SELLER ID
        // =========================================================

        private int GetSellerID(
            SqlConnection con,
            string sellerName)
        {
            string query = @"
                SELECT SellerID
                FROM dbo.tblSeller
                WHERE SellerName = @SellerName
                  AND IsApproved = 1
                  AND IsActive = 1;";

            using (SqlCommand cmd =
                   new SqlCommand(query, con))
            {
                cmd.Parameters.Add(
                    "@SellerName",
                    SqlDbType.NVarChar,
                    100).Value = sellerName;

                object result = cmd.ExecuteScalar();

                if (result == null ||
                    result == DBNull.Value)
                {
                    return 0;
                }

                return Convert.ToInt32(result);
            }
        }


        // =========================================================
        // ADD PRODUCT BUTTON
        // =========================================================

        private void btnAdd_Click(
            object sender,
            EventArgs e)
        {
            AddProduct();
        }


        // =========================================================
        // ADD PRODUCT
        // =========================================================

        private void AddProduct()
        {
            try
            {
                string productName =
                    txtProdName.Text.Trim();

                string categoryName =
                    txtCategoryName.Text.Trim();

                string description =
                    txtDescription.Text.Trim();

                decimal price;
                int quantity;


                // -------------------------------------------------
                // PRODUCT NAME
                // -------------------------------------------------

                if (string.IsNullOrWhiteSpace(productName))
                {
                    MessageBox.Show(
                        "Please enter a product name.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtProdName.Focus();
                    return;
                }


                // -------------------------------------------------
                // CATEGORY
                // -------------------------------------------------

                if (string.IsNullOrWhiteSpace(categoryName))
                {
                    MessageBox.Show(
                        "Please enter a category.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtCategoryName.Focus();
                    return;
                }


                // -------------------------------------------------
                // PRICE
                // -------------------------------------------------

                if (!decimal.TryParse(
                        txtProdPrice.Text.Trim(),
                        out price) ||
                    price < 0)
                {
                    MessageBox.Show(
                        "Please enter a valid price.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtProdPrice.Focus();
                    return;
                }


                // -------------------------------------------------
                // QUANTITY
                // -------------------------------------------------

                if (!int.TryParse(
                        txtProdQty.Text.Trim(),
                        out quantity) ||
                    quantity < 0)
                {
                    MessageBox.Show(
                        "Please enter a valid quantity.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtProdQty.Focus();
                    return;
                }


                // -------------------------------------------------
                // SELLER SESSION
                // -------------------------------------------------

                if (!Session.IsUserLoggedIn())
                {
                    MessageBox.Show(
                        "Your session has expired.\n\n" +
                        "Please login again.",
                        "Session Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }


                if (!Session.IsSeller())
                {
                    MessageBox.Show(
                        "Only a logged-in Seller can add a product.\n\n" +
                        "An Admin must use a seller-specific product form " +
                        "or assign the product to a seller.",
                        "Seller Required",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }


                int sellerID = Session.SellerID;

                if (sellerID <= 0)
                {
                    MessageBox.Show(
                        "Invalid seller session.\n\n" +
                        "Please login again.",
                        "Seller Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }


                // -------------------------------------------------
                // DATABASE
                // -------------------------------------------------

                using (SqlConnection con =
                       new SqlConnection(connectionString))
                {
                    con.Open();


                    // =================================================
                    // CATEGORY ID
                    // =================================================

                    int categoryID =
                        GetCategoryID(
                            con,
                            categoryName);

                    if (categoryID <= 0)
                    {
                        MessageBox.Show(
                            "Category does not exist.\n\n" +
                            "Please create the category first.",
                            "Category Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        txtCategoryName.Focus();
                        return;
                    }


                    // =================================================
                    // DUPLICATE PRODUCT CHECK
                    // =================================================

                    string duplicateQuery = @"
                        SELECT COUNT(*)
                        FROM dbo.tblProduct
                        WHERE ProdName = @ProdName
                          AND CategoryID = @CategoryID
                          AND SellerID = @SellerID
                          AND IsActive = 1;";

                    using (SqlCommand duplicateCmd =
                           new SqlCommand(
                               duplicateQuery,
                               con))
                    {
                        duplicateCmd.Parameters.Add(
                            "@ProdName",
                            SqlDbType.NVarChar,
                            150).Value =
                            productName;

                        duplicateCmd.Parameters.Add(
                            "@CategoryID",
                            SqlDbType.Int).Value =
                            categoryID;

                        duplicateCmd.Parameters.Add(
                            "@SellerID",
                            SqlDbType.Int).Value =
                            sellerID;

                        int count =
                            Convert.ToInt32(
                                duplicateCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show(
                                "This product already exists " +
                                "for this seller in this category.",
                                "Duplicate Product",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            txtProdName.Focus();
                            return;
                        }
                    }


                    // =================================================
                    // INSERT PRODUCT
                    // =================================================

                    using (SqlCommand cmd =
                           new SqlCommand(
                               "dbo.spInsertProduct",
                               con))
                    {
                        cmd.CommandType =
                            CommandType.StoredProcedure;


                        cmd.Parameters.Add(
                            "@ProdName",
                            SqlDbType.NVarChar,
                            150).Value =
                            productName;


                        cmd.Parameters.Add(
                            "@CategoryID",
                            SqlDbType.Int).Value =
                            categoryID;


                        cmd.Parameters.Add(
                            "@SellerID",
                            SqlDbType.Int).Value =
                            sellerID;


                        SqlParameter priceParameter =
                            cmd.Parameters.Add(
                                "@ProdPrice",
                                SqlDbType.Decimal);

                        priceParameter.Precision = 18;
                        priceParameter.Scale = 2;
                        priceParameter.Value = price;


                        cmd.Parameters.Add(
                            "@ProdQty",
                            SqlDbType.Int).Value =
                            quantity;


                        cmd.Parameters.Add(
                            "@ProdDescription",
                            SqlDbType.NVarChar,
                            500).Value =
                            string.IsNullOrWhiteSpace(description)
                            ? (object)DBNull.Value
                            : description;


                        cmd.ExecuteNonQuery();
                    }
                }


                MessageBox.Show(
                    "Product added successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ClearFields();
                LoadProducts();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Database error while adding product.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error while adding product.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =========================================================
        // UPDATE BUTTON
        // =========================================================

        private void btnUpdate_Click(
            object sender,
            EventArgs e)
        {
            UpdateProduct();
        }


        // =========================================================
        // UPDATE PRODUCT
        // =========================================================

        private void UpdateProduct()
        {
            try
            {
                if (selectedProductID <= 0)
                {
                    MessageBox.Show(
                        "Please select a product first.",
                        "No Product Selected",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }


                string productName =
                    txtProdName.Text.Trim();

                string categoryName =
                    txtCategoryName.Text.Trim();

                string description =
                    txtDescription.Text.Trim();

                decimal price;
                int quantity;


                // -------------------------------------------------
                // VALIDATE NAME
                // -------------------------------------------------

                if (string.IsNullOrWhiteSpace(productName))
                {
                    MessageBox.Show(
                        "Please enter a product name.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtProdName.Focus();
                    return;
                }


                // -------------------------------------------------
                // VALIDATE CATEGORY
                // -------------------------------------------------

                if (string.IsNullOrWhiteSpace(categoryName))
                {
                    MessageBox.Show(
                        "Please enter a category.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtCategoryName.Focus();
                    return;
                }


                // -------------------------------------------------
                // VALIDATE PRICE
                // -------------------------------------------------

                if (!decimal.TryParse(
                        txtProdPrice.Text.Trim(),
                        out price) ||
                    price < 0)
                {
                    MessageBox.Show(
                        "Please enter a valid price.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtProdPrice.Focus();
                    return;
                }


                // -------------------------------------------------
                // VALIDATE QUANTITY
                // -------------------------------------------------

                if (!int.TryParse(
                        txtProdQty.Text.Trim(),
                        out quantity) ||
                    quantity < 0)
                {
                    MessageBox.Show(
                        "Please enter a valid quantity.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtProdQty.Focus();
                    return;
                }


                using (SqlConnection con =
                       new SqlConnection(connectionString))
                {
                    con.Open();


                    // =================================================
                    // CATEGORY
                    // =================================================

                    int categoryID =
                        GetCategoryID(
                            con,
                            categoryName);

                    if (categoryID <= 0)
                    {
                        MessageBox.Show(
                            "Category does not exist.",
                            "Category Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        txtCategoryName.Focus();
                        return;
                    }


                    // =================================================
                    // DUPLICATE CHECK
                    // =================================================

                    string duplicateQuery = @"
                        SELECT COUNT(*)
                        FROM dbo.tblProduct
                        WHERE ProdName = @ProdName
                          AND CategoryID = @CategoryID
                          AND ProdID <> @ProdID
                          AND IsActive = 1;";

                    using (SqlCommand duplicateCmd =
                           new SqlCommand(
                               duplicateQuery,
                               con))
                    {
                        duplicateCmd.Parameters.Add(
                            "@ProdName",
                            SqlDbType.NVarChar,
                            150).Value =
                            productName;

                        duplicateCmd.Parameters.Add(
                            "@CategoryID",
                            SqlDbType.Int).Value =
                            categoryID;

                        duplicateCmd.Parameters.Add(
                            "@ProdID",
                            SqlDbType.Int).Value =
                            selectedProductID;

                        int count =
                            Convert.ToInt32(
                                duplicateCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show(
                                "Another product with this name " +
                                "already exists in this category.",
                                "Duplicate Product",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            txtProdName.Focus();
                            return;
                        }
                    }


                    // =================================================
                    // UPDATE PRODUCT
                    // =================================================

                    string updateQuery = @"
                        UPDATE dbo.tblProduct
                        SET
                            ProdName = @ProdName,
                            CategoryID = @CategoryID,
                            ProdPrice = @ProdPrice,
                            ProdQty = @ProdQty,
                            ProdDescription = @ProdDescription
                        WHERE ProdID = @ProdID
                          AND IsActive = 1;";


                    using (SqlCommand cmd =
                           new SqlCommand(
                               updateQuery,
                               con))
                    {
                        cmd.Parameters.Add(
                            "@ProdID",
                            SqlDbType.Int).Value =
                            selectedProductID;

                        cmd.Parameters.Add(
                            "@ProdName",
                            SqlDbType.NVarChar,
                            150).Value =
                            productName;

                        cmd.Parameters.Add(
                            "@CategoryID",
                            SqlDbType.Int).Value =
                            categoryID;


                        SqlParameter priceParameter =
                            cmd.Parameters.Add(
                                "@ProdPrice",
                                SqlDbType.Decimal);

                        priceParameter.Precision = 18;
                        priceParameter.Scale = 2;
                        priceParameter.Value = price;


                        cmd.Parameters.Add(
                            "@ProdQty",
                            SqlDbType.Int).Value =
                            quantity;


                        cmd.Parameters.Add(
                            "@ProdDescription",
                            SqlDbType.NVarChar,
                            500).Value =
                            string.IsNullOrWhiteSpace(description)
                            ? (object)DBNull.Value
                            : description;


                        int rowsAffected =
                            cmd.ExecuteNonQuery();


                        if (rowsAffected == 0)
                        {
                            MessageBox.Show(
                                "The product could not be updated.",
                                "Update Failed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return;
                        }
                    }
                }


                MessageBox.Show(
                    "Product updated successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ClearFields();
                LoadProducts();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Database error while updating product.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error while updating product.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =========================================================
        // DELETE BUTTON
        // =========================================================

        private void btnDelete_Click(
            object sender,
            EventArgs e)
        {
            DeleteProduct();
        }


        // =========================================================
        // DELETE PRODUCT
        // =========================================================

        private void DeleteProduct()
        {
            try
            {
                if (selectedProductID <= 0)
                {
                    MessageBox.Show(
                        "Please select a product first.",
                        "No Product Selected",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }


                string productName =
                    txtProdName.Text.Trim();


                DialogResult result =
                    MessageBox.Show(
                        "Are you sure you want to delete\n\n" +
                        productName +
                        "?",
                        "Confirm Delete",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);


                if (result != DialogResult.Yes)
                {
                    return;
                }


                using (SqlConnection con =
                       new SqlConnection(connectionString))
                {
                    con.Open();


                    string query = @"
                        UPDATE dbo.tblProduct
                        SET IsActive = 0
                        WHERE ProdID = @ProdID
                          AND IsActive = 1;";


                    using (SqlCommand cmd =
                           new SqlCommand(
                               query,
                               con))
                    {
                        cmd.Parameters.Add(
                            "@ProdID",
                            SqlDbType.Int).Value =
                            selectedProductID;


                        int rowsAffected =
                            cmd.ExecuteNonQuery();


                        if (rowsAffected == 0)
                        {
                            MessageBox.Show(
                                "Product could not be deleted " +
                                "or it has already been deleted.",
                                "Delete Failed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return;
                        }
                    }
                }


                MessageBox.Show(
                    "Product deleted successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ClearFields();
                LoadProducts();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Database error while deleting product.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error while deleting product.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =========================================================
        // REFRESH BUTTON
        // =========================================================

        private void btnRefresh_Click(
            object sender,
            EventArgs e)
        {
            ClearFields();
            LoadProducts();
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
        // CLEAR FIELDS
        // =========================================================

        private void ClearFields()
        {
            selectedProductID = 0;

            txtProdName.Clear();
            txtCategoryName.Clear();
            txtProdPrice.Clear();
            txtProdQty.Clear();
            txtDescription.Clear();

            if (dataGridViewProduct != null &&
                dataGridViewProduct.Rows.Count > 0)
            {
                dataGridViewProduct.ClearSelection();
            }

            txtProdName.Focus();
        }


        // =========================================================
        // PRODUCT GRID CELL CLICK
        // =========================================================

        private void dataGridViewProduct_CellClick(
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
                    dataGridViewProduct.Rows[e.RowIndex];


                // =================================================
                // PRODUCT ID
                // =================================================

                if (dataGridViewProduct.Columns.Contains("ProdID"))
                {
                    object value =
                        row.Cells["ProdID"].Value;

                    if (value != null &&
                        value != DBNull.Value)
                    {
                        selectedProductID =
                            Convert.ToInt32(value);
                    }
                    else
                    {
                        selectedProductID = 0;
                    }
                }


                // =================================================
                // PRODUCT NAME
                // =================================================

                if (dataGridViewProduct.Columns.Contains("ProdName"))
                {
                    object value =
                        row.Cells["ProdName"].Value;

                    txtProdName.Text =
                        value == null ||
                        value == DBNull.Value
                        ? ""
                        : value.ToString();
                }


                // =================================================
                // CATEGORY
                // =================================================

                if (dataGridViewProduct.Columns.Contains("CategoryName"))
                {
                    object value =
                        row.Cells["CategoryName"].Value;

                    txtCategoryName.Text =
                        value == null ||
                        value == DBNull.Value
                        ? ""
                        : value.ToString();
                }


                // =================================================
                // PRICE
                // =================================================

                if (dataGridViewProduct.Columns.Contains("ProdPrice"))
                {
                    object value =
                        row.Cells["ProdPrice"].Value;

                    if (value != null &&
                        value != DBNull.Value)
                    {
                        decimal price =
                            Convert.ToDecimal(value);

                        txtProdPrice.Text =
                            price.ToString("0.00");
                    }
                    else
                    {
                        txtProdPrice.Clear();
                    }
                }


                // =================================================
                // QUANTITY
                // =================================================

                if (dataGridViewProduct.Columns.Contains("ProdQty"))
                {
                    object value =
                        row.Cells["ProdQty"].Value;

                    txtProdQty.Text =
                        value == null ||
                        value == DBNull.Value
                        ? ""
                        : value.ToString();
                }


                // =================================================
                // DESCRIPTION
                // =================================================

                if (dataGridViewProduct.Columns.Contains("ProdDescription"))
                {
                    object value =
                        row.Cells["ProdDescription"].Value;

                    txtDescription.Text =
                        value == null ||
                        value == DBNull.Value
                        ? ""
                        : value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to select product.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}