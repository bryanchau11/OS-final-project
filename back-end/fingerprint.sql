CREATE DATABASE fingerprint

CREATE TABLE Persons(
	personID int IDENTITY(1,1) NOT NULL,
	personName nvarchar(50) NULL,
	fingerID int NULL,
)
