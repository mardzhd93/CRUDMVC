using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudMVCRazor.ViewModels
{
    public class FacturaViewModel
    {
        public int Id_Factura { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdCliente { get; set; }
        public int? IdVendedor { get; set; }
        public double? Iva { get; set; }
    }
}