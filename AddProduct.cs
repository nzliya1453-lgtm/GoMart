using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GoMartApplication
{
    public partial class AddProduct : Form
    {
        private readonly string connectionString =
        @"Data Source=.\SQLEXPRESS;Initial Catalog=GoMartDB;Integrated Security=True";

    public AddProduct()
        {
            InitializeComponent();
        }

        // ==========================================
        // ADD PRODUCT BUTTON
        // ==========================================

        private void btn0_Click(object sender, EventArgs e)
        {
            AddProductToDatabase();
        }

        // ==========================================
        // ADD PRODUCT
        // ==========================================

        private void AddProductToDatabase()
        {
            try
            {
                string productName = txtProdName.Text.Trim();
                string priceText = txtProdPrice.Text.Trim();
                string quantityText = txtProdQty.Text.Trim();
                string categoryName = txtCategoryName.Text.Trim();

                // ==========================================
                // VALIDATE PRODUCT NAME
                // ==========================================

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

                // ==========================================
                // VALIDATE PRICE
                // ==========================================

                decimal productPrice;

                if (!decimal.TryParse(priceText, out productPrice) ||
                    productPrice < 0)
                {
                    MessageBox.Show(
                        "Please enter a valid product price.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtProdPrice.Focus();
                    return;
                }

                // ==========================================
                // VALIDATE QUANTITY
                // ==========================================

                int productQuantity;

                if (!int.TryParse(quantityText, out productQuantity) ||
                    productQuantity < 0)
                {
                    MessageBox.Show(
                        "Please enter a valid product quantity.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtProdQty.Focus();
                    return;
                }

                // ==========================================
                // VALIDATE CATEGORY
                // ==========================================

                if (string.IsNullOrWhiteSpace(categoryName))
                {
                    MessageBox.Show(
                        "Please enter a product category.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtCategoryName.Focus();
                    return;
                }

                // ==========================================
                // DATABASE CONNECTION
                // ==========================================

                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    con.Open();

                    // ==========================================
                    // FIND CATEGORY ID
                    // ==========================================

                    string categoryQuery = @"
                    SELECT CategoryID
                    FROM dbo.tblCategory
                    WHERE Category = @Category
                    AND IsActive = 1";

                    int categoryID;

                    using (SqlCommand categoryCmd =
                        new SqlCommand(categoryQuery, con))
                    {
                        categoryCmd.Parameters.Add(
                            "@Category",
                            SqlDbType.NVarChar,
                            100).Value = categoryName;

                        object result =
                            categoryCmd.ExecuteScalar();

                        if (result == null ||
                            result == DBNull.Value)
                        {
                            MessageBox.Show(
                                "Category does not exist."
                                + Environment.NewLine
                                + Environment.NewLine
                                + "Please create the category first.",
                                "Category Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            txtCategoryName.Focus();
                            return;
                        }

                        categoryID =
                            Convert.ToInt32(result);
                    }

                    // ==========================================
                    // CHECK DUPLICATE PRODUCT
                    // ==========================================

                    string duplicateQuery = @"
                    SELECT COUNT(*)
                    FROM dbo.tblProduct
                    WHERE ProdName = @ProdName
                    AND ProdCatID = @ProdCatID
                    AND IsActive = 1";

                    using (SqlCommand duplicateCmd =
                        new SqlCommand(
                            duplicateQuery,
                            con))
                    {
                        duplicateCmd.Parameters.Add(
                            "@ProdName",
                            SqlDbType.NVarChar,
                            100).Value = productName;

                        duplicateCmd.Parameters.Add(
                            "@ProdCatID",
                            SqlDbType.Int).Value =
                                categoryID;

                        int count =
                            Convert.ToInt32(
                                duplicateCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show(
                                "This product already exists in this category.",
                                "Duplicate Product",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            txtProdName.Focus();
                            return;
                        }
                    }

                    // ==========================================
                    // INSERT PRODUCT
                    // ==========================================

                    using (SqlCommand cmd =
                        new SqlCommand(
                            "dbo.spInsertProduct",
                            con))
                    {
                        cmd.CommandType =
                            CommandType.StoredProcedure;

                        // Product Name
                        cmd.Parameters.Add(
                            "@ProdName",
                            SqlDbType.NVarChar,
                            100).Value =
                                productName;

                        // Category ID
                        cmd.Parameters.Add(
                            "@ProdCatID",
                            SqlDbType.Int).Value =
                                categoryID;

                        // Product Price
                        SqlParameter priceParameter =
                            cmd.Parameters.Add(
                                "@ProdPrice",
                                SqlDbType.Decimal);

                        priceParameter.Precision = 18;
                        priceParameter.Scale = 2;
                        priceParameter.Value =
                            productPrice;

                        // Product Quantity
                        cmd.Parameters.Add(
                            "@ProdQty",
                            SqlDbType.Int).Value =
                                productQuantity;

                        cmd.ExecuteNonQuery();
                    }
                }

                // ==========================================
                // SUCCESS
                // ==========================================

                MessageBox.Show(
                    "Product added successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ClearFields();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Database error:"
                    + Environment.NewLine
                    + Environment.NewLine
                    + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error:"
                    + Environment.NewLine
                    + Environment.NewLine
                    + ex.Message,
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
            txtProdName.Clear();
            txtProdPrice.Clear();
            txtProdQty.Clear();
            txtCategoryName.Clear();
            txtDescription.Clear();

            txtProdName.Focus();
        }

        // ==========================================
        // CLEAR BUTTON
        // ==========================================

        private void btn1_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }


}
