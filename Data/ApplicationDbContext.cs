using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace APIContacts.Data
{
    public class ApplicationDbContext : DbContext
    {
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Contact> Contacts { get; set; }

    }

   
}
 