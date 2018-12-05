CREATE PROCEDURE [dbo].ViewTournament
(
	@TournamentID int
)
AS
BEGIN
	SELECT * FROM Matches
	WHERE TournamentID = @TournamentID;
END