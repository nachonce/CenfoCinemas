//ja que maneja todo el comoportamineto de la vista de usuarios
//definir una clase JS usando prototype
function UsersViewController() {
    this.ViewName = "Users";

    this.ApiEndPointName = "User";

    this.InitView = function () {
        console.log("User init view ----> OK");
        this.LoadTable();

        //asociar el evento al boton
        $('#btnCreate').click(function () {
            var vc = new UsersViewController();
            vc.Create();

        })

        $('#btnUpdate').click(function () {
            var vc = new UsersViewController();
            vc.Update();

        })

        $('#btnDelete').click(function () {
            var vc = new UsersViewController();
            vc.Delete();

        })


    }

    //metodo para la carga de una tabla
    this.LoadTable = function () {

        //URL del API a invocar
        //https://localhost:7084/api/User/RetrieveAll


        var ca = new ControlActions();
        var service = this.ApiEndPointName + "/RetrieveAll";

        var urlService = ca.GetUrlApiService(service);

        /*

        {
           "userCode": "juan12",
           "name": "Juan Jose Rojas",
           "email": "juan3_6@hotmail.com",
          "password": "Juan1234",
           "birthDate": "1997-06-21T19:38:29.453",
           "status": "AC",
           "id": 19,
           "created": "2025-06-21T19:39:26.35",
            "updated": "0001-01-01T00:00:00"
        }
         <tr>
                    <th>Id</th>
                    <th>User Code</th>
                    <th>Nombre</th>
                    <th>Email</th>
                    <th>Birth Date</th>
                    <th>Status</th>
                </tr>


        /* */

        var columns = [];
        columns[0] = { 'data': 'id' }
        columns[1] = { 'data': 'userCode' }
        columns[2] = { 'data': 'name' }
        columns[3] = { 'data': 'email' }
        columns[4] = { 'data': 'birthDate' }
        columns[5] = { 'data': 'status' }
        //invocamos a datatable para convertir la tabla de html en una tabla mas robusta

        $("#tblUsers").dataTable({

            "ajax": {

                url: urlService,
                "dataSrc": ""
            },
            columns: columns

        });

        //asignar eventos de carga de datos o binding segun el clic en la tabla


        $('#tblUsers tbody').on('click', 'tr', function () {
            //extraemos la fila
            var row = $(this).closest('tr');

            
            //extraemos los dto
            //esto nos devuleve el json de la fila seleccionada por el usuaroo segun la data devuleta por el API
            var userDTO = $('#tblUsers').DataTable().row(row).data();

            //Binding con el form
            $('#txtId').val(userDTO.id);
            $('#txtUserCode').val(userDTO.userCode);
            $('#txtName').val(userDTO.name);
            $('#txtEmail').val(userDTO.email);
            $('#txtStatus').val(userDTO.status);

            //fecha tiene formato
            var onlyDate = userDTO.birthDate.split('T');
            $('#txtBirthDate').val(onlyDate[0]);

        })
    }


    this.Create = function () {
        var userDTO = {};

        userDTO.id = $('#txtId').val();
        userDTO.created = "2025-01-01";
        userDTO.updated = "2025-01-01";

        userDTO.userCode = $("#txtUserCode").val();
        userDTO.name = $("#txtName").val();
        userDTO.email = $("#txtEmail").val();
        userDTO.status = $("#txtStatus").val();
        userDTO.birthDate = $("#txtBirthDate").val();

        userDTO.password = $("#txtPassword").val();

        var ca = new ControlActions();
        var urlService = this.ApiEndPointName + "/Create";
        ca.PostToAPI(urlService, userDTO, function () {
            //recargo la tabla
            $('#tblUsers').DataTable().ajax.reload();

        })
    }

    this.Update = function () {
        var userDTO = {};

        userDTO.id = $('#txtId').val();
        userDTO.cretaed = "2025-01-1";
        userDTO.updated = "2025-01-01";


        userDTO.userCode = $("#txtUserCode").val();
        userDTO.name = $("#txtName").val();
        userDTO.email = $("#txtEmail").val();
        userDTO.status = $("#txtStatus").val();
        userDTO.birthDate = $("#txtBirthDate").val();

        userDTO.password = $("#txtPassword").val();

        var ca = new ControlActions();
        var urlService = this.ApiEndPointName + "/Update";

        ca.PutToAPI(urlService, userDTO, function () {
            //recargo la tabla
            $('#tblUsers').DataTable().ajax.reload();

        })
    }

    this.Delete = function () {
        var userDTO = {};

        userDTO.id = $('#txtId').val();
        userDTO.cretaed = "2025-01-1";
        userDTO.updated = "2025-01-01";


        userDTO.userCode = $("#txtUserCode").val();
        userDTO.name = $("#txtName").val();
        userDTO.email = $("#txtEmail").val();
        userDTO.status = $("#txtStatus").val();
        userDTO.birthDate = $("#txtBirthDate").val();

        userDTO.password = $("#txtPassword").val();

        var ca = new ControlActions();
        var urlService = this.ApiEndPointName + "/Delete";

        ca.DeleteToAPI(urlService, userDTO, function () {
            //recargo la tabla
            $('#tblUsers').DataTable().ajax.reload();

        })
    }
}




$(document).ready(function () {
    var vc = new UsersViewController();
    vc.InitView();

})
