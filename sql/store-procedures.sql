CREATE PROCEDURE ReassignProject(@projectName VARCHAR(101), @companyName VARCHAR(150))
AS BEGIN
    DECLARE @employeeId INT
    DECLARE @projectId INT

    SELECT @projectId = ProjectId
    FROM EmployeeProject AS Brdg
    INNER JOIN Projects AS Proj
    ON Brdg.ProjectId = Proj.Id
    WHERE Proj.Name = @projectName

    SELECT TOP 1 @employeeId = Empl.Id
    FROM Employees AS Empl
    INNER JOIN Companies AS Comp
    ON Empl.CompanyId = Comp.Id
    WHERE Comp.Name = @companyName

    WHILE @employeeId IS NOT NULL
    BEGIN
        IF (dbo.HasAnyProject(@employeeId) = 1)
        BEGIN
            DELETE
            FROM EmployeeProject
            WHERE EmployeeId = @employeeId;

            INSERT INTO EmployeeProject (EmployeeId, ProjectId)
            VALUES (@employeeId, @projectId)
        END;
    END;
END;
