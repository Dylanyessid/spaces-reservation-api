CREATE DATABASE SpaceReservations;

USE SpaceReservations;

CREATE TABLE Users (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Email VARCHAR(255),
	Password VARCHAR(MAX),
	DeletedAt DATETIME2,
);


CREATE TABLE Profiles(
	Id INT PRIMARY KEY IDENTITY(1,1),
	FirstName NVARCHAR(50),
	UserId INT NOT NULL UNIQUE,
	LastName NVARCHAR(50),
	DeletedAt DATETIME2,
	FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE
);

CREATE TABLE Spaces(
   Id INT PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(100) NOT NULL,
	Image VARCHAR(2048) NULL,           
   Description NVARCHAR(500) NULL,        
   Location NVARCHAR(200) NOT NULL,       
   Capacity INT NOT NULL,                 
   PricePerHour DECIMAL(10,2) NOT NULL,   
   OwnerId INT NOT NULL,                  
   IsActive BIT NOT NULL DEFAULT 1,
   DeletedAt DATETIME2 NULL,   
	FOREIGN KEY (OwnerId) REFERENCES Users(Id),
);

CREATE TABLE Reservations (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UserId INT NOT NULL,                    
    SpaceId INT NOT NULL,                   
    StartDateTime DATETIME NOT NULL,  
    EndDateTime DATETIME NOT NULL, 
    Status NVARCHAR(20) NOT NULL,           
    UpdatedAt DATETIME NULL,
    FOREIGN KEY (UserId) REFERENCES Users(Id),
    FOREIGN KEY (SpaceId) REFERENCES Spaces(Id)
);

