using DataAccess.DAOs;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataAccess.CRUD
{
    public class UserCrudFactory : CrudFactory
    {

            public UserCrudFactory() { 
                _sqlDao = SqlDao.GetInstance(); 
        }
        public override void Create(BaseDTO baseDTO)
        {
            var user = baseDTO as User;
            var op = new SqlOperation();
            op.ProcedureName = "CRE_USER_PR";


            op.AddStringParameter("P_UserCode", user.UserCode);
            op.AddStringParameter("P_Name", user.Name);
            op.AddStringParameter("P_Email", user.Email);
            op.AddStringParameter("P_Password", user.Password);
            op.AddStringParameter("P_Status", user.Status);
            op.AddDateTimeParam("P_BirthDate", user.BirthDate);

            _sqlDao.ExecuteProcedure(op);
        }

        public override void Delete(BaseDTO baseDTO)
        {
            var user = (User)baseDTO;
            var sqlOperation = new SqlOperation();
            sqlOperation.ProcedureName = "DEL_USER_PR";
            sqlOperation.AddStringParameter("@P_UserCode", user.UserCode); 

            _sqlDao.ExecuteProcedure(sqlOperation); 

        }




        public override T RetrieveById<T>(int id)
        {
            var op = new SqlOperation();
            op.ProcedureName = "RET_USER_BY_ID_PR";
            op.AddIntParam("P_Id", id);

            var result = _sqlDao.ExecuteQueryProcedure(op);

            if (result.Count > 0)
            {
                var row = result[0];
                var user = BuildUser(row);
                return (T)Convert.ChangeType(user, typeof(T));
            }

            return default(T); // o throw new Exception("Usuario no encontrado");
        }






        public T RetrieveByUerCode<T>(string userCode)
        {
                var sqlOperation = new SqlOperation();
            sqlOperation.ProcedureName = "RET_USER_BY_CODE_PR";
            sqlOperation.AddStringParameter("P_UserCode", userCode);

            var lstResults = _sqlDao.ExecuteQueryProcedure(sqlOperation);


            if (lstResults.Count > 0) {
                var row = lstResults[0];
                var user = BuildUser(row);

                return (T)Convert.ChangeType(user, typeof(T));

                    
            
            }
            return default(T);
        }






        public T RetrieveByEmail<T>(string  email)
        {
            var sqlOperation = new SqlOperation();
            sqlOperation.ProcedureName = "RET_USER_BY_EMAIL_PR";
            sqlOperation.AddStringParameter("P_Email", email);

            var lstResults = _sqlDao.ExecuteQueryProcedure(sqlOperation);


            if (lstResults.Count > 0)
            {
                var row = lstResults[0];
               var user = BuildUser(row);

                return (T)Convert.ChangeType(user, typeof(T));



            }
            return default(T);
        }







        public override List<T> RetrieveAll<T>()
        {
            var lstUsers = new List<T>();
            var sqlOperation = new SqlOperation();
            sqlOperation.ProcedureName = "RET_ALL_USER_PR";

            var lstResults = _sqlDao.ExecuteQueryProcedure(sqlOperation);

            if (lstResults.Count > 0) {
                foreach (var row in lstResults) {
                    var user = BuildUser(row);
                    lstUsers.Add((T)Convert.ChangeType(user, typeof(T)));
                }
            }
            return lstUsers;

        }


        public override void Update(BaseDTO baseDTO)
        {
            throw new NotImplementedException();
        }




        // metodo que convirte el diccionario en un usuario

        private User BuildUser(Dictionary<string, object> row) { 
        
            var user = new User() 
            { 
            
                Id = (int)row["Id"],
                Created = (DateTime)row["Created"],
               // Updated = (DateTime)row["Updated"],
                UserCode = (string)row["UserCode"],
                Name = (string)row["Name"],
                Email = (string)row["Email"],
                Password = (string)row["Password"],
                BirthDate = (DateTime)row["BirthDate"],
                Status = (string)row["Status"]





            };
            return user;
        }

        public override T Retrieve<T>()
        {
            throw new NotImplementedException();
        }


        public List<string> GetAllEmails() { 
        
            var emails =new List<string>();
            var sqlOpearation = new SqlOperation();
            sqlOpearation.ProcedureName = "RET_ALL_EMAILS_PR";


            var result = _sqlDao.ExecuteQueryProcedure(sqlOpearation);

            foreach (var row in result) {

                emails.Add((string)row["Email"]);

            }
            return emails;
        
        }
    }
}
