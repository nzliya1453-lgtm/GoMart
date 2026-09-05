using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace GoMartApplication
{
    public partial class SellerRequest : Form
    {
        // =========================================================
        // DATABASE CONNECTION
        // =========================================================
        private readonly DBConnect dbCon = new DBConnect();

        // =========================================================
        // SUPER ADMIN ID
        // =========================================================
        // IMPORTANT:
        // Change this to the actual SuperAdminID of the logged-in
        // Super Admin.
        private int approvedBy = 1;

        // =========================================================
        // CONSTRUCTOR
        // =========================================================
        public SellerRequest()
        {
            InitializeComponent();
        }

        // =========================================================
        // FORM LOAD
        // =========================================================
        private void SellerRequest_Load(object sender, EventArgs e)
        {
            LoadSellerRequests();
        }

        // =========================================================
        // LOAD SELLER REQUESTS
        // =========================================================
        private void LoadSellerRequests()
        {
            try
            {
                dbCon.OpenCon();

                using (SqlCommand cmd = new SqlCommand(
                    "dbo.spGetSellerRequests",
                    dbCon.GetCon()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter =
                           new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();

                        adapter.Fill(dt);

                        dgvRequests.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading seller requests:\n\n" +
                    ex.Message,
                    "Seller Requests",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                dbCon.CloseCon();
            }

            FormatDataGridView();
        }

        // =========================================================
        // FORMAT DATAGRIDVIEW
        // =========================================================
        private void FormatDataGridView()
        {
            try
            {
                if (dgvRequests.Columns.Contains("RequestID"))
                {
                    dgvRequests.Columns["RequestID"].HeaderText =
                        "Request ID";
                }

                if (dgvRequests.Columns.Contains("SellerName"))
                {
                    dgvRequests.Columns["SellerName"].HeaderText =
                        "Seller Name";
                }

                if (dgvRequests.Columns.Contains("Phone"))
                {
                    dgvRequests.Columns["Phone"].HeaderText =
                        "Phone";
                }

                if (dgvRequests.Columns.Contains("BusinessName"))
                {
                    dgvRequests.Columns["BusinessName"].HeaderText =
                        "Business Name";
                }

                if (dgvRequests.Columns.Contains("RequestDate"))
                {
                    dgvRequests.Columns["RequestDate"].HeaderText =
                        "Request Date";
                }

                if (dgvRequests.Columns.Contains("Status"))
                {
                    dgvRequests.Columns["Status"].HeaderText =
                        "Status";
                }

                if (dgvRequests.Columns.Contains("ApprovedBy"))
                {
                    dgvRequests.Columns["ApprovedBy"].HeaderText =
                        "Approved By";
                }

                if (dgvRequests.Columns.Contains("ApprovedByUser"))
                {
                    dgvRequests.Columns["ApprovedByUser"].HeaderText =
                        "Approved By";
                }
            }
            catch
            {
                // Ignore formatting errors
            }
        }

        // =========================================================
        // REFRESH BUTTON
        // =========================================================
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadSellerRequests();
        }

        // =========================================================
        // APPROVE BUTTON
        // =========================================================
        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (dgvRequests.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select a seller request first.",
                    "No Request Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            try
            {
                // =================================================
                // GET REQUEST ID
                // =================================================
                object requestIdValue =
                    dgvRequests.SelectedRows[0]
                    .Cells["RequestID"]
                    .Value;

                if (requestIdValue == null ||
                    requestIdValue == DBNull.Value)
                {
                    MessageBox.Show(
                        "Invalid Request ID.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    return;
                }

                int requestId =
                    Convert.ToInt32(requestIdValue);

                // =================================================
                // GET SELLER NAME
                // =================================================
                string sellerName =
                    Convert.ToString(
                        dgvRequests.SelectedRows[0]
                        .Cells["SellerName"]
                        .Value
                    );

                // =================================================
                // GET CURRENT STATUS
                // =================================================
                string status = "";

                if (dgvRequests.Columns.Contains("Status"))
                {
                    status =
                        Convert.ToString(
                            dgvRequests.SelectedRows[0]
                            .Cells["Status"]
                            .Value
                        );
                }

                if (status.Equals(
                    "Approved",
                    StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(
                        "This seller request is already approved.",
                        "Already Approved",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    return;
                }

                if (status.Equals(
                    "Rejected",
                    StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(
                        "This seller request has already been rejected.",
                        "Already Rejected",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                // =================================================
                // ASK FOR SELLER AGE
                // =================================================
                int sellerAge;

                if (!ShowAgeDialog(out sellerAge))
                {
                    return;
                }

                // =================================================
                // ASK FOR PASSWORD
                // =================================================
                string sellerPassword;

                if (!ShowPasswordDialog(out sellerPassword))
                {
                    return;
                }

                // =================================================
                // CONFIRM APPROVAL
                // =================================================
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to approve this seller?\n\n" +
                    "Seller Name: " + sellerName + "\n" +
                    "Age: " + sellerAge,
                    "Confirm Approval",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result != DialogResult.Yes)
                {
                    return;
                }

                // =================================================
                // APPROVE SELLER REQUEST
                // =================================================
                dbCon.OpenCon();

                using (SqlCommand cmd = new SqlCommand(
                    "dbo.spApproveSellerRequest",
                    dbCon.GetCon()))
                {
                    cmd.CommandType =
                        CommandType.StoredProcedure;

                    // Request ID
                    cmd.Parameters.Add(
                        "@RequestID",
                        SqlDbType.Int
                    ).Value = requestId;

                    // Super Admin ID
                    cmd.Parameters.Add(
                        "@ApprovedBy",
                        SqlDbType.Int
                    ).Value = approvedBy;

                    // Seller Age
                    cmd.Parameters.Add(
                        "@SellerAge",
                        SqlDbType.Int
                    ).Value = sellerAge;

                    // Seller Password
                    cmd.Parameters.Add(
                        "@SellerPass",
                        SqlDbType.NVarChar,
                        100
                    ).Value = sellerPassword;

                    cmd.ExecuteNonQuery();
                }

                dbCon.CloseCon();

                MessageBox.Show(
                    "Seller approved successfully.\n\n" +
                    "Seller Name: " + sellerName,
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // Refresh list
                LoadSellerRequests();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error approving seller request:\n\n" +
                    ex.Message,
                    "Approval Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                dbCon.CloseCon();
            }
        }

        // =========================================================
        // REJECT BUTTON
        // =========================================================
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvRequests.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select a seller request first.",
                    "No Request Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            try
            {
                // =================================================
                // GET REQUEST ID
                // =================================================
                object requestIdValue =
                    dgvRequests.SelectedRows[0]
                    .Cells["RequestID"]
                    .Value;

                if (requestIdValue == null ||
                    requestIdValue == DBNull.Value)
                {
                    MessageBox.Show(
                        "Invalid Request ID.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    return;
                }

                int requestId =
                    Convert.ToInt32(requestIdValue);

                // =================================================
                // GET SELLER NAME
                // =================================================
                string sellerName =
                    Convert.ToString(
                        dgvRequests.SelectedRows[0]
                        .Cells["SellerName"]
                        .Value
                    );

                // =================================================
                // GET STATUS
                // =================================================
                string status = "";

                if (dgvRequests.Columns.Contains("Status"))
                {
                    status =
                        Convert.ToString(
                            dgvRequests.SelectedRows[0]
                            .Cells["Status"]
                            .Value
                        );
                }

                if (status.Equals(
                    "Approved",
                    StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(
                        "An approved seller cannot be rejected.",
                        "Cannot Reject",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                if (status.Equals(
                    "Rejected",
                    StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(
                        "This seller request is already rejected.",
                        "Already Rejected",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    return;
                }

                // =================================================
                // CONFIRM REJECTION
                // =================================================
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to reject this seller request?\n\n" +
                    "Seller Name: " + sellerName,
                    "Confirm Rejection",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result != DialogResult.Yes)
                {
                    return;
                }

                // =================================================
                // REJECT REQUEST
                // =================================================
                dbCon.OpenCon();

                using (SqlCommand cmd = new SqlCommand(
                    "dbo.spRejectSellerRequest",
                    dbCon.GetCon()))
                {
                    cmd.CommandType =
                        CommandType.StoredProcedure;

                    cmd.Parameters.Add(
                        "@RequestID",
                        SqlDbType.Int
                    ).Value = requestId;

                    cmd.Parameters.Add(
                        "@ApprovedBy",
                        SqlDbType.Int
                    ).Value = approvedBy;

                    cmd.ExecuteNonQuery();
                }

                dbCon.CloseCon();

                MessageBox.Show(
                    "Seller request rejected successfully.",
                    "Rejected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // Refresh list
                LoadSellerRequests();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error rejecting seller request:\n\n" +
                    ex.Message,
                    "Rejection Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                dbCon.CloseCon();
            }
        }

        // =========================================================
        // AGE DIALOG
        // =========================================================
        private bool ShowAgeDialog(out int age)
        {
            age = 0;

            using (Form form = new Form())
            {
                form.Text = "Seller Age";
                form.Size = new Size(350, 170);
                form.StartPosition =
                    FormStartPosition.CenterParent;
                form.FormBorderStyle =
                    FormBorderStyle.FixedDialog;
                form.MaximizeBox = false;
                form.MinimizeBox = false;

                Label label = new Label();
                label.Text = "Enter seller age:";
                label.Location = new Point(20, 20);
                label.AutoSize = true;

                TextBox textBox = new TextBox();
                textBox.Location = new Point(20, 50);
                textBox.Size = new Size(290, 25);
                textBox.Text = "18";

                Button okButton = new Button();
                okButton.Text = "OK";
                okButton.Location = new Point(155, 90);
                okButton.Size = new Size(75, 30);
                okButton.DialogResult =
                    DialogResult.OK;

                Button cancelButton = new Button();
                cancelButton.Text = "Cancel";
                cancelButton.Location = new Point(235, 90);
                cancelButton.Size = new Size(75, 30);
                cancelButton.DialogResult =
                    DialogResult.Cancel;

                form.Controls.Add(label);
                form.Controls.Add(textBox);
                form.Controls.Add(okButton);
                form.Controls.Add(cancelButton);

                form.AcceptButton = okButton;
                form.CancelButton = cancelButton;

                if (form.ShowDialog(this) != DialogResult.OK)
                {
                    return false;
                }

                if (!int.TryParse(
                    textBox.Text.Trim(),
                    out age))
                {
                    MessageBox.Show(
                        "Please enter a valid age.",
                        "Invalid Age",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return false;
                }

                if (age < 18)
                {
                    MessageBox.Show(
                        "Seller must be at least 18 years old.",
                        "Invalid Age",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return false;
                }

                return true;
            }
        }

        // =========================================================
        // PASSWORD DIALOG
        // =========================================================
        private bool ShowPasswordDialog(
            out string password)
        {
            password = "";

            using (Form form = new Form())
            {
                form.Text = "Seller Password";
                form.Size = new Size(350, 170);
                form.StartPosition =
                    FormStartPosition.CenterParent;
                form.FormBorderStyle =
                    FormBorderStyle.FixedDialog;
                form.MaximizeBox = false;
                form.MinimizeBox = false;

                Label label = new Label();
                label.Text = "Enter seller password:";
                label.Location = new Point(20, 20);
                label.AutoSize = true;

                TextBox textBox = new TextBox();
                textBox.Location = new Point(20, 50);
                textBox.Size = new Size(290, 25);
                textBox.UseSystemPasswordChar = true;

                Button okButton = new Button();
                okButton.Text = "OK";
                okButton.Location = new Point(155, 90);
                okButton.Size = new Size(75, 30);
                okButton.DialogResult =
                    DialogResult.OK;

                Button cancelButton = new Button();
                cancelButton.Text = "Cancel";
                cancelButton.Location = new Point(235, 90);
                cancelButton.Size = new Size(75, 30);
                cancelButton.DialogResult =
                    DialogResult.Cancel;

                form.Controls.Add(label);
                form.Controls.Add(textBox);
                form.Controls.Add(okButton);
                form.Controls.Add(cancelButton);

                form.AcceptButton = okButton;
                form.CancelButton = cancelButton;

                if (form.ShowDialog(this) != DialogResult.OK)
                {
                    return false;
                }

                password = textBox.Text.Trim();

                if (string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show(
                        "Please enter a password.",
                        "Missing Password",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return false;
                }

                return true;
            }
        }

        // =========================================================
        // FORM CLOSING
        // =========================================================
        private void SellerRequest_FormClosing(
            object sender,
            FormClosingEventArgs e)
        {
            dbCon.CloseCon();
        }
    }
}