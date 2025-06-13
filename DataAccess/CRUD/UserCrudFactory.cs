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
            throw new NotImplementedException();
        }

        public override T RetrieveById<T>(string userCode)
        {
            var op = new SqlOperation();
            op.ProcedureName = "RET_USER_BY_ID_PR";
            op.AddStringParameter("P_UserCode", userCode);

            var result = _sqlDao.ExecuteQueryProcedure(op);

            if (result.Count > 0)
            {
                var row = result[0];
                var user = BuildUser(row);
                return (T)(object)user;
            }

            return default(T); // o throw new Exception("Usuario no encontrado");
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
    }
}
