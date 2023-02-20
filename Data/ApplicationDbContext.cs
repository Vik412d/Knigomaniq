using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Knigomaniq.Models;

namespace Knigomaniq.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Knigomaniq.Models.Book> Book { get; set; }
        public DbSet<Knigomaniq.Models.Category> Category { get; set; }
        public DbSet<Knigomaniq.Models.PrintHouse> PrintHouse { get; set; }
        public DbSet<Knigomaniq.Models.Shopping> Shopping { get; set; }
    }
}