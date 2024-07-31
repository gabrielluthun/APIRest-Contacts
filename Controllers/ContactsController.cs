using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto;
using Microsoft.EntityFrameworkCore;
using APIContacts.Data;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace APIContacts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        // Déclaration du contexte de la base de données
        private readonly ApplicationDbContext _context;

        // Constructeur
        public ContactsController(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Méthodes HTTP

        #region HTTP GET

        [HttpGet]

        public async Task<ActionResult<List<Contact>>> GetAllContacts()
        {
            // Récupérer tous les contacts
            var contacts = await _context.Contacts.ToListAsync();

            // Retourner les contacts
            return Ok(contacts);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Contact>> GetContacts(int id)
        {
            // Récupérer tous les contacts
            var contacts = await _context.Contacts.FindAsync(id);
            if (contacts is null)
            {
                return NotFound("Contact not found");
            }

            // Retourner les contacts
            return Ok(contacts);
        }
        #endregion

        #region HTTP POST
        [HttpPost]
        public async Task<ActionResult<List<Contact>>> AddContact(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
            // Retourner le contact
            return Ok(await GetAllContacts());
        }
        #endregion

        #region HTTP PUT/UPDATE
        [HttpPut]
        public async Task<ActionResult<List<Contact>>> UpdateContact(Contact contact)
        {
            var contactToUpdate = await _context.Contacts.FindAsync(contact.Id);
            if (contactToUpdate is null) return NotFound("Contact not found");

            contactToUpdate.Nom = contact.Nom;
            contactToUpdate.Prenom = contact.Prenom;
            contactToUpdate.Avatar = contact.Avatar;

            await _context.SaveChangesAsync();

            return Ok(await GetAllContacts());
        }
        #endregion

        #region HTTP DELETE
        [HttpDelete("{id}")]

        public async Task<ActionResult<List<Contact>>> DeleteContact(int id)
        {
            var contactToDelete = await _context.Contacts.FindAsync(id);
            if (contactToDelete is null) return NotFound("Contact not found");

            _context.Contacts.Remove(contactToDelete);
            await _context.SaveChangesAsync();
            return Ok(await GetAllContacts());
        }

        #endregion
    
     #endregion
    }
}
