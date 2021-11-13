using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarioNet6.Models;
using InventarioNet6.Services;
using Microsoft.AspNetCore.Mvc;
//using InventarioNet6.Models;

namespace InventarioNet6.Controllers
{
    public class ProductosController : Controller
    {
         private readonly IOperaciones db;

        public ProductosController(IOperaciones db)
        {
            this.db = db;
        }

        public IActionResult Inicio()
        {

            return View(db.GetProductos());
        }

        public IActionResult CrearProducto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CrearProducto(Productos producto)
        {
            if(producto.Nombre == "Cerveza")
                ModelState.AddModelError("Nombre","No se acepta");
            if (ModelState.IsValid)
            {
                db.AddProducto(producto);
                return RedirectToAction("Inicio");
            }
            return View(producto);
        }
    }
}