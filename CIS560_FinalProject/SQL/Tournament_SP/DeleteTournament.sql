CREATE PROCEDURE [dbo].DeleteTournament
	(
		@TournamentID int
	)
AS
BEGIN
	DELETE FROM Tournaments
WHERE TournamentID=@TournamentID
END