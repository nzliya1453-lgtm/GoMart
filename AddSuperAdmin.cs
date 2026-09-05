using System;
using System.Windows.Forms;

namespace GoMartApplication
{
    public partial class AddSuperAdmin : Form
    {
        public AddSuperAdmin()
        {
            InitializeComponent();
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            try
            {
                using (ManageSeller form = new ManageSeller())
                {
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to open seller management.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}