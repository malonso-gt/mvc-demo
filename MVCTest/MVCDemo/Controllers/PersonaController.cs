using MVCDemo.DbContext;
using MVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
                persona.PersonaID = ++db.IdActual; //Increment Persona ID
                db.Personas.Add(persona);
                return RedirectToAction("Index");
            }
            return View(persona);
        }

        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Persona persona = db.Personas.Find(x => x.PersonaID == id);

            if (persona == null) {
                return HttpNotFound();
            }

            return View(persona);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonaID,Nombre,Apellido,Edad")]Persona persona) {
            if (ModelState.IsValid) {
                Persona modifiedPersona = db.Personas.Find(x => x.PersonaID == persona.PersonaID);
                if (modifiedPersona == null)
                {
                    return HttpNotFound();
                }
                modifiedPersona.Nombre = persona.Nombre;
                modifiedPersona.Apellido = persona.Apellido;
                modifiedPersona.Edad = persona.Edad;
                return View(modifiedPersona);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Persona persona = db.Personas.Find(x => x.PersonaID == id);

            if (persona == null)
            {
                return HttpNotFound();
            }

            return View(persona);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            db.Personas.Remove(db.Personas.Find(x => x.PersonaID == id));
            return RedirectToAction("Index");
        }

        //Ejemplo de cambio indeseado
    }
}