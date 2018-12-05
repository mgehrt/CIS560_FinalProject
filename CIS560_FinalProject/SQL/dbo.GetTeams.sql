CREATE PROCEDURE [dbo].[GetTeams]

AS
	SELECT T.TeamID, T.LocationID, T.Mascot, T.[Name], L.Venue, L.City, L.StateProvince
	FROM dbo.Teams T
	INNER JOIN dbo.Locations L ON L.LocationID = T.LocationID
RETURN 0