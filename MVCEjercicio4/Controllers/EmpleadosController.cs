using Microsoft.AspNetCore.Mvc;
using DAL.Models;

namespace MVCEjercicio4.Controllers
{
   
    public class EmpleadosController : Controller
    {
        public DAL.Models.Mvcejercicio4Context db= new Mvcejercicio4Context();
        public IActionResult Index()
        {
            var empleados = db.Empleados.ToList();
            
            return View(empleados);
        }
        [HttpPost]
        public IActionResult Index(int IdArea)
        {
            Empleado empleado = db.Empleados.Where(e => e.IdArea == IdArea).FirstOrDefault();
            if (empleado == null)
            {
                ViewBag.Area="Empleado nombre: " + empleado.Nombre + "Area: " + empleado.IdAreaNavigation;
            }
            return View(empleado);
        }
    }
}
