using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeNotas.Data;
using SistemaDeNotas.Models;

namespace SistemaDeNotas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotasModelsController : ControllerBase
    {
        private readonly SistemaDeNotasContext _context;

        public NotasModelsController(SistemaDeNotasContext context)
        {
            _context = context;
        }

        // GET: api/NotasModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NotasModel>>> GetNotas()
        {
            return await _context.Notas.ToListAsync();
        }

        // GET: api/NotasModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NotasModel>> GetNotasModel(int id)
        {
            var notasModel = await _context.Notas.FindAsync(id);

            if (notasModel == null)
            {
                return NotFound();
            }

            return notasModel;
        }

        // PUT: api/NotasModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotasModel(int id, NotasModel notasModel)
        {
            if (id != notasModel.NotaId)
            {
                return BadRequest();
            }

            _context.Entry(notasModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotasModelExists(id))
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

        // POST: api/NotasModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NotasModel>> PostNotasModel(NotasModel notasModel)
        {
            if(!EstudanteModelExists(notasModel.IdEstudante))
            {
                return NotFound();
            }
            _context.Notas.Add(notasModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNotasModel", new { id = notasModel.NotaId }, notasModel);
        }

        // DELETE: api/NotasModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotasModel(int id)
        {
            var notasModel = await _context.Notas.FindAsync(id);
            if (notasModel == null)
            {
                return NotFound();
            }

            _context.Notas.Remove(notasModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NotasModelExists(int id)
        {
            return _context.Notas.Any(e => e.NotaId == id);
        }
        private bool EstudanteModelExists(int id)
        {
            return _context.Estudantes.Any(e => e.IdEstudante == id);
        }
    }
}
