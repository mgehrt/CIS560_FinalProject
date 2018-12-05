CREATE PROCEDURE [dbo].[DeleteTeam]
	@TeamID int
AS
	DELETE FROM dbo.Teams
	WHERE TeamID = @TeamID;
RETURN 0