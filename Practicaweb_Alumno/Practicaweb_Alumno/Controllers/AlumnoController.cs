using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practicaweb_Alumno.Models;
using System.Data.SqlClient;

namespace Practicaweb_Alumno.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        public ActionResult Inicio()
        {
            try
            {
                /* int edad = 18;
                 string sql = @"select a.Id, Nombres, Apellidos, Edad, Sexo, FechaRegistro, c.Nombre as Nombreciudad
                                from Alumno a inner join Ciudad c
                                on a.CodCiudad=c.Id
                                where Edad>@EdadAlumno";*/

                int edad = 17;
                using (BD_AlumnoEntities db = new BD_AlumnoEntities())
                {
                    //List<Alumno> lista = db.Alumno.Where(a => a.Edad > 17).ToList();
                    //return View(lista);
                    //return View(db.Alumno.ToList());

                     var data = from a in db.Alumno
                                 join c in db.Ciudad
                                 on a.CodCiudad equals c.Id
                                where a.Edad> edad
                                select new AlumnoCE()
                                 {
                                     Id = a.Id,
                                     Nombres = a.Nombres,
                                     Apellidos = a.Apellidos,
                                     Edad = a.Edad,
                                     Sexo = a.Sexo,
                                     Nombreciudad = c.Nombre,
                                     FechaRegistro=a.FechaRegistro
                                 };

                     return View(data.ToList());
                     

                   /* return View(db.Database.SqlQuery<AlumnoCE>(sql,new SqlParameter("@EdadAlumno",edad)).ToList());*/
                }

            }
            catch (Exception)
            {

                throw;
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

        public ActionResult ListaCiudades()
        {
            using (BD_AlumnoEntities db = new BD_AlumnoEntities())
            {
                return PartialView(db.Ciudad.ToList());
            }
        }

        public ActionResult Editar(int id)
        {
            using (var db = new BD_AlumnoEntities())
            {
                try
                {
                    //Alumno al = db.Alumno.Where(a => a.Id == id).FirstOrDefault();
                    Alumno alu = db.Alumno.Find(id);
                    return View(alu);
                }
                catch (Exception ep)
                {

                    throw;
                }
               
            }
               
        }

        [HttpPost]
        [ValidateAntiForgeryToken]  /* sirve para seguridad que no entren de otros formularios,toquen que verifica que el formulario que se esta enviando pertenece aca */
        public ActionResult Editar(Alumno a)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                using (BD_AlumnoEntities db = new BD_AlumnoEntities())
                {
                    Alumno al = db.Alumno.Find(a.Id);
                    al.Nombres = a.Nombres;
                    al.Apellidos = a.Apellidos;
                    al.Edad = a.Edad;
                    al.Sexo = a.Sexo;

                    db.SaveChanges();
                    return RedirectToAction("Inicio");
                }
                    
            }
            catch (Exception ep)
            {

                throw;
            }
            
        }

        public ActionResult Detalle_Alumno(int id)
        {
            using (BD_AlumnoEntities db = new BD_AlumnoEntities())
            {
                Alumno al = db.Alumno.Find(id);               
                
                return View(al);
            }
        }

        public ActionResult EliminarAlumno(int id)
        {
            using (BD_AlumnoEntities db = new BD_AlumnoEntities())
            {
                Alumno alu = db.Alumno.Find(id);
                db.Alumno.Remove(alu);
                db.SaveChanges();
                return RedirectToAction("Inicio");
            }
        }

        public static string NombreCiudad(int CodCiudad)
        {
            using (BD_AlumnoEntities db = new BD_AlumnoEntities())
            {
                return db.Ciudad.Find(CodCiudad).Nombre;
            }
        }

    }
}