using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExamenU3.Models;

namespace ExamenU3.Controllers
{
    public class MascotumController : Controller
    {
       
        private readonly MascotasContext db;

        public MascotumController(MascotasContext context)
        {
            db = context;
        }

        public IActionResult ListadoRegistros()
        {
            var listadoRegistros = db.Mascota.ToList();
            return View(listadoRegistros);
        }

        public IActionResult AgregarRegistro()
        {
            ViewBag.Tipos = new SelectList(db.Tipos, "Id", "Nombre");
            return View();
        }



        [HttpPost]
        public IActionResult AgregarRegistro(Mascotum mascota)
        {
            if (ModelState.IsValid)
            {
                db.Mascota.Add(mascota);
                db.SaveChanges();
                return RedirectToAction(nameof(ListadoRegistros));
            }
            return View(mascota);
        }

        public IActionResult EditarRegistro(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var mascotum = db.Mascota.Find(id);

            if (mascotum == null)
            {
                return NotFound();
            }

            ViewBag.Tipos = new SelectList(db.Tipos, "Id", "Nombre");
            return View(mascotum);

        }

        [HttpPost]
        public IActionResult EditarRegistro(Mascotum mascota)
        {

            if (ModelState.IsValid)
            {
                db.Update(mascota);
                db.SaveChanges();

                return RedirectToAction(nameof(ListadoRegistros));
            }

            return View();
        }

        public IActionResult EliminarRegistro(int Id)
        {
            var mascotum = db.Mascota.Find(Id);

            if (mascotum == null)
            {
                return NotFound();
            }

            db.Remove(mascotum);
            db.SaveChanges();

            return RedirectToAction(nameof(ListadoRegistros));
        }

    }
}
