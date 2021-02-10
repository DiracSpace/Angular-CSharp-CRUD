using CRUD.Core;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Data
{
    public class PersonDbContext : DbContext
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options)
            : base(options)
        {

        }

        public DbSet<Persons> Person { get; set; }
    }
}
