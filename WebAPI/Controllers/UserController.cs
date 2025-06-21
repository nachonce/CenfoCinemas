using CoreApp;
using DataAccess.CRUD;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    //indicamos que la direccion de este controlador sera
    //https://servidor:puerto/api/User
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpPost]
        [Route("Create")]
        public ActionResult Create(User user)
        {


            try
            {
                var userManage = new UserManager();
                userManage.Create(user);
                return Ok(user);


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
                var um = new UserManager();
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
        public ActionResult Update(User user)
        {
            try
            {
                var um = new UserManager();
                um.Update(user);    
                return Ok(user + "Uusario Actualziado");
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }


        [HttpDelete]
        [Route("Delete/{userCode}")]

        public ActionResult Delete(string userCode)
        {
            try
            {

                var um = new UserManager();
                


                um.Delete(userCode);

                return Ok("Usuario eliminado correctamente");
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }

        }

        [HttpGet]
        [Route("RetrieveByEmail/{email}")]
        public ActionResult RetrieveByEmail(string  email)
        {
            try
            {
                var um = new UserManager();
                var uCrud = um.RetrieveByEmail<User>(email);
                return Ok(uCrud);
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
                var um = new UserCrudFactory();
                var uCrud = um.RetrieveById<User>(id);

                return Ok(uCrud);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }

        }

        [HttpGet]
        [Route("RetrieveByUserCode/{userCode}")]

        public ActionResult RetrieveByUserCode(string userCode)
        {

          
          

            try
            {
                var um = new UserCrudFactory();
                var userParam = new User() { UserCode = userCode };
                var userResult = um.RetrieveByUerCode<User>(userCode);

                return Ok(userResult);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }

        }
    }
}
