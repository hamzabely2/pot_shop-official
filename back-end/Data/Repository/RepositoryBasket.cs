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
    public class RepositoryBasket : GenericRepository<Basket>, IRepositoryBasket
    { 
        public RepositoryBasket(IDBContext _idbcontext) : base(_idbcontext)
        {
        }
    }
}
