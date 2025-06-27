//ja que maneja todo el comoportamineto de la vista de usuarios
//definir una clase JS usando prototype
function UsersViewController() {


    this.ViewName = "Users";
    this.ApiEndPointName = "User";


    this.InitView = function () {
        console.log("User init view ----> OK");
        this.LoadTable();
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
    }
}


$(document).ready(function () {
    var vc = new UsersViewController();
    vc.InitView();

})