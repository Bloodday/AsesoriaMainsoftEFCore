using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestEFCore.Models.Requests
{
    public class UsuarioEmpresaRequest
    {
        public int Id { get; set; }
        [MaxLength(25)]
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        public int? CodigoDeCobroId { get; set; }
        public int? MunicipioId { get; set; }
    }
}
