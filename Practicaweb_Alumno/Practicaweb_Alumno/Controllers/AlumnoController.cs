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
        public ActionResult Agregar(Alumno a)
        {
            return View();
        }
    }
}