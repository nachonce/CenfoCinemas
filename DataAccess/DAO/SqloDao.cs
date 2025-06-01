using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    internal class SqloDao
    {

        // crear una instancia prvada de la misma clase

        private static SqloDao _instance;
        private string _connectionString;

        // pase numero 2: redidfinir el constructor default y convertirlo en privado

        private SqloDao() { 
        _connectionString = string.Empty;

        }

        // definir el metodo que expone la instancia 
        public static SqloDao getInstance() {
            if (_instance == null) { 
            _instance = new SqloDao();
            }
            return _instance;

        }

        //metodo para la ejecucionde de SP sin retorno

        public void ExcecuteProcedure(SqlOperation operation) { 
        //conectarse a la base da datos
        //ejecutar el SP
        
        }

        //metodo para la ejecucion de SP con retrono de data
        public List<Dictionary<string, object>> ExecuteQueryProcedure(SqlOperation operation)
        {
            //ejecutar en la base de datos
            // Ejecutar el SP
            //Capturar el resultado
            //Covertirlo en DTO´s
            var list = new List<Dictionary<string, object>>();
            return list;

        }
            }
}
