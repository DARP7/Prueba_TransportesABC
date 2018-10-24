using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransportesABC.Models;

namespace TransportesABC.Controllers
{
    public class SolicitudesController : Controller
    {
        // GET: Solicitudes
        public ActionResult MostrarSolicitudes()
        {
            TransporteEntities db = new TransporteEntities();
            List<Solicitud_Transporte> ListaSolicitudes = db.Solicitud_Transporte.ToList();
            return View(ListaSolicitudes);
        }
    }
}