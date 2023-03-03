using Contacts.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Contacts.WebApi
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }        

    }
}
