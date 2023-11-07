
using Microsoft.EntityFrameworkCore;
using Cashingaspnet.Models;
using Microsoft.Extensions.Hosting;

namespace Cashingaspnet.Models
{
    public class AppDbContext: DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }



        public DbSet<Employee> TblEmployee { get; set; }
        public DbSet<Designation> TblDesignation { get; set; }


      

        protected override void OnModelCreating(ModelBuilder builder)
            {
                base.OnModelCreating(builder);
            }

        }
}
