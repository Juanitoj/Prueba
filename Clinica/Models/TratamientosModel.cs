using Clinica.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinica.Models
{
    public class TratamientosModel
    {
        public ApplicationDbContext _contexto;

        public TratamientosModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public IdentityError Nuevo_Tratamiento_Model(
            string Nombre,
            string Costo)
        {
            IdentityError resultado = new IdentityError();
            Tratamientos tratamientos = new Tratamientos()
            {
                Nombre=Nombre,
                
                Costo = Costo


            };
            try
            {

                _contexto.Tratamientos.Add(tratamientos);
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

        public Tratamientos Un_Tratamiento_Model(int TratamientoId)
        {

            Tratamientos tratamientos = (from al in _contexto.Tratamientos
                                         where al.TratamientoId == TratamientoId
                                         select al).FirstOrDefault();
            return tratamientos;
        }

        public IdentityError Editar_Tratamiento_Model(
            int TratamientoId,
            string Nombre,
            string Costo)
        {
            IdentityError resultado = new IdentityError();
            Tratamientos tratamientos = new Tratamientos()
            {
                Nombre = Nombre,

                Costo = Costo,

                TratamientoId = TratamientoId
            };
            try
            {
                _contexto.Tratamientos.Update(tratamientos);
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
        public IdentityError Eliminar_Tratamiento_Model(
           int TratamientoId)
        {
            IdentityError resultado = new IdentityError();
            Tratamientos tratamientos = new Tratamientos()
            {
                TratamientoId = TratamientoId
            };
            try
            {
                _contexto.Tratamientos.Remove(tratamientos);
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



        public List<object[]> Lista_Tratamiento_Model()
        {
            List<object[]> listaRegresa = new List<object[]>();
            string dato = "";

            var tratamientos = _contexto.Tratamientos.ToList();

            foreach (var item in tratamientos)
            {
                dato += "<tr>" +
                    "<td>" + item.Nombre + "</td>" +
                    "<td>" + item.Costo + "</td>" +

                    "<td>  <a data-toggle='modal' data-target='#Ingreso_Tratamiento' " +
                    "onclick ='Un_Tratamiento(" + item.TratamientoId + ")' " +
                    "class='btn btn-primary'>Editar</a> |" +
                    "<a onclick='eliminar_tratamiento(" + item.TratamientoId + ")'" +
                    "class='btn btn-danger'>Eliminar</a></td>" +
                    "</tr>";
            }
            object[] objeto = { dato };
            listaRegresa.Add(objeto);
            return listaRegresa;


        }
    }
}
