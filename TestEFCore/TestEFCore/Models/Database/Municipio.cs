using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestEFCore.Models.Database
{
    public class Municipio
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(3)]
        public string Codigo { get; set; }

        [Required]
        public string Nombre { get; set; }
    }
}
