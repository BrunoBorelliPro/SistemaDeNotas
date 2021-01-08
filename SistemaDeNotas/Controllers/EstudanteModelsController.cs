using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeNotas;
using SistemaDeNotas.Data;
using SistemaDeNotas.Models;

namespace SistemaDeNotas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudanteModelsController : ControllerBase
    {
        private readonly SistemaDeNotasContext _context;

        public EstudanteModelsController(SistemaDeNotasContext context)
        {
            _context = context;
        }

        // GET: api/EstudanteModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstudanteModel>>> GetEstudantes()
        {
            return await _context.Estudantes.ToListAsync();
        }

        // GET: api/EstudanteModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstudanteModel>> GetEstudanteModel(int id)
        {
            var estudanteModel = await _context.Estudantes.FindAsync(id);

            if (estudanteModel == null)
            {
                return NotFound();
            }

            return estudanteModel;
        }

        // PUT: api/EstudanteModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstudanteModel(int id, EstudanteModel estudanteModel)
        {
            if (id != estudanteModel.IdEstudante)
            {
                return BadRequest();
            }

            _context.Entry(estudanteModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstudanteModelExists(id))
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

        // POST: api/EstudanteModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EstudanteModel>> PostEstudanteModel(EstudanteModel estudanteModel)
        {
            _context.Estudantes.Add(estudanteModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstudanteModel", new { id = estudanteModel.IdEstudante }, estudanteModel);
        }

        // DELETE: api/EstudanteModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstudanteModel(int id)
        {
            var estudanteModel = await _context.Estudantes.FindAsync(id);
            if (estudanteModel == null)
            {
                return NotFound();
            }

            _context.Estudantes.Remove(estudanteModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpGet("{id}/media")]
        public async Task<double> GetMediaEstudante(int id)
        {
            var notas = _context.Notas.Where(c => c.IdEstudante == id);
            if (notas == null)
            {
                return 0;
            }
            double media = 0;
            foreach(NotasModel nota in notas)
            {
                media += nota.Nota;
            }
            if (notas.Count() > 0)
            {
                media = media / notas.Count();
            }
            return media;
        }
        private bool EstudanteModelExists(int id)
        {
            return _context.Estudantes.Any(e => e.IdEstudante == id);
        }
    }
}
