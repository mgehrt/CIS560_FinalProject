CREATE PROCEDURE [dbo].[GetPlayer]
	@TeamID int
AS
	SELECT P.PlayerID, P.TeamID, P.FirstName, P.LastName, P.Number, T.[Name]
	FROM Players P
	INNER JOIN Teams T ON T.TeamID = P.TeamID
	WHERE P.TeamID = @TeamID
RETURN 0