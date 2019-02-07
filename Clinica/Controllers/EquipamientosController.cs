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
    public class EquipamientosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly EquipamientoModel _equipamiento_model;
        public EquipamientosController(ApplicationDbContext context)
        {
            _context = context;
            _equipamiento_model = new EquipamientoModel(context);
        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.Equipamentos.ToListAsync());
        }

        public IdentityError Nuevo_Equipamiento_Controller(string NSerie, string Fecha, string Tipos)
        {
            return _equipamiento_model.Nuevo_Equipamiento_Model(NSerie,Fecha,Tipos);

        }

        public Equipamiento Un_Equipamiento_Controller(int EquipamientoId)
        {
            return _equipamiento_model.Un_Equipamiento_Model(EquipamientoId);
        }
        public IdentityError Editar_Equipamiento_Controller(int EquipamientoId, string NSerie, string Fecha, string Tipos)
        {
            return _equipamiento_model.Editar_Equipamiento_Model(EquipamientoId, NSerie, Fecha, Tipos);

        }
        public IdentityError Eliminar_Equipamiento_Controller(int EquipamientoId)
        {
            return _equipamiento_model.Eliminar_Equipamiento_Model(EquipamientoId);
        }
        public List<object[]> Lista_Equipamiento_Controller()
        {
            return _equipamiento_model.Lista_Equipamiento_Model();
        }

    }
}