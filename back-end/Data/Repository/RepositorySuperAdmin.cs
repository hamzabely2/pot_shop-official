using Api.Data.Context.Contract;
using Api.Data.Context.Model;
using Api.Data.Repository.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Api.Data.Repository
{
    public class RepositorySuperAdmin : GenericRepository<User>, IRepositorySuperAdmin
    {
        public RepositorySuperAdmin(IDBContext _idbcontext) : base(_idbcontext)
        {
            _table = _idbcontext.Set<Item>();
        }

        private readonly DbSet<Item> _table;
    }  
}
