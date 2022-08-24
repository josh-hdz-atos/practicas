CREATE FUNCTION HasAnyProject(@name VARCHAR(101))
RETURNS BIT
BEGIN
    DECLARE @projCount INT;

    SELECT @projCount = COUNT(EmployeeProject.Id) FROM EmployeeProject
    INNER JOIN Employees
    ON EmployeeProject.EmployeeId=Employees.Id
    WHERE Employees.FirstName + ' ' + Employees.LastName = @name

    IF @projCount > 0
    BEGIN
        RETURN 1;
    END;

    RETURN 0;
END;
GO;

CREATE FUNCTION GetLastProjectEmployeeName(@name VARCHAR(101))
RETURNS INT
BEGIN
    RETURN (
		SELECT TOP 1 ProjectId
		FROM EmployeeProject AS Brdg
		INNER JOIN Employees AS Empl
		ON Brdg.EmployeeId = Empl.Id
		WHERE Empl.FirstName + ' ' + Empl.LastName = @name
	);
END;
GO;