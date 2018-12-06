CREATE PROCEDURE [dbo].UpdateTournament
CREATE PROCEDURE [dbo].UpdateTournament
(
	@TournamentID INT, 
	@Name NVARCHAR(MAX),
	@Sport NVARCHAR(MAX),
	@StartDate DATETIME,
	@EndDate DATETIME
)
AS
BEGIN
	UPDATE Tournaments
	SET
	Name = @Name,
	Sport = @Sport,
	StartDate = @StartDate,
	EndDate = @EndDate
WHERE TournamentID = @TournamentID
END