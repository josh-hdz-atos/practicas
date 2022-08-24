IF NOT EXISTS(
	SELECT *
	FROM sys.databases
	WHERE name = 'Practica'
)
BEGIN
	CREATE DATABASE Practica;
END;

USE Practica;

------------------- Generate tables -----------------

IF OBJECT_ID('Companies', 'U') IS NULL
CREATE TABLE Companies(
	Id INT PRIMARY KEY NOT NULL IDENTITY,
	Name VARCHAR(150) UNIQUE NOT NULL,
	Address VARCHAR(255) NOT NULL
);

IF OBJECT_ID('Status', 'U') IS NULL
CREATE TABLE Status(
	Id INT PRIMARY KEY NOT NULL IDENTITY,
	Name VARCHAR(90) UNIQUE NOT NULL
);

IF OBJECT_ID('Projects', 'U') IS NULL
CREATE TABLE Projects(
	Id INT PRIMARY KEY NOT NULL IDENTITY,
	Name VARCHAR(150) UNIQUE NOT NULL,
	StartDate DATETIME,
	Deadline DATETIME,
	FinishedOn DATETIME,
	StatusId INT NOT NULL
);

IF OBJECT_ID('Employees', 'U') IS NULL
CREATE TABLE Employees(
	Id INT PRIMARY KEY NOT NULL IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Email VARCHAR(100) UNIQUE NOT NULL,
	Phone VARCHAR(12) UNIQUE NOT NULL,
	Salary INT NOT NULL,
	CompanyId INT NOT NULL
);

IF OBJECT_ID('EmployeeProject', 'U') IS NULL
CREATE TABLE EmployeeProject(
	Id INT PRIMARY KEY NOT NULL IDENTITY,
	ProjectId INT NOT NULL,
	EmployeeId INT NOT NULL
);

-------------------- Relate tables ------------------
ALTER TABLE Employees
ADD FOREIGN KEY (CompanyId) REFERENCES Companies(Id);
ALTER TABLE EmployeeProject
ADD FOREIGN KEY (EmployeeId) REFERENCES Employees(Id);
ALTER TABLE Employeeproject
ADD FOREIGN KEY (ProjectId) REFERENCES Projects(Id);

------------------- Insert data ---------------------

INSERT INTO Status (Name)
VALUES
	('en proceso'),
	('pendiente'),
	('cancelado'),
	('finalizado'),
	('en pausa');

INSERT INTO Companies (Name, Address)
VALUES
	('IMC', '5151 W 29th St #2201Greeley, Colorado(CO), 806342007 Ardmore Hwy'),
	('Atoz', 'Ardmore, Tennessee(TN), 384494226 Highgate Dr'),
	('Disnei', 'Horn Lake, Mississippi(MS), 38637');

INSERT INTO Projects (Name, StartDate, Deadline, finishedOn, StatusId)
VALUES
	('Dainler Learning', '1995-02-07', '2050-02-22', NULL, (SELECT Name FROM Status WHERE Name = 'en proceso')),
	('Provident Software', '2022-09-15', '2023-02-28', NULL, (SELECT Name FROM Status WHERE Name = 'pendiente')),
	('DataAnalysis', '2023-01-31', '2023-10-05', NULL, (SELECT Name FROM Status WHERE Name = 'pendiente')),
	('Atoz Insight', '2022-12-30', '2024-10-01', NULL, (SELECT Name FROM Status WHERE Name = 'cancelado')),
	('SoftCentral Migration', '2021-05-02', '2022-07-25', '2022-01-01', (SELECT Name FROM Status WHERE Name = 'finalizado'));

INSERT INTO Employees (FirstName, LastName, Email, Phone, Salary, CompanyId)
VALUES 
	('Juan', 'Perez', 'juan@jmail.com', '9991808182', 9500, (SELECT Name FROM Companies WHERE Name = 'IMC')),
	('Paco', 'Ochoa', 'paco@jmail.com', '9991808183', 8000, (SELECT Name FROM Companies WHERE Name = 'IMC')),
	('Pedro', 'Fernandez', 'pedro@jmail.com', '9991808184', 12500, (SELECT Name FROM Companies WHERE Name = 'IMC')),
	('Sofi', 'Hernandez', 'sofi@jmail.com', '9991808185', 11000, (SELECT Name FROM Companies WHERE Name = 'Atoz')),
	('Isabella', 'Smith', 'abella@jmail.com', '9991808186', 9000, (SELECT Name FROM Companies WHERE Name = 'Atoz')),
	('Eduardo', 'Jimenez', 'eduardo@jmail.com', '9991808187', 11000, (SELECT Name FROM Companies WHERE Name = 'Atoz')),
	('Jose', 'Pavon', 'jose@jmail.com', '9991808188', 12000, (SELECT Name FROM Companies WHERE Name = 'Atoz')),
	('Pancho', 'Fernandez', 'pancho@jmail.com', '9991808189', 12500, (SELECT Name FROM Companies WHERE Name = 'Disnei')),
	('Francisco', 'Fernandez', 'francisco@jmail.com', '9991808190', 25000, (SELECT Name FROM Companies WHERE Name = 'Disnei')),
	('Diego', 'Olivarez', 'diego@jmail.com', '9991808191', 9000, (SELECT Name FROM Companies WHERE Name = 'Disnei'));

INSERT INTO EmployeeProject (EmployeeId, ProjectId)
VALUES
	((SELECT Id FROM Employees WHERE FirstName = 'Juan' AND LastName = 'Perez'), (SELECT Name FROM Projects WHERE Name = 'Dainler Learning')),
	((SELECT Id FROM Employees WHERE FirstName = 'paco' AND LastName = 'Ochoa'), (SELECT Name FROM Projects WHERE Name = 'Dainler Learning')),
	((SELECT Id FROM Employees WHERE FirstName = 'Pedro' AND LastName = 'Fernandez'), (SELECT Name FROM Projects WHERE Name = 'Atoz Insight')),
	((SELECT Id FROM Employees WHERE FirstName = 'Sofi' AND LastName = 'Hernandez'), (SELECT Name FROM Projects WHERE Name = 'Atoz Insight')),
	((SELECT Id FROM Employees WHERE FirstName = 'Isabella' AND LastName = 'Smith'), (SELECT Name FROM Projects WHERE Name = 'SoftCentral Migration')),
	((SELECT Id FROM Employees WHERE FirstName = 'Eduardo' AND LastName = 'jimenez'), (SELECT Name FROM Projects WHERE Name = 'SoftCentral Migration')),
	((SELECT Id FROM Employees WHERE FirstName = 'Jose' AND LastName = 'Pavon'), (SELECT Name FROM Projects WHERE Name = 'DataAnalysis')),
	((SELECT Id FROM Employees WHERE FirstName = 'Pancho' AND LastName = 'Fernandez'), (SELECT Name FROM Projects WHERE Name = 'DataAnalysis')),
	((SELECT Id FROM Employees WHERE FirstName = 'Francisco' AND LastName = 'Fernandez'), (SELECT Name FROM Projects WHERE Name = 'Provident Software')),
	((SELECT Id FROM Employees WHERE FirstName = 'Diego' AND LastName = 'Olivarez'), (SELECT Name FROM Projects WHERE Name = 'Provident Software'));