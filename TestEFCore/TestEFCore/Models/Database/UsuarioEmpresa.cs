using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestEFCore.Models.Database
{
    public class UsuarioEmpresa
    {
        public int Id { get; set; }
        [MaxLength(25)]
        [Required]
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public CodigoDeCobro CodigoDeCobro { get; set; }
        public int CodigoDeCobroId { get; set; }
        public Municipio Municipio { get; set; }
        public int MunicipioId { get; set; }
    }
}
