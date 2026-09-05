using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GoMartApplication
{
    public partial class FinancialDashboard : Form
    {
        // =====================================================
        // DATABASE CONNECTION
        // =====================================================

        private readonly DBConnect dbCon =
            new DBConnect();

        // =====================================================
        // CONSTRUCTOR
        // =====================================================

        public FinancialDashboard()
        {
            InitializeComponent();

            // Do NOT manually attach Load event here.
            // Designer.cs should wire FinancialDashboard_Load.
        }

        // =====================================================
        // FORM LOAD
        // =====================================================

        private void FinancialDashboard_Load(
            object sender,
            EventArgs e)
        {
            LoadFinancial();
        }

        // =====================================================
        // REFRESH BUTTON
        // =====================================================

        private void btn0_Click(
            object sender,
            EventArgs e)
        {
            LoadFinancial();
        }

        // =====================================================
        // LOAD FINANCIAL INFORMATION
        // =====================================================

        private void LoadFinancial()
        {
            decimal totalSales = 0m;
            decimal commission = 0m;

            try
            {
                // =================================================
                // GET TOTAL SALES
                // =================================================

                dbCon.OpenCon();

                using (SqlCommand cmd =
                    new SqlCommand(
                        "dbo.spGetTotalSales",
                        dbCon.GetCon()))
                {
                    cmd.CommandType =
                        CommandType.StoredProcedure;

                    object result =
                        cmd.ExecuteScalar();

                    if (result != null &&
                        result != DBNull.Value)
                    {
                        decimal.TryParse(
                            result.ToString(),
                            out totalSales);
                    }
                }

                dbCon.CloseCon();

                // =================================================
                // GET TOTAL COMMISSION
                // =================================================

                dbCon.OpenCon();

                using (SqlCommand cmd =
                    new SqlCommand(
                        "dbo.spGetTotalCommission",
                        dbCon.GetCon()))
                {
                    cmd.CommandType =
                        CommandType.StoredProcedure;

                    object result =
                        cmd.ExecuteScalar();

                    if (result != null &&
                        result != DBNull.Value)
                    {
                        decimal.TryParse(
                            result.ToString(),
                            out commission);
                    }
                }

                dbCon.CloseCon();

                // =================================================
                // CALCULATE SELLER EARNINGS
                // =================================================

                decimal sellerEarnings =
                    totalSales - commission;

                if (sellerEarnings < 0)
                    sellerEarnings = 0;

                // =================================================
                // DISPLAY RESULTS
                // =================================================

                lblTotalSales.Text =
                    "Total Sales: " +
                    totalSales.ToString("N2");

                lblCommission.Text =
                    "GoMart Commission: " +
                    commission.ToString("N2");

                lblSellerEarnings.Text =
                    "Seller Earnings: " +
                    sellerEarnings.ToString("N2");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Database error while loading financial data.\n\n" +
                    ex.Message,
                    "Financial Dashboard",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load financial data.\n\n" +
                    ex.Message,
                    "Financial Dashboard",
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

        private void FinancialDashboard_FormClosing(
            object sender,
            FormClosingEventArgs e)
        {
            dbCon.CloseCon();

            // Do not logout here.
            // The parent dashboard controls the session.
        }
    }
}