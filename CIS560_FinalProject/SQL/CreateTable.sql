CREATE PROCEDURE [dbo].CreateTournament
(
	@Name NVARCHAR(MAX),
	@Sport NVARCHAR(MAX),
	@StartDate DATETIME,
	@EndDate DATETIME
)
AS
BEGIN
	INSERT INTO Tournament VALUES(@Name, @Sport, @StartDate, @EndDate)
END