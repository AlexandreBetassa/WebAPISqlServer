using API_Ex.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Ex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdressController : ControllerBase
    {
        private readonly AgendaDB _agendaDB;

        public AdressController(AgendaDB context)
        {
            _agendaDB = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Person>>> Get() => await _agendaDB.Person.Include(x => x.Endereco).ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> Get(int id) =>
            await _agendaDB.Person.Include(x => x.Endereco).AsNoTracking().FirstAsync(x => x.Id == id);

        [HttpPost]
        public async Task<ActionResult<Person>> Post(Person person)
        {
            _agendaDB.Person.Add(person);
            await _agendaDB.SaveChangesAsync();
            return CreatedAtAction("Get", new { id = person.Id }, person);
        }

        [HttpPut]
        public async Task<ActionResult<Person>> Put(int id, Person person)
        {
            if (id != person.Id) return BadRequest();
            _agendaDB.Entry(person).State = EntityState.Modified;
            try
            {
                await _agendaDB.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id)) return NotFound();
                else throw;
            }
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var person = _agendaDB.Person.FindAsync(id);
            if (person == null) return NotFound();
            _agendaDB.Entry(person).State = EntityState.Deleted;
            await _agendaDB.SaveChangesAsync();
            return NoContent();

        }

        private bool PersonExists(int id) => _agendaDB.Person.Any(x => x.Id == id);

    }
}
