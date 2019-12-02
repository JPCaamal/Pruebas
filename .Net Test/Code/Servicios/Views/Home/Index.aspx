<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <title>Servicios Web</title>

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.0/css/bootstrap.min.css" integrity="sha384-9gVQ4dYFwwWSjIDZnLEWnxCjeSWFphJiwGPXr1jddIhOegiu1FwO5qRGvFXOdJZ4" crossorigin="anonymous">
    <!-- JQuery -->
    <script src="../../Scripts/jquery-3.3.1.js"></script>

    <script src="../../Scripts/JS/Principal.js" ></script>
</head>
<body>
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
        <a class="navbar-brand" href="#">Servicios Web</a>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNavAltMarkup" aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarNavAltMarkup">
                
        </div>
    </nav>
    <br />
    <div class="container">
        <form>  
            <label>Clases</label>
            <select class="form-control" id="listaClases">
                <option></option>
            </select>
            <label>Servicios</label>
            <select class="form-control" id="listaServicios">
                <option></option>
            </select>
        </form>
        <br />
        <div class="card">
            <div class="card-body">
                <h5 class="card-title">Petición</h5>
                <p class="card-text" id="formatoJSONPeticion"></p>
                <p class="card-text" id="urlPeticion"></p>
                <div id="formularioPeticion"></div>
            </div>
        </div>
        <br />
        <div class="card">
            <div class="card-body">
                <h5 class="card-title">Respuesta</h5>
                <p class="card-text" id="respuestaEsperada"></p>
                <p class="card-text" id="respuestaObtenida"></p>
            </div>
        </div>
        <br />
    </div>
    <!-- Bootstrap -->
    <!--<script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>-->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.0/umd/popper.min.js" integrity="sha384-cs/chFZiN24E4KMATLdqdvsezGxaGsi4hLGOzlXwp5UZB1LY//20VyM2taTB4QvJ" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.0/js/bootstrap.min.js" integrity="sha384-uefMccjFJAIv6A+rW+L4AHf99KvxDjWSu1z9VI8SKNVmz4sk7buKt/6v9KI65qnm" crossorigin="anonymous"></script>
</body>
</html>
