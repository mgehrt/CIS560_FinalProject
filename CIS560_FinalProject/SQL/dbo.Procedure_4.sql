CREATE PROCEDURE [dbo].CreateMatch
(
	@Round INT, 
	@Name NVARCHAR(MAX),
	@Date DATETIME,
	@Team1Score INT,
	@Team2Score INT
)	
AS
BEGIN
	INSERT INTO Match VALUES(@Round, @Name, @Date, @Team1Score, @Team2Score)
END
