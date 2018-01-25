using MVCDemo.DbContext;
using MVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class PersonaController : Controller
    {
        public DefaultConnection db = DefaultConnection.Instance;

        // GET: Persona
        public ActionResult Index()
        {
            return View(db.Personas.ToList());
        }

        // GET: Personas/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonaID,Nombre,Apellido,Edad")] Persona persona) {
            if (ModelState.IsValid) {
                db.Personas.Add(persona);
                return RedirectToAction("Index");
            }
            return View(persona);
        }
    }
}