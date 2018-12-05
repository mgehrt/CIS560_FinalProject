CREATE PROCEDURE [dbo].[ViewTeam]
	@TeamID int
AS
	SELECT P.PlayerID, P.FirstName, P.LastName, P.Number, P.TeamID
	FROM dbo.Players P
	WHERE P.TeamID = @TeamID
RETURN 0