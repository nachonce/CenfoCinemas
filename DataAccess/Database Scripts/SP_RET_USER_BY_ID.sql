CREATE PROCEDURE RET_USER_BY_ID_PR
    @P_UserCode VARCHAR(30)
AS
BEGIN
    SELECT Id,
           Created,
           Updated,
           UserCode,
           Name,
           Email,
           Password,
           BirthDate,
           Status
    FROM TBL_User
    WHERE UserCode = @P_UserCode;
END
GO
