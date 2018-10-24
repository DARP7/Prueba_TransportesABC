using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransportesABC.Models;

namespace TransportesABC.Controllers
{
    public class VehiculoController : Controller
    {
        // GET: Vehiculo
        public ActionResult RegistrarVehiculo(int id)
        {
            Auto auto = new Auto();
            auto.AutoSolicitudID = id;
            return View(auto);
        }
        [HttpPost]
        public ActionResult RegistrarVehiculo(Auto NuevoAuto)
        {
            using (TransporteEntities db = new TransporteEntities())
            {
                db.Agregar_Auto(NuevoAuto.Marca, NuevoAuto.Modelo, NuevoAuto.Folio, NuevoAuto.Color, NuevoAuto.Transmision, NuevoAuto.DescripcionEstetica, NuevoAuto.AutoSolicitudID);
            }
            //Response.Write("texto: ");
            //ModelState.Clear();
            ViewBag.SuccessMessage = "Registro exitoso, puedes registrar otro vehiculo";
            return View(NuevoAuto);
            //return View(NuevaSolicitud);
        }
        public ActionResult MostrarVehiculos(int id)
        {
            TransporteEntities db = new TransporteEntities();
            //List<Auto> ListaAutos = db.Where(a => a.AutoSolicitudID == id).Auto.ToList();
            //var ListaAutos = db.Auto.Where(a => a.AutoSolicitudID == id);
            var ListaAutos = db.Mostrar_Autos(id);
            List<Auto> Lista = new List<Auto>();
            foreach(Mostrar_Autos_Result a in ListaAutos){
                Auto auto = new Auto();
                auto.AutoID = a.AutoID;
                auto.Marca = a.Marca;
                auto.Modelo = a.Modelo;
                auto.Folio = a.Folio;
                auto.Color = a.Color;
                auto.Transmision = a.Transmision;
                auto.DescripcionEstetica = a.DescripcionEstetica;
                auto.AutoSolicitudID = a.AutoSolicitudID;
                Lista.Add(auto);
            }
            return View(Lista);
        }
        //EDICION DE VEHICULOS
        public ActionResult EditarVehiculo(int id)
        {
            //Auto auto = new Auto();
            TransporteEntities db = new TransporteEntities();
            //auto = db.Auto.SqlQuery("SELECT * FROM Auto WHERE AutoID="+id.ToString());//.Where(a => a.AutoID == id);
            var auto = db.Auto.Single(x => x.AutoID == id);
            Auto vehiculo = new Auto();
            vehiculo.AutoID = auto.AutoID;
            vehiculo.Marca = auto.Marca;
            vehiculo.Modelo = auto.Modelo;
            vehiculo.Folio = auto.Folio;
            vehiculo.Color = auto.Color;
            vehiculo.Transmision = auto.Transmision;
            vehiculo.DescripcionEstetica = auto.DescripcionEstetica;
            vehiculo.AutoSolicitudID = auto.AutoSolicitudID;
            return View(vehiculo);
        }
        [HttpPost]
        public ActionResult EditarVehiculo(Auto NuevoAuto)
        {
            using (TransporteEntities db = new TransporteEntities())
            {
                
                db.Editar_Auto(NuevoAuto.AutoID, NuevoAuto.Marca, NuevoAuto.Modelo, NuevoAuto.Folio, NuevoAuto.Color, NuevoAuto.Transmision, NuevoAuto.DescripcionEstetica);
            }
            //Response.Write("texto: ");
            //ModelState.Clear();
            ViewBag.SuccessMessage = "Edicion exitosa";
            return View(NuevoAuto);
            //return View(NuevaSolicitud);
        }
        public ActionResult MostrarAutosBlancos()
        {
            TransporteEntities db = new TransporteEntities();
            //List<Auto> ListaAutos = db.Where(a => a.AutoSolicitudID == id).Auto.ToList();
            //var ListaAutos = db.Auto.Where(a => a.AutoSolicitudID == id);
            var ListaAutos = db.Mostrar_Autos_Blancos();
            List<Auto> Lista = new List<Auto>();
            foreach (Mostrar_Autos_Blancos_Result a in ListaAutos)
            {
                Auto auto = new Auto();
                //auto.AutoID = a.AutoID;
                auto.Marca = a.Marca;
                auto.Modelo = a.Modelo;
                auto.Folio = a.Folio;
                auto.Cantidad = a.Cantidad.ToString();
                //auto.Color = a.Color;
                //auto.Transmision = a.Transmision;
                //auto.DescripcionEstetica = a.DescripcionEstetica;
                //auto.AutoSolicitudID = a.AutoSolicitudID;
                Lista.Add(auto);
            }
            return View(Lista);
        }
    }
}