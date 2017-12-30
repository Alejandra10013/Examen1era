using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tienda.Models;

namespace Tienda.Controllers
{
    public class ClientesController : Controller
    {
        VentaTiendaEntities cnx;

        public ClientesController()
        {
            cnx = new VentaTiendaEntities();
        }
        public ActionResult NuevoCliente()
        {

            return View();
        }
        public ActionResult Listado()
        {
            cnx.Database.Connection.Open();
            List<Clientes> cliente = cnx.Clientes.ToList();
            cnx.Database.Connection.Close();
            return View(cliente);
        }
        public ActionResult Guardar(int Rut, string Nombre, string Apellidos, string Direccion, string TipoCliente)
        {
            Clientes cliente = new Clientes()
            {
                Rut = Rut,
                NombreCli = Nombre,
                Apellido = Apellidos,
                Direccion = Direccion,
                TipoCliente = TipoCliente
            };

            cnx.Clientes.Add(cliente);
            cnx.SaveChanges();
            return View("Listado", cnx.Clientes.ToList());
        }
        public ActionResult Ficha(int Id)
        {
            return View(cnx.Clientes.Where(x => x.Id == Id).First());
        }
        
        public ActionResult Ver(int Id)
        {
            return View("Ficha", null);
        }
    }
}