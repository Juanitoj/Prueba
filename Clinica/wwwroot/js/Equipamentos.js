class ClaseEquipamento {
    constructor(NSerie,Fecha,Tipo, accion) {
        this.NSerie = NSerie;
        this.Fecha = Fecha;
        this.Tipos = Tipo;
        this.accion = accion;
    }

    nuevo_Equipamento(EquipamientoId) {
        var NSerie = this.NSerie;
        var Fecha = this.Fecha;
        var Tipos = this.Tipos;

        var accion = this.accion;

        if (EquipamientoId == '') {
            try {
                $.post(
                    accion,
                    { NSerie, Fecha, Tipos },
                    (respuesta) => {
                        console.log(respuesta);
                        if (respuesta.code == "ok") {
                            swal('Equipamentos', respuesta.description, 'success');
                            this.limpiar();
                        }
                        else {
                            swal('Equipamentos', respuesta.description, 'Error');
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
                    { EquipamientoId, NSerie, Fecha, Tipos },
                    (respuesta) => {
                        if (respuesta.code == "ok") {
                            swal('Equipamentos', respuesta.description, 'success');
                            this.limpiar();
                        }
                        else {
                            swal('Equipamentos', respuesta.description, 'Error');
                        }
                    });
            }
            catch (e) {
                alert(e.message);
            }
        }

    }

    Un_Equipamiento(EquipamientoId) {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: { EquipamientoId },
            success: (respuesta) => {
                console.log(respuesta);
                document.getElementById("NSerie").value = respuesta.nSerie;
                document.getElementById("Fecha").value = respuesta.fecha;
                document.getElementById("Tipos").value = respuesta.tipos;

                document.getElementById("EquipamientoId").value = respuesta.equipamientoId;
            }
        });
    }

    eliminar_equipamiento(EquipamientoId) {
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
                    $.post(accion, { EquipamientoId },
                        (respuesta) => {
                            if (respuesta.code == "ok") {
                                swal('Equipamento', respuesta.description, 'success');
                                this.limpiar();
                            }
                            else {
                                swal('Equipamento', respuesta.description, 'Error');
                            }
                        });
                } else {
                    swal('Equipamento', 'Usted a cancelo la accion', 'warning');
                }
            });
    }

    listaEquipamento() {
        var accion = this.accion;
        $.post(
            accion,
            {},
            (respuesta) => {
                $.each(respuesta, (Index, val) => {
                    $('#Cuerpo_Equipamento').html(val[0])
                });

            }
        );
    }




    limpiar() {
        document.getElementById("NSerie").value = '';
        document.getElementById("Fecha").value = '';
        document.getElementById("Tipos").value = '';
        document.getElementById("EquipamientoId").value = '';
        $('#Ingreso_Equipamento').modal('hide');
        listaEquipamento();
    }




}