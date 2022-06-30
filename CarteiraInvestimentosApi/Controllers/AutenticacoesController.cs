using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarteiraInvestimentosApi.Data;
using CarteiraInvestimentosApi.Models;

namespace CarteiraInvestimentosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacoesController : ControllerBase
    {
        private readonly DataContext _context;

        public AutenticacoesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Autenticacoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Autenticacao>>> GetAutenticacao()
        {
            return await _context.Autenticacao.ToListAsync();
        }

        // GET: api/Autenticacoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Autenticacao>> GetAutenticacao(int id)
        {
            var autenticacao = await _context.Autenticacao.FindAsync(id);

            if (autenticacao == null)
            {
                return NotFound();
            }

            return autenticacao;
        }

        // PUT: api/Autenticacoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutenticacao(int id, Autenticacao autenticacao)
        {
            if (id != autenticacao.AutenticacaoId)
            {
                return BadRequest();
            }

            _context.Entry(autenticacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutenticacaoExists(id))
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

        // POST: api/Autenticacoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Autenticacao>> PostAutenticacao(Autenticacao autenticacao)
        {
            _context.Autenticacao.Add(autenticacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAutenticacao", new { id = autenticacao.AutenticacaoId }, autenticacao);
        }

        // DELETE: api/Autenticacoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutenticacao(int id)
        {
            var autenticacao = await _context.Autenticacao.FindAsync(id);
            if (autenticacao == null)
            {
                return NotFound();
            }

            _context.Autenticacao.Remove(autenticacao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AutenticacaoExists(int id)
        {
            return _context.Autenticacao.Any(e => e.AutenticacaoId == id);
        }
    }
}
