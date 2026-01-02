using Microsoft.EntityFrameworkCore;

namespace _14Day_EntityFrameWork.Models
{
    public class IETDbContext:DbContext
    {
        public DbSet<Emp> emps { set; get; }

        public IETDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
