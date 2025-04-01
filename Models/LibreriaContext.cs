using Microsoft.EntityFrameworkCore;

namespace L02P02_2022AJ650_2022PD651.Models
{
    public class LibreriaContext:DbContext
    {
        public LibreriaContext(DbContextOptions<LibreriaContext> options) : base(options)
        {
        }
    }
}
