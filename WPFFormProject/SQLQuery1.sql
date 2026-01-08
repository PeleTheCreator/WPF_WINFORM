-- =============================================
-- Table: Departments
-- Stores department information
-- =============================================
CREATE TABLE Departments (
    DepartmentId INT PRIMARY KEY IDENTITY(1,1),
    DepartmentName NVARCHAR(100) NOT NULL UNIQUE,
    Description NVARCHAR(500) NULL,
    CreatedDate DATETIME2 DEFAULT GETDATE(),
    ModifiedDate DATETIME2 DEFAULT GETDATE(),
    IsActive BIT DEFAULT 1
);


-- =============================================
-- Table: Employees
-- Stores employee information with proper indexing
-- =============================================
CREATE TABLE Employees (
    EmployeeId INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Phone NVARCHAR(20) NULL,
    HireDate DATE NOT NULL,
    Salary DECIMAL(18,2) NOT NULL CHECK (Salary >= 0),
    DepartmentId INT NOT NULL,
    IsActive BIT DEFAULT 1,
    CreatedDate DATETIME2 DEFAULT GETDATE(),
    ModifiedDate DATETIME2 DEFAULT GETDATE(),
    
    -- Foreign Key Constraint
    CONSTRAINT FK_Employees_Departments 
        FOREIGN KEY (DepartmentId) 
        REFERENCES Departments(DepartmentId)
        ON DELETE NO ACTION
);

-- =============================================
-- Indexes for Performance Optimization
-- =============================================
CREATE NONCLUSTERED INDEX IX_Employees_DepartmentId 
    ON Employees(DepartmentId);

CREATE NONCLUSTERED INDEX IX_Employees_LastName 
    ON Employees(LastName);

CREATE NONCLUSTERED INDEX IX_Employees_Email 
    ON Employees(Email);

-- =============================================
-- Stored Procedures for Data Operations
-- Using stored procedures for better security and performance
-- =============================================

-- Get All Employees with Department Info
CREATE PROCEDURE sp_GetAllEmployees
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        e.EmployeeId,
        e.FirstName,
        e.LastName,
        e.Email,
        e.Phone,
        e.HireDate,
        e.Salary,
        e.DepartmentId,
        d.DepartmentName,
        e.IsActive,
        e.CreatedDate,
        e.ModifiedDate
    FROM Employees e
    INNER JOIN Departments d ON e.DepartmentId = d.DepartmentId
    WHERE e.IsActive = 1
    ORDER BY e.LastName, e.FirstName;
END;
GO

-- Get Employee by ID
CREATE PROCEDURE sp_GetEmployeeById
    @EmployeeId INT
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        e.EmployeeId,
        e.FirstName,
        e.LastName,
        e.Email,
        e.Phone,
        e.HireDate,
        e.Salary,
        e.DepartmentId,
        d.DepartmentName,
        e.IsActive
    FROM Employees e
    INNER JOIN Departments d ON e.DepartmentId = d.DepartmentId
    WHERE e.EmployeeId = @EmployeeId;
END;
GO

-- Insert Employee
CREATE PROCEDURE sp_InsertEmployee
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @Email NVARCHAR(100),
    @Phone NVARCHAR(20),
    @HireDate DATE,
    @Salary DECIMAL(18,2),
    @DepartmentId INT,
    @NewEmployeeId INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        
        INSERT INTO Employees (FirstName, LastName, Email, Phone, HireDate, Salary, DepartmentId)
        VALUES (@FirstName, @LastName, @Email, @Phone, @HireDate, @Salary, @DepartmentId);
        
        SET @NewEmployeeId = SCOPE_IDENTITY();
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

-- Update Employee
CREATE PROCEDURE sp_UpdateEmployee
    @EmployeeId INT,
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @Email NVARCHAR(100),
    @Phone NVARCHAR(20),
    @HireDate DATE,
    @Salary DECIMAL(18,2),
    @DepartmentId INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        
        UPDATE Employees
        SET 
            FirstName = @FirstName,
            LastName = @LastName,
            Email = @Email,
            Phone = @Phone,
            HireDate = @HireDate,
            Salary = @Salary,
            DepartmentId = @DepartmentId,
            ModifiedDate = GETDATE()
        WHERE EmployeeId = @EmployeeId;
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

-- Soft Delete Employee
CREATE PROCEDURE sp_DeleteEmployee
    @EmployeeId INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        
        UPDATE Employees
        SET IsActive = 0, ModifiedDate = GETDATE()
        WHERE EmployeeId = @EmployeeId;
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

-- Get All Departments
CREATE PROCEDURE sp_GetAllDepartments
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT DepartmentId, DepartmentName, Description, IsActive
    FROM Departments
    WHERE IsActive = 1
    ORDER BY DepartmentName;
END;
GO

-- Search Employees
CREATE PROCEDURE sp_SearchEmployees
    @SearchTerm NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        e.EmployeeId,
        e.FirstName,
        e.LastName,
        e.Email,
        e.Phone,
        e.HireDate,
        e.Salary,
        e.DepartmentId,
        d.DepartmentName
    FROM Employees e
    INNER JOIN Departments d ON e.DepartmentId = d.DepartmentId
    WHERE e.IsActive = 1
        AND (
            e.FirstName LIKE '%' + @SearchTerm + '%' OR
            e.LastName LIKE '%' + @SearchTerm + '%' OR
            e.Email LIKE '%' + @SearchTerm + '%' OR
            d.DepartmentName LIKE '%' + @SearchTerm + '%'
        )
    ORDER BY e.LastName, e.FirstName;
END;
GO

-- =============================================
-- Insert Sample Data
-- =============================================

-- Insert Departments
INSERT INTO Departments (DepartmentName, Description) VALUES
('IT', 'Information Technology Department'),
('HR', 'Human Resources Department'),
('Finance', 'Finance and Accounting Department'),
('Marketing', 'Marketing and Sales Department'),
('Operations', 'Operations and Management');

-- Insert Sample Employees
INSERT INTO Employees (FirstName, LastName, Email, Phone, HireDate, Salary, DepartmentId) VALUES
('John', 'Doe', 'john.doe@company.com', '555-0101', '2020-01-15', 75000.00, 1),
('Jane', 'Smith', 'jane.smith@company.com', '555-0102', '2019-03-22', 82000.00, 1),
('Michael', 'Johnson', 'michael.j@company.com', '555-0103', '2021-06-10', 65000.00, 2),
('Emily', 'Brown', 'emily.brown@company.com', '555-0104', '2018-09-05', 95000.00, 3),
('David', 'Wilson', 'david.wilson@company.com', '555-0105', '2022-02-14', 70000.00, 4);

GO