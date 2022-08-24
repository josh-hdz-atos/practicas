USE [Practica]
GO
/****** Object:  Trigger [dbo].[Update_Project_Status]    Script Date: 8/23/2022 10:13:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Joshua Hernandez
-- Create date: 08/23/2022
-- Description:	Updates the project's status to pendiente 
--				when the project's start date after the
--				project's day of creation and the deadline
--				hasn't passed.
-- =============================================
CREATE TRIGGER [dbo].[Update_Project_Status] 
   ON  [Practica].[dbo].[Projects] 
   AFTER INSERT
AS 
BEGIN
	DECLARE @todayDate DATE = GETDATE()
	DECLARE @startDate DATE
	DECLARE @deadline DATE
	DECLARE @id INT

	SELECT
		@startDate=StartDate,
		@deadline=Deadline,
		@id=Id
	FROM inserted

	IF @startDate > @todayDate AND @todayDate < @deadline
	BEGIN
		UPDATE Projects SET Projects.StatusId=(SELECT Id FROM Status WHERE Name = 'Pendiente') WHERE Projects.Id=@id;
	END;
END;
GO;

-- =============================================
-- Author:		Joshua Hernandez
-- Create date: 08/23/2022
-- Description:	Checks the prject's deadline is beofre
--				the day of creation.
-- =============================================
CREATE TRIGGER [dbo].[Invalid_Deadline] 
   ON  [Practica].[dbo].[Projects]
   INSTEAD OF INSERT
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @deadline DATE
	DECLARE @startDate DATE

	SELECT @startDate=Startdate, @deadline=Deadline
	FROM inserted

	IF @startDate > @deadline
	BEGIN
		RAISERROR('Invalid deadline', 1, 1);
		ROLLBACK TRANSACTION;
	END;
END

