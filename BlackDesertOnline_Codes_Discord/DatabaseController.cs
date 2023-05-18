using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackDesertOnline_Codes_Discord
{
    internal class DatabaseController:DbContext
    {
        public DatabaseController(DbContextOptions<DatabaseController> options) : base(options) { }
        public DbSet<Codes> tbl_BDOCodes { get; set; }

    }
}
