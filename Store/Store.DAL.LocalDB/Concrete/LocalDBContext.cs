using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Store.DAL.LocalDB.Concrete
{
    public class LocalDBContext : DbContext, Store.Abstract.IDALContext
    {
        public DbSet<Store.Entites.Book> Books { get; set; }

        public DbSet<Store.Entites.Order> Orders { get; set; }

        public LocalDBContext (DbContextOptions<LocalDBContext> options) : base(options)
        {
            Database.Migrate();
        }
    }
}
