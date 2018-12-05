CREATE PROCEDURE [dbo].[AddTeam]
	@Name NVARCHAR(128),
	@Mascot NVARCHAR(128),
	@LocationID int
AS
	INSERT INTO [dbo].[Teams] ([Name], [Mascot], [LocationID])
	VALUES (@Name, @Mascot, @LocationID)
RETURN 0