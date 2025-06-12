﻿---sp para crear usuario
CREATE PROCEDURE CRE_MOVIE_PR
(
	@P_Title nvarchar(35),
	@P_Description nvarchar(150),
	@P_ReleaseDate  dateTime,
	@P_Genre nvarchar(20),
	@P_Director nvarchar(30)

   
)
AS
BEGIN
	INSERT INTO TBL_Movie(Created, Title, Description, ReleaseDate, Genre, Director)
	VALUES (GETDATE(),@P_Title, @P_Description, @P_ReleaseDate, @P_Genre,@P_Director);
END
GO