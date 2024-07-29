using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto;
using Microsoft.EntityFrameworkCore;
using APIContacts.Data;

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

        [HttpGet]
        
        public async Task<ActionResult<List<Contact>>> GetAllContacts()
        {
          // Récupérer tous les contacts
            var contacts = await _context.Contacts.ToListAsync();

            // Retourner les contacts
            return Ok(contacts);
        }
    }
}
