
CREATE DATABASE CompanyDB;

USE CompanyDB;

CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Department NVARCHAR(50),
    Salary DECIMAL(10, 2)
);

-- Step 3: Insert Sample Data
INSERT INTO Employees (FirstName, LastName, Department, Salary)
VALUES 
('John', 'Doe', 'Sales', 60000),
('Jane', 'Smith', 'Marketing', 75000),
('Jim', 'Brown', 'IT', 80000),
('Jessica', 'Johnson', 'HR', 65000);

-- Step 4: Create a Stored Procedure
CREATE PROCEDURE GetEmployeeDetails
    @EmployeeID INT,
    @FirstName NVARCHAR(50) OUTPUT,
    @LastName NVARCHAR(50) OUTPUT,
    @Department NVARCHAR(50) OUTPUT,
    @Salary DECIMAL(10, 2) OUTPUT
AS
BEGIN
    SELECT 
        @FirstName = FirstName, 
        @LastName = LastName, 
        @Department = Department, 
        @Salary = Salary
    FROM Employees
    WHERE EmployeeID = @EmployeeID;
END;

DECLARE @FirstName NVARCHAR(50),
        @LastName NVARCHAR(50),
        @Department NVARCHAR(50),
        @Salary DECIMAL(10, 2);

EXEC GetEmployeeDetails 
    @EmployeeID = 2,
    @FirstName = @FirstName OUTPUT,
    @LastName = @LastName OUTPUT,
    @Department = @Department OUTPUT,
    @Salary = @Salary OUTPUT;

-- Print the output values
PRINT 'First Name: ' + @FirstName;
PRINT 'Last Name: ' + @LastName;
PRINT 'Department: ' + @Department;
PRINT 'Salary: ' + CAST(@Salary AS NVARCHAR(10));

CREATE TABLE SalaryChanges (
    ChangeID INT PRIMARY KEY IDENTITY(1,1),
    EmployeeID INT,
    OldSalary DECIMAL(10, 2),
    NewSalary DECIMAL(10, 2),
    ChangeDate DATETIME DEFAULT GETDATE()
);

CREATE PROCEDURE GiveRaise
    @EmployeeID INT,
    @RaiseAmount DECIMAL(10, 2)
AS
BEGIN
    DECLARE @OldSalary DECIMAL(10, 2);
    DECLARE @NewSalary DECIMAL(10, 2);

    -- Start the transaction
    BEGIN TRANSACTION;

    BEGIN TRY
        -- Get the current salary
        SELECT @OldSalary = Salary
        FROM Employees
        WHERE EmployeeID = @EmployeeID;

        
        SET @NewSalary = @OldSalary + @RaiseAmount;

        -- Update the employee's salary
        UPDATE Employees
        SET Salary = @NewSalary
        WHERE EmployeeID = @EmployeeID;

        -- Insert into the log table
        INSERT INTO SalaryChanges (EmployeeID, OldSalary, NewSalary)
        VALUES (@EmployeeID, @OldSalary, @NewSalary);

        -- Commit the transaction
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Rollback the transaction in case of error
        ROLLBACK TRANSACTION;

        -- Raise an error with the details of the error
        DECLARE @ErrorMessage NVARCHAR(4000);
        DECLARE @ErrorSeverity INT;
        DECLARE @ErrorState INT;

        SELECT 
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;

-- Execute the stored procedure to give a raise to employee with EmployeeID = 1
EXEC GiveRaise @EmployeeID = 1, @RaiseAmount = 5000;

-- Verify the changes
SELECT * FROM Employees WHERE EmployeeID = 1;
SELECT * FROM SalaryChanges WHERE EmployeeID = 1;

