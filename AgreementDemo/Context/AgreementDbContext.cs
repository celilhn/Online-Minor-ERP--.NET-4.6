using Domain.Models;
using System.Data.Entity;

namespace AgreementDemo.Context
{
    public class AgreementDbContext : DbContext
    {
        public DbSet<Agreement> Agreements { get; set; }

    }
}
