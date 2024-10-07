using ENTITIES.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES
{
    public class Context:DbContext
    {
        public Context() : base(new DbContextOptions<Context>()) { }
        public Context(DbContextOptions<Context> options) : base(options) { }
        public virtual DbSet<User> Users { get; set; }

    }
}
