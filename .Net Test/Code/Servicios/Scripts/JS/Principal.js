DefinicionServicios = function(){
    //Parametros
    var _datos = {};
    var _url = "";
    var _respuestaPruebaObtenida = {};
    //Funciones
    var _getDatos = function () {
        return _datos;
    };
    var _consultaServiciosDisponibles = function () {
        var respuesta = $.ajax({
            global   : false,
            url      : "AdminServicios/generarJsonDefinicionServicios/",
            dataType : "json",
            success  : function (data, textStatus, jqXHR) {
                _datos = data;
            },
            error    : function (data, textStatus, jqXHR) {
               
            }
        });

        return respuesta;
    };
    var _colocarClasesDisponiblesSelect = function ( Clases ) {
        $.each( Clases, function (indice, valor) {
            $("#listaClases").append("<option value='" + indice + "'>" + indice + "</option>");
        });
    };
    var _colocarServiciosDisponiblesSelect = function (Servicios) {
        $("#listaServicios").html("<option></option>");
        $.each( Servicios, function (indice, valor) {
            $("#listaServicios").append("<option value='" + indice + "'>" + indice + "</option>");
        });
    };
    var _generarUrl = function (Clase, Servicio) {
        $("#urlPeticion").html("");
        _url = Clase + "/" + Servicio + "/";
        $("#urlPeticion").html("url: <strong>" + _url + "</strong>");
    };
    var _imprimirPeticion = function (objetoPeticion) {
        $("#formatoJSONPeticion").html("");
        var cadenaJSON = JSON.stringify(objetoPeticion, null, 2);
        $("#formatoJSONPeticion").html("json: <strong>" + cadenaJSON + "</strong>");
    };
    var _generarFormularioPeticion = function (objetoPeticion) {
        $("#formularioPeticion").html("");
        var contenidohtml = '';
        contenidohtml += '<form>';
        $.each(objetoPeticion, function (indicePrincipal, valorPrincipal) {
            $.each(valorPrincipal, function (indice, valor) {

                contenidohtml += '<div class="form-group row">';
                contenidohtml += '<label class="col-sm-2 col-form-label">' + indice + '</label>';
                contenidohtml += '<div class="col-sm-10">';
                if (valor == "String" || valor == "Int32") {
                    contenidohtml += '<input type="text" class="form-control-plaintext" value="" id="identificadorPeticion_' + indice + '">';
                }
                contenidohtml += '</div>';
                contenidohtml += '</div>';
            });
        });
        contenidohtml += '<button type="button" class="btn btn-primary mb-2" id="idBotonEnviarPeticion">Enviar petición</button>';
        contenidohtml += '</form>'
        $("#formularioPeticion").html(contenidohtml);
    };
    var _enviarPeticion = function (objetoPeticion) {
        var objPeticionEnvio = {};
        $.each(objetoPeticion, function (indicePrincipal, valorPrincipal) {
            objPeticionEnvio[indicePrincipal] = {};
            $.each(valorPrincipal, function (indice, valor) {
                objPeticionEnvio[indicePrincipal][indice] = $("#identificadorPeticion_" + indice).val();
            });
        });

        var respuesta = $.ajax({
            global   : false,
            url      : _url,
            data     : JSON.stringify(objPeticionEnvio),
            dataType : "json",
            method   : "POST",
            success  : function (data, textStatus, jqXHR) {
                _respuestaPruebaObtenida = data;
            },
            error    : function (data, textStatus, jqXHR) {

            }
        });

        return respuesta;
    };
    var _imprimirRespuesta = function ( respuestaEsperada, respuestaObtenida )
    {
        var cadenaJSONREsperada = JSON.stringify(respuestaEsperada, null, 2);
        var cadenaJSONRObtenida = JSON.stringify(respuestaObtenida, null, 2);
        $("#respuestaEsperada").html("Respuesta Esperada: <strong>" + cadenaJSONREsperada + "</strong>");
        $("#respuestaObtenida").html("Respuesta Obtenida: <strong>" + cadenaJSONRObtenida + "</strong>");
    };
    //Eventos
    var _eventoObtenerClasesDisponibles = function () {
        var promesa = new Promise(function (resolve, reject) {
            resolve(_consultaServiciosDisponibles());
        });

        promesa.then(function (response) {
            _colocarClasesDisponiblesSelect(_datos);
        });
    };
    var _eventoObtenerServiciosDisponibles = function () {
        _colocarServiciosDisponiblesSelect(_datos[$("#listaClases option:selected").val()]);
    };
    var _eventRepresentarPeticion = function () {
        var definicionPeticion = _datos[$("#listaClases option:selected").val()][$("#listaServicios option:selected").val()].DefinicionPeticion;
        _imprimirPeticion(definicionPeticion);
        _generarUrl($("#listaClases option:selected").val(), $("#listaServicios option:selected").val());
        _generarFormularioPeticion(definicionPeticion);
        $("#idBotonEnviarPeticion").bind("click", _eventEnviarPeticionObtenerRespuesta);
    };
    var _eventEnviarPeticionObtenerRespuesta = function () {
        var promesa = new Promise(function (resolve, reject) {
            var definicionPeticion = _datos[$("#listaClases option:selected").val()][$("#listaServicios option:selected").val()].DefinicionPeticion;
            resolve(_enviarPeticion(definicionPeticion));
        });

        promesa.then(function (response) {
            var respuestaEsperada = _datos[$("#listaClases option:selected").val()][$("#listaServicios option:selected").val()].DefinicionRespuesta;
            var respuestaObtenida = _respuestaPruebaObtenida;
            _imprimirRespuesta(respuestaEsperada, respuestaObtenida);
        });
    };

    return {
        eventoObtenerClasesDisponibles    : _eventoObtenerClasesDisponibles,
        eventoObtenerServiciosDisponibles : _eventoObtenerServiciosDisponibles,
        eventRepresentarPeticion          : _eventRepresentarPeticion
    };
}();

//Evento automaticos
$(document).ready(function () {
    DefinicionServicios.eventoObtenerClasesDisponibles();
});
//Eventos
$(document).ready(function () {
    $("#listaClases").bind("change", DefinicionServicios.eventoObtenerServiciosDisponibles);
    $("#listaServicios").bind("change", DefinicionServicios.eventRepresentarPeticion);
});


