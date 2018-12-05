CREATE PROCEDURE [dbo].[CreatePlayer]
	@FirstName NVARCHAR(128),
	@LastName NVARCHAR(128),
	@TeamName NVARCHAR(128),
	@Number INT
AS
	INSERT INTO Players (FirstName, LastName, TeamID, Number)
	SELECT @FirstName, @LastName, T.TeamID, @Number
	FROM Teams T
	WHERE T.[Name] = @TeamName
RETURN 0