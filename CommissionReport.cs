using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GoMartApplication
{
    public partial class CommissionReport : Form
    {
        // =====================================================
        // DATABASE CONNECTION
        // =====================================================

        private readonly DBConnect db =
            new DBConnect();

        // =====================================================
        // CONSTRUCTOR
        // =====================================================

        public CommissionReport()
        {
            InitializeComponent();

            // Do NOT manually attach Load event here.
            // Designer.cs should wire CommissionReport_Load.
        }

        // =====================================================
        // FORM LOAD
        // =====================================================

        private void CommissionReport_Load(
            object sender,
            EventArgs e)
        {
            LoadCommissionReport();
            LoadSummary();
        }

        // =====================================================
        // LOAD COMMISSION REPORT
        // =====================================================

        private void LoadCommissionReport()
        {
            try
            {
                db.OpenCon();

                string sql = @"
                    SELECT
                        c.CommissionID,
                        c.OrderID,
                        c.OrderDetailID,
                        c.SellerID,
                        s.SellerName,
                        c.SaleAmount,
                        c.CommissionPercent,
                        c.CommissionAmount,
                        c.SellerEarnings,
                        c.CreatedAt
                    FROM dbo.tblCommission c
                    LEFT JOIN dbo.tblSeller s
                        ON c.SellerID = s.SellerID
                    ORDER BY c.CreatedAt DESC;";

                using (SqlCommand cmd =
                    new SqlCommand(
                        sql,
                        db.GetCon()))
                {
                    using (SqlDataAdapter da =
                        new SqlDataAdapter(cmd))
                    {
                        DataTable dt =
                            new DataTable();

                        da.Fill(dt);

                        dgvCommission.DataSource = dt;
                    }
                }

                ConfigureCommissionGrid();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Database error while loading commission report.\n\n" +
                    ex.Message,
                    "Commission Report",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load commission report.\n\n" +
                    ex.Message,
                    "Commission Report",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                db.CloseCon();
            }
        }

        // =====================================================
        // CONFIGURE COMMISSION GRID
        // =====================================================

        private void ConfigureCommissionGrid()
        {
            if (dgvCommission.Columns.Count == 0)
                return;

            dgvCommission.ReadOnly = true;

            dgvCommission.AllowUserToAddRows = false;

            dgvCommission.AllowUserToDeleteRows = false;

            dgvCommission.AllowUserToResizeRows = false;

            dgvCommission.MultiSelect = false;

            dgvCommission.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvCommission.RowHeadersVisible = false;

            dgvCommission.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            // -------------------------------------------------
            // COMMISSION ID
            // -------------------------------------------------

            if (dgvCommission.Columns.Contains(
                "CommissionID"))
            {
                dgvCommission.Columns["CommissionID"]
                    .HeaderText = "Commission ID";
            }

            // -------------------------------------------------
            // ORDER ID
            // -------------------------------------------------

            if (dgvCommission.Columns.Contains(
                "OrderID"))
            {
                dgvCommission.Columns["OrderID"]
                    .HeaderText = "Order ID";
            }

            // -------------------------------------------------
            // ORDER DETAIL ID
            // -------------------------------------------------

            if (dgvCommission.Columns.Contains(
                "OrderDetailID"))
            {
                dgvCommission.Columns["OrderDetailID"]
                    .HeaderText = "Order Detail ID";
            }

            // -------------------------------------------------
            // SELLER ID
            // -------------------------------------------------

            if (dgvCommission.Columns.Contains(
                "SellerID"))
            {
                dgvCommission.Columns["SellerID"]
                    .HeaderText = "Seller ID";
            }

            // -------------------------------------------------
            // SELLER NAME
            // -------------------------------------------------

            if (dgvCommission.Columns.Contains(
                "SellerName"))
            {
                dgvCommission.Columns["SellerName"]
                    .HeaderText = "Seller";
            }

            // -------------------------------------------------
            // SALE AMOUNT
            // -------------------------------------------------

            if (dgvCommission.Columns.Contains(
                "SaleAmount"))
            {
                dgvCommission.Columns["SaleAmount"]
                    .HeaderText = "Sale Amount";

                dgvCommission.Columns["SaleAmount"]
                    .DefaultCellStyle.Format = "N2";
            }

            // -------------------------------------------------
            // COMMISSION PERCENT
            // -------------------------------------------------

            if (dgvCommission.Columns.Contains(
                "CommissionPercent"))
            {
                dgvCommission.Columns["CommissionPercent"]
                    .HeaderText = "Commission %";

                dgvCommission.Columns["CommissionPercent"]
                    .DefaultCellStyle.Format = "0.00";
            }

            // -------------------------------------------------
            // COMMISSION AMOUNT
            // -------------------------------------------------

            if (dgvCommission.Columns.Contains(
                "CommissionAmount"))
            {
                dgvCommission.Columns["CommissionAmount"]
                    .HeaderText = "Commission Amount";

                dgvCommission.Columns["CommissionAmount"]
                    .DefaultCellStyle.Format = "N2";
            }

            // -------------------------------------------------
            // SELLER EARNINGS
            // -------------------------------------------------

            if (dgvCommission.Columns.Contains(
                "SellerEarnings"))
            {
                dgvCommission.Columns["SellerEarnings"]
                    .HeaderText = "Seller Earnings";

                dgvCommission.Columns["SellerEarnings"]
                    .DefaultCellStyle.Format = "N2";
            }

            // -------------------------------------------------
            // CREATED DATE
            // -------------------------------------------------

            if (dgvCommission.Columns.Contains(
                "CreatedAt"))
            {
                dgvCommission.Columns["CreatedAt"]
                    .HeaderText = "Date";

                dgvCommission.Columns["CreatedAt"]
                    .DefaultCellStyle.Format =
                    "dd-MMM-yyyy hh:mm tt";
            }
        }

        // =====================================================
        // LOAD FINANCIAL SUMMARY
        // =====================================================

        private void LoadSummary()
        {
            decimal totalSales = 0m;
            decimal commission = 0m;
            decimal sellerEarnings = 0m;

            try
            {
                db.OpenCon();

                // =================================================
                // TOTAL COMMISSION + SELLER EARNINGS
                // =================================================

                string commissionSql = @"
                    SELECT
                        ISNULL(SUM(CommissionAmount), 0)
                            AS TotalCommission,

                        ISNULL(SUM(SellerEarnings), 0)
                            AS TotalSellerEarnings
                    FROM dbo.tblCommission;";

                using (SqlCommand cmd =
                    new SqlCommand(
                        commissionSql,
                        db.GetCon()))
                {
                    using (SqlDataReader reader =
                        cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (reader["TotalCommission"] !=
                                DBNull.Value)
                            {
                                commission =
                                    Convert.ToDecimal(
                                        reader["TotalCommission"]);
                            }

                            if (reader["TotalSellerEarnings"] !=
                                DBNull.Value)
                            {
                                sellerEarnings =
                                    Convert.ToDecimal(
                                        reader["TotalSellerEarnings"]);
                            }
                        }
                    }
                }

                // =================================================
                // TOTAL SALES
                // =================================================

                string salesSql = @"
                    SELECT
                        ISNULL(SUM(SaleAmount), 0)
                    FROM dbo.tblCommission;";

                using (SqlCommand cmd =
                    new SqlCommand(
                        salesSql,
                        db.GetCon()))
                {
                    object result =
                        cmd.ExecuteScalar();

                    if (result != null &&
                        result != DBNull.Value)
                    {
                        totalSales =
                            Convert.ToDecimal(result);
                    }
                }

                // =================================================
                // DISPLAY SUMMARY
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
                    "Database error while loading financial summary.\n\n" +
                    ex.Message,
                    "Financial Summary",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load financial summary.\n\n" +
                    ex.Message,
                    "Financial Summary",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                db.CloseCon();
            }
        }

        // =====================================================
        // REFRESH BUTTON
        // =====================================================

        private void btnRefresh_Click(
            object sender,
            EventArgs e)
        {
            LoadCommissionReport();
            LoadSummary();
        }

        // =====================================================
        // CLOSE BUTTON
        // =====================================================

        private void btnClose_Click(
            object sender,
            EventArgs e)
        {
            Close();
        }

        // =====================================================
        // FORM CLOSING
        // =====================================================

        private void CommissionReport_FormClosing(
            object sender,
            FormClosingEventArgs e)
        {
            db.CloseCon();

            // Do not logout here.
            // Parent dashboard controls the session.
        }
    }
}