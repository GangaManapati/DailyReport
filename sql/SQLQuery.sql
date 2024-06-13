CREATE PROCEDURE GetUserByUsername
    @UserName NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM Users
    WHERE UserName = @UserName;
END;

DECLARE @UsernameToSearch NVARCHAR(50) = 'ram';

EXEC GetUserByUsername @UserName = @UsernameToSearch;

CREATE PROCEDURE InsertUser
    @UserName NVARCHAR(50),
    @spid NVARCHAR(100),
    @UserId INT OUTPUT
AS
BEGIN
    INSERT INTO Users (UserName, id)
    VALUES (@UserName, @spid);

    -- Retrieve the generated identity value and return it
    SELECT @UserId = SCOPE_IDENTITY();
END;



-- Declare variables to hold input parameters and output value
DECLARE @UserName NVARCHAR(50) = 'JohnDoe';
DECLARE @Email NVARCHAR(100) = 'john.doe@example.com';
DECLARE @NewUserId INT

-- Execute the stored procedure and retrieve the output parameter value
EXEC InsertUser @UserName, @Email, @NewUserId ;

-- Display the generated User


CREATE PROCEDURE InsertU
    @UserId INT OUTPUT
AS
BEGIN
    return(select COUNT(id) from Users);
    -- Retrieve the generated identity value and assign it to the output paramete
END;

declare @Uc int
EXECUTE @Uc=InsertU
select @ucs