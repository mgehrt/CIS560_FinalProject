CREATE TABLE [dbo].Locations
(
    LocationID    INT            IDENTITY (1, 1) NOT NULL PRIMARY KEY,
    Venue         NVARCHAR (MAX) NULL,
    City          NVARCHAR (MAX) NULL,
    StateProvince NVARCHAR (MAX) NULL,
);

