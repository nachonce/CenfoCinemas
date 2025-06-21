using CoreApp;
using DataAccess.CRUD;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class MovieController : ControllerBase
    {
        [HttpPost]
        [Route("Create")]

        public ActionResult Create(Movie movie)
        {
            try
            {

                var um = new MovieManager();
                um.Create(movie);
                return Ok(movie);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    
    

     [HttpDelete]
        [Route("Delete/{title}")]

        public ActionResult Delete(string title)
        {
            try
            {

                var um = new MovieManager();



                um.Delete(title);

                return Ok("Pelicula eliminada correctamente");
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }

        }


        [HttpGet]
        [Route("RetrieveAll")]

        public ActionResult RetrieveAll()

        {
            try
            {
                var um = new MovieManager();
                var listResults = um.RetrieveAll();

                return Ok(listResults);

            }
            catch (Exception ex)

            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPut]
        [Route("Update")]
        public ActionResult Update(Movie movie)
        {
            try
            {
                var movieManager = new MovieManager();
                movieManager.Update(movie);
                return Ok("La película fue actualizada correctamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("RetrieveById/{id}")]

        public ActionResult RetrieveById(int id)
        {
            try
            {
                var um = new MovieManager();
                var movieResult = um.RetrieveById(id);


                return Ok(movieResult);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }

        }


    }

}
