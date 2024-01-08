using Api.Business.Model.Item;
using Api.Data.Context.Contract;
using Api.Data.Context.Model;
using Api.Data.Repository.Contract;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repository
{
    public class RepositoryItem : GenericRepository<Item>, IRepositoryItem
    {
        public RepositoryItem(IDBContext _idbcontext) : base(_idbcontext)
        {
            _table = _idbcontext.Set<Item>();
        }
        private readonly DbSet<Item> _table;

        public List<Item> GetItemsWithDetails()
        {
            return _table.Include(item => item.Color).Include(item => item.Category).Include(item => item.Material).ToList();
        }
    }
}
