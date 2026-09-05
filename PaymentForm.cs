using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GoMartApplication
{
    public partial class PaymentForm : Form
    {
        private readonly int _customerID;
        private readonly int _orderID;

        private readonly DBConnect dbCon = new DBConnect();

        public PaymentForm(int customerID, int orderID)
        {
            InitializeComponent();

            _customerID = customerID;
            _orderID = orderID;
        }

        // =========================================================
        // FORM LOAD
        // =========================================================
        private void PaymentForm_Load(object sender, EventArgs e)
        {
            // Validate customer
            if (_customerID <= 0)
            {
                MessageBox.Show(
                    "Invalid customer session.\n\nPlease login again.",
                    "Payment",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                Close();
                return;
            }

            // Validate order
            if (_orderID <= 0)
            {
                MessageBox.Show(
                    "Invalid Order ID.\n\nPlease select an order again.",
                    "Payment",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                Close();
                return;
            }

            // Default payment method
            rbBkash.Checked = true;
            rbNagad.Checked = false;
            rbRocket.Checked = false;

            // Clear fields
            txtAmount.Text = "";
            txtNumber.Text = "";

            // Make sure amount can be typed
            txtAmount.ReadOnly = false;
            txtAmount.Enabled = true;

            // Put cursor in amount textbox
            txtAmount.Focus();
        }

        // =========================================================
        // PAY BUTTON
        // =========================================================
        private void BtnPay_Click(object sender, EventArgs e)
        {
            ProcessPayment();
        }

        // =========================================================
        // PROCESS PAYMENT
        // =========================================================
        private void ProcessPayment()
        {
            // -----------------------------------
            // Validate Customer
            // -----------------------------------
            if (_customerID <= 0)
            {
                MessageBox.Show(
                    "Invalid customer session.\n\nPlease login again.",
                    "Payment",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // -----------------------------------
            // Validate Order
            // -----------------------------------
            if (_orderID <= 0)
            {
                MessageBox.Show(
                    "Invalid Order ID.",
                    "Payment",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // -----------------------------------
            // Get Amount
            // -----------------------------------
            string amountText = txtAmount.Text.Trim();

            if (string.IsNullOrEmpty(amountText))
            {
                MessageBox.Show(
                    "Please enter the payment amount.",
                    "Payment",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtAmount.Focus();
                return;
            }

            decimal amount;

            if (!decimal.TryParse(amountText, out amount))
            {
                MessageBox.Show(
                    "Please enter a valid amount.\n\n" +
                    "Example:\n" +
                    "500\n" +
                    "1000\n" +
                    "500.50",

                    "Invalid Amount",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtAmount.Focus();
                txtAmount.SelectAll();
                return;
            }

            if (amount <= 0)
            {
                MessageBox.Show(
                    "Amount must be greater than 0.",
                    "Invalid Amount",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtAmount.Focus();
                txtAmount.SelectAll();
                return;
            }

            // -----------------------------------
            // Get Payment Method
            // -----------------------------------
            string paymentMethod = "";

            if (rbBkash.Checked)
            {
                paymentMethod = "bKash";
            }
            else if (rbNagad.Checked)
            {
                paymentMethod = "Nagad";
            }
            else if (rbRocket.Checked)
            {
                paymentMethod = "Rocket";
            }
            else
            {
                MessageBox.Show(
                    "Please select a payment method.",
                    "Payment",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // -----------------------------------
            // Get Mobile Number
            // -----------------------------------
            string mobileNumber = txtNumber.Text.Trim();

            if (string.IsNullOrEmpty(mobileNumber))
            {
                MessageBox.Show(
                    "Please enter your mobile number.",
                    "Payment",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtNumber.Focus();
                return;
            }

            // -----------------------------------
            // Confirm Payment
            // -----------------------------------
            DialogResult confirmation = MessageBox.Show(
                "Order ID: #" + _orderID +
                "\n\n" +
                "Amount: " + amount.ToString("0.00") +
                "\n\n" +
                "Payment Method: " + paymentMethod +
                "\n\n" +
                "Mobile Number: " + mobileNumber +
                "\n\n" +
                "Do you want to complete this payment?",

                "Confirm Payment",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmation != DialogResult.Yes)
            {
                return;
            }

            // Complete payment
            CompletePayment(
                paymentMethod,
                amount,
                mobileNumber);
        }

        // =========================================================
        // COMPLETE PAYMENT
        // =========================================================
        private void CompletePayment(
            string paymentMethod,
            decimal amount,
            string mobileNumber)
        {
            bool connectionOpened = false;

            try
            {
                // Open database connection
                dbCon.OpenCon();
                connectionOpened = true;

                // =================================================
                // EXISTING DATABASE PROCEDURE
                //
                // dbo.spUpdatePaymentStatus
                //
                // Parameters:
                // @OrderID
                // @PaymentStatus
                // =================================================
                using (SqlCommand cmd = new SqlCommand(
                    "dbo.spUpdatePaymentStatus",
                    dbCon.GetCon()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(
                        "@OrderID",
                        SqlDbType.Int).Value = _orderID;

                    cmd.Parameters.Add(
                        "@PaymentStatus",
                        SqlDbType.NVarChar,
                        30).Value = "Paid";

                    cmd.ExecuteNonQuery();
                }

                // =================================================
                // PAYMENT SUCCESS
                // =================================================
                MessageBox.Show(
                    "Payment Successful!\n\n" +
                    "Order ID: #" + _orderID + "\n" +
                    "Amount: " + amount.ToString("0.00") + "\n" +
                    "Payment Method: " + paymentMethod + "\n" +
                    "Mobile Number: " + mobileNumber + "\n" +
                    "Payment Status: Paid",

                    "Payment Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Payment failed.\n\n" +
                    "Database Error:\n" +
                    ex.Message,

                    "Payment Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An error occurred while processing payment.\n\n" +
                    ex.Message,

                    "Payment Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                if (connectionOpened)
                {
                    dbCon.CloseCon();
                }
            }
        }

        // =========================================================
        // CANCEL BUTTON
        // =========================================================
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to cancel payment?",

                "Cancel Payment",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }
    }
}