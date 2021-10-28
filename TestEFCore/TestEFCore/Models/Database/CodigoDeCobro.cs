using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestEFCore.Models.Database
{
    public class CodigoDeCobro
    {
        public int Id { set; get; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
    }
}
