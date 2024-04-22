CREATE DATABASE HELPINGHANDS;
USE HELPINGHANDS;

CREATE TABLE Donors (
    DonorID INT Identity(1,1) PRIMARY KEY,
    FirstName VARCHAR(255) NOT NULL,
    LastName VARCHAR(255) NOT NULL,
    Email VARCHAR(255),
    Address VARCHAR(255),
);

CREATE TABLE Projects (
    ProjectID INT IDENTITY(1,1) PRIMARY KEY,
    ProjectName VARCHAR(255) NOT NULL,
	Image VARCHAR(255) NOT NULL,
    Description TEXT,
    TargetAmount DECIMAL(10, 2)
);

CREATE TABLE Donations (
    DonationID INT IDENTITY(1,1) PRIMARY KEY,
    DonorID INT,
    ProjectID INT,
    Amount DECIMAL(10, 2) NOT NULL,
    DonationDate DATE,
    FOREIGN KEY (DonorID) REFERENCES Donors(DonorID),
    FOREIGN KEY (ProjectID) REFERENCES Projects(ProjectID)
);
