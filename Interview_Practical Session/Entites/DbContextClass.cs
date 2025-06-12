using Microsoft.EntityFrameworkCore;

namespace Interview_Practical_Session.NewFolder
{
    public class DbContextClass : DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass> options) : base(options) { }
        
           public DbSet<User> Users { get; set; }
    
    }

}

