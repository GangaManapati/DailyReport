using Microsoft.EntityFrameworkCore;

namespace WebApplication210624.Models
{
    public class BrandContext :DbContext
    {
        public BrandContext(DbContextOptions<BrandContext> Options) :base(Options) 
        {
        
        }  
        public DbSet<Brand> Brands { get; set; }
            
        
    }
}
