class ClaseLocales {
    constructor(Nombre, Direcion, Calle, ConsultoriosId, accion) {
        this.Nombre = Nombre;
        this.Direcion = Direcion;
        this.Calle = Calle;
        this.ConsultoriosId = ConsultoriosId;
        this.accion = accion;
    }

    nuevo_Locales(LocalesId) {
        var Nombre = this.Nombre;
        var Direcion = this.Direcion;
        var Calle = this.Calle;
        var ConsultoriosId = this.ConsultoriosId;
        var accion = this.accion;

        if (LocalesId == '') {
            try {
                $.post(
                    accion,
                    { Nombre, Direcion, Calle, ConsultoriosId },
                    (respuesta) => {
                        console.log(respuesta);
                        if (respuesta.code == "ok") {
                            swal('Locales', respuesta.description, 'success');
                            this.limpiar();
                        }
                        else {
                            swal('Locales', respuesta.description, 'Error');
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
                    { LocalesId, Nombre, Direcion, Calle, ConsultoriosId },
                    (respuesta) => {
                        if (respuesta.code == "ok") {
                            swal('Locales', respuesta.description, 'success');
                            this.limpiar();
                        }
                        else {
                            swal('Locales', respuesta.description, 'Error');
                        }
                    });
            }
            catch (e) {
                alert(e.message);
            }
        }

    }

    Un_Locales(LocalesId) {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: { LocalesId },
            success: (respuesta) => {
                console.log(respuesta);
                document.getElementById("Nombre").value = respuesta.nombre;
                document.getElementById("Direcion").value = respuesta.direcion;
                document.getElementById("Calle").value = respuesta.calle;
                document.getElementById("ConsultoriosId").value = respuesta.consultoriosId;
                document.getElementById("LocalesId").value = respuesta.equipamientoId;
            }
        });
    }

    eliminar_locales(LocalesId) {
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
                    $.post(accion, { LocalesId },
                        (respuesta) => {
                            if (respuesta.code == "ok") {
                                swal('Locales', respuesta.description, 'success');
                                this.limpiar();
                            }
                            else {
                                swal('Locales', respuesta.description, 'Error');
                            }
                        });
                } else {
                    swal('Locales', 'Usted a cancelo la accion', 'warning');
                }
            });
    }

    listaLocales() {
        var accion = this.accion;
        $.post(
            accion,
            {},
            (respuesta) => {
                $.each(respuesta, (Index, val) => {
                    $('#Cuerpo_Locales').html(val[0])
                });

            }
        );
    }




    limpiar() {
        document.getElementById("Nombre").value = '';
        document.getElementById("Direcion").value = '';
        document.getElementById("Calle").value = '';
        document.getElementById("ConsultoriosId").value = '';
        document.getElementById("LocalesId").value = '';
        $('#Ingreso_Locales').modal('hide');
        listaLocales();
    }




}