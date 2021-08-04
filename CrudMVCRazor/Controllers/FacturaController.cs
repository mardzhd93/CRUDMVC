using CrudMVCRazor.Models;
using CrudMVCRazor.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudMVCRazor.Controllers
{
    public class FacturaController : Controller
    {
        // GET: Factura
        public ActionResult Index()
        {
            return View();
        }   
        
        public ActionResult List()
        {
            List<FacturaViewModel> lst = new List<FacturaViewModel>();
            using (Models.IroxITEntities ITDB = new Models.IroxITEntities())
            {
                lst = (from v in ITDB.FACTURAS
                       orderby v.Id_Factura descending
                       select new FacturaViewModel
                       {
                           Id_Factura = v.Id_Factura,
                           Fecha = v.Fecha,
                           IdCliente = v.IdCliente,
                           IdVendedor = v.IdVendedor,
                           Iva = v.Iva,
                       }).ToList();
            }
            return View(lst);
        }
        [HttpGet]
        public ActionResult New()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Save(FacturaViewModel model)
        {
            try
            {
                using (IroxITEntities db = new IroxITEntities())
                {
                    var FACTURA = new FACTURA();
                    FACTURA.Fecha = DateTime.Now;
                    FACTURA.IdCliente = model.IdCliente;
                    FACTURA.IdVendedor = model.IdVendedor;
                    FACTURA.Iva = model.Iva;
                    db.FACTURAS.Add(FACTURA);
                    db.SaveChanges();
                }
                return Content("1");
            }
            catch (Exception Ex)
            {

                return Content(Ex.Message);
            }

        }
        public ActionResult Edit(int Id)
        {
            FacturaViewModel model = new FacturaViewModel();
            using (IroxITEntities db = new IroxITEntities())
            {
                var Factura = db.FACTURAS.Find(Id);
                model.Fecha = Factura.Fecha;
                model.IdCliente = Factura.IdCliente;
                model.IdVendedor = Factura.IdVendedor;
                model.Iva = Factura.Iva;
                model.Id_Factura = Factura.Id_Factura;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(FacturaViewModel model)
        {
            try
            {
                using (IroxITEntities db = new IroxITEntities())
                {
                    var factura = db.FACTURAS.Find(model.Id_Factura);
                    factura.Fecha = DateTime.Now;
                    factura.IdCliente = model.IdCliente;
                    factura.IdVendedor = model.IdVendedor;
                    factura.Iva = model.Iva;
                    db.Entry(factura).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return Content("1");
            }
            catch (Exception Ex)
            {

                return Content(Ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            try
            {
                using (IroxITEntities db = new IroxITEntities())
                {
                    var Factura = db.FACTURAS.Find(Id);
                    db.FACTURAS.Remove(Factura);
                    db.SaveChanges();
                }
                return Content("1");
            }
            catch (Exception Ex)
            {

                return Content(Ex.Message);
            }
        }
    }
}