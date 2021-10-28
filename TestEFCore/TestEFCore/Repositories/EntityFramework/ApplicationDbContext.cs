using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TestEFCore.Models.Database;

namespace TestEFCore.Repositories.EntityFramework
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CodigoDeCobro> CodigosDeCobro { set; get; }
        public DbSet<Municipio> Municipios { set; get; }
        public DbSet<UsuarioEmpresa> UsuariosEmpresa { set; get; }

    }
}
