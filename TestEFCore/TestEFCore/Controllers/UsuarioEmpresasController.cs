using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestEFCore.Models.Database;
using TestEFCore.Models.Requests;
using TestEFCore.Repositories.EntityFramework;

namespace TestEFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioEmpresasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper mapper;

        public UsuarioEmpresasController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: api/UsuarioEmpresas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioEmpresa>>> GetUsuariosEmpresa()
        {
            return await _context.UsuariosEmpresa.ToListAsync();
        }

        // GET: api/UsuarioEmpresas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioEmpresa>> GetUsuarioEmpresa(int id)
        {
            var usuarioEmpresa = await _context.UsuariosEmpresa.Include(x=>x.CodigoDeCobro).Include(x=>x.Municipio).FirstAsync(x=>x.Id == id);

            if (usuarioEmpresa == null)
            {
                return NotFound();
            }

            return usuarioEmpresa;
        }

        // PUT: api/UsuarioEmpresas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarioEmpresa(int id, UsuarioEmpresa usuarioEmpresa)
        {
            if (id != usuarioEmpresa.Id)
            {
                return BadRequest();
            }

            _context.Entry(usuarioEmpresa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioEmpresaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UsuarioEmpresas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UsuarioEmpresaRequest>> PostUsuarioEmpresa(UsuarioEmpresaRequest usuarioEmpresaRequest)
        {
            var usuarioEmpresaDb = mapper.Map<UsuarioEmpresa>(usuarioEmpresaRequest);
            _context.UsuariosEmpresa.Add(usuarioEmpresaDb);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuarioEmpresa", new { id = usuarioEmpresaRequest.Id }, usuarioEmpresaRequest);
        }

        // DELETE: api/UsuarioEmpresas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuarioEmpresa(int id)
        {
            var usuarioEmpresa = await _context.UsuariosEmpresa.FindAsync(id);
            if (usuarioEmpresa == null)
            {
                return NotFound();
            }

            _context.UsuariosEmpresa.Remove(usuarioEmpresa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioEmpresaExists(int id)
        {
            return _context.UsuariosEmpresa.Any(e => e.Id == id);
        }
    }
}
