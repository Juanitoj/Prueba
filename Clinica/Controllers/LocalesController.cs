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
    public class LocalesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly LocalesModel _local_model;
        public LocalesController(ApplicationDbContext context)
        {
            _context = context;
            _local_model = new LocalesModel(context);
        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.Locales.ToListAsync());
        }

        public IdentityError Nuevo_Locales_Controller(string Nombre, string Direcion, string Calle, int ConsultoriosId)
        {
            return _local_model.Nuevo_Locales_Model(Nombre, Direcion, Calle, ConsultoriosId);

        }

        public Locales Un_Locales_Controller(int LocalesId)
        {
            return _local_model.Un_Locales_Model(LocalesId);
        }
        public IdentityError Editar_Locales_Controller(int LocalesId, string Nombre, string Direcion, string Calle, int ConsultoriosId)
        {
            return _local_model.Editar_Locales_Model(LocalesId, Nombre, Direcion, Calle, ConsultoriosId);

        }
        public IdentityError Eliminar_Locales_Controller(int LocalesId)
        {
            return _local_model.Eliminar_Locales_Model(LocalesId);
        }
        public List<object[]> Lista_Locales_Controller()
        {
            return _local_model.Lista_Locales_Model();
        }


    }
}
