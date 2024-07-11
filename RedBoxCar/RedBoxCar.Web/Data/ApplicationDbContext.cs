using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RedBoxCar.Web.Models;

namespace RedBoxCar.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Users> Users { get; set; }

        public DbSet<Orders> Orders { get; set; }

        public DbSet<Products> Products { get; set; }

        public DbSet<Ingredients> Ingredients { get; set; }
    }
}