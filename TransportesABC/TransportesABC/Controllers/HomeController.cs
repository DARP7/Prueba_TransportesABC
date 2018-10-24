using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransportesABC.Models;

namespace TransportesABC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult RegistroSolicitud(int id = 0)
        {
            Solicitud_Transporte NuevaSolicitud = new Solicitud_Transporte();

            return View(NuevaSolicitud);
        }

        [HttpPost]
        public ActionResult RegistroSolicitud(Solicitud_Transporte NuevaSolicitud)
        {
            using (TransporteEntities db = new TransporteEntities())
            {
                db.Registro_Solicitud(NuevaSolicitud.Fecha, NuevaSolicitud.NumeroLote);
            }
            //Response.Write("texto: ");
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registro exitoso";
            return View(new Solicitud_Transporte());
            //return View(NuevaSolicitud);
        }

    }
}