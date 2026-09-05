namespace GoMartApplication
{
    public static class AppSession
    {
        // =====================================================
        // COMMON LOGIN INFORMATION
        // =====================================================
        public static string UserId { get; set; }
        public static string UserName { get; set; }
        public static string UserType { get; set; }


    // =====================================================
    // ROLE-SPECIFIC IDs
    // =====================================================
    public static int SuperAdminId { get; set; }
        public static int AdminId { get; set; }
        public static int SellerId { get; set; }
        public static int CustomerId { get; set; }

        // =====================================================
        // CHECK CUSTOMER
        // =====================================================
        public static bool IsCustomer
        {
            get
            {
                return UserType == "Customer";
            }
        }

        // =====================================================
        // CHECK ADMIN
        // =====================================================
        public static bool IsAdmin
        {
            get
            {
                return UserType == "Admin";
            }
        }

        // =====================================================
        // CHECK SUPER ADMIN
        // =====================================================
        public static bool IsSuperAdmin
        {
            get
            {
                return UserType == "SuperAdmin";
            }
        }

        // =====================================================
        // CHECK SELLER
        // =====================================================
        public static bool IsSeller
        {
            get
            {
                return UserType == "Seller";
            }
        }

        // =====================================================
        // CLEAR SESSION
        // =====================================================
        public static void Clear()
        {
            UserId = null;
            UserName = null;
            UserType = null;

            SuperAdminId = 0;
            AdminId = 0;
            SellerId = 0;
            CustomerId = 0;
        }
    }


}
