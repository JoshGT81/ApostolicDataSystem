function mostrarValidacionCampo(control, esValido = true, mensajeEtiqueta = null) {

    var etiquetaExistente = document.getElementById("lblFeedBack" + control.id);
    if (typeof (etiquetaExistente) != 'undefined' && etiquetaExistente != null) {
        control.parentElement.removeChild(etiquetaExistente);
    }

    if (mensajeEtiqueta != null) {
        etiqueta = document.createElement('span');
        etiqueta.setAttribute("id", "lblFeedBack" + control.id);
        etiqueta.setAttribute("class", "form-label" + (esValido ? "" : " text-danger"));
        etiqueta.innerHTML = (mensajeEtiqueta !== null ? mensajeEtiqueta : "");
        control.parentElement.appendChild(etiqueta);
    }

    if (esValido) {
        control.classList.remove("is-invalid");
    }
    else {
        control.classList.add("is-invalid");
        control.value = "";
    }
}

function validaTexto(control) {
    var idValor = control.value;

    if (idValor.length > 0) {
        var valor = idValor.split("");
        const pattern = "0123456789°!\"#$%&/()=?¿.,'¡¨|*][_:}{;+-\\<>¬@^`~";
        var patternarray = pattern.split("");

        for (var i = 0; i < valor.length; i++) {
            var result = patternarray.includes(valor[i]);
            if (result) {
                mostrarValidacionCampo(control, false, "El valor ingresado es incorrecto.");
            } else {
                mostrarValidacionCampo(control);
            }
        }
    }
    else {
        mostrarValidacionCampo(control, false, "Es necesario que ingrese información.");
    }
}

function validaFecha(control) {
    const fecha = control.value;
    const _fechaHoy = new Date();
    var fechaAntigua = new Date("1950-01-01");
    var nombreElemento = control.getAttribute('name');

    //Valida fecha ingresada
    if (fecha.trim().length > 0) {
        var _fechaRecibida = new Date(fecha);
        var _fecha = new Date(_fechaRecibida.getFullYear(), _fechaRecibida.getMonth(), _fechaRecibida.getDate() + 1, _fechaHoy.getHours(), _fechaHoy.getMinutes(), _fechaHoy.getSeconds());
        _fecha.setHours(0, 0, 0, 0);
        mostrarValidacionCampo(control);

        if (_fecha.getTime() < fechaAntigua.getTime() || _fecha.getTime() > _fechaHoy.getTime()) {
            mostrarValidacionCampo(control, false, "La Fecha esta fuera de rango.");
            control.value = "";
        }
    }
    else {
        mostrarValidacionCampo(control, false, "La Fecha ingresada Invalida.");
        control.value = "";
    }
}

function validaSeleccion(control) {
    const selectedValue = control.value;
    if (selectedValue!="Elegir...") {
        mostrarValidacionCampo(control);
    } else {
        mostrarValidacionCampo(control, false, "Debe seleccionar una opción.");
    }
}

function validaDireccion(control) {
    var idControl = document.getElementById(control);
    var idValor = control.value;

    if (idValor.length > 0) {
        var valor = idValor.split("");
        const pattern = "°!\"$%&()=?¿'¡¨|*][_:}{;+\\<>¬@^`~";
        var patternarray = pattern.split("");

        for (var i = 0; i < valor.length; i++) {
            var result = patternarray.includes(valor[i]);
            if (result) {
                mostrarValidacionCampo(control, false, "La dirección ingresada no es correcta.");
            } else {
                mostrarValidacionCampo(control);
            }
        }
    }
    else {
        mostrarValidacionCampo(control, false, "Es necesario que ingrese esta información.");
    }
}

function controlInvalido(control) {    
    mostrarValidacionCampo(control, false, "Es necesario que ingrese esta información.");
}

function validaEmail(control) {
    var idValor = control.value;

    if (idValor.length > 0) {
        const pattern = "/^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$/";
        
        if (pattern.test(control.value)) {
            mostrarValidacionCampo(control, false, "Ingrese un correo Electrónico válido.");
        } else {
            mostrarValidacionCampo(control);
        }        
    }
    else {
        mostrarValidacionCampo(control, false, "Es necesario que ingrese información.");
    }
}