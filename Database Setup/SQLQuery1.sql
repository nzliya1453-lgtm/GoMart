/* ============================================================
   GOMART DATABASE
   SQL SERVER - COMPLETE CORRECTED DATABASE SCRIPT
   ============================================================ */

USE master;
GO

/* ============================================================
   1. DROP DATABASE IF EXISTS
   ============================================================ */

IF DB_ID(N'GoMartDB') IS NOT NULL
BEGIN
    ALTER DATABASE GoMartDB
    SET SINGLE_USER
    WITH ROLLBACK IMMEDIATE;

    DROP DATABASE GoMartDB;
END
GO

CREATE DATABASE GoMartDB;
GO

USE GoMartDB;
GO


/* ============================================================
   2. ADMIN TABLE
   ============================================================ */

CREATE TABLE dbo.tblAdmin
(
    AdminID INT IDENTITY(1,1) PRIMARY KEY,
    AdminName NVARCHAR(100) NOT NULL,
    AdminEmail NVARCHAR(150) NOT NULL UNIQUE,
    AdminPassword NVARCHAR(255) NOT NULL,
    Phone NVARCHAR(30) NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE()
);
GO


/* ============================================================
   3. SUPER ADMIN TABLE
   ============================================================ */

CREATE TABLE dbo.tblSuperAdmin
(
    SuperAdminID INT IDENTITY(1,1) PRIMARY KEY,
    SuperAdminName NVARCHAR(100) NOT NULL,
    SuperAdminEmail NVARCHAR(150) NOT NULL UNIQUE,
    SuperAdminPassword NVARCHAR(255) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE()
);
GO


/* ============================================================
   4. SELLER TABLE
   ============================================================ */

CREATE TABLE dbo.tblSeller
(
    SellerID INT IDENTITY(1,1) PRIMARY KEY,
    SellerName NVARCHAR(100) NOT NULL,
    SellerEmail NVARCHAR(150) NOT NULL UNIQUE,
    SellerPassword NVARCHAR(255) NOT NULL,
    SellerPhone NVARCHAR(30) NULL,
    SellerAddress NVARCHAR(300) NULL,
    IsApproved BIT NOT NULL DEFAULT 0,
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE()
);
GO


/* ============================================================
   5. CUSTOMER TABLE
   ============================================================ */

CREATE TABLE dbo.tblCustomer
(
    CustomerID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerName NVARCHAR(100) NOT NULL,
    CustomerEmail NVARCHAR(150) NOT NULL UNIQUE,
    CustomerPassword NVARCHAR(255) NOT NULL,
    CustomerPhone NVARCHAR(30) NULL,
    CustomerAddress NVARCHAR(300) NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE()
);
GO


/* ============================================================
   6. CATEGORY TABLE
   ============================================================ */

CREATE TABLE dbo.tblCategory
(
    CategoryID INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName NVARCHAR(100) NOT NULL UNIQUE,
    Description NVARCHAR(500) NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE()
);
GO


/* ============================================================
   7. PRODUCT TABLE
   ============================================================ */

CREATE TABLE dbo.tblProduct
(
    ProdID INT IDENTITY(1,1) PRIMARY KEY,
    ProdName NVARCHAR(200) NOT NULL,

    CategoryID INT NOT NULL,
    SellerID INT NOT NULL,

    ProdPrice DECIMAL(18,2) NOT NULL
        CHECK (ProdPrice >= 0),

    ProdQty INT NOT NULL DEFAULT 0
        CHECK (ProdQty >= 0),

    ProdDescription NVARCHAR(1000) NULL,
    ProdImage NVARCHAR(500) NULL,

    IsActive BIT NOT NULL DEFAULT 1,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),

    CONSTRAINT FK_Product_Category
        FOREIGN KEY (CategoryID)
        REFERENCES dbo.tblCategory(CategoryID),

    CONSTRAINT FK_Product_Seller
        FOREIGN KEY (SellerID)
        REFERENCES dbo.tblSeller(SellerID)
);
GO


/* ============================================================
   8. SELLER REQUEST TABLE
   ============================================================ */

CREATE TABLE dbo.tblSellerRequest
(
    RequestID INT IDENTITY(1,1) PRIMARY KEY,
    SellerID INT NOT NULL,

    RequestDate DATETIME NOT NULL DEFAULT GETDATE(),

    RequestStatus NVARCHAR(30) NOT NULL DEFAULT N'Pending'
        CHECK
        (
            RequestStatus IN
            (
                N'Pending',
                N'Approved',
                N'Rejected'
            )
        ),

    ApprovedBy INT NULL,
    ApprovedDate DATETIME NULL,

    CONSTRAINT FK_SellerRequest_Seller
        FOREIGN KEY (SellerID)
        REFERENCES dbo.tblSeller(SellerID),

    CONSTRAINT FK_SellerRequest_Admin
        FOREIGN KEY (ApprovedBy)
        REFERENCES dbo.tblAdmin(AdminID)
);
GO


/* ============================================================
   9. OFFER TABLE
   ============================================================ */

CREATE TABLE dbo.tblOffer
(
    OfferID INT IDENTITY(1,1) PRIMARY KEY,

    OfferTitle NVARCHAR(200) NOT NULL,

    DiscountPercent DECIMAL(5,2) NOT NULL
        CHECK
        (
            DiscountPercent >= 0
            AND DiscountPercent <= 100
        ),

    StartDate DATETIME NOT NULL,
    EndDate DATETIME NOT NULL,

    IsActive BIT NOT NULL DEFAULT 1,

    CONSTRAINT CK_Offer_Date
        CHECK (EndDate >= StartDate)
);
GO


/* ============================================================
   10. CUSTOMER OFFER TABLE
   ============================================================ */

CREATE TABLE dbo.tblCustomerOffer
(
    CustomerOfferID INT IDENTITY(1,1) PRIMARY KEY,

    CustomerID INT NOT NULL,
    OfferID INT NOT NULL,

    TakenDate DATETIME NOT NULL DEFAULT GETDATE(),

    IsUsed BIT NOT NULL DEFAULT 0,

    CONSTRAINT FK_CustomerOffer_Customer
        FOREIGN KEY (CustomerID)
        REFERENCES dbo.tblCustomer(CustomerID),

    CONSTRAINT FK_CustomerOffer_Offer
        FOREIGN KEY (OfferID)
        REFERENCES dbo.tblOffer(OfferID),

    CONSTRAINT UQ_Customer_Offer
        UNIQUE(CustomerID, OfferID)
);
GO


/* ============================================================
   11. CART TABLE
   ============================================================ */

CREATE TABLE dbo.tblCart
(
    CartID INT IDENTITY(1,1) PRIMARY KEY,

    CustomerID INT NOT NULL,
    ProdID INT NOT NULL,

    Quantity INT NOT NULL
        CHECK (Quantity > 0),

    AddedDate DATETIME NOT NULL DEFAULT GETDATE(),

    CONSTRAINT FK_Cart_Customer
        FOREIGN KEY (CustomerID)
        REFERENCES dbo.tblCustomer(CustomerID),

    CONSTRAINT FK_Cart_Product
        FOREIGN KEY (ProdID)
        REFERENCES dbo.tblProduct(ProdID),

    CONSTRAINT UQ_Cart_Customer_Product
        UNIQUE(CustomerID, ProdID)
);
GO


/* ============================================================
   12. CUSTOMER ORDER TABLE
   ============================================================ */

CREATE TABLE dbo.tblCustomerOrder
(
    OrderID INT IDENTITY(1,1) PRIMARY KEY,

    CustomerID INT NOT NULL,

    OrderDate DATETIME NOT NULL DEFAULT GETDATE(),

    TotalAmount DECIMAL(18,2) NOT NULL
        CHECK (TotalAmount >= 0),

    PaymentMethod NVARCHAR(50) NOT NULL,

    PaymentStatus NVARCHAR(30) NOT NULL DEFAULT N'Pending'
        CHECK
        (
            PaymentStatus IN
            (
                N'Pending',
                N'Paid',
                N'Failed',
                N'Refunded'
            )
        ),

    OrderStatus NVARCHAR(30) NOT NULL DEFAULT N'Pending'
        CHECK
        (
            OrderStatus IN
            (
                N'Pending',
                N'Confirmed',
                N'Processing',
                N'Shipped',
                N'Delivered',
                N'Cancelled'
            )
        ),

    CONSTRAINT FK_Order_Customer
        FOREIGN KEY (CustomerID)
        REFERENCES dbo.tblCustomer(CustomerID)
);
GO


/* ============================================================
   13. ORDER DETAIL TABLE
   ============================================================ */

CREATE TABLE dbo.tblCustomerOrderDetail
(
    OrderDetailID INT IDENTITY(1,1) PRIMARY KEY,

    OrderID INT NOT NULL,
    ProdID INT NOT NULL,
    SellerID INT NOT NULL,

    Quantity INT NOT NULL
        CHECK (Quantity > 0),

    UnitPrice DECIMAL(18,2) NOT NULL
        CHECK (UnitPrice >= 0),

    LineTotal AS
    (
        Quantity * UnitPrice
    ) PERSISTED,

    CONSTRAINT FK_OrderDetail_Order
        FOREIGN KEY (OrderID)
        REFERENCES dbo.tblCustomerOrder(OrderID),

    CONSTRAINT FK_OrderDetail_Product
        FOREIGN KEY (ProdID)
        REFERENCES dbo.tblProduct(ProdID),

    CONSTRAINT FK_OrderDetail_Seller
        FOREIGN KEY (SellerID)
        REFERENCES dbo.tblSeller(SellerID)
);
GO


/* ============================================================
   14. COMMISSION TABLE
   ============================================================ */

CREATE TABLE dbo.tblCommission
(
    CommissionID INT IDENTITY(1,1) PRIMARY KEY,

    OrderID INT NOT NULL,
    SellerID INT NOT NULL,

    CommissionRate DECIMAL(5,2) NOT NULL
        CHECK
        (
            CommissionRate >= 0
            AND CommissionRate <= 100
        ),

    CommissionAmount DECIMAL(18,2) NOT NULL
        CHECK (CommissionAmount >= 0),

    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),

    CONSTRAINT FK_Commission_Order
        FOREIGN KEY (OrderID)
        REFERENCES dbo.tblCustomerOrder(OrderID),

    CONSTRAINT FK_Commission_Seller
        FOREIGN KEY (SellerID)
        REFERENCES dbo.tblSeller(SellerID)
);
GO


/* ============================================================
   15. BILL TABLE
   ============================================================ */

CREATE TABLE dbo.tblBill
(
    BillID INT IDENTITY(1,1) PRIMARY KEY,

    OrderID INT NOT NULL,
    SellerID INT NOT NULL,

    BillAmount DECIMAL(18,2) NOT NULL
        CHECK (BillAmount >= 0),

    BillDate DATETIME NOT NULL DEFAULT GETDATE(),

    PaymentStatus NVARCHAR(30) NOT NULL DEFAULT N'Pending'
        CHECK
        (
            PaymentStatus IN
            (
                N'Pending',
                N'Paid',
                N'Cancelled'
            )
        ),

    CONSTRAINT FK_Bill_Order
        FOREIGN KEY (OrderID)
        REFERENCES dbo.tblCustomerOrder(OrderID),

    CONSTRAINT FK_Bill_Seller
        FOREIGN KEY (SellerID)
        REFERENCES dbo.tblSeller(SellerID)
);
GO


/* ============================================================
   16. REVIEW TABLE
   ============================================================ */

CREATE TABLE dbo.tblReview
(
    ReviewID INT IDENTITY(1,1) PRIMARY KEY,

    CustomerID INT NOT NULL,
    ProdID INT NOT NULL,

    Rating INT NOT NULL
        CHECK (Rating BETWEEN 1 AND 5),

    Comment NVARCHAR(1000) NULL,

    ReviewDate DATETIME NOT NULL DEFAULT GETDATE(),

    CONSTRAINT FK_Review_Customer
        FOREIGN KEY (CustomerID)
        REFERENCES dbo.tblCustomer(CustomerID),

    CONSTRAINT FK_Review_Product
        FOREIGN KEY (ProdID)
        REFERENCES dbo.tblProduct(ProdID)
);
GO


/* ============================================================
   17. INDEXES
   ============================================================ */

CREATE INDEX IX_Product_Category
ON dbo.tblProduct(CategoryID);
GO

CREATE INDEX IX_Product_Seller
ON dbo.tblProduct(SellerID);
GO

CREATE INDEX IX_Product_Name
ON dbo.tblProduct(ProdName);
GO

CREATE INDEX IX_Cart_Customer
ON dbo.tblCart(CustomerID);
GO

CREATE INDEX IX_Order_Customer
ON dbo.tblCustomerOrder(CustomerID);
GO

CREATE INDEX IX_OrderDetail_Order
ON dbo.tblCustomerOrderDetail(OrderID);
GO


/* ============================================================
   18. ADMIN PROCEDURES
   ============================================================ */

CREATE OR ALTER PROCEDURE dbo.spAdminLogin
    @AdminEmail NVARCHAR(150),
    @AdminPassword NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        AdminID,
        AdminName,
        AdminEmail,
        Phone,
        IsActive
    FROM dbo.tblAdmin
    WHERE AdminEmail = @AdminEmail
      AND AdminPassword = @AdminPassword
      AND IsActive = 1;
END
GO


CREATE OR ALTER PROCEDURE dbo.spInsertAdmin
    @AdminName NVARCHAR(100),
    @AdminEmail NVARCHAR(150),
    @AdminPassword NVARCHAR(255),
    @Phone NVARCHAR(30) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS
    (
        SELECT 1
        FROM dbo.tblAdmin
        WHERE AdminEmail = @AdminEmail
    )
    BEGIN
        SELECT 0 AS Success,
               N'Admin email already exists.' AS Message;
        RETURN;
    END;

    INSERT INTO dbo.tblAdmin
    (
        AdminName,
        AdminEmail,
        AdminPassword,
        Phone
    )
    VALUES
    (
        @AdminName,
        @AdminEmail,
        @AdminPassword,
        @Phone
    );

    SELECT
        1 AS Success,
        N'Admin inserted successfully.' AS Message,
        CAST(SCOPE_IDENTITY() AS INT) AS AdminID;
END
GO


/* ============================================================
   19. SUPER ADMIN PROCEDURES
   ============================================================ */

CREATE OR ALTER PROCEDURE dbo.spSuperAdminLogin
    @SuperAdminEmail NVARCHAR(150),
    @SuperAdminPassword NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        SuperAdminID,
        SuperAdminName,
        SuperAdminEmail,
        IsActive
    FROM dbo.tblSuperAdmin
    WHERE SuperAdminEmail = @SuperAdminEmail
      AND SuperAdminPassword = @SuperAdminPassword
      AND IsActive = 1;
END
GO


/* ============================================================
   20. SELLER PROCEDURES
   ============================================================ */

CREATE OR ALTER PROCEDURE dbo.spSellerRegister
    @SellerName NVARCHAR(100),
    @SellerEmail NVARCHAR(150),
    @SellerPassword NVARCHAR(255),
    @SellerPhone NVARCHAR(30) = NULL,
    @SellerAddress NVARCHAR(300) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS
    (
        SELECT 1
        FROM dbo.tblSeller
        WHERE SellerEmail = @SellerEmail
    )
    BEGIN
        SELECT 0 AS Success,
               N'Seller email already exists.' AS Message;
        RETURN;
    END;

    INSERT INTO dbo.tblSeller
    (
        SellerName,
        SellerEmail,
        SellerPassword,
        SellerPhone,
        SellerAddress
    )
    VALUES
    (
        @SellerName,
        @SellerEmail,
        @SellerPassword,
        @SellerPhone,
        @SellerAddress
    );

    SELECT
        1 AS Success,
        N'Seller registered successfully.' AS Message,
        CAST(SCOPE_IDENTITY() AS INT) AS SellerID;
END
GO


CREATE OR ALTER PROCEDURE dbo.spSellerLogin
    @SellerEmail NVARCHAR(150),
    @SellerPassword NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        SellerID,
        SellerName,
        SellerEmail,
        SellerPhone,
        SellerAddress,
        IsApproved,
        IsActive
    FROM dbo.tblSeller
    WHERE SellerEmail = @SellerEmail
      AND SellerPassword = @SellerPassword
      AND IsActive = 1
      AND IsApproved = 1;
END
GO


CREATE OR ALTER PROCEDURE dbo.spGetAllSeller
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        SellerID,
        SellerName,
        SellerEmail,
        SellerPhone,
        SellerAddress,
        IsApproved,
        IsActive,
        CreatedDate
    FROM dbo.tblSeller
    ORDER BY SellerID DESC;
END
GO


CREATE OR ALTER PROCEDURE dbo.spUpdateSeller
    @SellerID INT,
    @SellerName NVARCHAR(100),
    @SellerPhone NVARCHAR(30),
    @SellerAddress NVARCHAR(300)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.tblSeller
        WHERE SellerID = @SellerID
    )
    BEGIN
        SELECT 0 AS Success,
               N'Seller not found.' AS Message;
        RETURN;
    END;

    UPDATE dbo.tblSeller
    SET
        SellerName = @SellerName,
        SellerPhone = @SellerPhone,
        SellerAddress = @SellerAddress
    WHERE SellerID = @SellerID;

    SELECT
        1 AS Success,
        N'Seller updated successfully.' AS Message;
END
GO


CREATE OR ALTER PROCEDURE dbo.spDeleteSeller
    @SellerID INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.tblSeller
        WHERE SellerID = @SellerID
    )
    BEGIN
        SELECT 0 AS Success,
               N'Seller not found.' AS Message;
        RETURN;
    END;

    UPDATE dbo.tblSeller
    SET IsActive = 0
    WHERE SellerID = @SellerID;

    SELECT
        1 AS Success,
        N'Seller deactivated successfully.' AS Message;
END
GO


/* ============================================================
   21. CATEGORY PROCEDURES
   ============================================================ */

CREATE OR ALTER PROCEDURE dbo.spInsertCategory
    @CategoryName NVARCHAR(100),
    @Description NVARCHAR(500) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS
    (
        SELECT 1
        FROM dbo.tblCategory
        WHERE CategoryName = @CategoryName
    )
    BEGIN
        SELECT 0 AS Success,
               N'Category already exists.' AS Message;
        RETURN;
    END;

    INSERT INTO dbo.tblCategory
    (
        CategoryName,
        Description
    )
    VALUES
    (
        @CategoryName,
        @Description
    );

    SELECT
        1 AS Success,
        N'Category inserted successfully.' AS Message,
        CAST(SCOPE_IDENTITY() AS INT) AS CategoryID;
END
GO


CREATE OR ALTER PROCEDURE dbo.spUpdateCategory
    @CategoryID INT,
    @CategoryName NVARCHAR(100),
    @Description NVARCHAR(500) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.tblCategory
        WHERE CategoryID = @CategoryID
    )
    BEGIN
        SELECT 0 AS Success,
               N'Category not found.' AS Message;
        RETURN;
    END;

    UPDATE dbo.tblCategory
    SET
        CategoryName = @CategoryName,
        Description = @Description
    WHERE CategoryID = @CategoryID;

    SELECT
        1 AS Success,
        N'Category updated successfully.' AS Message;
END
GO


CREATE OR ALTER PROCEDURE dbo.spDeleteCategory
    @CategoryID INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.tblCategory
        WHERE CategoryID = @CategoryID
    )
    BEGIN
        SELECT 0 AS Success,
               N'Category not found.' AS Message;
        RETURN;
    END;

    UPDATE dbo.tblCategory
    SET IsActive = 0
    WHERE CategoryID = @CategoryID;

    SELECT
        1 AS Success,
        N'Category deactivated successfully.' AS Message;
END
GO


CREATE OR ALTER PROCEDURE dbo.spGetAllCategory
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        CategoryID,
        CategoryName,
        Description,
        IsActive,
        CreatedDate
    FROM dbo.tblCategory
    ORDER BY CategoryID DESC;
END
GO


/* ============================================================
   22. PRODUCT PROCEDURES
   ============================================================ */

CREATE OR ALTER PROCEDURE dbo.spInsertProduct
    @ProdName NVARCHAR(200),
    @CategoryID INT,
    @SellerID INT,
    @ProdPrice DECIMAL(18,2),
    @ProdQty INT,
    @ProdDescription NVARCHAR(1000) = NULL,
    @ProdImage NVARCHAR(500) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @ProdQty < 0
    BEGIN
        SELECT 0 AS Success,
               N'Stock quantity cannot be negative.' AS Message;
        RETURN;
    END;

    IF @ProdPrice < 0
    BEGIN
        SELECT 0 AS Success,
               N'Price cannot be negative.' AS Message;
        RETURN;
    END;

    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.tblCategory
        WHERE CategoryID = @CategoryID
          AND IsActive = 1
    )
    BEGIN
        SELECT 0 AS Success,
               N'Invalid category.' AS Message;
        RETURN;
    END;

    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.tblSeller
        WHERE SellerID = @SellerID
          AND IsActive = 1
          AND IsApproved = 1
    )
    BEGIN
        SELECT 0 AS Success,
               N'Invalid or inactive seller.' AS Message;
        RETURN;
    END;

    INSERT INTO dbo.tblProduct
    (
        ProdName,
        CategoryID,
        SellerID,
        ProdPrice,
        ProdQty,
        ProdDescription,
        ProdImage
    )
    VALUES
    (
        @ProdName,
        @CategoryID,
        @SellerID,
        @ProdPrice,
        @ProdQty,
        @ProdDescription,
        @ProdImage
    );

    SELECT
        1 AS Success,
        N'Product inserted successfully.' AS Message,
        CAST(SCOPE_IDENTITY() AS INT) AS ProdID;
END
GO


CREATE OR ALTER PROCEDURE dbo.spUpdateProduct
    @ProdID INT,
    @ProdName NVARCHAR(200),
    @CategoryID INT,
    @ProdPrice DECIMAL(18,2),
    @ProdQty INT,
    @ProdDescription NVARCHAR(1000) = NULL,
    @ProdImage NVARCHAR(500) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @ProdQty < 0
    BEGIN
        SELECT 0 AS Success,
               N'Stock quantity cannot be negative.' AS Message;
        RETURN;
    END;

    IF @ProdPrice < 0
    BEGIN
        SELECT 0 AS Success,
               N'Price cannot be negative.' AS Message;
        RETURN;
    END;

    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.tblProduct
        WHERE ProdID = @ProdID
    )
    BEGIN
        SELECT 0 AS Success,
               N'Product not found.' AS Message;
        RETURN;
    END;

    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.tblCategory
        WHERE CategoryID = @CategoryID
          AND IsActive = 1
    )
    BEGIN
        SELECT 0 AS Success,
               N'Invalid category.' AS Message;
        RETURN;
    END;

    UPDATE dbo.tblProduct
    SET
        ProdName = @ProdName,
        CategoryID = @CategoryID,
        ProdPrice = @ProdPrice,
        ProdQty = @ProdQty,
        ProdDescription = @ProdDescription,
        ProdImage = @ProdImage
    WHERE ProdID = @ProdID;

    SELECT
        1 AS Success,
        N'Product updated successfully.' AS Message;
END
GO


CREATE OR ALTER PROCEDURE dbo.spRestockProduct
    @ProdID INT,
    @AddQty INT
AS
BEGIN
    SET NOCOUNT ON;

    IF @AddQty <= 0
    BEGIN
        SELECT 0 AS Success,
               N'Restock quantity must be greater than 0.' AS Message;
        RETURN;
    END;

    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.tblProduct
        WHERE ProdID = @ProdID
    )
    BEGIN
        SELECT 0 AS Success,
               N'Product not found.' AS Message;
        RETURN;
    END;

    UPDATE dbo.tblProduct
    SET ProdQty = ProdQty + @AddQty
    WHERE ProdID = @ProdID;

    SELECT
        1 AS Success,
        N'Product restocked successfully.' AS Message,
        ProdID,
        ProdName,
        ProdQty AS CurrentStock
    FROM dbo.tblProduct
    WHERE ProdID = @ProdID;
END
GO


CREATE OR ALTER PROCEDURE dbo.spSetProductStock
    @ProdID INT,
    @NewQty INT
AS
BEGIN
    SET NOCOUNT ON;

    IF @NewQty < 0
    BEGIN
        SELECT 0 AS Success,
               N'Stock cannot be negative.' AS Message;
        RETURN;
    END;

    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.tblProduct
        WHERE ProdID = @ProdID
    )
    BEGIN
        SELECT 0 AS Success,
               N'Product not found.' AS Message;
        RETURN;
    END;

    UPDATE dbo.tblProduct
    SET ProdQty = @NewQty
    WHERE ProdID = @ProdID;

    SELECT
        1 AS Success,
        N'Stock updated successfully.' AS Message,
        ProdID,
        ProdName,
        ProdQty AS CurrentStock
    FROM dbo.tblProduct
    WHERE ProdID = @ProdID;
END
GO


CREATE OR ALTER PROCEDURE dbo.spDeleteProduct
    @ProdID INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.tblProduct
        WHERE ProdID = @ProdID
    )
    BEGIN
        SELECT 0 AS Success,
               N'Product not found.' AS Message;
        RETURN;
    END;

    UPDATE dbo.tblProduct
    SET IsActive = 0
    WHERE ProdID = @ProdID;

    SELECT
        1 AS Success,
        N'Product deactivated successfully.' AS Message;
END
GO


CREATE OR ALTER PROCEDURE dbo.spGetAllProductList
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        p.ProdID,
        p.ProdName,
        p.CategoryID,
        c.CategoryName,
        p.SellerID,
        s.SellerName,
        p.ProdPrice,
        p.ProdQty,
        p.ProdDescription,
        p.ProdImage,
        p.IsActive,

        CASE
            WHEN p.ProdQty <= 0 THEN N'Out of Stock'
            WHEN p.ProdQty <= 5 THEN N'Low Stock'
            ELSE N'In Stock'
        END AS StockStatus,

        CASE
            WHEN p.IsActive = 1
             AND p.ProdQty > 0
            THEN 1
            ELSE 0
        END AS CanAddToCart,

        p.CreatedDate

    FROM dbo.tblProduct AS p

    INNER JOIN dbo.tblCategory AS c
        ON p.CategoryID = c.CategoryID

    INNER JOIN dbo.tblSeller AS s
        ON p.SellerID = s.SellerID

    WHERE p.IsActive = 1

    ORDER BY p.ProdID DESC;
END
GO


CREATE OR ALTER PROCEDURE dbo.spSearchProduct
    @Search NVARCHAR(200)
AS
BEGIN
    SET NOCOUNT ON;

    SET @Search = ISNULL(@Search, N'');

    SELECT
        p.ProdID,
        p.ProdName,
        c.CategoryName,
        s.SellerName,
        p.ProdPrice,
        p.ProdQty,
        p.ProdDescription,
        p.ProdImage,

        CASE
            WHEN p.ProdQty <= 0 THEN N'Out of Stock'
            WHEN p.ProdQty <= 5 THEN N'Low Stock'
            ELSE N'In Stock'
        END AS StockStatus,

        CASE
            WHEN p.IsActive = 1
             AND p.ProdQty > 0
            THEN 1
            ELSE 0
        END AS CanAddToCart

    FROM dbo.tblProduct AS p

    INNER JOIN dbo.tblCategory AS c
        ON p.CategoryID = c.CategoryID

    INNER JOIN dbo.tblSeller AS s
        ON p.SellerID = s.SellerID

    WHERE p.IsActive = 1
      AND
      (
            p.ProdName LIKE N'%' + @Search + N'%'
         OR p.ProdDescription LIKE N'%' + @Search + N'%'
         OR c.CategoryName LIKE N'%' + @Search + N'%'
         OR s.SellerName LIKE N'%' + @Search + N'%'
      )

    ORDER BY p.ProdName;
END
GO


CREATE OR ALTER PROCEDURE dbo.spGetAllProductList_SearchbyCat
    @CategoryID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        p.ProdID,
        p.ProdName,
        c.CategoryName,
        s.SellerName,
        p.ProdPrice,
        p.ProdQty,
        p.ProdDescription,
        p.ProdImage,

        CASE
            WHEN p.ProdQty <= 0 THEN N'Out of Stock'
            WHEN p.ProdQty <= 5 THEN N'Low Stock'
            ELSE N'In Stock'
        END AS StockStatus,

        CASE
            WHEN p.IsActive = 1
             AND p.ProdQty > 0
            THEN 1
            ELSE 0
        END AS CanAddToCart

    FROM dbo.tblProduct AS p

    INNER JOIN dbo.tblCategory AS c
        ON p.CategoryID = c.CategoryID

    INNER JOIN dbo.tblSeller AS s
        ON p.SellerID = s.SellerID

    WHERE p.CategoryID = @CategoryID
      AND p.IsActive = 1

    ORDER BY p.ProdID DESC;
END
GO


CREATE OR ALTER PROCEDURE dbo.spGetProductByID
    @ProdID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        p.ProdID,
        p.ProdName,
        p.CategoryID,
        p.SellerID,
        p.ProdPrice,
        p.ProdQty,
        p.ProdDescription,
        p.ProdImage,
        p.IsActive,
        p.CreatedDate,
        c.CategoryName,
        s.SellerName,

        CASE
            WHEN p.ProdQty <= 0 THEN N'Out of Stock'
            WHEN p.ProdQty <= 5 THEN N'Low Stock'
            ELSE N'In Stock'
        END AS StockStatus,

        CASE
            WHEN p.IsActive = 1
             AND p.ProdQty > 0
            THEN 1
            ELSE 0
        END AS CanAddToCart

    FROM dbo.tblProduct AS p

    INNER JOIN dbo.tblCategory AS c
        ON p.CategoryID = c.CategoryID

    INNER JOIN dbo.tblSeller AS s
        ON p.SellerID = s.SellerID

    WHERE p.ProdID = @ProdID;
END
GO


/* ============================================================
   23. CUSTOMER PROCEDURES
   ============================================================ */

CREATE OR ALTER PROCEDURE dbo.spCustomerRegister
    @CustomerName NVARCHAR(100),
    @CustomerEmail NVARCHAR(150),
    @CustomerPassword NVARCHAR(255),
    @CustomerPhone NVARCHAR(30) = NULL,
    @CustomerAddress NVARCHAR(300) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS
    (
        SELECT 1
        FROM dbo.tblCustomer
        WHERE CustomerEmail = @CustomerEmail
    )
    BEGIN
        SELECT 0 AS Success,
               N'Customer email already exists.' AS Message;
        RETURN;
    END;

    INSERT INTO dbo.tblCustomer
    (
        CustomerName,
        CustomerEmail,
        CustomerPassword,
        CustomerPhone,
        CustomerAddress
    )
    VALUES
    (
        @CustomerName,
        @CustomerEmail,
        @CustomerPassword,
        @CustomerPhone,
        @CustomerAddress
    );

    SELECT
        1 AS Success,
        N'Customer registered successfully.' AS Message,
        CAST(SCOPE_IDENTITY() AS INT) AS CustomerID;
END
GO


CREATE OR ALTER PROCEDURE dbo.spCustomerLogin
    @CustomerEmail NVARCHAR(150),
    @CustomerPassword NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        CustomerID,
        CustomerName,
        CustomerEmail,
        CustomerPhone,
        CustomerAddress,
        IsActive
    FROM dbo.tblCustomer
    WHERE CustomerEmail = @CustomerEmail
      AND CustomerPassword = @CustomerPassword
      AND IsActive = 1;
END
GO


CREATE OR ALTER PROCEDURE dbo.spUpdateCustomer
    @CustomerID INT,
    @CustomerName NVARCHAR(100),
    @CustomerPhone NVARCHAR(30),
    @CustomerAddress NVARCHAR(300)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.tblCustomer
        WHERE CustomerID = @CustomerID
    )
    BEGIN
        SELECT 0 AS Success,
               N'Customer not found.' AS Message;
        RETURN;
    END;

    UPDATE dbo.tblCustomer
    SET
        CustomerName = @CustomerName,
        CustomerPhone = @CustomerPhone,
        CustomerAddress = @CustomerAddress
    WHERE CustomerID = @CustomerID;

    SELECT
        1 AS Success,
        N'Customer updated successfully.' AS Message;
END
GO


/* ============================================================
   24. SELLER REQUEST PROCEDURES
   ============================================================ */

CREATE OR ALTER PROCEDURE dbo.spCreateSellerRequest
    @SellerID INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.tblSeller
        WHERE SellerID = @SellerID
    )
    BEGIN
        SELECT 0 AS Success,
               N'Seller not found.' AS Message;
        RETURN;
    END;

    IF EXISTS
    (
        SELECT 1
        FROM dbo.tblSellerRequest
        WHERE SellerID = @SellerID
          AND RequestStatus = N'Pending'
    )
    BEGIN
        SELECT 0 AS Success,
               N'A pending request already exists.' AS Message;
        RETURN;
    END;

    INSERT INTO dbo.tblSellerRequest
    (
        SellerID
    )
    VALUES
    (
        @SellerID
    );

    SELECT
        1 AS Success,
        N'Seller request submitted successfully.' AS Message;
END
GO


CREATE OR ALTER PROCEDURE dbo.spGetSellerRequests
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        r.RequestID,
        r.SellerID,
        s.SellerName,
        s.SellerEmail,
        s.SellerPhone,
        r.RequestDate,
        r.RequestStatus,
        r.ApprovedBy,
        r.ApprovedDate
    FROM dbo.tblSellerRequest AS r

    INNER JOIN dbo.tblSeller AS s
        ON r.SellerID = s.SellerID

    ORDER BY r.RequestID DESC;
END
GO


CREATE OR ALTER PROCEDURE dbo.spApproveSellerRequest
    @RequestID INT,
    @AdminID INT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRY

        BEGIN TRANSACTION;

        DECLARE @SellerID INT;

        IF NOT EXISTS
        (
            SELECT 1
            FROM dbo.tblAdmin
            WHERE AdminID = @AdminID
              AND IsActive = 1
        )
        BEGIN
            ROLLBACK TRANSACTION;

            SELECT 0 AS Success,
                   N'Admin not found or inactive.' AS Message;
            RETURN;
        END;

        SELECT
            @SellerID = SellerID
        FROM dbo.tblSellerRequest
        WHERE RequestID = @RequestID
          AND RequestStatus = N'Pending';

        IF @SellerID IS NULL
        BEGIN
            ROLLBACK TRANSACTION;

            SELECT 0 AS Success,
                   N'Pending seller request not found.' AS Message;
            RETURN;
        END;

        UPDATE dbo.tblSellerRequest
        SET
            RequestStatus = N'Approved',
            ApprovedBy = @AdminID,
            ApprovedDate = GETDATE()
        WHERE RequestID = @RequestID;

        UPDATE dbo.tblSeller
        SET
            IsApproved = 1,
            IsActive = 1
        WHERE SellerID = @SellerID;

        COMMIT TRANSACTION;

        SELECT
            1 AS Success,
            N'Seller approved successfully.' AS Message;

    END TRY
    BEGIN CATCH

        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        SELECT
            0 AS Success,
            ERROR_MESSAGE() AS Message;

    END CATCH
END
GO


CREATE OR ALTER PROCEDURE dbo.spRejectSellerRequest
    @RequestID INT,
    @AdminID INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.tblAdmin
        WHERE AdminID = @AdminID
          AND IsActive = 1
    )
    BEGIN
        SELECT 0 AS Success,
               N'Admin not found or inactive.' AS Message;
        RETURN;
    END;

    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.tblSellerRequest
        WHERE RequestID = @RequestID
          AND RequestStatus = N'Pending'
    )
    BEGIN
        SELECT 0 AS Success,
               N'Pending seller request not found.' AS Message;
        RETURN;
    END;

    UPDATE dbo.tblSellerRequest
    SET
        RequestStatus = N'Rejected',
        ApprovedBy = @AdminID,
        ApprovedDate = GETDATE()
    WHERE RequestID = @RequestID;

    SELECT
        1 AS Success,
        N'Seller request rejected.' AS Message;
END
GO


/* ============================================================
   25. OFFER PROCEDURES
   DUPLICATE OFFER SECTION REMOVED
   ============================================================ */

CREATE OR ALTER PROCEDURE dbo.spInsertOffer
    @OfferTitle NVARCHAR(200),
    @DiscountPercent DECIMAL(5,2),
    @StartDate DATETIME,
    @EndDate DATETIME
AS
BEGIN
    SET NOCOUNT ON;

    IF @OfferTitle IS NULL
       OR LTRIM(RTRIM(@OfferTitle)) = N''
    BEGIN
        SELECT 0 AS Success,
               N'Offer title is required.' AS Message;
        RETURN;
    END;

    IF @DiscountPercent < 0
       OR @DiscountPercent > 100
    BEGIN
        SELECT 0 AS Success,
               N'Discount must be between 0 and 100.' AS Message;
        RETURN;
    END;

    IF @EndDate < @StartDate
    BEGIN
        SELECT 0 AS Success,
               N'End date cannot be before start date.' AS Message;
        RETURN;
    END;

    INSERT INTO dbo.tblOffer
    (
        OfferTitle,
        DiscountPercent,
        StartDate,
        EndDate,
        IsActive
    )
    VALUES
    (
        @OfferTitle,
        @DiscountPercent,
        @StartDate,
        @EndDate,
        1
    );

    SELECT
        1 AS Success,
        N'Offer created successfully.' AS Message,
        CAST(SCOPE_IDENTITY() AS INT) AS OfferID;
END
GO


CREATE OR ALTER PROCEDURE dbo.spGetActiveOffers
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        OfferID,
        OfferTitle,
        DiscountPercent,
        StartDate,
        EndDate,
        IsActive
    FROM dbo.tblOffer
    WHERE IsActive = 1
      AND StartDate <= GETDATE()
      AND EndDate >= GETDATE()
    ORDER BY StartDate DESC,
             OfferID DESC;
END
GO


CREATE OR ALTER PROCEDURE dbo.spGetOfferDetails
    @OfferID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        OfferID,
        OfferTitle,
        DiscountPercent,
        StartDate,
        EndDate,
        IsActive
    FROM dbo.tblOffer
    WHERE OfferID = @OfferID;
END
GO


CREATE OR ALTER PROCEDURE dbo.spTakeCustomerOffer
    @CustomerID INT,
    @OfferID INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.tblCustomer
        WHERE CustomerID = @CustomerID
          AND IsActive = 1
    )
    BEGIN
        SELECT 0 AS Success,
               N'Customer not found.' AS Message;
        RETURN;
    END;

    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.tblOffer
        WHERE OfferID = @OfferID
          AND IsActive = 1
          AND StartDate <= GETDATE()
          AND EndDate >= GETDATE()
    )
    BEGIN
        SELECT 0 AS Success,
               N'Offer is not active.' AS Message;
        RETURN;
    END;

    IF EXISTS
    (
        SELECT 1
        FROM dbo.tblCustomerOffer
        WHERE CustomerID = @CustomerID
          AND OfferID = @OfferID
    )
    BEGIN
        SELECT 0 AS Success,
               N'Customer already has this offer.' AS Message;
        RETURN;
    END;

    INSERT INTO dbo.tblCustomerOffer
    (
        CustomerID,
        OfferID
    )
    VALUES
    (
        @CustomerID,
        @OfferID
    );

    SELECT
        1 AS Success,
        N'Offer added to customer successfully.' AS Message;
END
GO


CREATE OR ALTER PROCEDURE dbo.spGetCustomerOffers
    @CustomerID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        co.CustomerOfferID,
        co.CustomerID,
        o.OfferID,
        o.OfferTitle,
        o.DiscountPercent,
        o.StartDate,
        o.EndDate,
        co.TakenDate,
        co.IsUsed
    FROM dbo.tblCustomerOffer AS co

    INNER JOIN dbo.tblOffer AS o
        ON co.OfferID = o.OfferID

    WHERE co.CustomerID = @CustomerID

    ORDER BY co.CustomerOfferID DESC;
END
GO


/* ============================================================
   26. CART PROCEDURES
   ============================================================ */

CREATE OR ALTER PROCEDURE dbo.spAddToCart
    @CustomerID INT,
    @ProdID INT,
    @Quantity INT
AS
BEGIN
    SET NOCOUNT ON;

    IF @Quantity <= 0
    BEGIN
        SELECT 0 AS Success,
               N'Quantity must be greater than 0.' AS Message;
        RETURN;
    END;

    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.tblCustomer
        WHERE CustomerID = @CustomerID
          AND IsActive = 1
    )
    BEGIN
        SELECT 0 AS Success,
               N'Customer not found or inactive.' AS Message;
        RETURN;
    END;

    DECLARE
        @Stock INT,
        @IsActive BIT,
        @CurrentCartQty INT;

    SET @CurrentCartQty = 0;

    SELECT
        @Stock = ProdQty,
        @IsActive = IsActive
    FROM dbo.tblProduct
    WHERE ProdID = @ProdID;

    IF @Stock IS NULL
    BEGIN
        SELECT 0 AS Success,
               N'Product not found.' AS Message;
        RETURN;
    END;

    IF @IsActive = 0
    BEGIN
        SELECT 0 AS Success,
               N'Product is inactive.' AS Message;
        RETURN;
    END;

    IF @Stock <= 0
    BEGIN
        SELECT
            0 AS Success,
            N'Product is out of stock.' AS Message,
            0 AS AvailableStock;
        RETURN;
    END;

    SELECT
        @CurrentCartQty = ISNULL(Quantity, 0)
    FROM dbo.tblCart
    WHERE CustomerID = @CustomerID
      AND ProdID = @ProdID;

    IF @CurrentCartQty + @Quantity > @Stock
    BEGIN
        SELECT
            0 AS Success,
            N'Requested quantity is greater than available stock.' AS Message,
            @Stock AS AvailableStock,
            @CurrentCartQty AS CurrentCartQuantity;
        RETURN;
    END;

    IF EXISTS
    (
        SELECT 1
        FROM dbo.tblCart
        WHERE CustomerID = @CustomerID
          AND ProdID = @ProdID
    )
    BEGIN
        UPDATE dbo.tblCart
        SET Quantity = Quantity + @Quantity
        WHERE CustomerID = @CustomerID
          AND ProdID = @ProdID;
    END
    ELSE
    BEGIN
        INSERT INTO dbo.tblCart
        (
            CustomerID,
            ProdID,
            Quantity
        )
        VALUES
        (
            @CustomerID,
            @ProdID,
            @Quantity
        );
    END;

    SELECT
        1 AS Success,
        N'Product added to cart successfully.' AS Message,
        @Stock - (@CurrentCartQty + @Quantity) AS RemainingStock;
END
GO


CREATE OR ALTER PROCEDURE dbo.spGetCart
    @CustomerID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        c.CartID,
        c.CustomerID,
        c.ProdID,
        p.ProdName,
        p.ProdPrice,
        c.Quantity,
        p.ProdQty AS AvailableStock,
        c.Quantity * p.ProdPrice AS SubTotal,

        CASE
            WHEN p.ProdQty <= 0
                THEN N'Out of Stock'
            WHEN c.Quantity > p.ProdQty
                THEN N'Insufficient Stock'
            WHEN p.ProdQty <= 5
                THEN N'Low Stock'
            ELSE N'In Stock'
        END AS StockStatus,

        CASE
            WHEN p.IsActive = 1
             AND p.ProdQty >= c.Quantity
                THEN 1
            ELSE 0
        END AS CanCheckout

    FROM dbo.tblCart AS c

    INNER JOIN dbo.tblProduct AS p
        ON c.ProdID = p.ProdID

    WHERE c.CustomerID = @CustomerID

    ORDER BY c.CartID DESC;
END
GO


CREATE OR ALTER PROCEDURE dbo.spUpdateCartQuantity
    @CustomerID INT,
    @ProdID INT,
    @Quantity INT
AS
BEGIN
    SET NOCOUNT ON;

    IF @Quantity <= 0
    BEGIN
        SELECT 0 AS Success,
               N'Quantity must be greater than 0.' AS Message;
        RETURN;
    END;

    DECLARE
        @Stock INT,
        @IsActive BIT;

    SELECT
        @Stock = ProdQty,
        @IsActive = IsActive
    FROM dbo.tblProduct
    WHERE ProdID = @ProdID;

    IF @Stock IS NULL
    BEGIN
        SELECT 0 AS Success,
               N'Product not found.' AS Message;
        RETURN;
    END;

    IF @IsActive = 0
    BEGIN
        SELECT 0 AS Success,
               N'Product is inactive.' AS Message;
        RETURN;
    END;

    IF @Stock <= 0
    BEGIN
        SELECT 0 AS Success,
               N'Product is out of stock.' AS Message;
        RETURN;
    END;

    IF @Quantity > @Stock
    BEGIN
        SELECT
            0 AS Success,
            N'Requested quantity is greater than available stock.' AS Message,
            @Stock AS AvailableStock;
        RETURN;
    END;

    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.tblCart
        WHERE CustomerID = @CustomerID
          AND ProdID = @ProdID
    )
    BEGIN
        SELECT 0 AS Success,
               N'Product is not in cart.' AS Message;
        RETURN;
    END;

    UPDATE dbo.tblCart
    SET Quantity = @Quantity
    WHERE CustomerID = @CustomerID
      AND ProdID = @ProdID;

    SELECT
        1 AS Success,
        N'Cart quantity updated successfully.' AS Message,
        @Quantity AS Quantity,
        @Stock AS AvailableStock;
END
GO


CREATE OR ALTER PROCEDURE dbo.spRemoveFromCart
    @CustomerID INT,
    @ProdID INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM dbo.tblCart
    WHERE CustomerID = @CustomerID
      AND ProdID = @ProdID;

    SELECT
        1 AS Success,
        N'Product removed from cart.' AS Message;
END
GO


CREATE OR ALTER PROCEDURE dbo.spClearCart
    @CustomerID INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM dbo.tblCart
    WHERE CustomerID = @CustomerID;

    SELECT
        1 AS Success,
        N'Cart cleared successfully.' AS Message;
END
GO


/* ============================================================
   27. CHECKOUT PROCEDURE
   ============================================================ */

CREATE OR ALTER PROCEDURE dbo.spCheckout
    @CustomerID INT,
    @PaymentMethod NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    DECLARE
        @OrderID INT,
        @TotalAmount DECIMAL(18,2);

    IF @PaymentMethod IS NULL
       OR LTRIM(RTRIM(@PaymentMethod)) = N''
    BEGIN
        SELECT
            0 AS Success,
            N'Payment method is required.' AS Message;
        RETURN;
    END;

    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.tblCustomer
        WHERE CustomerID = @CustomerID
          AND IsActive = 1
    )
    BEGIN
        SELECT
            0 AS Success,
            N'Customer not found or inactive.' AS Message;
        RETURN;
    END;

    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.tblCart
        WHERE CustomerID = @CustomerID
    )
    BEGIN
        SELECT
            0 AS Success,
            N'Cart is empty.' AS Message;
        RETURN;
    END;

    BEGIN TRY

        BEGIN TRANSACTION;

        /* Lock product rows while checking stock */
        IF EXISTS
        (
            SELECT 1
            FROM dbo.tblCart AS c
            INNER JOIN dbo.tblProduct AS p WITH (UPDLOCK, HOLDLOCK)
                ON c.ProdID = p.ProdID
            WHERE c.CustomerID = @CustomerID
              AND
              (
                    p.IsActive = 0
                 OR p.ProdQty <= 0
                 OR p.ProdQty < c.Quantity
              )
        )
        BEGIN
            ROLLBACK TRANSACTION;

            SELECT
                0 AS Success,
                N'One or more products are out of stock or have insufficient stock.' AS Message;
            RETURN;
        END;

        SELECT
            @TotalAmount =
                SUM(c.Quantity * p.ProdPrice)
        FROM dbo.tblCart AS c
        INNER JOIN dbo.tblProduct AS p
            ON c.ProdID = p.ProdID
        WHERE c.CustomerID = @CustomerID;

        IF @TotalAmount IS NULL
        BEGIN
            ROLLBACK TRANSACTION;

            SELECT
                0 AS Success,
                N'Unable to calculate order total.' AS Message;
            RETURN;
        END;

        INSERT INTO dbo.tblCustomerOrder
        (
            CustomerID,
            TotalAmount,
            PaymentMethod,
            PaymentStatus,
            OrderStatus
        )
        VALUES
        (
            @CustomerID,
            @TotalAmount,
            @PaymentMethod,

            CASE
                WHEN LTRIM(RTRIM(@PaymentMethod)) =
                     N'Cash on Delivery'
                    THEN N'Pending'
                ELSE N'Paid'
            END,

            N'Confirmed'
        );

        SET @OrderID = CAST(SCOPE_IDENTITY() AS INT);

        INSERT INTO dbo.tblCustomerOrderDetail
        (
            OrderID,
            ProdID,
            SellerID,
            Quantity,
            UnitPrice
        )
        SELECT
            @OrderID,
            c.ProdID,
            p.SellerID,
            c.Quantity,
            p.ProdPrice
        FROM dbo.tblCart AS c
        INNER JOIN dbo.tblProduct AS p
            ON c.ProdID = p.ProdID
        WHERE c.CustomerID = @CustomerID;

        UPDATE p
        SET p.ProdQty = p.ProdQty - c.Quantity
        FROM dbo.tblProduct AS p
        INNER JOIN dbo.tblCart AS c
            ON p.ProdID = c.ProdID
        WHERE c.CustomerID = @CustomerID;

        /* Commission = 10% per seller */
        INSERT INTO dbo.tblCommission
        (
            OrderID,
            SellerID,
            CommissionRate,
            CommissionAmount
        )
        SELECT
            od.OrderID,
            od.SellerID,
            10.00,
            SUM(od.LineTotal) * 0.10
        FROM dbo.tblCustomerOrderDetail AS od
        WHERE od.OrderID = @OrderID
        GROUP BY
            od.OrderID,
            od.SellerID;

        /* Seller bill */
        INSERT INTO dbo.tblBill
        (
            OrderID,
            SellerID,
            BillAmount,
            PaymentStatus
        )
        SELECT
            od.OrderID,
            od.SellerID,
            SUM(od.LineTotal),
            N'Pending'
        FROM dbo.tblCustomerOrderDetail AS od
        WHERE od.OrderID = @OrderID
        GROUP BY
            od.OrderID,
            od.SellerID;

        DELETE FROM dbo.tblCart
        WHERE CustomerID = @CustomerID;

        COMMIT TRANSACTION;

        SELECT
            1 AS Success,
            N'Order placed successfully.' AS Message,
            @OrderID AS OrderID,
            @TotalAmount AS TotalAmount;

    END TRY
    BEGIN CATCH

        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        SELECT
            0 AS Success,
            ERROR_MESSAGE() AS Message;

    END CATCH
END
GO


/* ============================================================
   28. ORDER PROCEDURES
   ============================================================ */

/* CUSTOMER ORDERS
   ONLY @CustomerID
*/

CREATE OR ALTER PROCEDURE dbo.spGetCustomerOrders
    @CustomerID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        o.OrderID,
        o.CustomerID,
        o.OrderDate,
        o.TotalAmount,
        o.PaymentMethod,
        o.PaymentStatus,
        o.OrderStatus
    FROM dbo.tblCustomerOrder AS o
    WHERE o.CustomerID = @CustomerID
    ORDER BY o.OrderID DESC;
END
GO


/* ============================================================
   ORDER DETAILS
   IMPORTANT:
   ONLY @OrderID
   ============================================================ */

CREATE OR ALTER PROCEDURE dbo.spOrderDetails
    @OrderID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        od.OrderDetailID,
        od.OrderID,
        od.ProdID,
        p.ProdName,
        od.SellerID,
        s.SellerName,
        od.Quantity,
        od.UnitPrice,
        od.LineTotal
    FROM dbo.tblCustomerOrderDetail AS od

    INNER JOIN dbo.tblProduct AS p
        ON od.ProdID = p.ProdID

    INNER JOIN dbo.tblSeller AS s
        ON od.SellerID = s.SellerID

    WHERE od.OrderID = @OrderID

    ORDER BY od.OrderDetailID;
END
GO


/* ============================================================
   COMPATIBILITY PROCEDURE
   IMPORTANT:
   ONLY @OrderID
   ============================================================ */

CREATE OR ALTER PROCEDURE dbo.spGetOrderDetails
    @OrderID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        od.OrderDetailID,
        od.OrderID,
        od.ProdID,
        p.ProdName,
        od.SellerID,
        s.SellerName,
        od.Quantity,
        od.UnitPrice,
        od.LineTotal
    FROM dbo.tblCustomerOrderDetail AS od

    INNER JOIN dbo.tblProduct AS p
        ON od.ProdID = p.ProdID

    INNER JOIN dbo.tblSeller AS s
        ON od.SellerID = s.SellerID

    WHERE od.OrderID = @OrderID

    ORDER BY od.OrderDetailID;
END
GO


/* ============================================================
   GET ALL ORDERS
   NO PARAMETERS
   ============================================================ */

CREATE OR ALTER PROCEDURE dbo.spGetAllOrders
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        o.OrderID,
        o.OrderDate,
        c.CustomerID,
        c.CustomerName,
        c.CustomerEmail,
        o.TotalAmount,
        o.PaymentMethod,
        o.PaymentStatus,
        o.OrderStatus
    FROM dbo.tblCustomerOrder AS o

    INNER JOIN dbo.tblCustomer AS c
        ON o.CustomerID = c.CustomerID

    ORDER BY o.OrderID DESC;
END
GO


/* ============================================================
   UPDATE ORDER STATUS
   ============================================================ */

CREATE OR ALTER PROCEDURE dbo.spUpdateOrderStatus
    @OrderID INT,
    @OrderStatus NVARCHAR(30)
AS
BEGIN
    SET NOCOUNT ON;

    IF @OrderStatus NOT IN
    (
        N'Pending',
        N'Confirmed',
        N'Processing',
        N'Shipped',
        N'Delivered',
        N'Cancelled'
    )
    BEGIN
        SELECT
            0 AS Success,
            N'Invalid order status.' AS Message;
        RETURN;
    END;

    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.tblCustomerOrder
        WHERE OrderID = @OrderID
    )
    BEGIN
        SELECT
            0 AS Success,
            N'Order not found.' AS Message;
        RETURN;
    END;

    UPDATE dbo.tblCustomerOrder
    SET OrderStatus = @OrderStatus
    WHERE OrderID = @OrderID;

    SELECT
        1 AS Success,
        N'Order status updated successfully.' AS Message;
END
GO


/* ============================================================
   29. PAYMENT
   ============================================================ */

CREATE OR ALTER PROCEDURE dbo.spUpdatePaymentStatus
    @OrderID INT,
    @PaymentStatus NVARCHAR(30)
AS
BEGIN
    SET NOCOUNT ON;

    IF @PaymentStatus NOT IN
    (
        N'Pending',
        N'Paid',
        N'Failed',
        N'Refunded'
    )
    BEGIN
        SELECT
            0 AS Success,
            N'Invalid payment status.' AS Message;
        RETURN;
    END;

    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.tblCustomerOrder
        WHERE OrderID = @OrderID
    )
    BEGIN
        SELECT
            0 AS Success,
            N'Order not found.' AS Message;
        RETURN;
    END;

    UPDATE dbo.tblCustomerOrder
    SET PaymentStatus = @PaymentStatus
    WHERE OrderID = @OrderID;

    SELECT
        1 AS Success,
        N'Payment status updated successfully.' AS Message;
END
GO


/* ============================================================
   30. SELLER PRODUCT PROCEDURE
   ============================================================ */

CREATE OR ALTER PROCEDURE dbo.spGetSellerProducts
    @SellerID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        p.ProdID,
        p.ProdName,
        c.CategoryName,
        p.ProdPrice,
        p.ProdQty,

        CASE
            WHEN p.ProdQty <= 0
                THEN N'Out of Stock'
            WHEN p.ProdQty <= 5
                THEN N'Low Stock'
            ELSE N'In Stock'
        END AS StockStatus,

        p.IsActive,
        p.CreatedDate

    FROM dbo.tblProduct AS p

    INNER JOIN dbo.tblCategory AS c
        ON p.CategoryID = c.CategoryID

    WHERE p.SellerID = @SellerID

    ORDER BY p.ProdID DESC;
END
GO


/* ============================================================
   31. SELLER ORDERS
   ============================================================ */

CREATE OR ALTER PROCEDURE dbo.spGetSellerOrders
    @SellerID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        o.OrderID,
        o.OrderDate,
        c.CustomerName,
        c.CustomerPhone,
        c.CustomerAddress,

        od.ProdID,
        p.ProdName,

        od.Quantity,
        od.UnitPrice,
        od.LineTotal,

        o.PaymentMethod,
        o.PaymentStatus,
        o.OrderStatus

    FROM dbo.tblCustomerOrderDetail AS od

    INNER JOIN dbo.tblCustomerOrder AS o
        ON od.OrderID = o.OrderID

    INNER JOIN dbo.tblCustomer AS c
        ON o.CustomerID = c.CustomerID

    INNER JOIN dbo.tblProduct AS p
        ON od.ProdID = p.ProdID

    WHERE od.SellerID = @SellerID

    ORDER BY o.OrderID DESC;
END
GO


/* ============================================================
   32. SELLER BILL
   ============================================================ */

CREATE OR ALTER PROCEDURE dbo.spGetSellerBills
    @SellerID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        b.BillID,
        b.OrderID,
        b.SellerID,
        s.SellerName,
        b.BillAmount,
        b.BillDate,
        b.PaymentStatus

    FROM dbo.tblBill AS b

    INNER JOIN dbo.tblSeller AS s
        ON b.SellerID = s.SellerID

    WHERE b.SellerID = @SellerID

    ORDER BY b.BillID DESC;
END
GO


CREATE OR ALTER PROCEDURE dbo.spUpdateBillPaymentStatus
    @BillID INT,
    @PaymentStatus NVARCHAR(30)
AS
BEGIN
    SET NOCOUNT ON;

    IF @PaymentStatus NOT IN
    (
        N'Pending',
        N'Paid',
        N'Cancelled'
    )
    BEGIN
        SELECT
            0 AS Success,
            N'Invalid bill payment status.' AS Message;
        RETURN;
    END;

    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.tblBill
        WHERE BillID = @BillID
    )
    BEGIN
        SELECT
            0 AS Success,
            N'Bill not found.' AS Message;
        RETURN;
    END;

    UPDATE dbo.tblBill
    SET PaymentStatus = @PaymentStatus
    WHERE BillID = @BillID;

    SELECT
        1 AS Success,
        N'Bill payment status updated successfully.' AS Message;
END
GO


/* ============================================================
   33. REVIEW PROCEDURES
   ============================================================ */

CREATE OR ALTER PROCEDURE dbo.spAddReview
    @CustomerID INT,
    @ProdID INT,
    @Rating INT,
    @Comment NVARCHAR(1000) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @Rating < 1 OR @Rating > 5
    BEGIN
        SELECT
            0 AS Success,
            N'Rating must be between 1 and 5.' AS Message;
        RETURN;
    END;

    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.tblCustomer
        WHERE CustomerID = @CustomerID
          AND IsActive = 1
    )
    BEGIN
        SELECT
            0 AS Success,
            N'Customer not found.' AS Message;
        RETURN;
    END;

    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.tblProduct
        WHERE ProdID = @ProdID
    )
    BEGIN
        SELECT
            0 AS Success,
            N'Product not found.' AS Message;
        RETURN;
    END;

    INSERT INTO dbo.tblReview
    (
        CustomerID,
        ProdID,
        Rating,
        Comment
    )
    VALUES
    (
        @CustomerID,
        @ProdID,
        @Rating,
        @Comment
    );

    SELECT
        1 AS Success,
        N'Review added successfully.' AS Message;
END
GO


CREATE OR ALTER PROCEDURE dbo.spGetProductReviews
    @ProdID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        r.ReviewID,
        r.CustomerID,
        c.CustomerName,
        r.ProdID,
        p.SellerID,
        r.Rating,
        r.Comment,
        r.ReviewDate

    FROM dbo.tblReview AS r

    INNER JOIN dbo.tblCustomer AS c
        ON r.CustomerID = c.CustomerID

    INNER JOIN dbo.tblProduct AS p
        ON r.ProdID = p.ProdID

    WHERE r.ProdID = @ProdID

    ORDER BY r.ReviewDate DESC;
END
GO


/* ============================================================
   34. REPORT PROCEDURES
   ============================================================ */

CREATE OR ALTER PROCEDURE dbo.spGetTotalSales
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        COUNT(OrderID) AS TotalOrders,
        ISNULL(SUM(TotalAmount), 0) AS TotalSales
    FROM dbo.tblCustomerOrder
    WHERE PaymentStatus = N'Paid'
       OR PaymentMethod = N'Cash on Delivery';
END
GO


CREATE OR ALTER PROCEDURE dbo.spGetTotalCommission
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        ISNULL(SUM(CommissionAmount), 0) AS TotalCommission
    FROM dbo.tblCommission;
END
GO


CREATE OR ALTER PROCEDURE dbo.spGetSellerSales
    @SellerID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        s.SellerID,
        s.SellerName,

        COUNT(DISTINCT od.OrderID) AS TotalOrders,

        ISNULL(SUM(od.LineTotal), 0) AS TotalSales,

        ISNULL(SUM(od.LineTotal * 0.10), 0)
            AS Commission,

        ISNULL(SUM(od.LineTotal * 0.90), 0)
            AS SellerAmount

    FROM dbo.tblSeller AS s

    LEFT JOIN dbo.tblCustomerOrderDetail AS od
        ON s.SellerID = od.SellerID

    WHERE s.SellerID = @SellerID

    GROUP BY
        s.SellerID,
        s.SellerName;
END
GO


/* ============================================================
   35. STOCK REPORT
   ============================================================ */

CREATE OR ALTER PROCEDURE dbo.spGetStockReport
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        p.ProdID,
        p.ProdName,
        c.CategoryName,
        s.SellerName,
        p.ProdPrice,
        p.ProdQty,

        CASE
            WHEN p.ProdQty <= 0
                THEN N'Out of Stock'
            WHEN p.ProdQty <= 5
                THEN N'Low Stock'
            ELSE N'In Stock'
        END AS StockStatus,

        p.IsActive

    FROM dbo.tblProduct AS p

    INNER JOIN dbo.tblCategory AS c
        ON p.CategoryID = c.CategoryID

    INNER JOIN dbo.tblSeller AS s
        ON p.SellerID = s.SellerID

    ORDER BY p.ProdQty ASC;
END
GO


/* ============================================================
   36. OUT OF STOCK
   ============================================================ */

CREATE OR ALTER PROCEDURE dbo.spGetOutOfStockProducts
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        p.ProdID,
        p.ProdName,
        c.CategoryName,
        s.SellerName,
        p.ProdPrice,
        p.ProdQty

    FROM dbo.tblProduct AS p

    INNER JOIN dbo.tblCategory AS c
        ON p.CategoryID = c.CategoryID

    INNER JOIN dbo.tblSeller AS s
        ON p.SellerID = s.SellerID

    WHERE p.ProdQty <= 0
      AND p.IsActive = 1

    ORDER BY p.ProdName;
END
GO


/* ============================================================
   37. LOW STOCK
   ============================================================ */

CREATE OR ALTER PROCEDURE dbo.spGetLowStockProducts
    @MinimumStock INT = 5
AS
BEGIN
    SET NOCOUNT ON;

    IF @MinimumStock < 0
        SET @MinimumStock = 0;

    SELECT
        p.ProdID,
        p.ProdName,
        c.CategoryName,
        s.SellerName,
        p.ProdPrice,
        p.ProdQty,

        CASE
            WHEN p.ProdQty <= 0
                THEN N'Out of Stock'
            ELSE N'Low Stock'
        END AS StockStatus

    FROM dbo.tblProduct AS p

    INNER JOIN dbo.tblCategory AS c
        ON p.CategoryID = c.CategoryID

    INNER JOIN dbo.tblSeller AS s
        ON p.SellerID = s.SellerID

    WHERE p.ProdQty <= @MinimumStock
      AND p.IsActive = 1

    ORDER BY p.ProdQty ASC;
END
GO


/* ============================================================
   38. SEED DATA
   ============================================================ */

/* ADMIN */

INSERT INTO dbo.tblAdmin
(
    AdminName,
    AdminEmail,
    AdminPassword,
    Phone
)
VALUES
(
    N'Main Admin',
    N'admin@gomart.com',
    N'admin123',
    N'01700000000'
);
GO


/* SUPER ADMIN */

INSERT INTO dbo.tblSuperAdmin
(
    SuperAdminName,
    SuperAdminEmail,
    SuperAdminPassword
)
VALUES
(
    N'Super Admin',
    N'superadmin@gomart.com',
    N'super123'
);
GO


/* SELLERS */

INSERT INTO dbo.tblSeller
(
    SellerName,
    SellerEmail,
    SellerPassword,
    SellerPhone,
    SellerAddress,
    IsApproved
)
VALUES
(
    N'ABC Seller',
    N'seller1@gomart.com',
    N'seller123',
    N'01811111111',
    N'Dhaka',
    1
),
(
    N'XYZ Seller',
    N'seller2@gomart.com',
    N'seller123',
    N'01822222222',
    N'Chittagong',
    1
);
GO


/* CATEGORIES */

INSERT INTO dbo.tblCategory
(
    CategoryName,
    Description
)
VALUES
(
    N'Beverages',
    N'Soft drinks, juice and other beverages'
),
(
    N'Snacks',
    N'Chips, biscuits and snacks'
),
(
    N'Grocery',
    N'Daily grocery products'
),
(
    N'Personal Care',
    N'Personal care products'
);
GO


/* PRODUCTS */

INSERT INTO dbo.tblProduct
(
    ProdName,
    CategoryID,
    SellerID,
    ProdPrice,
    ProdQty,
    ProdDescription
)
VALUES
(
    N'Coca Cola',
    1,
    1,
    60.00,
    20,
    N'Coca Cola soft drink'
),
(
    N'Pepsi',
    1,
    1,
    55.00,
    15,
    N'Pepsi soft drink'
),
(
    N'Pringles',
    2,
    1,
    250.00,
    10,
    N'Potato chips'
),
(
    N'Biscuit',
    2,
    2,
    50.00,
    30,
    N'Pack of biscuits'
),
(
    N'Rice',
    3,
    2,
    80.00,
    50,
    N'Premium rice'
),
(
    N'Shampoo',
    4,
    2,
    350.00,
    8,
    N'Hair shampoo'
);
GO


/* CUSTOMER */

INSERT INTO dbo.tblCustomer
(
    CustomerName,
    CustomerEmail,
    CustomerPassword,
    CustomerPhone,
    CustomerAddress
)
VALUES
(
    N'John Customer',
    N'customer@gomart.com',
    N'customer123',
    N'01900000000',
    N'Dhaka'
);
GO


/* OFFER */

INSERT INTO dbo.tblOffer
(
    OfferTitle,
    DiscountPercent,
    StartDate,
    EndDate,
    IsActive
)
VALUES
(
    N'Summer Offer',
    10.00,
    GETDATE(),
    DATEADD(DAY, 30, GETDATE()),
    1
);
GO


/* ============================================================
   39. BASIC TESTS
   ============================================================ */

/* PRODUCT */

EXEC dbo.spGetAllProductList;
GO

EXEC dbo.spSearchProduct
    @Search = N'Coca';
GO

EXEC dbo.spGetAllProductList_SearchbyCat
    @CategoryID = 1;
GO

EXEC dbo.spGetProductByID
    @ProdID = 1;
GO


/* ============================================================
   CART TEST
   ============================================================ */

EXEC dbo.spAddToCart
    @CustomerID = 1,
    @ProdID = 1,
    @Quantity = 2;
GO

EXEC dbo.spGetCart
    @CustomerID = 1;
GO

EXEC dbo.spUpdateCartQuantity
    @CustomerID = 1,
    @ProdID = 1,
    @Quantity = 3;
GO

EXEC dbo.spGetCart
    @CustomerID = 1;
GO


/* ============================================================
   OFFER TEST
   ============================================================ */

EXEC dbo.spGetActiveOffers;
GO

EXEC dbo.spTakeCustomerOffer
    @CustomerID = 1,
    @OfferID = 1;
GO

EXEC dbo.spGetCustomerOffers
    @CustomerID = 1;
GO


/* ============================================================
   STOCK TEST
   ============================================================ */

/* Clear existing cart first */
EXEC dbo.spClearCart
    @CustomerID = 1;
GO

/* Set product 1 to zero */
EXEC dbo.spSetProductStock
    @ProdID = 1,
    @NewQty = 0;
GO

/* This correctly returns an OUT-OF-STOCK message */
EXEC dbo.spAddToCart
    @CustomerID = 1,
    @ProdID = 1,
    @Quantity = 1;
GO

EXEC dbo.spGetOutOfStockProducts;
GO

/* Restock product */
EXEC dbo.spRestockProduct
    @ProdID = 1,
    @AddQty = 20;
GO


/* ============================================================
   CHECKOUT TEST
   ============================================================ */

EXEC dbo.spClearCart
    @CustomerID = 1;
GO

EXEC dbo.spAddToCart
    @CustomerID = 1,
    @ProdID = 1,
    @Quantity = 2;
GO

EXEC dbo.spAddToCart
    @CustomerID = 1,
    @ProdID = 2,
    @Quantity = 1;
GO

EXEC dbo.spGetCart
    @CustomerID = 1;
GO

EXEC dbo.spCheckout
    @CustomerID = 1,
    @PaymentMethod = N'Cash on Delivery';
GO


/* ============================================================
   ORDER TEST
   ============================================================ */

EXEC dbo.spGetCustomerOrders
    @CustomerID = 1;
GO

EXEC dbo.spGetAllOrders;
GO


/* ============================================================
   ORDER DETAILS TEST
   IMPORTANT:
   ONLY @OrderID IS PASSED
   ============================================================ */

EXEC dbo.spGetOrderDetails
    @OrderID = 1;
GO

EXEC dbo.spOrderDetails
    @OrderID = 1;
GO


/* ============================================================
   PAYMENT TEST
   ============================================================ */

EXEC dbo.spUpdatePaymentStatus
    @OrderID = 1,
    @PaymentStatus = N'Paid';
GO


/* ============================================================
   ORDER STATUS TEST
   ============================================================ */

EXEC dbo.spUpdateOrderStatus
    @OrderID = 1,
    @OrderStatus = N'Processing';
GO


/* ============================================================
   SELLER TEST
   ============================================================ */

EXEC dbo.spGetSellerProducts
    @SellerID = 1;
GO

EXEC dbo.spGetSellerOrders
    @SellerID = 1;
GO

EXEC dbo.spGetSellerBills
    @SellerID = 1;
GO


/* ============================================================
   REPORT TESTS
   ============================================================ */

EXEC dbo.spGetStockReport;
GO

EXEC dbo.spGetSellerSales
    @SellerID = 1;
GO

EXEC dbo.spGetTotalSales;
GO

EXEC dbo.spGetTotalCommission;
GO

EXEC dbo.spGetLowStockProducts;
GO

EXEC dbo.spGetOutOfStockProducts;
GO


/* ============================================================
   REVIEW TEST
   ============================================================ */

EXEC dbo.spAddReview
    @CustomerID = 1,
    @ProdID = 1,
    @Rating = 5,
    @Comment = N'Very good product.';
GO

EXEC dbo.spGetProductReviews
    @ProdID = 1;
GO


/* ============================================================
   FINAL DATABASE CHECK
   ============================================================ */

SELECT
    DB_NAME() AS CurrentDatabase;
GO

SELECT
    COUNT(*) AS TotalTables
FROM sys.tables
WHERE is_ms_shipped = 0;
GO

SELECT
    name AS ProcedureName
FROM sys.procedures
WHERE is_ms_shipped = 0
ORDER BY name;
GO


/* ============================================================
   VERIFY ORDER PROCEDURE PARAMETERS
   THIS SHOULD SHOW ONLY @OrderID FOR BOTH PROCEDURES
   ============================================================ */

SELECT
    p.name AS ProcedureName,
    prm.parameter_id,
    prm.name AS ParameterName,
    TYPE_NAME(prm.user_type_id) AS DataType
FROM sys.procedures AS p
LEFT JOIN sys.parameters AS prm
    ON p.object_id = prm.object_id
WHERE p.name IN
(
    N'spGetOrderDetails',
    N'spOrderDetails'
)
ORDER BY
    p.name,
    prm.parameter_id;
GO


/* ============================================================
   END OF GOMART DATABASE
   ============================================================ */