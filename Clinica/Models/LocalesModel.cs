using Clinica.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinica.Models
{
    public class LocalesModel
    {
        public ApplicationDbContext _contexto;

        public LocalesModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public IdentityError Nuevo_Locales_Model(
            string Nombre,
            string Direcion,
            string Calle,
            int ConsultoriosId
            )
        {
            IdentityError resultado = new IdentityError();
            Locales locales = new Locales()
            {
                Nombre = Nombre,
                Direcion = Direcion,
                Calle = Calle,
                ConsultoriosId= ConsultoriosId


            };
            try
            {

                _contexto.Locales.Add(locales);
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

        public Locales Un_Locales_Model(int LocalesId)
        {

            Locales locales = (from al in _contexto.Locales
                                         where al.LocalesId == LocalesId
                                    select al).FirstOrDefault();
            return locales;
        }

        public IdentityError Editar_Locales_Model(
            int LocalesId,
            string Nombre,
            string Direcion,
            string Calle,
            int ConsultoriosId)
        {
            IdentityError resultado = new IdentityError();
            Locales locales = new Locales()
            {
                Nombre = Nombre,
                Direcion = Direcion,
                Calle = Calle,
                ConsultoriosId = ConsultoriosId,

                LocalesId = LocalesId
            };
            try
            {
                _contexto.Locales.Update(locales);
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
        public IdentityError Eliminar_Locales_Model(
           int LocalesId)
        {
            IdentityError resultado = new IdentityError();
            Locales locales = new Locales()
            {
                LocalesId = LocalesId
            };
            try
            {
                _contexto.Locales.Remove(locales);
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



        public List<object[]> Lista_Locales_Model()
        {
            List<object[]> listaRegresa = new List<object[]>();
            string dato = "";

            var locales = _contexto.Locales.ToList();

            foreach (var item in locales)
            {
                dato += "<tr>" +
                    "<td>" + item.Nombre + "</td>" +
                    "<td>" + item.Direcion + "</td>" +
                    "<td>" + item.Calle + "</td>" +
                    "<td>" + item.Consultorios + "</td>" +
                    "<td>  <a data-toggle='modal' data-target='#Ingreso_Locales' " +
                    "onclick ='Un_Locales(" + item.LocalesId + ")' " +
                    "class='btn btn-primary'>Edit</a> |" +
                    "<a onclick='eliminar_locales(" + item.LocalesId + ")'" +
                    "class='btn btn-danger'>Delete</a></td>" +
                    "</tr>";
            }
            object[] objeto = { dato };
            listaRegresa.Add(objeto);
            return listaRegresa;


        }
    }
}
