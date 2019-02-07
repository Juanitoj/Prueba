using Clinica.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinica.Models
{
    public class ConsultoriosModel
    {
        public ApplicationDbContext _contexto;

        public ConsultoriosModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public IdentityError Nuevo_Consultorio_Model(
            string Numero
            )
        {
            IdentityError resultado = new IdentityError();
            Consultorios consultorios = new Consultorios()
            {
                Numero = Numero
                

            };
            try
            {

                _contexto.Consultorios.Add(consultorios);
                _contexto.SaveChanges();
                resultado = new IdentityError()
                {
                    Code = "ok",
                    Description = "Se Guardo con Exito"
                };

            }
            catch (Exception ex)
            {
                resultado = new IdentityError()
                {
                    Code = "error",
                    Description = ex.Message.ToString()
                };

            }
            return resultado;
        }

        public Consultorios Un_Consultorio_Model(int ConsultoriosId)
        {
            
            Consultorios consultorios = (from al in _contexto.Consultorios
                               where al.ConsultoriosId == ConsultoriosId
                                         select al).FirstOrDefault();
            return consultorios;
        }

        public IdentityError Editar_Consultorio_Model(
            int ConsultoriosId,
            string Numero)
        {
            IdentityError resultado = new IdentityError();
            Consultorios consultorios = new Consultorios()
            {
                Numero = Numero,

                ConsultoriosId = ConsultoriosId
            };
            try
            {
                _contexto.Consultorios.Update(consultorios);
                _contexto.SaveChanges();
                resultado = new IdentityError()
                {
                    Code = "ok",
                    Description = "Se Actualizo con Exito"
                };

            }
            catch (Exception ex)
            {
                resultado = new IdentityError()
                {
                    Code = "error",
                    Description = ex.Message.ToString()
                };

            }
            return resultado;
        }
        public IdentityError Eliminar_Consultorio_Model(
           int ConsultoriosId)
        {
            IdentityError resultado = new IdentityError();
            Consultorios consultorios  = new Consultorios()
            {
                ConsultoriosId = ConsultoriosId
            };
            try
            {
                _contexto.Consultorios.Remove(consultorios);
                _contexto.SaveChanges();
                resultado = new IdentityError()
                {
                    Code = "ok",
                    Description = "Se Elimino con Exito"
                };

            }
            catch (Exception ex)
            {
                resultado = new IdentityError()
                {
                    Code = "error",
                    Description = ex.Message.ToString()
                };

            }
            return resultado;
        }



        public List<object[]> Lista_Consultorio_Model()
        {
            List<object[]> listaRegresa = new List<object[]>();
            string dato = "";

            var consultorio = _contexto.Consultorios.ToList();

            foreach (var item in consultorio)
            {
                dato += "<tr>" +
                    "<td>" + item.Numero + "</td>" +

                    "<td>  <a data-toggle='modal' data-target='#Ingreso_Consultorio' " +
                    "onclick ='Un_Consultorio(" + item.ConsultoriosId + ")' " +
                    "class='btn btn-primary'>Edit</a> |" +
                    "<a onclick='eliminar_consultorios(" + item.ConsultoriosId + ")'" +
                    "class='btn btn-danger'>Delete</a></td>" +
                    "</tr>";
            }
            object[] objeto = { dato };
            listaRegresa.Add(objeto);
            return listaRegresa;


        }

    }
}
