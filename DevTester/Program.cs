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

    }

}


