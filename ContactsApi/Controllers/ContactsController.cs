using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ContactsApi.Models;
using ContactsApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;

namespace ContactsApi.Controllers
{
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private readonly IContactsRepository _repo;

        public ContactsController(IContactsRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var contactsList = await _repo.GetAll();
            return Ok(contactsList);
        }   

        [HttpGet("{id}", Name = "GetContacts")]
        public async Task<IActionResult> GetById(string id)
        {
            var item = await _repo.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Contacts item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            await _repo.Add(item);
            return CreatedAtRoute("GetContacts", new {Controller = "Contacts", id = item.MobilePhone}, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Contacts item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            var contactObj = await _repo.Find(id);
            if (contactObj == null)
            {
                return NotFound();
            }
            await _repo.Update(item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _repo.Remove(id);
            return NoContent();
        }
    }
}
