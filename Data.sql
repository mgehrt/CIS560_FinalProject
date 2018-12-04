-- Insert Tournaments
INSERT INTO dbo.Tournaments(Sport, [Name], StartDate, EndDate)
VALUES
	(N'Basketball', N'NCAA Division I Mens Basketball Tournament', '2018-03-13', '2018-04-02'),
	(N'Basketball', N'2017 Big 12 Mens Basketball Tournament','2019-03-08','2019-03-16'),
	(N'Basketball', N'U.S. Virgin Islands Paradise Jam','2018-11-16','2018-11-19'),
	(N'Football', N'2018 College Football Playoff','2018-01-01','2018-01-08'),
	(N'Football', N'NFL Playoffs','2018-01-06','2018-02-04'),
	(N'Soccer', N'FIFA World Cup 2018','2018-07-10','2018-07-15')

-- Insert Locations for CFB Playoff and Teams Locations
INSERT dbo.Locations(Venue, City, StateProvince)
VALUES
	(N'Mercedes-Benz Superdome', N'New Orleans', N'Louisiana'),
	(N'Rose Bowl', N'Pasadena', N'California'),
	(N'Mercedes-Benz Stadium', N'Atlanta', N'Georgia'),
	(N'Bryant-Denny Stadium', N'Tuscaloosa', N'Alabama'),
	(N'Sanford Stadium', N'Athens', N'Georgia'),
	(N'The Gaylord Family Oklahoma Memorial Stadium', N'Norman', N'Oklahoma'),
	(N'Clemson Memorial Stadium', N'Clemson', N'South Carolina')

-- Insert locations  for Paradise Jam Basketball tournament and team locations
INSERT dbo.Locations(Venue, City, StateProvince)
VALUES
	(N'Sports and Fitness Center', N'St. Thomas', N'U.S. Virgin Islands'), -- Tournament location
	(N'Gill Coliseum', N'Corvallis', N'Oregon'), -- Oregon State
	(N'Ted Constant Convocation Center', N'Norfolk', N'Virginia'), -- Old Dominion
	(N'KSU Convocation Center', N'Kennesaw', N'Georgia'), -- Kennesaw State
	(N'Mizzou Arena', N'Columbia', N'Missouri'), -- Missouri
	(N'McLeod Center', N'Cedar Falls', N'Iowa'), -- Northern Iowa
	(N'The Palestra', N'Philadelphia', N'Pennsylvania'), -- Penn
	(N'Alumni Coliseum', N'Richmond', N'Kentucky'), -- Eastern Kentucky
	(N'Bramlage Coliseum', N'Manhattan', N'Kansas') -- K-State
--SELECT * From dbo.Locations;

-- Insert locations  for 2017 Big 12 
INSERT dbo.Locations(Venue, City, StateProvince)
VALUES
	(N'Sprint Center', N'Kansas City', N'Missouri'), -- Tournament location
	(N'Allen Fieldhouse', N'Lawrence', N'Kansas'),
	(N'WVU Coliseum', N'Morgantown', N'Virginia'),
	(N'Ferrell Center', N'Waco', N'Texas'),
	(N'Hilton Coliseum', N'Ames', N'Iowa'),
	(N'Gallagher-Iba Arena', N'Stillwater', N'Oklahoma'),
	--(N'Bramlage Coliseum', N'Manhattan', N'Kansas'), --already have it
	(N'United Supermarkets Arena', N'Lubbock', N'Texas'),
	(N'Ed and Rae Schollmaier Arena', N'Fort Worth', N'Texas'),
	(N'Lloyd Noble Center', N'Norman', N'Oklahoma'),
	(N'Frank Erwin Center', N'Austin', N'Texas')

	-- Insert teams for Paradise Jam
INSERT dbo.Teams(LocationID, Name, Mascot)
SELECT L.LocationID, T.Name, T.Mascot
FROM
(
	VALUES
		(N'Gill Coliseum', N'Oregon State University', N'Benny Beaver'),
		(N'Ted Constant Convocation Center', N'Old Dominion University', N'Big Blue'),
		(N'KSU Convocation Center', N'Kennesaw State University', N'Scrappy the Owl'),
		(N'Mizzou Arena', N'University of Missouri', N'Truman the Tiger'),
		(N'McLeod Center', N'University of Northern Iowa', N'TC Panther'),
		(N'The Palestra', N'University of Pennsylvania', N'Quaker'),
		(N'Alumni Coliseum', N'Eastern Kentucky University', N'The Colonel'),
		(N'Bramlage Coliseum', N'Kansas State University', N'Willie the Wildcat')
) T(Venue, Name, Mascot)
	LEFT JOIN dbo.Locations L ON L.Venue = T.Venue

-- Insert teams for CFB Playoff
INSERT dbo.Teams(LocationID, Name, Mascot)
SELECT L.LocationID, T.Name, T.Mascot
FROM
(
	VALUES
		(N'Bryant-Denny Stadium', N'University of Alabama', N'Big Al'),
		(N'Sanford Stadium', N'University of Georgia', N'Uga'),
		(N'The Gaylord Family Oklahoma Memorial Stadium', N'University of Oklahoma', N'Boomer and Sooner'),
		(N'Clemson Memorial Stadium', N'Clemson University', N'The Tiger')
) T(Venue, Name, Mascot)
	LEFT JOIN dbo.Locations L ON L.Venue = T.Venue

-- Insert teams for N'2017 Big 12 Mens Basketball Tournament'
INSERT dbo.Teams(LocationID, Name, Mascot)
SELECT L.LocationID, T.Name, T.Mascot
FROM
(
	VALUES
		(N'Allen Fieldhouse', N'Kansas University', N'Big Jay the Jayhawk'),
		(N'WVU Coliseum', N'West Virginia University', N'Mountaineers'),
		(N'Ferrell Center', N'Baylor University', N'Bears'),
		(N'Hilton Coliseum', N'Iowa State University', N'Cy the Cardinal'),
		(N'Gallagher-Iba Arena', N'Oklahoma State University', N'Pistol Pete'),
		--(N'Bramlage Coliseum', N'Kansas State University', N'Willie the Wildcat'), dont need this again?
		(N'United Supermarkets Arena', N'Texas Tech University', N'Raider Red'),
		(N'Ed and Rae Schollmaier Arena', N'Texas Christian University', N'Horned Frogs'),
		(N'Lloyd Noble Center', N'Oklahoma University', N'Sooners'),
		(N'Frank Erwin Center', N'Texas University', N'Bevo the Longhorn')
) T(Venue, Name, Mascot)
	LEFT JOIN dbo.Locations L ON L.Venue = T.Venue

-- Insert players for Alabama
INSERT dbo.Players(TeamID, FirstName, LastName, [Number])
SELECT Team.TeamID, T.FirstName, T.LastName, T.[Number]
FROM
(
	VALUES
		(N'University of Alabama', N'Jalen', N'Hurts', 2),
		(N'University of Alabama', N'Calvin', N'Ridley', 18),
		(N'University of Alabama', N'Damien', N'Harris', 34)
) T(Name, FirstName, LastName, [Number])
	LEFT JOIN dbo.Teams Team ON T.Name = Team.Name

-- Insert players for K-State
INSERT dbo.Players(TeamID, FirstName, LastName, [Number])
SELECT Team.TeamID, T.FirstName, T.LastName, T.[Number]
FROM
(
	VALUES
		(N'Kansas State University', N'Barry', N'Brown', 5),
		(N'Kansas State University', N'Kamau', N'Stokes', 3),
		(N'Kansas State University', N'Xavier', N'Sneed', 20),
		(N'Kansas State University', N'Makol', N'Mawien', 14),
		(N'Kansas State University', N'Dean', N'Wade', 32)
) T(Name, FirstName, LastName, [Number])
	LEFT JOIN dbo.Teams Team ON T.Name = Team.Name
	
	
-- Insert players for Iowa (Big 12 Tournament)
INSERT dbo.Players(TeamID, FirstName, LastName, [Number])
SELECT Team.TeamID, T.FirstName, T.LastName, T.[Number]
FROM
(
	VALUES
		(N'Iowa State University', N'Nick', N'Weiler-Babb', 1),
		(N'Iowa State University', N'Cameron', N'Lard', 2),
		(N'Iowa State University', N'Marial', N'Shayok', 3),
		(N'Iowa State University', N'Donovan', N'Jackson', 4),
		(N'Iowa State University', N'Lindell', N'Wigginton', 5),
		(N'Iowa State University', N'Michael', N'Jacobson', 12),
		(N'Iowa State University', N'Jakolby', N'Long', 13),
		(N'Iowa State University', N'Zoran', N'Talley Jr.', 23),
		(N'Iowa State University', N'Terrence', N'Lewis', 24),
		(N'Iowa State University', N'Hans', N'Brase', 30),
		(N'Iowa State University', N'Solomon', N'Young', 33),
		(N'Iowa State University', N'Jeff', N'Beverly', 55)
		
) T(Name, FirstName, LastName, [Number])
	LEFT JOIN dbo.Teams Team ON T.[Name] = Team.[Name]

-- Insert matches for Paradise Jam
INSERT dbo.Matches(TournamentID, Team1ID, Team2ID, LocationID, [Round], [Date], Team1Score, Team2Score)
SELECT Tourn.TournamentID, TeamO.TeamID, TeamT.TeamID, L.LocationID, T.[Round], T.[Date], T.Team1Score, T.Team2Score
FROM
(
	VALUES
		(N'U.S. Virgin Islands Paradise Jam', N'Oregon State University', N'Old Dominion University', N'Sports and Fitness Center', N'Quarter-final', '2018-11-16', 61, 56),
		(N'U.S. Virgin Islands Paradise Jam', N'Kennesaw State University', N'University of Missouri', N'Sports and Fitness Center', N'Quarter-final', '2018-11-16', 52, 55),
		(N'U.S. Virgin Islands Paradise Jam', N'University of Northern Iowa', N'University of Pennsylvania', N'Sports and Fitness Center', N'Quarter-final', '2018-11-16', 71, 78),
		(N'U.S. Virgin Islands Paradise Jam', N'Eastern Kentucky University', N'Kansas State University', N'Sports and Fitness Center', N'Quarter-final', '2018-11-16', 68, 95),
		(N'U.S. Virgin Islands Paradise Jam', N'Oregon State University', N'University of Missouri', N'Sports and Fitness Center', N'Semi-final', '2018-11-18', 63, 69),
		(N'U.S. Virgin Islands Paradise Jam', N'University of Pennsylvania', N'Kansas State University', N'Sports and Fitness Center', N'Semi-final', '2018-11-18', 48, 64),
		(N'U.S. Virgin Islands Paradise Jam', N'University of Missouri', N'Kansas State University', N'Sports and Fitness Center', N'Final', '2018-01-01', 67, 82)
) T(TournamentName, Team1, Team2, Venue, [Round], [Date], Team1Score, Team2Score)
	LEFT JOIN dbo.Tournaments Tourn ON Tourn.Name = T.TournamentName
	LEFT JOIN dbo.Teams TeamO ON T.Team1 = TeamO.Name
	LEFT JOIN dbo.Teams TeamT ON T.Team2 = TeamT.Name
	LEFT JOIN dbo.Locations L ON T.Venue = L.Venue

-- Insert matches for CFB Playoff
INSERT dbo.Matches(TournamentID, Team1ID, Team2ID, LocationID, [Round], [Date], Team1Score, Team2Score)
SELECT Tourn.TournamentID, TeamO.TeamID, TeamT.TeamID, L.LocationID, T.[Round], T.[Date], T.Team1Score, T.Team2Score
FROM
(
	VALUES
		(N'2018 College Football Playoff', N'Clemson University', N'University of Alabama', N'Mercedes-Benz Superdome', N'Semi-final', '2018-01-01', 0, 24),
		(N'2018 College Football Playoff', N'University of Oklahoma', N'University of Georgia', N'Rose Bowl', N'Semi-final', '2018-01-01', 48, 54),
		(N'2018 College Football Playoff', N'University of Alabama', N'University of Georgia', N'Mercedes-Benz Stadium', N'Championship', '2018-01-08', 26, 23)
) T(TournamentName, Team1, Team2, Venue, [Round], [Date], Team1Score, Team2Score)
	LEFT JOIN dbo.Tournaments Tourn ON Tourn.[Name] = T.TournamentName
	LEFT JOIN dbo.Teams TeamO ON T.Team1 = TeamO.[Name]
	LEFT JOIN dbo.Teams TeamT ON T.Team2 = TeamT.[Name]
	LEFT JOIN dbo.Locations L ON T.Venue = L.Venue

-- Insert matches for N'2017 Big 12 Mens Basketball Tournament'
INSERT dbo.Matches(TournamentID, Team1ID, Team2ID, LocationID, [Round], [Date], Team1Score, Team2Score)
SELECT Tourn.TournamentID, TeamO.TeamID, TeamT.TeamID, L.LocationID, T.[Round], T.[Date], T.Team1Score, T.Team2Score
FROM
(
	VALUES
		(N'2017 Big 12 Mens Basketball Tournament', N'Texas Christian University', N'Oklahoma University', N'Sprint Center', N'First Round', '2017-03-08', 82, 63),
		(N'2017 Big 12 Mens Basketball Tournament', N'Texas Tech University', N'Texas University', N'Sprint Center', N'First Round', '2017-03-08', 52, 61),
		(N'2017 Big 12 Mens Basketball Tournament', N'Iowa State University', N'Oklahoma State University', N'Sprint Center', N'Quarter-final', '2017-03-09', 92, 83),
		(N'2017 Big 12 Mens Basketball Tournament', N'Kansas University', N'Texas Christian University', N'Sprint Center', N'Quarter-final', '2017-03-09', 82, 85),
		(N'2017 Big 12 Mens Basketball Tournament', N'West Virginia University', N'Texas University', N'Sprint Center', N'Quarter-final', '2017-03-09', 63, 53),
		(N'2017 Big 12 Mens Basketball Tournament', N'Baylor University', N'Kansas State University', N'Sprint Center', N'Quarter-final', '2017-03-09', 64, 70),
		(N'2017 Big 12 Mens Basketball Tournament', N'Iowa State University', N'Texas Christian University', N'Sprint Center', N'Semi-final', '2017-03-10', 84, 63),
		(N'2017 Big 12 Mens Basketball Tournament', N'West Virginia University', N'Kansas State University', N'Sprint Center', N'Semi-final', '2017-03-10', 51, 50),
		(N'2017 Big 12 Mens Basketball Tournament', N'Iowa State University', N'West Virginia University', N'Sprint Center', N'Final', '2018-01-01', 80, 74)
) T(TournamentName, Team1, Team2, Venue, [Round], [Date], Team1Score, Team2Score)
	LEFT JOIN dbo.Tournaments Tourn ON Tourn.Name = T.TournamentName
	LEFT JOIN dbo.Teams TeamO ON T.Team1 = TeamO.Name
	LEFT JOIN dbo.Teams TeamT ON T.Team2 = TeamT.Name
	LEFT JOIN dbo.Locations L ON T.Venue = L.Venue