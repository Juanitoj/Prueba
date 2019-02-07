using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Clinica.Data;
using Clinica.Models;
using Microsoft.AspNetCore.Identity;

namespace Clinica.Controllers
{
    public class ConsultoriosController : Controller
    {
        private readonly ApplicationDbContext _context;


        private readonly ConsultoriosModel _consultorio_model;

        public ConsultoriosController(ApplicationDbContext context)
        {
            _context = context;
            _consultorio_model = new ConsultoriosModel(context);
        }

       
        public async Task<IActionResult> Index()
        {
            return View(await _context.Consultorios.ToListAsync());
        }

        public IdentityError Nuevo_Consultorio_Controller(string Numero)
        {
            return _consultorio_model.Nuevo_Consultorio_Model(Numero);

        }
       
        public Consultorios Un_Consultorio_Controller(int ConsultoriosId)
        {
            return _consultorio_model.Un_Consultorio_Model(ConsultoriosId);
        }
        public IdentityError Editar_Consultorio_Controller(int ConsultoriosId, string Numero)
        {
            return _consultorio_model.Editar_Consultorio_Model(ConsultoriosId, Numero);

        }
        public IdentityError Eliminar_Consultorio_Controller(int ConsultoriosId)
        {
            return _consultorio_model.Eliminar_Consultorio_Model(ConsultoriosId);
        }
        public List<object[]> Lista_Consultorio_Controller()
        {
            return _consultorio_model.Lista_Consultorio_Model();
        }
    }
}
