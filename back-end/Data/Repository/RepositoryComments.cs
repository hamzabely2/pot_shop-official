using Api.Data.Context.Contract;
using Api.Data.Context.Model;
using Api.Data.Repository.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Data.Repository
{
    public class RepositoryComments : GenericRepository<Comment>, IRepositoryComments
    {
        public RepositoryComments(IDBContext _idbcontext) : base(_idbcontext)
        {
            _table = _idbcontext.Set<Comment>();
        }
        public readonly DbSet<Comment> _table;


        public async Task<List<Comment>> GetCommentOfAnItem(int IdItem)
        {
            var comments = await _idbcontext.Comments.Where(c => c.Item_Id == IdItem).ToListAsync().ConfigureAwait(false);
            return comments;
        }
    }
}
