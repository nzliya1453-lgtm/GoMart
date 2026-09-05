using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GoMartApplication
{
    public partial class Cart : Form
    {
        // =====================================================
        // DATABASE CONNECTION
        // =====================================================

        private readonly string connectionString =
            @"Data Source=.\SQLEXPRESS;" +
            "Initial Catalog=GoMartDB;" +
            "Integrated Security=True;" +
            "TrustServerCertificate=True";


        // =====================================================
        // LOGGED-IN CUSTOMER ID
        // =====================================================

        private int customerID;


        // =====================================================
        // DEFAULT CONSTRUCTOR
        // =====================================================
        // Used for WinForms Designer compatibility.

        public Cart()
        {
            InitializeComponent();

            customerID = 0;
        }


        // =====================================================
        // CONSTRUCTOR WITH CUSTOMER ID
        // =====================================================

        public Cart(int loggedInCustomerID)
        {
            InitializeComponent();

            customerID = loggedInCustomerID;
        }


        // =====================================================
        // FORM LOAD
        // =====================================================

        private void Cart_Load(object sender, EventArgs e)
        {
            if (!ValidateCustomerSession())
            {
                return;
            }

            LoadCart();
        }


        // =====================================================
        // VALIDATE CUSTOMER SESSION
        // =====================================================

        private bool ValidateCustomerSession()
        {
            try
            {
                // -------------------------------------------------
                // CUSTOMER ID
                // -------------------------------------------------

                if (customerID <= 0)
                {
                    ShowSessionError(
                        "Invalid customer ID.\n\n" +
                        "Please login as a customer first.");

                    return false;
                }


                // -------------------------------------------------
                // LOGIN SESSION
                // -------------------------------------------------

                if (!Session.IsUserLoggedIn())
                {
                    ShowSessionError(
                        "Your session has expired.\n\n" +
                        "Please login again.");

                    return false;
                }


                // -------------------------------------------------
                // CUSTOMER ROLE
                // -------------------------------------------------

                if (!Session.IsCustomer())
                {
                    ShowSessionError(
                        "Only customers can access the shopping cart.");

                    return false;
                }


                // -------------------------------------------------
                // CUSTOMER ID MATCH
                // -------------------------------------------------

                if (Session.CustomerID != customerID)
                {
                    ShowSessionError(
                        "Customer session mismatch.\n\n" +
                        "Please login again.");

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
        // SESSION ERROR
        // =====================================================

        private void ShowSessionError(string message)
        {
            MessageBox.Show(
                message,
                "Session Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            Session.Logout();

            Close();
        }


        // =====================================================
        // REFRESH CART
        // =====================================================

        private void btn0_Click(object sender, EventArgs e)
        {
            if (!ValidateCustomerSession())
            {
                return;
            }

            LoadCart();
        }


        // =====================================================
        // CHECKOUT
        // =====================================================

        private void btn1_Click(object sender, EventArgs e)
        {
            if (!ValidateCustomerSession())
            {
                return;
            }

            Checkout();
        }


        // =====================================================
        // REMOVE SELECTED ITEM
        // =====================================================

        private void btn2_Click(object sender, EventArgs e)
        {
            if (!ValidateCustomerSession())
            {
                return;
            }

            RemoveSelected();
        }


        // =====================================================
        // LOAD CART
        // =====================================================

        private void LoadCart()
        {
            if (customerID <= 0)
            {
                return;
            }

            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT
                            c.CartID,
                            c.CustomerID,
                            c.ProdID,
                            p.ProdName AS ProductName,
                            p.ProdPrice AS UnitPrice,
                            p.ProdQty AS AvailableStock,
                            c.Quantity,
                            CONVERT(
                                DECIMAL(18,2),
                                p.ProdPrice * c.Quantity
                            ) AS Amount,
                            c.AddedDate
                        FROM dbo.tblCart c
                        INNER JOIN dbo.tblProduct p
                            ON c.ProdID = p.ProdID
                        WHERE c.CustomerID = @CustomerID
                          AND p.IsActive = 1
                        ORDER BY c.AddedDate DESC;";

                    using (SqlDataAdapter adapter =
                        new SqlDataAdapter(query, con))
                    {
                        adapter.SelectCommand.Parameters.Add(
                            "@CustomerID",
                            SqlDbType.Int).Value = customerID;

                        DataTable dt = new DataTable();

                        adapter.Fill(dt);

                        dataGridViewCart.DataSource = dt;
                    }
                }

                ConfigureCartGrid();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Error loading cart from database.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading cart.\n\n" +
                    ex.Message,
                    "Cart Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =====================================================
        // CONFIGURE CART GRID
        // =====================================================

        private void ConfigureCartGrid()
        {
            if (dataGridViewCart == null)
            {
                return;
            }


            // -------------------------------------------------
            // GENERAL SETTINGS
            // -------------------------------------------------

            dataGridViewCart.AllowUserToAddRows = false;
            dataGridViewCart.AllowUserToDeleteRows = false;
            dataGridViewCart.AllowUserToResizeRows = false;

            dataGridViewCart.ReadOnly = true;
            dataGridViewCart.MultiSelect = false;

            dataGridViewCart.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dataGridViewCart.RowHeadersVisible = false;

            dataGridViewCart.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;


            // -------------------------------------------------
            // HIDE INTERNAL COLUMNS
            // -------------------------------------------------

            if (dataGridViewCart.Columns.Contains("CartID"))
            {
                dataGridViewCart.Columns["CartID"].Visible = false;
            }

            if (dataGridViewCart.Columns.Contains("CustomerID"))
            {
                dataGridViewCart.Columns["CustomerID"].Visible = false;
            }

            if (dataGridViewCart.Columns.Contains("ProdID"))
            {
                dataGridViewCart.Columns["ProdID"].Visible = false;
            }


            // -------------------------------------------------
            // PRODUCT NAME
            // -------------------------------------------------

            if (dataGridViewCart.Columns.Contains("ProductName"))
            {
                dataGridViewCart.Columns["ProductName"]
                    .HeaderText = "Product";
            }


            // -------------------------------------------------
            // UNIT PRICE
            // -------------------------------------------------

            if (dataGridViewCart.Columns.Contains("UnitPrice"))
            {
                dataGridViewCart.Columns["UnitPrice"]
                    .HeaderText = "Unit Price";

                dataGridViewCart.Columns["UnitPrice"]
                    .DefaultCellStyle.Format = "N2";
            }


            // -------------------------------------------------
            // AVAILABLE STOCK
            // -------------------------------------------------

            if (dataGridViewCart.Columns.Contains("AvailableStock"))
            {
                dataGridViewCart.Columns["AvailableStock"]
                    .HeaderText = "Available Stock";
            }


            // -------------------------------------------------
            // QUANTITY
            // -------------------------------------------------

            if (dataGridViewCart.Columns.Contains("Quantity"))
            {
                dataGridViewCart.Columns["Quantity"]
                    .HeaderText = "Quantity";
            }


            // -------------------------------------------------
            // AMOUNT
            // -------------------------------------------------

            if (dataGridViewCart.Columns.Contains("Amount"))
            {
                dataGridViewCart.Columns["Amount"]
                    .HeaderText = "Amount";

                dataGridViewCart.Columns["Amount"]
                    .DefaultCellStyle.Format = "N2";
            }


            // -------------------------------------------------
            // ADDED DATE
            // -------------------------------------------------

            if (dataGridViewCart.Columns.Contains("AddedDate"))
            {
                dataGridViewCart.Columns["AddedDate"]
                    .HeaderText = "Added At";

                dataGridViewCart.Columns["AddedDate"]
                    .DefaultCellStyle.Format =
                    "dd/MM/yyyy HH:mm";
            }

            dataGridViewCart.ClearSelection();
        }


        // =====================================================
        // CHECKOUT
        // =====================================================

        private void Checkout()
        {
            if (!ValidateCustomerSession())
            {
                return;
            }

            try
            {
                // -------------------------------------------------
                // CHECK CART
                // -------------------------------------------------

                if (dataGridViewCart.DataSource == null ||
                    dataGridViewCart.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "Your cart is empty.",
                        "Empty Cart",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }


                // -------------------------------------------------
                // CONFIRM CHECKOUT
                // -------------------------------------------------

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to checkout?",
                    "Confirm Checkout",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                {
                    return;
                }


                // -------------------------------------------------
                // OPEN CONNECTION
                // -------------------------------------------------

                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    con.Open();


                    // -------------------------------------------------
                    // EXECUTE CHECKOUT STORED PROCEDURE
                    // -------------------------------------------------
                    //
                    // IMPORTANT:
                    // Your database procedure is:
                    //
                    // spCheckout
                    //     @CustomerID
                    //     @PaymentMethod
                    //
                    // It does NOT have:
                    //     @ShippingAddress
                    //     @Phone
                    //
                    // Therefore those parameters are removed.
                    // -------------------------------------------------

                    using (SqlCommand cmd =
                        new SqlCommand(
                            "dbo.spCheckout",
                            con))
                    {
                        cmd.CommandType =
                            CommandType.StoredProcedure;

                        cmd.CommandTimeout = 30;


                        // -------------------------------------------------
                        // CUSTOMER ID
                        // -------------------------------------------------

                        cmd.Parameters.Add(
                            "@CustomerID",
                            SqlDbType.Int).Value =
                            customerID;


                        // -------------------------------------------------
                        // PAYMENT METHOD
                        // -------------------------------------------------

                        cmd.Parameters.Add(
                            "@PaymentMethod",
                            SqlDbType.NVarChar,
                            50).Value =
                            "Cash";


                        // -------------------------------------------------
                        // EXECUTE
                        // -------------------------------------------------

                        using (SqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                MessageBox.Show(
                                    "Checkout completed, but no " +
                                    "order information was returned.",
                                    "Checkout",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                                return;
                            }


                            int orderID = 0;

                            decimal totalAmount = 0;

                            string message =
                                "Order placed successfully.";


                            // -------------------------------------------------
                            // ORDER ID
                            // -------------------------------------------------

                            if (HasColumn(reader, "OrderID") &&
                                reader["OrderID"] != DBNull.Value)
                            {
                                orderID =
                                    Convert.ToInt32(
                                        reader["OrderID"]);
                            }


                            // -------------------------------------------------
                            // TOTAL AMOUNT
                            // -------------------------------------------------

                            if (HasColumn(reader, "TotalAmount") &&
                                reader["TotalAmount"] != DBNull.Value)
                            {
                                totalAmount =
                                    Convert.ToDecimal(
                                        reader["TotalAmount"]);
                            }


                            // -------------------------------------------------
                            // MESSAGE
                            // -------------------------------------------------

                            if (HasColumn(reader, "Message") &&
                                reader["Message"] != DBNull.Value)
                            {
                                message =
                                    reader["Message"].ToString();
                            }


                            // -------------------------------------------------
                            // SUCCESS MESSAGE
                            // -------------------------------------------------

                            MessageBox.Show(
                                message +
                                "\n\nOrder ID: #" +
                                orderID +
                                "\n\nTotal Amount: " +
                                totalAmount.ToString("N2"),
                                "Checkout Successful",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                    }
                }


                // -------------------------------------------------
                // REFRESH CART
                // -------------------------------------------------

                LoadCart();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Checkout failed.\n\n" +
                    ex.Message,
                    "Checkout Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Checkout failed.\n\n" +
                    ex.Message,
                    "Checkout Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =====================================================
        // CHECK DATAREADER COLUMN
        // =====================================================

        private bool HasColumn(
            SqlDataReader reader,
            string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (string.Equals(
                    reader.GetName(i),
                    columnName,
                    StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }


        // =====================================================
        // REMOVE SELECTED ITEM
        // =====================================================

        private void RemoveSelected()
        {
            if (!ValidateCustomerSession())
            {
                return;
            }

            try
            {
                // -------------------------------------------------
                // CHECK SELECTED ROW
                // -------------------------------------------------

                if (dataGridViewCart.CurrentRow == null)
                {
                    MessageBox.Show(
                        "Please select an item from the cart.",
                        "No Item Selected",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }


                // -------------------------------------------------
                // CHECK CART ID COLUMN
                // -------------------------------------------------

                if (!dataGridViewCart.Columns.Contains("CartID"))
                {
                    MessageBox.Show(
                        "CartID column was not found.",
                        "Grid Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }


                // -------------------------------------------------
                // GET CART ID
                // -------------------------------------------------

                object cartIDValue =
                    dataGridViewCart.CurrentRow
                        .Cells["CartID"]
                        .Value;

                if (cartIDValue == null ||
                    cartIDValue == DBNull.Value)
                {
                    MessageBox.Show(
                        "Invalid cart item.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                int cartID;

                if (!int.TryParse(
                    cartIDValue.ToString(),
                    out cartID) ||
                    cartID <= 0)
                {
                    MessageBox.Show(
                        "Invalid Cart ID.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }


                // -------------------------------------------------
                // GET PRODUCT NAME
                // -------------------------------------------------

                string productName = "";

                if (dataGridViewCart.Columns.Contains(
                    "ProductName"))
                {
                    object productValue =
                        dataGridViewCart.CurrentRow
                            .Cells["ProductName"]
                            .Value;

                    if (productValue != null &&
                        productValue != DBNull.Value)
                    {
                        productName =
                            productValue.ToString();
                    }
                }


                // -------------------------------------------------
                // CONFIRM REMOVE
                // -------------------------------------------------

                string confirmMessage =
                    "Remove this item from your cart?";

                if (!string.IsNullOrWhiteSpace(productName))
                {
                    confirmMessage +=
                        "\n\nProduct: " + productName;
                }

                DialogResult result =
                    MessageBox.Show(
                        confirmMessage,
                        "Confirm Remove",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                {
                    return;
                }


                // -------------------------------------------------
                // DELETE CART ITEM
                // -------------------------------------------------

                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    con.Open();

                    string query = @"
                        DELETE FROM dbo.tblCart
                        WHERE CartID = @CartID
                          AND CustomerID = @CustomerID;";

                    using (SqlCommand cmd =
                        new SqlCommand(query, con))
                    {
                        cmd.Parameters.Add(
                            "@CartID",
                            SqlDbType.Int).Value =
                            cartID;

                        cmd.Parameters.Add(
                            "@CustomerID",
                            SqlDbType.Int).Value =
                            customerID;

                        int rowsAffected =
                            cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show(
                                "Item removed from cart.",
                                "Cart",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            LoadCart();
                        }
                        else
                        {
                            MessageBox.Show(
                                "The item could not be removed.",
                                "Remove Failed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Database error while removing item.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error removing item.\n\n" +
                    ex.Message,
                    "Cart Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =====================================================
        // FORM CLOSING
        // =====================================================

        private void Cart_FormClosing(
            object sender,
            FormClosingEventArgs e)
        {
            // Do NOT call Session.Logout() here.
            //
            // The customer session belongs to the dashboard/login
            // flow and should remain active when this form closes.
        }
    }
}