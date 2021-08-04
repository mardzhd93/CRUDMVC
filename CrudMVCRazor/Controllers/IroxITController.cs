using CrudMVCRazor.Models;
using CrudMVCRazor.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudMVCRazor.Controllers
{
    public class IroxITController : Controller
    {
        // GET: IroxIT
        public ActionResult Index()
        {
            return View();
        }
              public ActionResult List()
        {
            List<VENDEDORViewModel> lst = new List<VENDEDORViewModel>();
            using (Models.IroxITEntities ITDB = new Models.IroxITEntities())
            {
                lst = (from v in ITDB.VENDEDORES
                    orderby v.IdVendedor descending
                    select new VENDEDORViewModel
                    {
                            IdVendedor = v.IdVendedor,
                           Nombre = v.Nombre,
                           Direccion = v.Direccion,
                           CodigoPostal = v.CodigoPostal,
                           IdCiudad = v.IdCiudad,
                           IdVendedorSupervisor = v.IdVendedorSupervisor
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
        public ActionResult Save(VENDEDORViewModel model)
        {
            try
            {
                using (IroxITEntities db = new IroxITEntities())
                {
                    var Vendedor = new VENDEDORE();
                    Vendedor.Nombre = model.Nombre;
                    Vendedor.Direccion = model.Direccion;
                    Vendedor.CodigoPostal = model.CodigoPostal;
                    Vendedor.IdCiudad = model.IdCiudad;
                    Vendedor.IdVendedorSupervisor = model.IdVendedorSupervisor;
                    db.VENDEDORES.Add(Vendedor);
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
            VENDEDORViewModel model = new VENDEDORViewModel();
            using (IroxITEntities db = new IroxITEntities())
            {
                var Vendedor = db.VENDEDORES.Find(Id);
                model.IdVendedor = Vendedor.IdVendedor;
                model.Nombre = Vendedor.Nombre;
                model.Direccion = Vendedor.Direccion;
                model.CodigoPostal = Vendedor.CodigoPostal;
                model.IdCiudad = Vendedor.IdCiudad;
                model.IdVendedorSupervisor = Vendedor.IdVendedorSupervisor;
                
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(VENDEDORViewModel model)
        {
            try
            {
                using (IroxITEntities db = new IroxITEntities())
                {
                    var Vendedor = db.VENDEDORES.Find(model.IdVendedor);
                    Vendedor.Nombre = model.Nombre;
                    Vendedor.Direccion = model.Direccion;
                    Vendedor.CodigoPostal = model.CodigoPostal;
                    Vendedor.IdCiudad = model.IdCiudad;
                    Vendedor.IdVendedorSupervisor = model.IdVendedorSupervisor;
                    db.Entry(Vendedor).State = System.Data.Entity.EntityState.Modified;
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
                    var Vendedor = db.VENDEDORES.Find(Id);
                    db.VENDEDORES.Remove(Vendedor);
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