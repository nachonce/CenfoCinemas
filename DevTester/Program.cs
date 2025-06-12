using DataAccess.DAOs;

public class program {

    public static void Main(String[] args) {

        var sqlOperation = new SqlOperation();
        sqlOperation.ProcedureName = "CRE_USER_PR";

        sqlOperation.AddStringParameter("P_UserCode", "bjoseign");
        sqlOperation.AddStringParameter("P_Name", "Nacho");
        sqlOperation.AddStringParameter("P_Email", "nacho3_6@hotmail.com");
        sqlOperation.AddStringParameter("P_Password", "Cenfotec123?");
        sqlOperation.AddStringParameter("P_Status", "AC");
        sqlOperation.AddDateTimeParam("P_BirthDate", DateTime.Now);

        var sqlDao = SqlDao.GetInstance();
        sqlDao.ExecuteProcedure(sqlOperation);

        var movieOperation = new SqlOperation();
        movieOperation.ProcedureName = "CRE_MOVIE_PR";

        movieOperation.AddStringParameter("P_Title", "Titanic");
        movieOperation.AddStringParameter("P_Description", "El barco se hunde");
        movieOperation.AddDateTimeParam("P_ReleaseDate", DateTime.Now);
        movieOperation.AddStringParameter("P_Genre", "Drama");
        movieOperation.AddStringParameter("P_Director", "Juan Lopez");

        sqlDao.ExecuteProcedure(movieOperation);

    }

}


