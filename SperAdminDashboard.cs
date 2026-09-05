using System;
using System.Windows.Forms;

namespace GoMartApplication
{
    public partial class SuperAdminDashboard : Form
    {
        public SuperAdminDashboard()
        {
            InitializeComponent();
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            new AddSuperAdmin().ShowDialog();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            new SellerRequest().ShowDialog();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            new ManageSeller().ShowDialog();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            new ManageCustomer().ShowDialog();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            new ManageReview().ShowDialog();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            new ManageOffer().ShowDialog();
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            new FinancialDashboard().ShowDialog();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            AppSession.Clear();

            this.Hide();

            Loginfrom login = new Loginfrom();
            login.ShowDialog();

            this.Close();
        }
    }
}