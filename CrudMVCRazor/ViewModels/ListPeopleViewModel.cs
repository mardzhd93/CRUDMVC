using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudMVCRazor.ViewModels
{
    public class ListPeopleViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
    }
}