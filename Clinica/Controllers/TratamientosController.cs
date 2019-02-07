using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Clinica.Data;
using Microsoft.AspNetCore.Identity;
using Clinica.Models;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Controllers
{
    public class TratamientosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly TratamientosModel _tratamiento_model;
        public TratamientosController(ApplicationDbContext context)
        {
            _context = context;
            _tratamiento_model = new TratamientosModel(context);
        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.Tratamientos.ToListAsync());
        }

        public IdentityError Nuevo_Tratamiento_Controller(string Nombre, string Costo)
        {
            return _tratamiento_model.Nuevo_Tratamiento_Model(Nombre, Costo);

        }

        public Tratamientos Un_Tratamiento_Controller(int TratamientoId)
        {
            return _tratamiento_model.Un_Tratamiento_Model(TratamientoId);
        }
        public IdentityError Editar_Tratamiento_Controller(int TratamientoId, string Nombre, string Costo)
        {
            return _tratamiento_model.Editar_Tratamiento_Model(TratamientoId, Nombre, Costo);

        }
        public IdentityError Eliminar_Tratamiento_Controller(int TratamientoId)
        {
            return _tratamiento_model.Eliminar_Tratamiento_Model(TratamientoId);
        }
        public List<object[]> Lista_Tratamiento_Controller()
        {
            return _tratamiento_model.Lista_Tratamiento_Model();
        }
    }
}