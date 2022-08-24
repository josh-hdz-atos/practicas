USE Practica;

SELECT Name FROM Companies;

SELECT FirstName, LastName
FROM Employees;

SELECT Name, FinishedOn, Deadline
FROM Projects
WHERE FinishedOn < Deadline;

SELECT Name, Startdate, GETDATE() AS Today
FROM Projects
WHERE Startdate > GETDATE();

SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary > 10000

SELECT Emp.FirstName, Emp.LastName, Com.Name
FROM Employees AS Emp
INNER JOIN Companies AS Com
ON Emp.CompanyId = Com.Id
WHERE Com.Name = 'Atoz';

SELECT Emp.FirstName, Emp.LastName, Com.Name
FROM Employees AS Emp
INNER JOIN Companies AS Com
ON Emp.CompanyId = Com.Id
WHERE Com.Name = 'Atoz';

SELECT Emp.FirstName, Emp.LastName, Com.Name
FROM Employees AS Emp
INNER JOIN Companies AS Com
ON Emp.CompanyId = Com.Id
WHERE Com.Name != 'Atoz';

SELECT Emp.FirstName, Emp.LastName, Com.Name
FROM Employees AS Emp
INNER JOIN Companies AS Com
ON Emp.CompanyId = Com.Id
ORDER BY Com.Name, Emp.Lastname

SELECT Emp.FirstName, Emp.LastName, Proj.Name, Stat.Name
FROM EmployeeProject AS Bridge
INNER JOIN Employees AS Emp
ON Bridge.EmployeeId = Emp.Id
INNER JOIN Projects AS Proj
ON Bridge.ProjectId = Proj.Id
INNER JOIN Status AS Stat
ON Proj.StatusId = Stat.Id
WHERE Stat.Name = 'en proceso';

