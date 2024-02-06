using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface.Order
{
    public interface IOrderRepository : IGenericRepository<Entity.Model.Order>
    {
        Task<List<Entity.Model.Order>> GetOrdersByUserId(int userId);
    }
}
