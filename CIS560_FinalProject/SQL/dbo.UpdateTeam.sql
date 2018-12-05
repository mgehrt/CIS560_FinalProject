CREATE PROCEDURE [dbo].[UpdateTeam]
	@TeamID int,
	@Name int,
	@LocationID int,
	@Mascot nvarchar(128)
AS
	Update dbo.Teams
	SET [Name] = @Name, [LocationID] = @LocationID, [Mascot] = @Mascot
	WHERE TeamID = @TeamID;
RETURN 0