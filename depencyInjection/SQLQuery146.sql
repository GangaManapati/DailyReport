CREATE PROCEDURE GetUsersWithPagination
(
    @StartIndex INT,
    @EndIndex INT
)
AS
BEGIN
    SET NOCOUNT ON; -- Ensure EndIndex is greater than StartIndex
    IF @EndIndex <= @StartIndex
    BEGIN
        RAISERROR ('EndIndex must be greater than StartIndex', 16, 1);
        RETURN;
    END
    -- Calculate the number of rows to fetch
    DECLARE @PageSize INT;
    SET @PageSize = @EndIndex - @StartIndex + 1; -- Fetch the records within the specified range
    SELECT id, UserName, Password
    FROM
    (
        SELECT id, UserName, Password,
               ROW_NUMBER() OVER (ORDER BY id) AS RowNum
        FROM [Users]
    ) AS UserWithRowNum
    WHERE UserWithRowNum.RowNum BETWEEN @StartIndex AND @EndIndex;
END


--Execute  

GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[GetUsersWithPagination]
		@StartIndex = 3,
		@EndIndex = 5

SELECT	'Return Value' = @return_value

GO
