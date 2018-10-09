using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
  public class BusinessLogicDbContext : DbContext

  {
        
        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Buy> Buys { get; set; }
        public DbSet<BuyProduct> BuyProducts { get; set; }
    
        public BusinessLogicDbContext(DbContextOptions<BusinessLogicDbContext> options)
      :base(options)
    { }
   }
}
