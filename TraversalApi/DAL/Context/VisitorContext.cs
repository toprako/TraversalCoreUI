using Microsoft.EntityFrameworkCore;
using TraversalApi.DAL.Entities;

namespace TraversalApi.DAL.Context
{
    public class VisitorContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=MERT-PC;Database=SeyahatDbApi;Trusted_Connection=True;Encrypt=False;");
        }

        public DbSet<Visitor> Visitors { get; set; }
    }
}
