using Microsoft.EntityFrameworkCore;

namespace Factory.Models
{
  public class FactoryContext : DbContext
  {
    public DbSet<Engineer> Engineers { get; set; }
    public DbSet<Machine> Machines { get; set; }
    public DbSet<License> Licenses { get; set; }
    public DbSet<Record> Records { get; set; }
    public DbSet<EngineerLicense> EngineerLicense { get; set; }

    public FactoryContext(DbContextOptions options) : base(options) { }
  }
}