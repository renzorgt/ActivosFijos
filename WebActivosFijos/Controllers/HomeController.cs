using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebActivosFijos.Dtos;
using WebActivosFijos.Models;
using WebActivosFijos.Services;

namespace WebActivosFijos.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceApi _serviceApi;

        public HomeController(IServiceApi serviceApi)
        {
            _serviceApi = serviceApi;
        }
        public async Task <IActionResult> Index()
        {
            List<ActivoFijo> list = await _serviceApi.GetAll();
            return View(list);
        }

        public async Task<IActionResult> ActivoFijo(int id)
        {
            ActivoFijoInsert  activoFijoInsert = new ActivoFijoInsert();
            ActivoFijo activo = new ActivoFijo();

            ViewBag.Accion = "Nuevo Activo";

            //if (id !=0)
            //{
            //    ViewBag.Accion = "Editar Producto";
            //    activo = await _serviceApi.Get(id);
            //}
            return View(activoFijoInsert);
        }
        [HttpPost]
        public async Task<IActionResult> SaveChange(ActivoFijoInsert ob_activoFijo)
        {
            bool resp;
            
            
           // if (ob_activoFijo.id ==0)
            //{
                 List<ActivoFijo> activoFijo = await _serviceApi.Insert(ob_activoFijo);
                resp = true;
           // }
           // else
            //{
                //resp = true;
                // resp = await _serviceApi.Update(ob_activoFijo.id, ob_activoFijo);

           // }
            if (resp)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return NoContent();
            }
        }
        [HttpPost]
        public async Task<IActionResult> SaveUpdate(ActivoFijoUpdate ob_activoFijo)
        {
            bool resp;
            ActivoFijoPut ob_ = new ActivoFijoPut();
            ob_.serial = ob_activoFijo.serial;
            ob_.fecha_baja = ob_activoFijo.fecha_baja;

            // if (ob_activoFijo.id ==0)
            //{
            resp = await _serviceApi.Update(ob_activoFijo.id, ob_);
            //resp = true;
            // }
            // else
            //{
            //resp = true;
            // resp = await _serviceApi.Update(ob_activoFijo.id, ob_activoFijo);

            // }
            if (resp)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return NoContent();
            }
        }
        public async Task<IActionResult> UpdateActivoFijo(int id)
        {
            ActivoFijoUpdate activoFijoUpdate = new ActivoFijoUpdate();
            ActivoFijo activo = new ActivoFijo();

            ViewBag.Accion = "Actualizar Activo";

            activoFijoUpdate.id = id;

            //if (id !=0)
            //{
            //    ViewBag.Accion = "Editar Producto";
            //    activo = await _serviceApi.Get(id);
            //}
            return View(activoFijoUpdate);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}