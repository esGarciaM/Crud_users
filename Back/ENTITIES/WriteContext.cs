using ENTITIES.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES
{
    public class WriteContext:DbContext
    {
        public WriteContext() : base(new DbContextOptions < WriteContext >()) { }
        public WriteContext(DbContextOptions<WriteContext> optons) : base(optons) { }
        public virtual DbSet<User> Users { get; set; }

    }
}
