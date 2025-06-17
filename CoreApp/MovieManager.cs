using DataAccess.CRUD;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp
{
    public  class MovieManager: BaseManager
    {

        public async Task Create(Movie movie)
        {
            try
            {
                var mCrud = new MovieCrudFactory();

                // Verificar si la película ya está registrada por título
                var existingMovie = mCrud.RetrieveByTitle(movie);

                if (existingMovie != null)
                {
                    throw new Exception("La película ya está registrada");
                }

                // Si no existe, crear la nueva película
                mCrud.Create(movie);

                var uCrud = new UserCrudFactory();
                try
                {
                    var allEmails = uCrud.GetAllEmails();
                    Console.WriteLine("Correos encontrados: " + allEmails.Count);

                    foreach (var email in allEmails)
                    {
                        await EmailSender.SendNewMovieEmail(email, movie.Title);
                    }
                }
                catch (Exception innerEx)
                {
                    Console.WriteLine("⚠️ Error al obtener o enviar correos: " + innerEx.Message);
                }


            }
            catch (Exception ex)
            {
                ManagerException(ex); // Método heredado de BaseManager para manejo uniforme
            }
        }
    }
}

