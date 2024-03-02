using Microsoft.EntityFrameworkCore;
using caxivari.DATA;

namespace caxivari.DATA;


public class CaxivariContext : DbContext
{

    public CaxivariContext( DbContextOptions<CaxivariContext>  options ) 
        : base(options)
    {

    }
    
    
    public DbSet<Person> Persons { get; set; }

    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
        modelBuilder.Entity<Person>().ToTable("Person");
    }

}
