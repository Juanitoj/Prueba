$().ready(
    () => {
        listaConsultorio();
        listaEquipamento();
        listaTratamiento();
        listaLocales();
    }
    
);
///////////////////Consultorio/////////////////////////////
var nuevo_Consultorio = () => {
    var Numero = document.getElementById('Numero').value;
    

    var ConsultoriosId = document.getElementById('ConsultoriosId').value;

    if (ConsultoriosId == '') {
        var accion = '../Consultorios/Nuevo_Consultorio_Controller';
    } else {
        var accion = '../Consultorios/Editar_Consultorio_Controller';
    }

    var consultorio = new ClaseConsultorios(Numero, accion);
    consultorio.nuevo_Consultorio(ConsultoriosId);

}
var Un_Consultorio = (ConsultoriosId) => {
        var accion = "Consultorios/Un_Equipamiento_Controller";
        var consultorio = new ClaseConsultorios(' ', accion);
        consultorio.Un_Consultorio(ConsultoriosId);
    }


    var eliminar_consultorios = (ConsultoriosId) => {
        var accion = "Consultorios/Eliminar_Consultorio_Controller";
        var consultorios = new ClaseConsultorios(' ', accion);
        consultorios.eliminar_consultorios(ConsultoriosId);
    }

    var listaConsultorio = () => {
        var accion = '../Consultorios/Lista_Consultorio_Controller';
        var consultorios = new ClaseConsultorios('', accion);
        consultorios.listaConsultorio();
    }


////equipamento////////////////
var nuevo_Equipamento = () => {
    var NSerie = document.getElementById('NSerie').value;
    var Fecha = document.getElementById('Fecha').value;
    var Tipos = document.getElementById('Tipos').value;
    

    var EquipamientoId = document.getElementById('EquipamientoId').value;

    if (EquipamientoId == '') {
        var accion = '../Equipamientos/Nuevo_Equipamiento_Controller';
    } else {
        var accion = '../Equipamientos/Editar_Equipamiento_Controller';
    }

    var equipamiento = new ClaseEquipamento(NSerie, Fecha, Tipos, accion);
    equipamiento.nuevo_Equipamento(EquipamientoId);

}
var Un_Equipamiento = (EquipamientoId) => {
    var accion = "Equipamientos/Un_Equipamiento_Controller";
    var equipamiento = new ClaseEquipamento('', '', '', accion);
        equipamiento.Un_Equipamiento(EquipamientoId);
    }


var eliminar_equipamiento = (EquipamientoId) => {
    var accion = "Equipamientos/Eliminar_Equipamiento_Controller";
        var equipamiento = new ClaseEquipamento('', '', '', accion);
        equipamiento.eliminar_equipamiento(EquipamientoId);
    }

var listaEquipamento = () => {
    var accion = '../Equipamientos/Lista_Equipamiento_Controller';
        var equipamiento = new ClaseEquipamento('','','', accion);
        equipamiento.listaEquipamento();
}


////////////////Tratamiento/////////////////////

var nuevo_Tratamiento = () => {
    var Nombre = document.getElementById('Nombre').value;
    var Costo = document.getElementById('Costo').value;
    var TratamientoId = document.getElementById('TratamientoId').value;

    if (TratamientoId == '') {
        var accion = '../Tratamientos/Nuevo_Tratamiento_Controller';
    } else {
        var accion = '../Tratamientos/Editar_Tratamiento_Controller';
    }

    var tratamiento = new ClaseTratamiento(Nombre, Costo, accion);
    tratamiento.nuevo_Tratamiento(TratamientoId);

}
var Un_Tratamiento = (TratamientoId) => {
    var accion = "Tratamientos/Un_Tratamiento_Controller";
    var tratamiento = new ClaseTratamiento('', '', accion);
    tratamiento.Un_Tratamiento(TratamientoId);
}


var eliminar_tratamiento = (TratamientoId) => {
    var accion = "Tratamientos/Eliminar_Tratamiento_Controller";
    var tratamiento = new ClaseTratamiento('', '',  accion);
    tratamiento.eliminar_tratamiento(TratamientoId);
}

var listaTratamiento = () => {
    var accion = '../Tratamientos/Lista_Tratamiento_Controller';
    var tratamiento = new ClaseTratamiento('', '',  accion);
    tratamiento.listaTratamiento();
}


/////////////locales//////////////


var nuevo_Locales = () => {
    var Nombre = document.getElementById('Nombre').value;
    var Direcion = document.getElementById('Direcion').value;
    var Calle = document.getElementById('Calle').value;
    var ConsultoriosId = document.getElementById('ConsultoriosId').value;

    var LocalesId = document.getElementById('LocalesId').value;

    if (LocalesId == '') {
        var accion = '../Locales/Nuevo_Locales_Controller';
    } else {
        var accion = '../Locales/Editar_Locales_Controller';
    }

    var locales = new ClaseLocales(Nombre, Direcion, Calle, ConsultoriosId, accion);
    locales.nuevo_Locales(LocalesId);

}
var Un_Locales = (LocalesId) => {
    var accion = "Locales/Un_Locales_Controller";
    var locales = new ClaseLocales('', '','','', accion);
    locales.Un_Locales(LocalesId);
}


var eliminar_locales = (LocalesId) => {
    var accion = "Locales/Eliminar_Locales_Controller";
    var locales = new ClaseLocales('', '', '', '', accion);
    locales.eliminar_locales(LocalesId);
}

var listaLocales = () => {
    var accion = '../Locales/Lista_Locales_Controller';
    var locales = new ClaseLocales('', '', '', '', accion);
    locales.listaLocales();
}

