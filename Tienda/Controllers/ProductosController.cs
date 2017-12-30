using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tienda.Models;

namespace Tienda.Controllers
{
    public class ProductosController : Controller
    {
         VentaTiendaEntities cnx;

         public ProductosController()
         {
             cnx = new VentaTiendaEntities();
         }
         public ActionResult NuevoProducto()
         {
             return View();
         }
         public ActionResult Listado()
         {
             cnx.Database.Connection.Open();
             List<Productos> producto = cnx.Productos.ToList();
             cnx.Database.Connection.Close();
             return View(producto);
         }
        public ActionResult Guardar(string NombreProd, int CodigoBarra, string Familia, int Precio, int Descuento, string Descripcion)
        {
            Productos producto = new Productos()
            {
                NombreProd = NombreProd,
                CodigoBarra = CodigoBarra,
                Familia = Familia,
                Precio = Precio,
                Descuento = Descuento,
                Descripcion = Descripcion
            };

            cnx.Productos.Add(producto);
            cnx.SaveChanges();
            return View("Listado", cnx.Productos.ToList());
        }
        public ActionResult Ficha(int Id)
        {
            return View(cnx.Productos.Where(x => x.Id == Id).First());
        }
        public ActionResult Ver(int Id)
        {


            return View("Ficha", null);
        }
    }
}