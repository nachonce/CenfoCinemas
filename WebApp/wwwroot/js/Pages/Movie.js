function MovieViewController() {

    this.ViewName = "Movies";
    this.ApiEndPointName = "Movie";

    this.InitView = function () {
        console.log("Movie init view ----> OK");
        this.LoadTable();
        
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

    }
}

$(document).ready(function () {
    var vc = new MovieViewController();
    vc.InitView();

})