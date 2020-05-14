using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practicaweb_Alumno.Models;

namespace Practicaweb_Alumno.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        public ActionResult Inicio()
        {
            using (BD_AlumnoEntities db = new BD_AlumnoEntities())
            {
                //List<Alumno> lista = db.Alumno.Where(a=>a.Edad>18).ToList();
                return View(db.Alumno.ToList());
            }               
        }

        public ActionResult Agregar()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]  /* sirve para seguridad que no entren de otros formularios,toquen que verifica que el formulario que se esta enviando pertenece aca */
        public ActionResult Agregar(Alumno a)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (BD_AlumnoEntities db = new BD_AlumnoEntities())
                {
                    a.FechaRegistro = DateTime.Now;
                    db.Alumno.Add(a);
                    db.SaveChanges();
                    return RedirectToAction("Inicio");
                }
            }
            catch (Exception ep)
            {

                ModelState.AddModelError("","Error al agregar el alumno - "+ ep.Message);
                return View();
            }
                        
        }
    }
}