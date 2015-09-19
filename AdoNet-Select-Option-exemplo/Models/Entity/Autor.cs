using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdoNet_Select_Option_exemplo.Models.Entity
{
    public class Autor
    {
        public int id { get; set; }
        public string nome{ get; set; }
        public string endereco { get; set; }

        public Cidade cidade { get; set; }
    }
}