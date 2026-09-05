
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GoMartApplication
{
    public partial class AddNewSeller : Form
    {
        DBConnect dbCon = new DBConnect();

        public AddNewSeller()
        {
            InitializeComponent();
        }

        // =========================================================
        // FORM LOAD
        // =========================================================
        private void AddNewSeller_Load(object sender, EventArgs e)
        {
            lblSellerID.Visible = false;

            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnAdd.Visible = true;

            BindSeller();
        }

        // =========================================================
        // ADD SELLER
        // =========================================================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateSellerInput())
                return;

            int sellerAge;

            if (!int.TryParse(txtSellerAge.Text.Trim(), out sellerAge))
            {
                MessageBox.Show(
                    "Seller age must be a valid number.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                txtSellerAge.Focus();
                return;
            }

            if (sellerAge < 18)
            {
                MessageBox.Show(
                    "Seller must be at least 18 years old.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtSellerAge.Focus();
                return;
            }

            try
            {
                dbCon.OpenCon();

                // Check duplicate seller name
                SqlCommand checkCmd = new SqlCommand(
                    "SELECT COUNT(*) FROM dbo.tblSeller " +
                    "WHERE SellerName = @SellerName",
                    dbCon.GetCon());

                checkCmd.Parameters.Add(
                    "@SellerName",
                    SqlDbType.NVarChar,
                    100).Value = txtSellerName.Text.Trim();

                int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (count > 0)
                {
                    MessageBox.Show(
                        "Seller name already exists.",
                        "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtSellerName.Focus();
                    return;
                }

                // Insert seller
                SqlCommand cmd = new SqlCommand(
                    "dbo.spSellerInsert",
                    dbCon.GetCon());

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(
                    "@SellerName",
                    SqlDbType.NVarChar,
                    100).Value = txtSellerName.Text.Trim();

                cmd.Parameters.Add(
                    "@SellerAge",
                    SqlDbType.Int).Value = sellerAge;

                cmd.Parameters.Add(
                    "@SellerPhone",
                    SqlDbType.NVarChar,
                    20).Value = txtPhone.Text.Trim();

                cmd.Parameters.Add(
                    "@SellerPass",
                    SqlDbType.NVarChar,
                    100).Value = txtPassword.Text;

                int result = cmd.ExecuteNonQuery();

                if (result >= 0)
                {
                    MessageBox.Show(
                        "Seller inserted successfully.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    txtClear();

                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btnAdd.Visible = true;
                    lblSellerID.Visible = false;

                    BindSeller();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                dbCon.CloseCon();
            }
        }

        // =========================================================
        // VALIDATE INPUT
        // =========================================================
        private bool ValidateSellerInput()
        {
            if (string.IsNullOrWhiteSpace(txtSellerName.Text))
            {
                MessageBox.Show(
                    "Please enter seller name.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                txtSellerName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSellerAge.Text))
            {
                MessageBox.Show(
                    "Please enter seller age.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                txtSellerAge.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show(
                    "Please enter seller phone.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                txtPhone.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show(
                    "Please enter password.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                txtPassword.Focus();
                return false;
            }

            return true;
        }

        // =========================================================
        // CLEAR TEXTBOXES
        // =========================================================
        private void txtClear()
        {
            txtSellerName.Clear();
            txtSellerAge.Clear();
            txtPhone.Clear();
            txtPassword.Clear();

            lblSellerID.Text = "";
        }

        // =========================================================
        // LOAD SELLERS
        // =========================================================
        private void BindSeller()
        {
            try
            {
                SqlCommand cmd = new SqlCommand(
                    "dbo.spGetAllSeller",
                    dbCon.GetCon());

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dt;

                // Optional column headers
                if (dataGridView1.Columns.Count >= 5)
                {
                    dataGridView1.Columns[0].HeaderText = "Seller ID";
                    dataGridView1.Columns[1].HeaderText = "Seller Name";
                    dataGridView1.Columns[2].HeaderText = "Age";
                    dataGridView1.Columns[3].HeaderText = "Phone";
                    dataGridView1.Columns[4].HeaderText = "Password";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // UPDATE SELLER
        // =========================================================
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lblSellerID.Text))
            {
                MessageBox.Show(
                    "Please select a seller.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            if (!ValidateSellerInput())
                return;

            int sellerID;
            int sellerAge;

            if (!int.TryParse(lblSellerID.Text, out sellerID))
            {
                MessageBox.Show(
                    "Invalid seller ID.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            if (!int.TryParse(txtSellerAge.Text.Trim(), out sellerAge))
            {
                MessageBox.Show(
                    "Seller age must be a valid number.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                txtSellerAge.Focus();
                return;
            }

            if (sellerAge < 18)
            {
                MessageBox.Show(
                    "Seller must be at least 18 years old.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtSellerAge.Focus();
                return;
            }

            try
            {
                dbCon.OpenCon();

                SqlCommand cmd = new SqlCommand(
                    "dbo.spSellerUpdate",
                    dbCon.GetCon());

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(
                    "@SellerID",
                    SqlDbType.Int).Value = sellerID;

                cmd.Parameters.Add(
                    "@SellerName",
                    SqlDbType.NVarChar,
                    100).Value = txtSellerName.Text.Trim();

                cmd.Parameters.Add(
                    "@SellerAge",
                    SqlDbType.Int).Value = sellerAge;

                cmd.Parameters.Add(
                    "@SellerPhone",
                    SqlDbType.NVarChar,
                    20).Value = txtPhone.Text.Trim();

                cmd.Parameters.Add(
                    "@SellerPass",
                    SqlDbType.NVarChar,
                    100).Value = txtPassword.Text;

                cmd.ExecuteNonQuery();

                MessageBox.Show(
                    "Seller updated successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                txtClear();

                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAdd.Visible = true;
                lblSellerID.Visible = false;

                BindSeller();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                dbCon.CloseCon();
            }
        }

        // =========================================================
        // DELETE SELLER
        // =========================================================
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lblSellerID.Text))
            {
                MessageBox.Show(
                    "Please select a seller.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            int sellerID;

            if (!int.TryParse(lblSellerID.Text, out sellerID))
            {
                MessageBox.Show(
                    "Invalid seller ID.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this seller?",
                "Delete Seller",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            try
            {
                dbCon.OpenCon();

                SqlCommand cmd = new SqlCommand(
                    "dbo.spDeleteSeller",
                    dbCon.GetCon());

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(
                    "@SellerID",
                    SqlDbType.Int).Value = sellerID;

                cmd.ExecuteNonQuery();

                MessageBox.Show(
                    "Seller deleted successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                txtClear();

                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAdd.Visible = true;
                lblSellerID.Visible = false;

                BindSeller();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                dbCon.CloseCon();
            }
        }

        // =========================================================
        // SELECT SELLER FROM DATAGRIDVIEW
        // =========================================================
        private void dataGridView1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                    return;

                DataGridViewRow row =
                    dataGridView1.SelectedRows[0];

                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblSellerID.Visible = true;
                btnAdd.Visible = false;

                lblSellerID.Text =
                    row.Cells["SellerID"].Value?.ToString();

                txtSellerName.Text =
                    row.Cells["SellerName"].Value?.ToString();

                txtSellerAge.Text =
                    row.Cells["SellerAge"].Value?.ToString();

                txtPhone.Text =
                    row.Cells["SellerPhone"].Value?.ToString();

                txtPassword.Text =
                    row.Cells["SellerPass"].Value?.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}

