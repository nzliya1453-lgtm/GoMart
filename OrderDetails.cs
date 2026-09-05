using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GoMartApplication
{
    public partial class OrderDetails : Form
    {
        private readonly int _customerID;
        private readonly int _orderID;

        private readonly DBConnect dbCon = new DBConnect();

        // =====================================================
        // CONSTRUCTOR
        // =====================================================

        public OrderDetails(int customerID, int orderID)
        {
            InitializeComponent();

            _customerID = customerID;
            _orderID = orderID;
        }

        // =====================================================
        // FORM LOAD
        // =====================================================

        private void OrderDetails_Load(object sender, EventArgs e)
        {
            if (!ValidateSession())
            {
                Close();
                return;
            }

            if (_orderID <= 0)
            {
                MessageBox.Show(
                    "Invalid Order ID.",
                    "Order Details",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                Close();
                return;
            }

            lblOrder.Text = "Order #" + _orderID;

            LoadOrderDetails();
        }

        // =====================================================
        // VALIDATE SESSION
        // =====================================================

        private bool ValidateSession()
        {
            if (!Session.IsUserLoggedIn())
            {
                MessageBox.Show(
                    "You are not logged in.\n\n" +
                    "Please login again.",
                    "Order Details",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (!Session.IsCustomer())
            {
                MessageBox.Show(
                    "Only customers can view order details.",
                    "Order Details",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (_customerID <= 0)
            {
                MessageBox.Show(
                    "Invalid customer ID.\n\n" +
                    "Please login again.",
                    "Order Details",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (Session.CustomerID != _customerID)
            {
                MessageBox.Show(
                    "Customer session does not match this order.",
                    "Order Details",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }

        // =====================================================
        // LOAD ORDER DETAILS
        // =====================================================

        private void LoadOrderDetails()
        {
            if (!ValidateSession())
            {
                Close();
                return;
            }

            if (_orderID <= 0)
            {
                MessageBox.Show(
                    "Invalid Order ID.",
                    "Order Details",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                dbCon.OpenCon();

                using (SqlCommand cmd = new SqlCommand(
                    "dbo.spGetOrderDetails",
                    dbCon.GetCon()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(
                        "@CustomerID",
                        SqlDbType.Int).Value = _customerID;

                    cmd.Parameters.Add(
                        "@OrderID",
                        SqlDbType.Int).Value = _orderID;

                    using (SqlDataAdapter adapter =
                           new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();

                        adapter.Fill(dt);

                        dataGridView1.DataSource = dt;

                        ConfigureGrid();

                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show(
                                "No details found for Order #" +
                                _orderID +
                                ".",
                                "Order Details",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Database error while loading order details.\n\n" +
                    ex.Message,
                    "Order Details",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load order details.\n\n" +
                    ex.Message,
                    "Order Details",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                dbCon.CloseCon();
            }
        }

        // =====================================================
        // CONFIGURE GRID
        // =====================================================

        private void ConfigureGrid()
        {
            try
            {
                dataGridView1.ReadOnly = true;

                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.AllowUserToResizeRows = false;

                dataGridView1.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dataGridView1.MultiSelect = false;

                dataGridView1.RowHeadersVisible = false;

                dataGridView1.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                // -------------------------------------------------
                // Order ID
                // -------------------------------------------------

                if (dataGridView1.Columns.Contains("OrderID"))
                {
                    dataGridView1.Columns["OrderID"]
                        .HeaderText = "Order ID";
                }

                // -------------------------------------------------
                // Product ID
                // -------------------------------------------------

                if (dataGridView1.Columns.Contains("ProdID"))
                {
                    dataGridView1.Columns["ProdID"]
                        .HeaderText = "Product ID";
                }

                if (dataGridView1.Columns.Contains("ProductID"))
                {
                    dataGridView1.Columns["ProductID"]
                        .HeaderText = "Product ID";
                }

                // -------------------------------------------------
                // Product Name
                // -------------------------------------------------

                if (dataGridView1.Columns.Contains("ProdName"))
                {
                    dataGridView1.Columns["ProdName"]
                        .HeaderText = "Product";
                }

                if (dataGridView1.Columns.Contains("ProductName"))
                {
                    dataGridView1.Columns["ProductName"]
                        .HeaderText = "Product";
                }

                // -------------------------------------------------
                // Quantity
                // -------------------------------------------------

                if (dataGridView1.Columns.Contains("Quantity"))
                {
                    dataGridView1.Columns["Quantity"]
                        .HeaderText = "Quantity";
                }

                // -------------------------------------------------
                // Unit Price
                // -------------------------------------------------

                if (dataGridView1.Columns.Contains("UnitPrice"))
                {
                    dataGridView1.Columns["UnitPrice"]
                        .HeaderText = "Unit Price";

                    dataGridView1.Columns["UnitPrice"]
                        .DefaultCellStyle.Format = "0.00";
                }

                // -------------------------------------------------
                // Line Total
                // -------------------------------------------------

                if (dataGridView1.Columns.Contains("LineTotal"))
                {
                    dataGridView1.Columns["LineTotal"]
                        .HeaderText = "Total";

                    dataGridView1.Columns["LineTotal"]
                        .DefaultCellStyle.Format = "0.00";
                }

                // -------------------------------------------------
                // Other possible total column
                // -------------------------------------------------

                if (dataGridView1.Columns.Contains("TotalAmount"))
                {
                    dataGridView1.Columns["TotalAmount"]
                        .HeaderText = "Total Amount";

                    dataGridView1.Columns["TotalAmount"]
                        .DefaultCellStyle.Format = "0.00";
                }

                // -------------------------------------------------
                // Hide internal OrderDetailID
                // -------------------------------------------------

                if (dataGridView1.Columns.Contains("OrderDetailID"))
                {
                    dataGridView1.Columns["OrderDetailID"]
                        .Visible = false;
                }
            }
            catch
            {
                // Grid formatting should not stop the form
                // from displaying database data.
            }
        }

        // =====================================================
        // PAYMENT BUTTON
        // =====================================================

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (!ValidateSession())
            {
                return;
            }

            if (_orderID <= 0)
            {
                MessageBox.Show(
                    "Invalid Order ID.",
                    "Payment",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                using (PaymentForm form =
                       new PaymentForm(
                           _customerID,
                           _orderID))
                {
                    DialogResult result = form.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        MessageBox.Show(
                            "Payment completed successfully for Order #" +
                            _orderID +
                            ".",
                            "Payment Successful",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        // Reload order details after payment.
                        LoadOrderDetails();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to open Payment Form.\n\n" +
                    ex.Message,
                    "Payment",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =====================================================
        // CLOSE BUTTON
        // =====================================================

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}