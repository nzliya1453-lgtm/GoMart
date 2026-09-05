using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GoMartApplication
{
    public partial class CustomerOrder : Form
    {
        // =====================================================
        // CUSTOMER ID
        // =====================================================

        private readonly int _customerID;

        // =====================================================
        // DATABASE CONNECTION
        // =====================================================

        private readonly DBConnect dbCon = new DBConnect();

        // =====================================================
        // CONSTRUCTOR
        // =====================================================

        public CustomerOrder(int customerID)
        {
            InitializeComponent();

            _customerID = customerID;
        }

        // =====================================================
        // FORM LOAD
        // =====================================================

        private void CustomerOrder_Load(object sender, EventArgs e)
        {
            if (!ValidateCustomerSession())
                return;

            LoadOrders();
        }

        // =====================================================
        // VALIDATE CUSTOMER SESSION
        // =====================================================

        private bool ValidateCustomerSession()
        {
            if (_customerID <= 0)
            {
                ShowInvalidSession();
                return false;
            }

            if (!Session.IsUserLoggedIn())
            {
                ShowInvalidSession();
                return false;
            }

            if (!Session.IsCustomer())
            {
                ShowInvalidSession();
                return false;
            }

            if (Session.CustomerID != _customerID)
            {
                ShowInvalidSession();
                return false;
            }

            return true;
        }

        // =====================================================
        // INVALID SESSION
        // =====================================================

        private void ShowInvalidSession()
        {
            MessageBox.Show(
                "Your customer session is invalid.\n\n" +
                "Please login again.",
                "Login Required",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );

            Session.Logout();

            if (!IsDisposed && !Disposing)
            {
                Close();
            }
        }

        // =====================================================
        // LOAD CUSTOMER ORDERS
        // DATABASE PROCEDURE:
        //
        // dbo.spGetCustomerOrders
        //     @CustomerID INT
        //
        // =====================================================

        private void LoadOrders()
        {
            if (_customerID <= 0)
                return;

            try
            {
                dbCon.OpenCon();

                using (SqlCommand cmd = new SqlCommand(
                    "dbo.spGetCustomerOrders",
                    dbCon.GetCon()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // IMPORTANT:
                    // spGetCustomerOrders accepts ONLY @CustomerID

                    cmd.Parameters.Add(
                        "@CustomerID",
                        SqlDbType.Int
                    ).Value = _customerID;

                    using (SqlDataAdapter adapter =
                           new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();

                        adapter.Fill(dt);

                        dataGridView1.DataSource = dt;
                    }
                }

                ConfigureOrderGrid();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Database error while loading orders.\n\n" +
                    ex.Message,
                    "My Orders",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load orders.\n\n" +
                    ex.Message,
                    "My Orders",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                dbCon.CloseCon();
            }
        }

        // =====================================================
        // CONFIGURE ORDER GRID
        // =====================================================

        private void ConfigureOrderGrid()
        {
            if (dataGridView1.Columns.Count == 0)
                return;

            dataGridView1.ReadOnly = true;

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AllowUserToOrderColumns = false;

            dataGridView1.MultiSelect = false;

            dataGridView1.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dataGridView1.RowHeadersVisible = false;

            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            // =================================================
            // ORDER ID
            // =================================================

            if (dataGridView1.Columns.Contains("OrderID"))
            {
                dataGridView1.Columns["OrderID"].HeaderText =
                    "Order ID";

                dataGridView1.Columns["OrderID"].FillWeight = 60;
            }

            // =================================================
            // CUSTOMER ID
            // =================================================

            if (dataGridView1.Columns.Contains("CustomerID"))
            {
                // Customer already logged in.
                // No need to display CustomerID.

                dataGridView1.Columns["CustomerID"].Visible = false;
            }

            // =================================================
            // ORDER DATE
            // =================================================

            if (dataGridView1.Columns.Contains("OrderDate"))
            {
                dataGridView1.Columns["OrderDate"].HeaderText =
                    "Order Date";

                dataGridView1.Columns["OrderDate"]
                    .DefaultCellStyle.Format =
                    "dd-MMM-yyyy hh:mm tt";
            }

            // =================================================
            // TOTAL AMOUNT
            // =================================================

            if (dataGridView1.Columns.Contains("TotalAmount"))
            {
                dataGridView1.Columns["TotalAmount"].HeaderText =
                    "Total Amount";

                dataGridView1.Columns["TotalAmount"]
                    .DefaultCellStyle.Format = "N2";
            }

            // =================================================
            // PAYMENT METHOD
            // =================================================

            if (dataGridView1.Columns.Contains("PaymentMethod"))
            {
                dataGridView1.Columns["PaymentMethod"].HeaderText =
                    "Payment Method";
            }

            // =================================================
            // PAYMENT STATUS
            // =================================================

            if (dataGridView1.Columns.Contains("PaymentStatus"))
            {
                dataGridView1.Columns["PaymentStatus"].HeaderText =
                    "Payment Status";
            }

            // =================================================
            // ORDER STATUS
            // =================================================

            if (dataGridView1.Columns.Contains("OrderStatus"))
            {
                dataGridView1.Columns["OrderStatus"].HeaderText =
                    "Order Status";
            }
        }

        // =====================================================
        // DOUBLE CLICK ORDER
        // =====================================================

        private void dataGridView1_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (!ValidateCustomerSession())
                return;

            // =================================================
            // CHECK ORDER ID COLUMN
            // =================================================

            if (!dataGridView1.Columns.Contains("OrderID"))
            {
                MessageBox.Show(
                    "OrderID column was not found in the order list.",
                    "My Orders",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            // =================================================
            // GET ORDER ID
            // =================================================

            object value =
                dataGridView1.Rows[e.RowIndex]
                    .Cells["OrderID"].Value;

            if (value == null || value == DBNull.Value)
            {
                MessageBox.Show(
                    "Invalid Order ID.",
                    "My Orders",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            int orderID;

            if (!int.TryParse(
                    value.ToString(),
                    out orderID) ||
                orderID <= 0)
            {
                MessageBox.Show(
                    "Invalid Order ID.",
                    "My Orders",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            // =================================================
            // OPEN ORDER DETAILS
            //
            // OrderDetails should receive:
            //
            //     customerID
            //     orderID
            //
            // =================================================

            try
            {
                using (OrderDetails form =
                       new OrderDetails(
                           _customerID,
                           orderID))
                {
                    form.ShowDialog(this);
                }

                // =================================================
                // REFRESH ORDERS AFTER DETAILS FORM CLOSES
                // =================================================

                if (!IsDisposed &&
                    !Disposing)
                {
                    if (ValidateCustomerSession())
                    {
                        LoadOrders();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to open Order Details.\n\n" +
                    ex.Message,
                    "Order Details",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =====================================================
        // FORM CLOSING
        // =====================================================

        private void CustomerOrder_FormClosing(
            object sender,
            FormClosingEventArgs e)
        {
            // Do NOT logout here.
            //
            // CustomerDashboard/Login controls
            // the customer session.
        }
    }
}