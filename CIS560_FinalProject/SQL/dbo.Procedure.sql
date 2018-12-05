CREATE PROCEDURE [dbo].[Procedure]
	@teamName NVARCHAR(128),
	@teamMascot NVARCHAR(128),
	@teamLocationID int
AS
	INSERT INTO [dbo].[Teams] ([Name], [Mascot], [LocationID])
	VALUES (@teamName, @teamMascot, @teamLocationID)
RETURN 0