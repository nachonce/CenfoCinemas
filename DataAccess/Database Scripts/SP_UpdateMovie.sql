CREATE PROCEDURE UPD_MOVIE_PR
    @Id INT,
    @Title NVARCHAR(35),
    @Description NVARCHAR(150),
    @ReleaseDate DATETIME,
    @Genre NVARCHAR(20),
    @Director NVARCHAR(30)
AS
BEGIN
    UPDATE TBL_Movie
    SET
        Title = @Title,
        Description = @Description,
        ReleaseDate = @ReleaseDate,
        Genre = @Genre,
        Director = @Director,
        Updated = GETDATE()
    WHERE Id = @Id
END
