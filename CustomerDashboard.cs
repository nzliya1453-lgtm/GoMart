using System;
using System.Windows.Forms;

namespace GoMartApplication
{
    public partial class CustomerDashboard : Form
    {
        // =====================================================
        // CUSTOMER ID
        // =====================================================

        private readonly int _customerID;


        // =====================================================
        // CONSTRUCTOR
        // =====================================================

        public CustomerDashboard(int customerID)
        {
            InitializeComponent();

            _customerID = customerID;

            // Load event is connected in CustomerDashboard.Designer.cs.
            // Do NOT manually connect it here.
        }


        // =====================================================
        // FORM LOAD
        // =====================================================

        private void CustomerDashboard_Load(
            object sender,
            EventArgs e)
        {
            ValidateCustomerSession();
        }


        // =====================================================
        // VALIDATE CUSTOMER SESSION
        // =====================================================

        private bool ValidateCustomerSession()
        {
            if (_customerID <= 0)
            {
                ShowSessionError();
                return false;
            }

            if (!Session.IsUserLoggedIn())
            {
                ShowSessionError();
                return false;
            }

            if (!Session.IsCustomer())
            {
                ShowSessionError();
                return false;
            }

            if (Session.CustomerID != _customerID)
            {
                ShowSessionError();
                return false;
            }

            return true;
        }


        // =====================================================
        // SESSION ERROR
        // =====================================================

        private void ShowSessionError()
        {
            MessageBox.Show(
                "Invalid customer session.\n\n" +
                "Please login again.",
                "Session Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            Session.Logout();

            Close();
        }


        // =====================================================
        // PRODUCTS
        // =====================================================

        private void btn0_Click(
            object sender,
            EventArgs e)
        {
            if (!ValidateCustomerSession())
                return;

            try
            {
                using (ProductFilter form =
                       new ProductFilter(_customerID))
                {
                    form.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to open Products.\n\n" +
                    ex.Message,
                    "Products",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =====================================================
        // CART
        // =====================================================

        private void btn1_Click(
            object sender,
            EventArgs e)
        {
            if (!ValidateCustomerSession())
                return;

            try
            {
                using (Cart form =
                       new Cart(_customerID))
                {
                    form.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to open Cart.\n\n" +
                    ex.Message,
                    "Cart",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =====================================================
        // MY ORDERS
        // =====================================================

        private void btn2_Click(
            object sender,
            EventArgs e)
        {
            if (!ValidateCustomerSession())
                return;

            try
            {
                using (CustomerOrder form =
                       new CustomerOrder(_customerID))
                {
                    form.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to open Orders.\n\n" +
                    ex.Message,
                    "Orders",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =====================================================
        // REVIEWS
        // =====================================================

        private void btn3_Click(
            object sender,
            EventArgs e)
        {
            if (!ValidateCustomerSession())
                return;

            try
            {
                using (CustomerReview form =
                       new CustomerReview(_customerID))
                {
                    form.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to open Reviews.\n\n" +
                    ex.Message,
                    "Reviews",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =====================================================
        // OFFERS
        // =====================================================

        private void btn4_Click(
            object sender,
            EventArgs e)
        {
            if (!ValidateCustomerSession())
                return;

            try
            {
                using (CustomerOffers form =
                       new CustomerOffers())
                {
                    form.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to open Offers.\n\n" +
                    ex.Message,
                    "Offers",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =====================================================
        // LOGOUT
        // =====================================================

        private void btn5_Click(
            object sender,
            EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            Session.Logout();

            Close();
        }


        // =====================================================
        // PAYMENT
        // =====================================================

        private void btn6_Click(
            object sender,
            EventArgs e)
        {
            if (!ValidateCustomerSession())
                return;

            MessageBox.Show(
                "Please open My Orders and select an order " +
                "before making a payment.",
                "Payment",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }


        // =====================================================
        // FORM CLOSING
        // =====================================================

        private void CustomerDashboard_FormClosing(
            object sender,
            FormClosingEventArgs e)
        {
            // Do NOT call Session.Logout() here.
            //
            // Loginfrom.OpenMainForm() handles session cleanup
            // when the dashboard is closed.
        }
    }
}