using DataAccess.CRUD;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;


namespace CoreApp
{
    public  class UserManager : BaseManager
    {

        //metodo para la creacion de un usuario, valid que ele usuario sea mayor de 18 anhos,
        //Valida que el codigo de usuario este disponible,
        //valida que el correo elelctronico no este registrado
        //envia un correo electrnico de bienvenida


        
        public void Create(User user)
        {
            try
            {
                if (IsOver18(user))
                {
                    var uCrud = new UserCrudFactory();

                    // Verificar si ya existe un usuario con ese código
                    Console.WriteLine("DEBUG USER CODE: " + user.UserCode);
                    var uExist = uCrud.RetrieveByUerCode<User>(user.UserCode);
                    if (uExist != null)
                    {
                        throw new Exception("El código no está disponible");
                    }

                    // Verificar si ya existe un usuario con ese correo
                    var emailExist = uCrud.RetrieveByEmail<User>(user.Email);
                    if (emailExist != null)
                    {
                        throw new Exception("El correo ya está registrado");
                    }

                    // Si pasa todas las validaciones, crear el usuario
                    uCrud.Create(user);
                    // .Wait() si estás en un método no async
                    /*
                    try
                    {
                        EmailSender.SendWelcomeEmail(user.Email, user.Name).Wait();
                    }
                    catch (Exception mailEx)
                    {
                        
                        Console.WriteLine($"Error enviando correo de bienvenida: {mailEx.Message}");

                    }
                    */
                }
                else
                {
                    throw new Exception("El usuario no cumple con la edad mínima");
                }
            }
            catch (Exception ex)
            {
                ManagerException(ex);
            }
        }

        public List<User> RetrieveAll() {


            var uCrud = new UserCrudFactory();
            return uCrud.RetrieveAll<User>();
        }

        public void Delete(User  user ) {
            var uCrud = new UserCrudFactory();
           
            uCrud.Delete(user);
        }

        public T RetrieveByEmail<T>(string email) { 

            var uCrud = new UserCrudFactory();
         

            return uCrud.RetrieveByEmail<T>(email);
        
        }

        public void Update(User user) { 
            var uCrud = new UserCrudFactory();
            uCrud.Update(user); 
        }




        private Boolean IsOver18(User user)
        {
            var currentDate = DateTime.Now;
            int age = currentDate.Year - user.BirthDate.Year;

            if (user.BirthDate > currentDate.AddYears(-age).Date)
            {

                age--;


            }

            return age >= 18;


        }


        
    }
}

