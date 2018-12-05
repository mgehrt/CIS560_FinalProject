CREATE PROCEDURE [dbo].[SearchPlayer]
	@SearchString NVARCHAR(128)
AS
	SELECT P.PlayerID
	FROM Players P
	WHERE P.Firstname LIKE @SearchString OR P.LastName LIKE @SearchString OR CONVERT(NVARCHAR(128), P.Number) LIKE @SearchString
RETURN 0