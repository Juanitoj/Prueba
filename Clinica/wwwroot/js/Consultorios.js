class ClaseConsultorios {
    constructor(Numero, accion) {
        this.Numero = Numero;
        this.accion = accion;
    }

    nuevo_Consultorio(ConsultoriosId) {
        var Numero = this.Numero;
        
        var accion = this.accion;

        if (ConsultoriosId == '') {
            try {
                $.post(
                    accion,
                    { Numero },
                    (respuesta) => {
                        if (respuesta.code == "ok") {
                            swal('Consultorios', respuesta.description, 'success');
                            this.limpiar();
                        }
                        else {
                            swal('Consultorios', respuesta.description, 'Error');
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
                    { ConsultoriosId, Numero },
                    (respuesta) => {
                        if (respuesta.code == "ok") {
                            swal('Consultorios', respuesta.description, 'success');
                            this.limpiar();
                        }
                        else {
                            swal('Consultorios', respuesta.description, 'Error');
                        }
                    });
            }
            catch (e) {
                alert(e.message);
            }
        }

    }

    Un_Consultorio(ConsultoriosId) {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: { ConsultoriosId },
            success: (respuesta) => {
                console.log(respuesta);
                document.getElementById("Numero").value =respuesta.numero;          

                document.getElementById("ConsultoriosId").value =respuesta.consultoriosId;
            }
        });
    }

    eliminar_consultorios(ConsultoriosId) {
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
                    $.post(accion, { ConsultoriosId },
                        (respuesta) => {
                            if (respuesta.code == "ok") {
                                swal('Consultorios', respuesta.description, 'success');
                                this.limpiar();
                            }
                            else {
                                swal('Consultorios', respuesta.description, 'Error');
                            }
                        });
                } else {
                    swal('Consultorios', 'Usted a cancelo la accion', 'warning');
                }
            });
    }

    listaConsultorio() {
        var accion = this.accion;
        $.post(
            accion,
            {},
            (respuesta) => {
                $.each(respuesta, (Index, val) => {
                    $('#Cuerpo_Consultorio').html(val[0])
                });

            }
        );
    }




    limpiar() {
        document.getElementById("Numero").value = '';
        document.getElementById("ConsultoriosId").value = '';
        $('#Ingreso_Consultorio').modal('hide');
        listaConsultorio();
    }




}
