using DataAccess.DAOs;
using DTOs;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUD
{
    public  class MovieCrudFactory : CrudFactory
    {

        public MovieCrudFactory()
        {
            _sqlDao = SqlDao.GetInstance();
        }
        public override void Create(BaseDTO baseDTO)
        {
            var movie = baseDTO as Movie;
            var op = new SqlOperation();
            op.ProcedureName = "CRE_MOVIE_PR";

            op.ProcedureName = "CRE_MOVIE_PR";
            op.AddStringParameter("P_Title",movie.Title );
            op.AddStringParameter("P_Description", movie.Description);
            op.AddDateTimeParam("P_ReleaseDate", movie.ReleaseDate);
            op.AddStringParameter("P_Genre", movie.Genre);
            op.AddStringParameter("P_Director", movie.Director);

            _sqlDao.ExecuteProcedure(op);
        }

        public override void Delete(BaseDTO baseDTO)
        {
            var movie = (Movie)baseDTO;
            var sqlOperation = new SqlOperation();
            sqlOperation.ProcedureName = "DEL_MOVIE_PR";
            sqlOperation.AddStringParameter("@P_Title", movie.Title);

            _sqlDao.ExecuteProcedure(sqlOperation);
        }

        public override T Retrieve<T>()
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstMovies = new List<T>();
            var sqlOperation = new SqlOperation();
            sqlOperation.ProcedureName = "RET_ALL_MOVIES_PR";

            var lstResults = _sqlDao.ExecuteQueryProcedure(sqlOperation);

            if (lstResults.Count > 0)
            {
                foreach (var row in lstResults)
                {
                    var movie = BuildMovie(row);
                    lstMovies.Add((T)Convert.ChangeType(movie, typeof(T)));
                }
            }
            return lstMovies;
        }

        public override T RetrieveById<T>(int   id)
        {
            

            var op = new SqlOperation();
            op.ProcedureName = "RET_MOVIE_BY_ID_PR";
            op.AddIntParam("P_Id", id);

            var result = _sqlDao.ExecuteQueryProcedure(op);

            if (result.Count > 0)
            {
                var row = result[0];
                var movie = BuildMovie(row);
                return (T)(object)movie;
            }

            return default(T);
        }



        public override void Update(BaseDTO baseDTO)
        {
            var movie = (Movie)baseDTO;
            var sqlOperation = new SqlOperation
            {
                ProcedureName = "UPD_MOVIE_PR"
            };

            sqlOperation.AddIntParam("Id", movie.Id);
            sqlOperation.AddStringParameter("Title", movie.Title);
            sqlOperation.AddStringParameter("Description", movie.Description);
            sqlOperation.AddDateTimeParam("ReleaseDate", movie.ReleaseDate);
            sqlOperation.AddStringParameter("Genre", movie.Genre);
            sqlOperation.AddStringParameter("Director", movie.Director);

            _sqlDao.ExecuteProcedure(sqlOperation);
        }


        private Movie BuildMovie(Dictionary<string, object> row)
        {

            var movie = new Movie()
            {

                Id = (int)row["Id"],
                Created = (DateTime)row["Created"],
                // Updated = (DateTime)row["Updated"],
                Title = (string)row["Title"],
                Description = (string)row["Description"],
                ReleaseDate = (DateTime)row["ReleaseDate"],
                Genre = (string)row["Genre"],
                Director = (string)row["Director"],
       
            };
            return movie;
        }

        public Movie RetrieveByTitle(Movie movie)
        {
            var sqlOperation = new SqlOperation
            {
                ProcedureName = "RET_MOVIE_BY_TITLE_PR"
            };
            sqlOperation.AddStringParameter("P_Title", movie.Title);

            var result = _sqlDao.ExecuteQueryProcedure(sqlOperation);

            if (result.Count > 0)
            {
                var obj = BuildMovie(result[0]);
                return (Movie)obj;
            }

            return null;
        }

    }
}
