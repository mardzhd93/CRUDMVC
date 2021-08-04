using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudMVCRazor.ViewModels
{
    public class VENDEDORViewModel
    {
		public int IdVendedor { get; set; }
		public string Nombre { get; set; }
			public string Direccion { get; set; }
			public Int16? CodigoPostal { get; set; }
			public int? IdCiudad { get; set; }
			public int? IdVendedorSupervisor { get; set; }

	}
}