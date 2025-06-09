using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public  class SqlOperation
    {
        public string ProcedureName { get; set; }
        public List<String> Parameters  { get; set; }

        public void ExecuteProcedure(SqlOperation sqlOperation)

        {
            using (var command = new SqlCommand(sqlOperation.ProcedureName, conn)
            { }
        }

    }
}
