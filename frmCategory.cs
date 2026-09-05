
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GoMartApplication
{
    public partial class frmCategory : Form
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
        // CONSTRUCTOR
        // =====================================================

        public frmCategory()
        {
            InitializeComponent();

            // If the event is not already connected from the
            // Designer, these ensure the events work.
            this.Load += frmCategory_Load;
            dataGridViewCategory.CellClick += dataGridViewCategory_CellClick;
        }


        // =====================================================
        // FORM LOAD
        // =====================================================

        private void frmCategory_Load(object sender, EventArgs e)
        {
            LoadCategories();
        }


        // =====================================================
        // ADD CATEGORY BUTTON
        // =====================================================

        private void btn0_Click(object sender, EventArgs e)
        {
            AddCategory();
        }


        // =====================================================
        // UPDATE CATEGORY BUTTON
        // =====================================================

        private void btn1_Click(object sender, EventArgs e)
        {
            UpdateCategory();
        }


        // =====================================================
        // DELETE CATEGORY BUTTON
        // =====================================================

        private void btn2_Click(object sender, EventArgs e)
        {
            DeleteCategory();
        }


        // =====================================================
        // REFRESH BUTTON
        // =====================================================

        private void btn3_Click(object sender, EventArgs e)
        {
            LoadCategories();
        }


        // =====================================================
        // LOAD CATEGORIES
        // IMPORTANT:
        // SQL PROCEDURE = spGetAllCategory
        // =====================================================

        private void LoadCategories()
        {
            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd =
                        new SqlCommand("spGetAllCategory", con))
                    {
                        cmd.CommandType =
                            CommandType.StoredProcedure;

                        using (SqlDataAdapter adapter =
                            new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();

                            adapter.Fill(dt);

                            dataGridViewCategory.DataSource = dt;
                        }
                    }
                }

                ConfigureGrid();
                dataGridViewCategory.ClearSelection();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Error loading categories.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading categories.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =====================================================
        // CONFIGURE GRID
        // =====================================================

        private void ConfigureGrid()
        {
            if (dataGridViewCategory == null)
            {
                return;
            }

            dataGridViewCategory.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dataGridViewCategory.AllowUserToAddRows = false;
            dataGridViewCategory.AllowUserToDeleteRows = false;
            dataGridViewCategory.AllowUserToResizeRows = false;

            dataGridViewCategory.ReadOnly = true;
            dataGridViewCategory.MultiSelect = false;

            dataGridViewCategory.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dataGridViewCategory.RowHeadersVisible = false;


            // =================================================
            // CATEGORY ID
            // =================================================

            if (dataGridViewCategory.Columns.Contains("CategoryID"))
            {
                dataGridViewCategory.Columns["CategoryID"].HeaderText =
                    "ID";

                dataGridViewCategory.Columns["CategoryID"].FillWeight =
                    15;
            }


            // =================================================
            // CATEGORY NAME
            // =================================================

            if (dataGridViewCategory.Columns.Contains("CategoryName"))
            {
                dataGridViewCategory.Columns["CategoryName"].HeaderText =
                    "Category Name";

                dataGridViewCategory.Columns["CategoryName"].FillWeight =
                    30;
            }


            // =================================================
            // DESCRIPTION
            // =================================================

            if (dataGridViewCategory.Columns.Contains("Description"))
            {
                dataGridViewCategory.Columns["Description"].HeaderText =
                    "Description";

                dataGridViewCategory.Columns["Description"].FillWeight =
                    40;
            }


            // =================================================
            // ACTIVE
            // =================================================

            if (dataGridViewCategory.Columns.Contains("IsActive"))
            {
                dataGridViewCategory.Columns["IsActive"].HeaderText =
                    "Active";

                dataGridViewCategory.Columns["IsActive"].FillWeight =
                    15;
            }


            // =================================================
            // CREATED DATE
            // =================================================

            if (dataGridViewCategory.Columns.Contains("CreatedDate"))
            {
                dataGridViewCategory.Columns["CreatedDate"].HeaderText =
                    "Created Date";

                dataGridViewCategory.Columns["CreatedDate"].DefaultCellStyle
                    .Format = "dd-MMM-yyyy hh:mm tt";
            }
        }


        // =====================================================
        // ADD CATEGORY
        // =====================================================

        private void AddCategory()
        {
            try
            {
                string categoryName =
                    txtCategoryName.Text.Trim();

                string description =
                    txtDescription.Text.Trim();


                // =================================================
                // VALIDATION
                // =================================================

                if (string.IsNullOrWhiteSpace(categoryName))
                {
                    MessageBox.Show(
                        "Please enter a category name.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtCategoryName.Focus();
                    return;
                }


                // =================================================
                // INSERT CATEGORY
                // =================================================

                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd =
                        new SqlCommand("spInsertCategory", con))
                    {
                        cmd.CommandType =
                            CommandType.StoredProcedure;

                        cmd.Parameters.Add(
                            "@CategoryName",
                            SqlDbType.NVarChar,
                            100).Value =
                                categoryName;

                        cmd.Parameters.Add(
                            "@Description",
                            SqlDbType.NVarChar,
                            500).Value =
                                string.IsNullOrWhiteSpace(description)
                                ? (object)DBNull.Value
                                : description;

                        con.Open();

                        using (SqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int success =
                                    Convert.ToInt32(
                                        reader["Success"]);

                                string message =
                                    reader["Message"].ToString();

                                if (success == 0)
                                {
                                    MessageBox.Show(
                                        message,
                                        "Category",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);

                                    return;
                                }
                            }
                        }
                    }
                }


                MessageBox.Show(
                    "Category added successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ClearFields();

                LoadCategories();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Error adding category.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error adding category.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =====================================================
        // UPDATE CATEGORY
        // =====================================================

        private void UpdateCategory()
        {
            try
            {
                // =================================================
                // CHECK SELECTION
                // =================================================

                if (dataGridViewCategory.CurrentRow == null)
                {
                    MessageBox.Show(
                        "Please select a category to update.",
                        "No Category Selected",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }


                // =================================================
                // CHECK CATEGORY ID COLUMN
                // =================================================

                if (!dataGridViewCategory.Columns.Contains(
                    "CategoryID"))
                {
                    MessageBox.Show(
                        "CategoryID column was not found.",
                        "Grid Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }


                // =================================================
                // GET CATEGORY ID
                // =================================================

                object idValue =
                    dataGridViewCategory.CurrentRow
                        .Cells["CategoryID"]
                        .Value;

                if (idValue == null ||
                    idValue == DBNull.Value)
                {
                    MessageBox.Show(
                        "Invalid category selected.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                int categoryID =
                    Convert.ToInt32(idValue);


                // =================================================
                // GET VALUES
                // =================================================

                string categoryName =
                    txtCategoryName.Text.Trim();

                string description =
                    txtDescription.Text.Trim();


                // =================================================
                // VALIDATION
                // =================================================

                if (string.IsNullOrWhiteSpace(categoryName))
                {
                    MessageBox.Show(
                        "Please enter a category name.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtCategoryName.Focus();
                    return;
                }


                // =================================================
                // UPDATE CATEGORY
                // =================================================

                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd =
                        new SqlCommand("spUpdateCategory", con))
                    {
                        cmd.CommandType =
                            CommandType.StoredProcedure;

                        cmd.Parameters.Add(
                            "@CategoryID",
                            SqlDbType.Int).Value =
                                categoryID;

                        cmd.Parameters.Add(
                            "@CategoryName",
                            SqlDbType.NVarChar,
                            100).Value =
                                categoryName;

                        cmd.Parameters.Add(
                            "@Description",
                            SqlDbType.NVarChar,
                            500).Value =
                                string.IsNullOrWhiteSpace(description)
                                ? (object)DBNull.Value
                                : description;

                        con.Open();

                        using (SqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int success =
                                    Convert.ToInt32(
                                        reader["Success"]);

                                string message =
                                    reader["Message"].ToString();

                                if (success == 0)
                                {
                                    MessageBox.Show(
                                        message,
                                        "Category",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);

                                    return;
                                }
                            }
                        }
                    }
                }


                MessageBox.Show(
                    "Category updated successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ClearFields();

                LoadCategories();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Error updating category.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error updating category.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =====================================================
        // DELETE CATEGORY
        //
        // NOTE:
        // Your SQL procedure performs a SOFT DELETE:
        // IsActive = 0
        // =====================================================

        private void DeleteCategory()
        {
            try
            {
                // =================================================
                // CHECK SELECTION
                // =================================================

                if (dataGridViewCategory.CurrentRow == null)
                {
                    MessageBox.Show(
                        "Please select a category to delete.",
                        "No Category Selected",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }


                // =================================================
                // CHECK CATEGORY ID COLUMN
                // =================================================

                if (!dataGridViewCategory.Columns.Contains(
                    "CategoryID"))
                {
                    MessageBox.Show(
                        "CategoryID column was not found.",
                        "Grid Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }


                // =================================================
                // GET CATEGORY ID
                // =================================================

                object idValue =
                    dataGridViewCategory.CurrentRow
                        .Cells["CategoryID"]
                        .Value;

                if (idValue == null ||
                    idValue == DBNull.Value)
                {
                    MessageBox.Show(
                        "Invalid category selected.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                int categoryID =
                    Convert.ToInt32(idValue);


                // =================================================
                // GET CATEGORY NAME
                // =================================================

                string categoryName = "";

                if (dataGridViewCategory.Columns.Contains(
                    "CategoryName"))
                {
                    object nameValue =
                        dataGridViewCategory.CurrentRow
                            .Cells["CategoryName"]
                            .Value;

                    if (nameValue != null &&
                        nameValue != DBNull.Value)
                    {
                        categoryName =
                            nameValue.ToString();
                    }
                }


                // =================================================
                // CHECK ACTIVE STATUS
                // =================================================

                if (dataGridViewCategory.Columns.Contains(
                    "IsActive"))
                {
                    object activeValue =
                        dataGridViewCategory.CurrentRow
                            .Cells["IsActive"]
                            .Value;

                    if (activeValue != null &&
                        activeValue != DBNull.Value)
                    {
                        bool isActive =
                            Convert.ToBoolean(activeValue);

                        if (!isActive)
                        {
                            MessageBox.Show(
                                "This category is already inactive.",
                                "Category",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            return;
                        }
                    }
                }


                // =================================================
                // CONFIRM DELETE
                // =================================================

                DialogResult result =
                    MessageBox.Show(
                        "Are you sure you want to deactivate " +
                        "this category?\n\n" +
                        categoryName,
                        "Confirm Delete",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                {
                    return;
                }


                // =================================================
                // DELETE CATEGORY
                // =================================================

                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd =
                        new SqlCommand("spDeleteCategory", con))
                    {
                        cmd.CommandType =
                            CommandType.StoredProcedure;

                        cmd.Parameters.Add(
                            "@CategoryID",
                            SqlDbType.Int).Value =
                                categoryID;

                        con.Open();

                        using (SqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int success =
                                    Convert.ToInt32(
                                        reader["Success"]);

                                string message =
                                    reader["Message"].ToString();

                                if (success == 0)
                                {
                                    MessageBox.Show(
                                        message,
                                        "Category",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);

                                    return;
                                }
                            }
                        }
                    }
                }


                MessageBox.Show(
                    "Category deactivated successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ClearFields();

                LoadCategories();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "The category could not be deleted.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error deleting category.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =====================================================
        // GRID ROW CLICK
        // =====================================================

        private void dataGridViewCategory_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            try
            {
                // Ignore header click
                if (e.RowIndex < 0)
                {
                    return;
                }

                DataGridViewRow row =
                    dataGridViewCategory.Rows[e.RowIndex];


                // =================================================
                // CATEGORY NAME
                // =================================================

                if (dataGridViewCategory.Columns.Contains(
                    "CategoryName"))
                {
                    object categoryValue =
                        row.Cells["CategoryName"].Value;

                    if (categoryValue != null &&
                        categoryValue != DBNull.Value)
                    {
                        txtCategoryName.Text =
                            categoryValue.ToString();
                    }
                    else
                    {
                        txtCategoryName.Clear();
                    }
                }


                // =================================================
                // DESCRIPTION
                // =================================================

                if (dataGridViewCategory.Columns.Contains(
                    "Description"))
                {
                    object descriptionValue =
                        row.Cells["Description"].Value;

                    if (descriptionValue != null &&
                        descriptionValue != DBNull.Value)
                    {
                        txtDescription.Text =
                            descriptionValue.ToString();
                    }
                    else
                    {
                        txtDescription.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to select category.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =====================================================
        // CLEAR FIELDS
        // =====================================================

        private void ClearFields()
        {
            if (txtCategoryName != null)
            {
                txtCategoryName.Clear();
            }

            if (txtDescription != null)
            {
                txtDescription.Clear();
            }

            if (dataGridViewCategory != null)
            {
                dataGridViewCategory.ClearSelection();
                dataGridViewCategory.CurrentCell = null;
            }

            if (txtCategoryName != null)
            {
                txtCategoryName.Focus();
            }
        }
    }
}
