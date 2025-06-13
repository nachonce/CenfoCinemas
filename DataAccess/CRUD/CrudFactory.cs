using DataAccess.DAOs;
using System;
using DTOs;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUD
{

    //clase madre abstracta de lus CRUDS de fine como se hacen los cruds en la arquitectura
    public abstract class CrudFactory
    {

        protected SqlDao _sqlDao;
        //definir los emtodos que forman parte del contrato 
        //create
        //retrive
        //Udate
        // Delete

        public abstract void Create(BaseDTO baseDTO);
        public abstract void Update(BaseDTO baseDTO);
        public abstract void Delete(BaseDTO baseDTO);
        public abstract T Retrieve<T>();
        public abstract T RetrieveById<T>(string id);
        public abstract List<T> RetrieveAll<T>();





    }
}
