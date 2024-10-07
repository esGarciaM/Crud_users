using ENTITIES;
using ENTITIES.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ContextHandler<T> where T : EntityBase
    {
        private Context _context;
        private WriteContext _wContext;
        public DbContext _dbContext;
        private DbSet<T> _dbSet;
        private T entity;
        public ContextHandler(Context context, WriteContext wContext) { 
            _context = context;
            _wContext = wContext;
        }
        public DbSet<T> readEntitySet()
        {
            _dbContext = _context;
            return _dbContext.Set<T>();
        }
        public DbSet<T> writeEntitySet() {
            _dbContext = _wContext;
            return _dbContext.Set<T>();
        }
        public DbSet<T> Write() {
            return writeEntitySet();
        }
        public DbSet<T> Read()
        {
            return readEntitySet();
        }
        public async Task<int> Save() { 
            return await _dbContext.SaveChangesAsync();
        }
    }
}
