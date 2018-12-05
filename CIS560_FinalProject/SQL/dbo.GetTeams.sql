CREATE PROCEDURE [dbo].[GetTeams]

AS
	SELECT T.LocationID, T.Mascot, T.[Name], T.TeamID, L.Venue, L.City, L.StateProvince
	FROM dbo.Teams T
	INNER JOIN dbo.Locations L ON L.LocationID = T.LocationID
RETURN 0