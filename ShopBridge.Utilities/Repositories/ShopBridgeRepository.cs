using Microsoft.EntityFrameworkCore;
using ShopBridge.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.Utilities.Repositories
{
    public class ShopBridgeRepository<Tentity>:IRepository<Tentity> where Tentity : class
    {
        private ShopBridgeContext _context;
        private DbSet<Tentity> _dbSet;

        public ShopBridgeRepository(ShopBridgeContext context)
        {
            _context = context;
            _dbSet = context.Set<Tentity>();
        }

        public void Add(Tentity data) => _dbSet.Add(data);

        public void Delete(long id)
        {
            var dataToDelete = _dbSet.Find(id);
            _dbSet.Remove(dataToDelete);
        }

        public IEnumerable<Tentity> Get() => _dbSet.ToList();

        public Tentity Get(long id) => _dbSet.Find(id);

        public void Save() => _context.SaveChanges();

        public void Update(Tentity data)
        {
           _dbSet.Attach(data);
            _context.Entry(data).State=EntityState.Modified;
        }
    }
}
