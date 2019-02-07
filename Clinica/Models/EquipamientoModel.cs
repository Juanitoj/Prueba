using Clinica.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinica.Models
{
    public class EquipamientoModel
    {
        public ApplicationDbContext _contexto;

        public EquipamientoModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public IdentityError Nuevo_Equipamiento_Model(
            string NSerie,
            string Fecha,
            string Tipos
            )
        {
            IdentityError resultado = new IdentityError();
            Equipamiento equipamiento = new Equipamiento()
            {
               NSerie=NSerie,
               Fecha=Fecha,
                Tipos = Tipos


            };
            try
            {

                _contexto.Equipamentos.Add(equipamiento);
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

        public Equipamiento Un_Equipamiento_Model(int EquipamientoId)
        {

            Equipamiento equipamiento = (from al in _contexto.Equipamentos
                                         where al.EquipamientoId == EquipamientoId
                                         select al).FirstOrDefault();
            return equipamiento;
        }

        public IdentityError Editar_Equipamiento_Model(
            int EquipamientoId,
            string NSerie,
            string Fecha,
            string Tipo)
        {
            IdentityError resultado = new IdentityError();
            Equipamiento equipamiento = new Equipamiento()
            {
                NSerie = NSerie,
                Fecha=Fecha,
                Tipos = Tipo,

                EquipamientoId = EquipamientoId
            };
            try
            {
                _contexto.Equipamentos.Update(equipamiento);
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
        public IdentityError Eliminar_Equipamiento_Model(
           int EquipamientoId)
        {
            IdentityError resultado = new IdentityError();
            Equipamiento equipamiento = new Equipamiento()
            {
                EquipamientoId = EquipamientoId
            };
            try
            {
                _contexto.Equipamentos.Remove(equipamiento);
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



        public List<object[]> Lista_Equipamiento_Model()
        {
            List<object[]> listaRegresa = new List<object[]>();
            string dato = "";

            var equipamiento = _contexto.Equipamentos.ToList();

            foreach (var item in equipamiento)
            {
                dato += "<tr>" +
                    "<td>" + item.NSerie + "</td>" +
                    "<td>" + item.Fecha + "</td>" +
                    "<td>" + item.Tipos + "</td>" +
                    "<td>  <a data-toggle='modal' data-target='#Ingreso_Equipamento' " +
                    "onclick ='Un_Equipamiento(" + item.EquipamientoId + ")' " +
                    "class='btn btn-primary'>Edit</a> |" +
                    "<a onclick='eliminar_equipamiento(" + item.EquipamientoId + ")'" +
                    "class='btn btn-danger'>Delete</a></td>" +
                    "</tr>";
            }
            object[] objeto = { dato };
            listaRegresa.Add(objeto);
            return listaRegresa;


        }

    }
}
