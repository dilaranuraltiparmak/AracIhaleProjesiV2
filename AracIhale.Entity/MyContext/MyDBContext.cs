using AracIhale.Entity.DTO;
using Microsoft.EntityFrameworkCore;

namespace AracIhale.Entity
    .MyContext
{
    public class MyDBContext :DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
        }

        public DbSet<IhaleDTO> IhaleDTOs { get; set; }

    }
}
