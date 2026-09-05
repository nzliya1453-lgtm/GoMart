using System;

namespace GoMartApplication
{
    public static class Session
    {
        // =====================================================
        // LOGIN STATUS
        // =====================================================

        public static bool IsLoggedIn { get; private set; }

        // =====================================================
        // COMMON USER INFORMATION
        // =====================================================

        public static string Username { get; private set; }
        public static string FullName { get; private set; }
        public static string Role { get; private set; }

        // =====================================================
        // USER IDs
        // =====================================================

        public static int CustomerID { get; private set; }
        public static int SellerID { get; private set; }
        public static int SuperAdminID { get; private set; }

        // AdminID is string because your LoginAdmin()
        // currently receives a string AdminID.
        public static string AdminID { get; private set; }

        // =====================================================
        // STATIC CONSTRUCTOR
        // =====================================================

        static Session()
        {
            Clear();
        }

        // =====================================================
        // CUSTOMER LOGIN
        // =====================================================

        public static void LoginCustomer(
            int customerID,
            string username,
            string fullName)
        {
            Clear();

            if (customerID <= 0)
                return;

            if (string.IsNullOrWhiteSpace(username))
                return;

            CustomerID = customerID;

            Username = username.Trim();

            FullName = string.IsNullOrWhiteSpace(fullName)
                ? Username
                : fullName.Trim();

            Role = "Customer";

            IsLoggedIn = true;
        }

        // =====================================================
        // SELLER LOGIN
        // =====================================================

        public static void LoginSeller(
            int sellerID,
            string sellerName)
        {
            Clear();

            if (sellerID <= 0)
                return;

            if (string.IsNullOrWhiteSpace(sellerName))
                return;

            SellerID = sellerID;

            Username = sellerName.Trim();

            FullName = Username;

            Role = "Seller";

            IsLoggedIn = true;
        }

        // =====================================================
        // ADMIN LOGIN
        // =====================================================

        public static void LoginAdmin(
            string adminID,
            string fullName)
        {
            Clear();

            if (string.IsNullOrWhiteSpace(adminID))
                return;

            AdminID = adminID.Trim();

            Username = AdminID;

            FullName = string.IsNullOrWhiteSpace(fullName)
                ? Username
                : fullName.Trim();

            Role = "Admin";

            IsLoggedIn = true;
        }

        // =====================================================
        // SUPER ADMIN LOGIN
        // =====================================================

        public static void LoginSuperAdmin(
            int superAdminID,
            string username,
            string fullName)
        {
            Clear();

            if (superAdminID <= 0)
                return;

            if (string.IsNullOrWhiteSpace(username))
                return;

            SuperAdminID = superAdminID;

            Username = username.Trim();

            FullName = string.IsNullOrWhiteSpace(fullName)
                ? Username
                : fullName.Trim();

            Role = "Super Admin";

            IsLoggedIn = true;
        }

        // =====================================================
        // CUSTOMER CHECK
        // =====================================================

        public static bool IsCustomer()
        {
            return IsLoggedIn
                && CustomerID > 0
                && string.Equals(
                    Role,
                    "Customer",
                    StringComparison.OrdinalIgnoreCase);
        }

        // =====================================================
        // SELLER CHECK
        // =====================================================

        public static bool IsSeller()
        {
            return IsLoggedIn
                && SellerID > 0
                && string.Equals(
                    Role,
                    "Seller",
                    StringComparison.OrdinalIgnoreCase);
        }

        // =====================================================
        // ADMIN CHECK
        // =====================================================

        public static bool IsAdmin()
        {
            return IsLoggedIn
                && !string.IsNullOrWhiteSpace(AdminID)
                && string.Equals(
                    Role,
                    "Admin",
                    StringComparison.OrdinalIgnoreCase);
        }

        // =====================================================
        // SUPER ADMIN CHECK
        // =====================================================

        public static bool IsSuperAdmin()
        {
            return IsLoggedIn
                && SuperAdminID > 0
                && string.Equals(
                    Role,
                    "Super Admin",
                    StringComparison.OrdinalIgnoreCase);
        }

        // =====================================================
        // GENERAL LOGIN CHECK
        // =====================================================

        public static bool IsUserLoggedIn()
        {
            return IsLoggedIn;
        }

        // =====================================================
        // LOGOUT
        // =====================================================

        public static void Logout()
        {
            Clear();
        }

        // =====================================================
        // CLEAR SESSION
        // =====================================================

        private static void Clear()
        {
            IsLoggedIn = false;

            Username = string.Empty;
            FullName = string.Empty;
            Role = string.Empty;

            CustomerID = 0;
            SellerID = 0;
            SuperAdminID = 0;

            AdminID = string.Empty;
        }
    }
}