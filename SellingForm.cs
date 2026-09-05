using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GoMartApplication
{
    public partial class SellingForm : Form
    {
        // ============================================================
        // DATABASE CONNECTION
        // ============================================================

        private readonly DBConnect dbCon = new DBConnect();

        // ============================================================
        // TOTAL AMOUNT
        // ============================================================

        private decimal totalAmount = 0m;

        // ============================================================
        // CONSTRUCTOR
        // ============================================================

        public SellingForm()
        {
            InitializeComponent();
        }

        // ============================================================
        // FORM LOAD
        // ============================================================

        private void SellingForm_Load(object sender, EventArgs e)
        {
            try
            {
                lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

                ConfigureOrderGrid();
                ConfigureProductGrid();
                ConfigureSellGrid();

                BindCategory();
                BindProduct();
                BindSellList();

                ClearProductFields();

                totalAmount = 0m;
                UpdateTotalLabel();
            }
            catch (Exception ex)
            {
                CloseConnection();

                MessageBox.Show(
                    "Error loading selling form.\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // ORDER GRID
        // ============================================================

        private void ConfigureOrderGrid()
        {
            dataGridView1_Order.AutoGenerateColumns = false;
            dataGridView1_Order.AllowUserToAddRows = false;
            dataGridView1_Order.AllowUserToDeleteRows = false;
            dataGridView1_Order.ReadOnly = true;
            dataGridView1_Order.MultiSelect = false;
            dataGridView1_Order.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dataGridView1_Order.RowHeadersVisible = false;

            if (dataGridView1_Order.Columns.Count == 0)
            {
                DataGridViewTextBoxColumn idColumn =
                    new DataGridViewTextBoxColumn();

                idColumn.Name = "SellID";
                idColumn.HeaderText = "Product ID";
                idColumn.ReadOnly = true;

                dataGridView1_Order.Columns.Add(idColumn);

                DataGridViewTextBoxColumn productColumn =
                    new DataGridViewTextBoxColumn();

                productColumn.Name = "SellProduct";
                productColumn.HeaderText = "Product";
                productColumn.ReadOnly = true;

                dataGridView1_Order.Columns.Add(productColumn);

                DataGridViewTextBoxColumn priceColumn =
                    new DataGridViewTextBoxColumn();

                priceColumn.Name = "SellPrice";
                priceColumn.HeaderText = "Price";
                priceColumn.ReadOnly = true;
                priceColumn.DefaultCellStyle.Format = "N2";

                dataGridView1_Order.Columns.Add(priceColumn);

                DataGridViewTextBoxColumn quantityColumn =
                    new DataGridViewTextBoxColumn();

                quantityColumn.Name = "SellQuantity";
                quantityColumn.HeaderText = "Quantity";
                quantityColumn.ReadOnly = true;

                dataGridView1_Order.Columns.Add(quantityColumn);

                DataGridViewTextBoxColumn amountColumn =
                    new DataGridViewTextBoxColumn();

                amountColumn.Name = "SellAmount";
                amountColumn.HeaderText = "Amount";
                amountColumn.ReadOnly = true;
                amountColumn.DefaultCellStyle.Format = "N2";

                dataGridView1_Order.Columns.Add(amountColumn);
            }

            dataGridView1_Order.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ============================================================
        // PRODUCT GRID
        // ============================================================

        private void ConfigureProductGrid()
        {
            dataGridView2_Product.AutoGenerateColumns = true;
            dataGridView2_Product.AllowUserToAddRows = false;
            dataGridView2_Product.AllowUserToDeleteRows = false;
            dataGridView2_Product.ReadOnly = true;
            dataGridView2_Product.MultiSelect = false;
            dataGridView2_Product.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dataGridView2_Product.RowHeadersVisible = false;

            dataGridView2_Product.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ============================================================
        // BILL GRID
        // ============================================================

        private void ConfigureSellGrid()
        {
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ============================================================
        // LOAD CATEGORY
        // Correct procedure:
        // dbo.spGetAllCategory
        // ============================================================

        private void BindCategory()
        {
            try
            {
                dbCon.OpenCon();

                using (SqlCommand cmd = new SqlCommand(
                    "dbo.spGetAllCategory",
                    dbCon.GetCon()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter da =
                        new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();

                        da.Fill(dt);

                        cmbCategory.DataSource = null;

                        cmbCategory.DisplayMember = "CategoryName";
                        cmbCategory.ValueMember = "CategoryID";

                        cmbCategory.DataSource = dt;
                        cmbCategory.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading categories.\n\n" + ex.Message,
                    "Category Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                CloseConnection();
            }
        }

        // ============================================================
        // LOAD PRODUCTS
        // Correct procedure:
        // dbo.spGetAllProductList
        // ============================================================

        private void BindProduct()
        {
            try
            {
                dbCon.OpenCon();

                using (SqlCommand cmd = new SqlCommand(
                    "dbo.spGetAllProductList",
                    dbCon.GetCon()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter da =
                        new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();

                        da.Fill(dt);

                        dataGridView2_Product.DataSource = null;
                        dataGridView2_Product.DataSource = dt;
                    }
                }

                FormatProductGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading products.\n\n" + ex.Message,
                    "Product Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                CloseConnection();
            }
        }

        // ============================================================
        // FORMAT PRODUCT GRID
        // ============================================================

        private void FormatProductGrid()
        {
            try
            {
                if (dataGridView2_Product.Columns.Contains("ProdID"))
                {
                    dataGridView2_Product.Columns["ProdID"].HeaderText =
                        "Product ID";
                }

                if (dataGridView2_Product.Columns.Contains("ProdName"))
                {
                    dataGridView2_Product.Columns["ProdName"].HeaderText =
                        "Product";
                }

                if (dataGridView2_Product.Columns.Contains("CategoryID"))
                {
                    dataGridView2_Product.Columns["CategoryID"].HeaderText =
                        "Category ID";
                }

                if (dataGridView2_Product.Columns.Contains("CategoryName"))
                {
                    dataGridView2_Product.Columns["CategoryName"].HeaderText =
                        "Category";
                }

                if (dataGridView2_Product.Columns.Contains("ProdPrice"))
                {
                    dataGridView2_Product.Columns["ProdPrice"].HeaderText =
                        "Price";

                    dataGridView2_Product.Columns["ProdPrice"]
                        .DefaultCellStyle.Format = "N2";
                }

                if (dataGridView2_Product.Columns.Contains("ProdQty"))
                {
                    dataGridView2_Product.Columns["ProdQty"].HeaderText =
                        "Stock";
                }

                if (dataGridView2_Product.Columns.Contains("SellerName"))
                {
                    dataGridView2_Product.Columns["SellerName"].HeaderText =
                        "Seller";
                }

                if (dataGridView2_Product.Columns.Contains("ProdDescription"))
                {
                    dataGridView2_Product.Columns["ProdDescription"].HeaderText =
                        "Description";
                }

                if (dataGridView2_Product.Columns.Contains("IsActive"))
                {
                    dataGridView2_Product.Columns["IsActive"].HeaderText =
                        "Active";
                }

                if (dataGridView2_Product.Columns.Contains("CreatedDate"))
                {
                    dataGridView2_Product.Columns["CreatedDate"].HeaderText =
                        "Created Date";
                }
            }
            catch
            {
                // Ignore formatting errors.
            }
        }

        // ============================================================
        // SEARCH PRODUCT BY CATEGORY
        //
        // Correct procedure:
        // dbo.spGetAllProductList_SearchbyCat
        //
        // Parameter:
        // @CategoryID
        // ============================================================

        private void Searched_Product()
        {
            if (cmbCategory.SelectedIndex == -1 ||
                cmbCategory.SelectedValue == null)
            {
                MessageBox.Show(
                    "Please select a category.",
                    "Category Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                int categoryID;

                if (!int.TryParse(
                    cmbCategory.SelectedValue.ToString(),
                    out categoryID))
                {
                    MessageBox.Show(
                        "Invalid category selected.",
                        "Category Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                dbCon.OpenCon();

                using (SqlCommand cmd = new SqlCommand(
                    "dbo.spGetAllProductList_SearchbyCat",
                    dbCon.GetCon()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(
                        "@CategoryID",
                        SqlDbType.Int).Value = categoryID;

                    using (SqlDataAdapter da =
                        new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();

                        da.Fill(dt);

                        dataGridView2_Product.DataSource = null;
                        dataGridView2_Product.DataSource = dt;
                    }
                }

                FormatProductGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error searching products.\n\n" + ex.Message,
                    "Search Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                CloseConnection();
            }
        }

        // ============================================================
        // SEARCH BUTTON
        // ============================================================

        private void button3_Click(object sender, EventArgs e)
        {
            Searched_Product();
        }

        // ============================================================
        // REFRESH CATEGORY / PRODUCT
        // ============================================================

        private void btnRefCat_Click(object sender, EventArgs e)
        {
            BindCategory();
            BindProduct();
        }

        // ============================================================
        // PRODUCT GRID CLICK
        // ============================================================

        private void dataGridView2_Product_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            SelectProduct(e.RowIndex);
        }

        // ============================================================
        // SELECT PRODUCT
        // ============================================================

        private void SelectProduct(int rowIndex)
        {
            try
            {
                if (rowIndex < 0 ||
                    rowIndex >= dataGridView2_Product.Rows.Count)
                {
                    return;
                }

                DataGridViewRow row =
                    dataGridView2_Product.Rows[rowIndex];

                txtProductID.Text =
                    GetCellValue(row, "ProdID");

                txtProductName.Text =
                    GetCellValue(row, "ProdName");

                txtPrice.Text =
                    GetCellValue(row, "ProdPrice");

                txtQty.Text = "1";

                CalculateAmount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to select product.\n\n" + ex.Message,
                    "Selection Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // GET CELL VALUE
        // ============================================================

        private string GetCellValue(
            DataGridViewRow row,
            string columnName)
        {
            if (row == null)
                return "";

            if (!dataGridView2_Product.Columns.Contains(columnName))
                return "";

            object value = row.Cells[columnName].Value;

            if (value == null || value == DBNull.Value)
                return "";

            return value.ToString();
        }

        // ============================================================
        // QUANTITY CHANGED
        // ============================================================

        private void textBox4_TextChanged(
            object sender,
            EventArgs e)
        {
            CalculateAmount();
        }

        // ============================================================
        // CALCULATE AMOUNT
        // ============================================================

        private decimal CalculateAmount()
        {
            decimal price;
            int quantity;

            if (!decimal.TryParse(
                txtPrice.Text.Trim(),
                out price))
            {
                return 0m;
            }

            if (!int.TryParse(
                txtQty.Text.Trim(),
                out quantity))
            {
                return 0m;
            }

            if (price < 0 || quantity <= 0)
                return 0m;

            return price * quantity;
        }

        // ============================================================
        // ADD PRODUCT TO ORDER
        // ============================================================

        private void btnAddOrder_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtProductID.Text) ||
                    string.IsNullOrWhiteSpace(txtProductName.Text))
                {
                    MessageBox.Show(
                        "Please select a product.",
                        "Product Required",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                int productID;

                if (!int.TryParse(
                    txtProductID.Text.Trim(),
                    out productID) ||
                    productID <= 0)
                {
                    MessageBox.Show(
                        "Invalid product ID.",
                        "Product Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                decimal price;

                if (!decimal.TryParse(
                    txtPrice.Text.Trim(),
                    out price) ||
                    price < 0)
                {
                    MessageBox.Show(
                        "Invalid product price.",
                        "Price Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                int quantity;

                if (!int.TryParse(
                    txtQty.Text.Trim(),
                    out quantity) ||
                    quantity <= 0)
                {
                    MessageBox.Show(
                        "Quantity must be greater than 0.",
                        "Quantity Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtQty.Focus();
                    return;
                }

                // ====================================================
                // GET CURRENT STOCK
                // ====================================================

                int availableStock = GetProductStock(productID);

                if (availableStock < 0)
                {
                    MessageBox.Show(
                        "Unable to verify product stock.",
                        "Stock Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (availableStock == 0)
                {
                    MessageBox.Show(
                        "This product is out of stock.",
                        "Out of Stock",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (quantity > availableStock)
                {
                    MessageBox.Show(
                        "Insufficient stock.\n\n" +
                        "Available stock: " + availableStock,
                        "Stock Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                // ====================================================
                // PREVENT DUPLICATE PRODUCT
                // ====================================================

                foreach (DataGridViewRow existingRow
                    in dataGridView1_Order.Rows)
                {
                    if (existingRow.Cells["SellID"].Value == null)
                        continue;

                    int existingID;

                    if (int.TryParse(
                        existingRow.Cells["SellID"]
                            .Value.ToString(),
                        out existingID))
                    {
                        if (existingID == productID)
                        {
                            MessageBox.Show(
                                "This product is already in the order.",
                                "Duplicate Product",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return;
                        }
                    }
                }

                // ====================================================
                // CALCULATE AMOUNT
                // ====================================================

                decimal amount = price * quantity;

                // ====================================================
                // ADD TO ORDER GRID
                // ====================================================

                dataGridView1_Order.Rows.Add(
                    productID,
                    txtProductName.Text.Trim(),
                    price,
                    quantity,
                    amount);

                totalAmount += amount;

                UpdateTotalLabel();

                ClearProductFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to add product to order.\n\n" +
                    ex.Message,
                    "Order Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // GET PRODUCT STOCK
        //
        // Uses the EXISTING tblProduct table.
        // No database changes.
        // ============================================================

        private int GetProductStock(int productID)
        {
            try
            {
                dbCon.OpenCon();

                const string query = @"
                    SELECT ProdQty
                    FROM dbo.tblProduct
                    WHERE ProdID = @ProdID
                      AND IsActive = 1;";

                using (SqlCommand cmd =
                    new SqlCommand(query, dbCon.GetCon()))
                {
                    cmd.Parameters.Add(
                        "@ProdID",
                        SqlDbType.Int).Value = productID;

                    object result = cmd.ExecuteScalar();

                    if (result == null ||
                        result == DBNull.Value)
                    {
                        return -1;
                    }

                    return Convert.ToInt32(result);
                }
            }
            catch
            {
                return -1;
            }
            finally
            {
                CloseConnection();
            }
        }

        // ============================================================
        // CLEAR PRODUCT FIELDS
        // ============================================================

        private void ClearProductFields()
        {
            txtProductID.Clear();
            txtProductName.Clear();
            txtPrice.Clear();
            txtQty.Text = "1";
        }

        // ============================================================
        // UPDATE TOTAL
        // ============================================================

        private void UpdateTotalLabel()
        {
            label9.Text =
                "Rs." + totalAmount.ToString("0.00");
        }

        // ============================================================
        // REMOVE SELECTED ORDER ITEM
        // ============================================================

        private void button1_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (dataGridView1_Order.SelectedRows.Count == 0)
                {
                    MessageBox.Show(
                        "Please select an order item.",
                        "No Item Selected",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                DataGridViewRow row =
                    dataGridView1_Order.SelectedRows[0];

                decimal amount = 0m;

                if (row.Cells["SellAmount"].Value != null)
                {
                    decimal.TryParse(
                        row.Cells["SellAmount"]
                            .Value.ToString(),
                        out amount);
                }

                dataGridView1_Order.Rows.Remove(row);

                totalAmount -= amount;

                if (totalAmount < 0)
                    totalAmount = 0m;

                UpdateTotalLabel();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to remove order item.\n\n" +
                    ex.Message,
                    "Delete Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // CLEAR ALL ORDER ITEMS
        // ============================================================

        private void button2_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (dataGridView1_Order.Rows.Count > 0)
                {
                    DialogResult result = MessageBox.Show(
                        "Are you sure you want to clear all items?",
                        "Confirm Clear",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result != DialogResult.Yes)
                        return;
                }

                dataGridView1_Order.Rows.Clear();

                totalAmount = 0m;

                UpdateTotalLabel();

                ClearProductFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to clear order.\n\n" +
                    ex.Message,
                    "Clear Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // PRODUCT DOUBLE CLICK
        // ============================================================

        private void dataGridView2_Product_DoubleClick(
            object sender,
            EventArgs e)
        {
            try
            {
                if (dataGridView2_Product.SelectedRows.Count == 0)
                    return;

                int rowIndex =
                    dataGridView2_Product.SelectedRows[0].Index;

                SelectProduct(rowIndex);

                string categoryID =
                    GetCellValue(
                        dataGridView2_Product.SelectedRows[0],
                        "CategoryID");

                if (!string.IsNullOrWhiteSpace(categoryID))
                {
                    int catID;

                    if (int.TryParse(categoryID, out catID))
                    {
                        cmbCategory.SelectedValue = catID;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to select product.\n\n" +
                    ex.Message,
                    "Product Selection Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // SAVE / CONFIRM ORDER
        //
        // IMPORTANT:
        // Your current SellingForm has no CustomerID control and no
        // PaymentMethod control.
        //
        // Your database's spCheckout requires:
        // @CustomerID
        // @PaymentMethod
        //
        // Therefore it is NOT safe to invent a CustomerID here.
        //
        // This button validates the order only.
        // ============================================================

        private void Add_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (dataGridView1_Order.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "Please add at least one product to the order.",
                        "Order Empty",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (totalAmount <= 0)
                {
                    MessageBox.Show(
                        "Total amount must be greater than 0.",
                        "Invalid Amount",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                MessageBox.Show(
                    "Order validated successfully.\n\n" +
                    "Items: " +
                    dataGridView1_Order.Rows.Count +
                    "\n\nTotal Amount: Rs." +
                    totalAmount.ToString("0.00") +
                    "\n\n" +
                    "To save this as a customer order, the form must " +
                    "provide a valid CustomerID and PaymentMethod for " +
                    "the existing dbo.spCheckout procedure.",
                    "Order Summary",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to process order.\n\n" +
                    ex.Message,
                    "Order Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // LOAD BILL LIST
        //
        // Current tblBill columns:
        //
        // BillID
        // OrderID
        // SellerID
        // BillAmount
        // BillDate
        // PaymentStatus
        // ============================================================

        private void BindSellList()
        {
            try
            {
                dbCon.OpenCon();

                const string query = @"
                    SELECT TOP 100
                        BillID,
                        OrderID,
                        SellerID,
                        BillAmount,
                        BillDate,
                        PaymentStatus
                    FROM dbo.tblBill
                    ORDER BY BillID DESC;";

                using (SqlCommand cmd =
                    new SqlCommand(query, dbCon.GetCon()))
                {
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataAdapter da =
                        new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();

                        da.Fill(dt);

                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = dt;
                    }
                }

                FormatSellGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading bills.\n\n" +
                    ex.Message,
                    "Bill List Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                CloseConnection();
            }
        }

        // ============================================================
        // FORMAT BILL GRID
        // Matches current tblBill exactly.
        // ============================================================

        private void FormatSellGrid()
        {
            try
            {
                if (dataGridView1.Columns.Contains("BillID"))
                {
                    dataGridView1.Columns["BillID"].HeaderText =
                        "Bill ID";
                }

                if (dataGridView1.Columns.Contains("OrderID"))
                {
                    dataGridView1.Columns["OrderID"].HeaderText =
                        "Order ID";
                }

                if (dataGridView1.Columns.Contains("SellerID"))
                {
                    dataGridView1.Columns["SellerID"].HeaderText =
                        "Seller ID";
                }

                if (dataGridView1.Columns.Contains("BillAmount"))
                {
                    dataGridView1.Columns["BillAmount"].HeaderText =
                        "Bill Amount";

                    dataGridView1.Columns["BillAmount"]
                        .DefaultCellStyle.Format = "N2";
                }

                if (dataGridView1.Columns.Contains("BillDate"))
                {
                    dataGridView1.Columns["BillDate"].HeaderText =
                        "Bill Date";

                    dataGridView1.Columns["BillDate"]
                        .DefaultCellStyle.Format =
                        "dd-MMM-yyyy hh:mm tt";
                }

                if (dataGridView1.Columns.Contains("PaymentStatus"))
                {
                    dataGridView1.Columns["PaymentStatus"].HeaderText =
                        "Payment Status";
                }
            }
            catch
            {
                // Ignore formatting errors.
            }
        }

        // ============================================================
        // CLOSE DATABASE CONNECTION
        // ============================================================

        private void CloseConnection()
        {
            try
            {
                dbCon.CloseCon();
            }
            catch
            {
                // Ignore close errors.
            }
        }

        // ============================================================
        // FORM CLOSING
        // ============================================================

        private void SellingForm_FormClosing(
            object sender,
            FormClosingEventArgs e)
        {
            CloseConnection();
        }
    }
}