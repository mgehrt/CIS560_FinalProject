CREATE PROCEDURE [dbo].GetPlayers
AS
	SELECT P.FirstName, P.LastName, P.Number, P.PlayerID, P.TeamID, T.[Name] AS Team
	FROM Players P
	INNER JOIN Teams T ON T.TeamID = P.TeamID
RETURN 0