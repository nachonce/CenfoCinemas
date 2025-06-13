--SP PARA CREAR USUARIO
CREATE PROCEDURE CRE_USER_PR
(

	@P_userCode nvarchar(30),
	@P_Name nvarchar(50),
	@P_Email nvarchar(30),
	@P_Password nvarchar(50),
	@P_BirthDate Datetime,
	@P_Status nvarchar (10)


)
AS
BEGIN
    INSERT INTO TBL_User(Created, UserCode, Name, Email, Password,Status, BirthDate)
	VALUES(GETDATE(), @P_UserCode, @P_Name, @P_Email, @P_Password, @P_BirthDate, @P_Status);
END
GO
