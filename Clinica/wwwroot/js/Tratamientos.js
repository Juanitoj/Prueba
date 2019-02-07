class ClaseTratamiento {
    constructor(Nombre, Costo, accion) {
        this.Nombre = Nombre;
        this.Costo = Costo;
        this.accion = accion;
    }

    nuevo_Tratamiento(TratamientoId) {
        var Nombre = this.Nombre;
        var Costo = this.Costo;
        var accion = this.accion;

        if (TratamientoId == '') {
            try {
                $.post(
                    accion,
                    { Nombre, Costo },
                    (respuesta) => {
                       
                        if (respuesta.code == "ok") {
                            swal('Tratamientos', respuesta.description, 'success');
                            this.limpiar();
                        }
                        else {
                            swal('Tratamientos', respuesta.description, 'Error');
                        }
                    });
            }
            catch (e) {
                alert(e.message);
            }
        }
        else {
            try {
                $.post(
                    accion,
                    { TratamientoId, Nombre, Costo },
                    (respuesta) => {
                        if (respuesta.code == "ok") {
                            swal('Tratamientos', respuesta.description, 'success');
                            this.limpiar();
                        }
                        else {
                            swal('Tratamientos', respuesta.description, 'Error');
                        }
                    });
            }
            catch (e) {
                alert(e.message);
            }
        }

    }

    Un_Tratamiento(TratamientoId) {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: { TratamientoId },
            success: (respuesta) => {
                console.log(respuesta);
                document.getElementById("Nombre").value = respuesta.nombre;
                document.getElementById("Costo").value = respuesta.costo;
                document.getElementById("TratamientoId").value = respuesta.tratamientoId;
            }
        });
    }

    eliminar_tratamiento(TratamientoId) {
        swal({
            title: "¿Eliminar Alumnos?",
            text: "Esta seguro que desea eliminar el alumno..!",
            icon: "warning",
            buttons: true,
            dangerMode: true,
        })
            .then((willDelete) => {
                if (willDelete) {
                    var accion = this.accion;
                    $.post(accion, { TratamientoId },
                        (respuesta) => {
                            if (respuesta.code == "ok") {
                                swal('Tratamientos', respuesta.description, 'success');
                                this.limpiar();
                            }
                            else {
                                swal('Tratamientos', respuesta.description, 'Error');
                            }
                        });
                } else {
                    swal('Tratamientos', 'Usted a cancelo la accion', 'warning');
                }
            });
    }

    listaTratamiento() {
        var accion = this.accion;
        $.post(
            accion,
            {},
            (respuesta) => {
                $.each(respuesta, (Index, val) => {
                    $('#Cuerpo_Tratamiento').html(val[0])
                });

            }
        );
    }




    limpiar() {
        document.getElementById("Nombre").value = '';
        document.getElementById("Costo").value = '';
       
        document.getElementById("TratamientoId").value = '';
        $('#Ingreso_Tratamiento').modal('hide');
        listaTratamiento();
    }




}