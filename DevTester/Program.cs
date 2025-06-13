using DataAccess.CRUD;
using DataAccess.DAOs;
using DTOs;
using Newtonsoft.Json;
using System;
using System.Text.Json.Serialization;

public class program {

    public static void Main(String[] args) {

        var sqlDao = SqlDao.GetInstance();

        bool salir = false;

        while (!salir)
        {

            Console.WriteLine("Bienvenido al sistema\n");
            Console.WriteLine("1. Agregar Usuario");
            Console.WriteLine("2. Agregar Pelicula");
            Console.WriteLine("3. Actualizar Pelicula");
            Console.WriteLine("4. Actualizar Usuario");
            Console.WriteLine("5. Borrar Usuario");
            Console.WriteLine("6. Borrar Pelicula");
            Console.WriteLine("7. Consultar Usuario");
            Console.WriteLine("8. Consultar Pelicula");
            Console.WriteLine("9. Listar Todos los Usuarios");
            Console.WriteLine("10. Listar Todos las Peliculas");

            Console.WriteLine("11. Consultar usuario por código");
            Console.WriteLine("11. Consultar pelicula por código");

            Console.WriteLine("12.Salir");


            Console.WriteLine("Seleccione una opcion");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    AgregarUsuario();
                   
                    break;
                case "2":
                    AgregarPelicula(sqlDao);
                    break;
                 case "3":
                    ActualizarUsuario(sqlDao);
                    break;
                
                case "5":
                    BorrarUsuario(sqlDao);
                    break;
               
                case "9":
                    ListarUsuarios(sqlDao);
                    break;
                case "10":
                    ListarPeliculas(sqlDao);
                    break;
                case "11":
                    ConsultarUsuarioPorCodigo();

                    break;

                case "12":
                    ConsultarPeliculaPorId();
                    break;
                case "13":
                    salir = true;
                    break;
                default:

                    Console.WriteLine("Opcion no valid");
                    break;
            
            }
            Console.WriteLine();



        }

        static void AgregarPelicula(SqlDao sqlDao) {

            Console.WriteLine("Titulo...");
            string title = Console.ReadLine();

            Console.WriteLine("Desription...");
            string description = Console.ReadLine();

            Console.WriteLine("Genero...");
            string genre = Console.ReadLine();

            Console.WriteLine("Director...");
            string director = Console.ReadLine();

            DateTime releaseDate = DateTime.Now;

            var movie = new Movie()
            {
                Title = title,
                Description = description,
                Genre = genre,
                Director = director,
                ReleaseDate = releaseDate,
               

            };
            var uCrud = new MovieCrudFactory();
            uCrud.Create(movie);

            Console.WriteLine("Película agregada con éxito.");


        }


        static void AgregarUsuario()
        {
            Console.Write("Código de usuario: ");
            string userCode = Console.ReadLine();

            Console.Write("Nombre: ");
            string name = Console.ReadLine();

            Console.Write("Correo: ");
            string email = Console.ReadLine();

            Console.Write("Contraseña: ");
            string password = Console.ReadLine();

            Console.Write("Estado (ej: AC): ");
            string status = Console.ReadLine();

            Console.Write("Fecha de nacimiento (yyyy-mm-dd): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

                //creamos el objeto del usuario a aprtir de los valores capturados
                var user = new User()
                {
                    UserCode = userCode,
                    Name = name,
                    Email = email,
                    Password =  password,
                    Status = status,
                    BirthDate = birthDate

                };
                var uCrud = new UserCrudFactory();
                uCrud.Create(user);

            Console.WriteLine(" Usuario agregado con éxito.");
        }

        static void ActualizarUsuario(SqlDao sqlDao)
        {
            Console.Write("Código nuevo del usuario: ");
            string userCode = Console.ReadLine();

            Console.Write("Nombre Nuevo: ");
            string nombre = Console.ReadLine();

            Console.Write("Correo Nuevo: ");
            string correo = Console.ReadLine();

            Console.Write("Contraseña Nueva: ");
            string password = Console.ReadLine();

            Console.Write("Estado (ej: AC): ");
            string status = Console.ReadLine();

            Console.Write("Fecha de nacimiento (yyyy-mm-dd): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            var op = new SqlOperation();
            op.ProcedureName = "UPD_USER_PR";


            op.AddStringParameter("P_UserCode", userCode);
            op.AddStringParameter("P_Name", nombre);
            op.AddStringParameter("P_Email", correo);
            op.AddStringParameter("P_Password", password);
            op.AddStringParameter("P_Status", status);
            op.AddDateTimeParam("P_BirthDate", birthDate);

            sqlDao.ExecuteProcedure(op);
            Console.WriteLine(" Usuario actualizado con éxito.");
        }


        static void BorrarUsuario(SqlDao sqlDao) { 
            Console.WriteLine("Digite el codigo del Usuario");
            string userCode = Console.ReadLine();

            var op = new SqlOperation();
            op.ProcedureName = "DEL_USER_PR";
            op.AddStringParameter("P_userCode", userCode);

            sqlDao.ExecuteProcedure(op);
            Console.WriteLine(" Usuario actualizado con éxito.");


        }

        static void ListarUsuarios(SqlDao sqlDao) {
            var uCrud = new UserCrudFactory();
            var lstUsers = uCrud.RetrieveAll<User>();
            foreach (var u in lstUsers) {
                Console.WriteLine(JsonConvert.SerializeObject(u));
            }
        }

        static void ListarPeliculas(SqlDao sqlDao)
        {
            var uCrud = new MovieCrudFactory();
            var lstMovies = uCrud.RetrieveAll<Movie>();
            foreach (var u in lstMovies)
            {
                Console.WriteLine(JsonConvert.SerializeObject(u));
            }
        }

        static void ConsultarUsuarioPorCodigo()
        {
            Console.Write("Digite el código del usuario: ");
            string userCode = Console.ReadLine();

            var uCrud = new UserCrudFactory();
            var user = uCrud.RetrieveById<User>(userCode);

            if (user != null)
            {
                Console.WriteLine("Usuario encontrado:");
                Console.WriteLine(JsonConvert.SerializeObject(user, Formatting.Indented));
            }
            else
            {
                Console.WriteLine("Usuario no encontrado.");
            }
        }

        static void ConsultarPeliculaPorId()
        {
            Console.Write("Digite el ID de la película: ");
            string idStr = Console.ReadLine();

            var mCrud = new MovieCrudFactory();
            var movie = mCrud.RetrieveById<Movie>(idStr);

            if (movie != null)
            {
                Console.WriteLine("Película encontrada:");
                Console.WriteLine(JsonConvert.SerializeObject(movie, Formatting.Indented));
            }
            else
            {
                Console.WriteLine("Película no encontrada.");
            }
        }



    }



}


