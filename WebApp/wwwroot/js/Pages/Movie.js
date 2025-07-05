function MovieViewController() {

    this.ViewName = "Movies";
    this.ApiEndPointName = "Movie";

    this.InitView = function () {
        console.log("Movie init view ----> OK");
        this.LoadTable();

        $('#btnCreate').click(function () {


            var vc = new MovieViewController();
            vc.Create();
        })

        $('#btnUpdate').click(function () {


            var vc = new MovieViewController();
            vc.Update();
        })

        $('#btnDelete').click(function () {


            var vc = new MovieViewController();
            vc.Delete();
        })

        $('#btnSearch').click(function () {

            var vc = new MovieViewController();
            vc.LoadProfile();


        })
    

    }



    this.LoadTable = function () {

        //https://localhost:7084/api/Movie/RetrieveAll


        var ca = new ControlActions();
        var service = this.ApiEndPointName + "/RetrieveAll";

        var urlService = ca.GetUrlApiService(service);
        /*
        {
        "title": "Titanic",
        "description": "El barco se hunde",
        "releaseDate": "2025-06-11T22:05:35.91",
        "genre": "Drama",
        "director": "Juan Lopez",
        "id": 1,
        "created": "2025-06-12T04:05:35.97",
        "updated": "0001-01-01T00:00:00"

           <th>Id</th>
                        <th>Title</th>
                        <th>Description</th>
                        <th>ReleaseDate</th>
                        <th>Genre</th>
                        <th>Director</th>
  }
        /* */

        var columns = [];
        columns[0] = { 'data': 'id' }
        columns[1] = { 'data': 'title' }
        columns[2] = { 'data': 'description' }
        columns[3] = { 'data': 'releaseDate' }
        columns[4] = { 'data': 'genre' }
        columns[5] = { 'data': 'director' }


        $("#tblMovies").dataTable({

            "ajax": {

                url: urlService,
                "dataSrc": ""
            },
            columns: columns

        });
        // Cuando el usuario hace clic en cualquier fila ('tr') dentro del 'tbody' de la tabla con id 'tblMovies'

        $('#tblMovies tbody').on('click', 'tr', function () {
            // Obtenemos la fila que fue clickeada

            var row = $(this).closest('tr');

            // Extraemos los datos de esa fila
            // DataTable() permite obtener la información de la tabla
            // .row(row).data() nos da un objeto con los datos de esa película

            var movieDTO = $('#tblMovies').DataTable().row(row).data();

            // Ahora colocamos esos datos en los campos del formulario
            // Esto permite al usuario editar la información de la película seleccionada
            $('#txtId').val(movieDTO.id);
            $('#txtTitle').val(movieDTO.title);
            $('#txtDescription').val(movieDTO.description);
            $('#txtGenre').val(movieDTO.genre);
            $('#txtDirector').val(movieDTO.director);

            // Normalmente la fecha viene con hora (ej: '2025-07-20T00:00:00')
            // Vamos a quitar la parte de la hora para mostrar solo la fecha
            var onlyDate = movieDTO.releaseDate.split("T");
            // Colocamos solo la fecha en el campo 'txtBirthDate'

            $('#txtReleaseDate').val(onlyDate[0])


        })
    }


    this.Create = function () {

        var movieDTO = {};
        //Atributos con valoes default que son controlados por el API
        movieDTO.id = 0;
        movieDTO.created = "2025-01-01";
        movieDTO.updated = "2025-01-01";

        //valores capturados en pantalla
        movieDTO.title = $('#txtTitle').val();
        movieDTO.description = $('#txtDescription').val();
        movieDTO.genre = $('#txtGenre').val();
        movieDTO.director = $('#txtDirector').val();
        movieDTO.releaseDate = $('#txtReleaseDate').val();


        //enviar la data a la API
        var ca = new ControlActions();
        var urlService = this.ApiEndPointName + "/Create";

        ca.PostToAPI(urlService, movieDTO, function () {
            $('#tblMovies').DataTable().ajax.reload();

        })
    }

    this.Update = function () {


        var movieDTO = {};
        movieDTO.id = $('#txtId').val();

        movieDTO.created = "2025-01-01";
        movieDTO.updated = "2025-01-01";

        //valores capturados en pantalla
        movieDTO.title = $('#txtTitle').val();
        movieDTO.description = $('#txtDescription').val();
        movieDTO.genre = $('#txtGenre').val();
        movieDTO.director = $('#txtDirector').val();
        movieDTO.releaseDate = $('#txtReleaseDate').val();


        //enviar la data a la API
        var ca = new ControlActions();
        var urlService = this.ApiEndPointName + "/Update";

        ca.PutToAPI(urlService, movieDTO, function () {
            $('#tblMovies').DataTable().ajax.reload();

        })
    }

    this.Delete = function () {


        var movieDTO = {};
        movieDTO.id = $('#txtId').val();

        movieDTO.created = "2025-01-01";
        movieDTO.updated = "2025-01-01";

        //valores capturados en pantalla
        movieDTO.title = $('#txtTitle').val();
        movieDTO.description = $('#txtDescription').val();
        movieDTO.genre = $('#txtGenre').val();
        movieDTO.director = $('#txtDirector').val();
        movieDTO.releaseDate = $('#txtReleaseDate').val();


        //enviar la data a la API
        var ca = new ControlActions();
        var urlService = this.ApiEndPointName + "/Delete";

        ca.DeleteToAPI(urlService, movieDTO, function () {
            $('#tblMovies').DataTable().ajax.reload();

        })
    }

    this.LoadProfile = function () {

        // 1. Obtener el valor del campo de texto con el ID
        const id = $("#txtId").val();
        if (!id) {
            alert("Por favor ingresa un Id para buscar.");
            return;
        }

        const urlService = this.ApiEndPointName + "/RetrieveById/" + id;
        const ca = new ControlActions();

        ca.GetToApi(urlService, function (movieDTO) {//Llamada HTTP GET a la API	Llamar por teléfono a la oficina ,
            //URL del endpoint	Número de la oficina que quiero llamar
            //function(userDTO)	Qué hacer cuando contesten	Escuchar lo que dicen y escribirlo
            // 6. Llenar el formulario con los datos del usuario
            console.log("Usuario recibido:", movieDTO);
            console.table(movieDTO);
            $('#txtId').val(movieDTO.id);
            $('#txtTitle').val(movieDTO.title);
            $('#txtDescription').val(movieDTO.description);
            $('#txtGenre').val(movieDTO.genre);
            $('#txtDirector').val(movieDTO.director);

            // Normalmente la fecha viene con hora (ej: '2025-07-20T00:00:00')
            // Vamos a quitar la parte de la hora para mostrar solo la fecha
            var onlyDate = movieDTO.releaseDate.split("T");
            // Colocamos solo la fecha en el campo 'txtBirthDate'

            $('#txtReleaseDate').val(onlyDate[0])



        });
    };
}

$(document).ready(function () {
    var vc = new MovieViewController();
    vc.InitView();

})