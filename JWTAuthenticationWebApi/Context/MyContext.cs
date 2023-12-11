using JWTAuthenticationWebApi.Model;
using Microsoft.EntityFrameworkCore;

namespace JWTAuthenticationWebApi.Context
{
    public class MyContext:DbContext
    {
        public MyContext(DbContextOptions<MyContext> options):base(options) 
        { 

        }
      public  DbSet<User> Users { get; set; }
      public  DbSet<RawMaterials> Materials { get; set; }
    }
}
