using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.Utilities.Repositories
{
    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> Get();
        TEntity Get(long id);
        void Add(TEntity data);
        void Delete(long id);
        void Update(TEntity data);
        void Save();
    }
}
