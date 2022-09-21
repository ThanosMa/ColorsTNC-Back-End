using Entities.Models;
using MyDatabase;
using RepositoryServices.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryServices.Persistance.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        
        public OrderRepository(ApplicationDbContext context): base(context)
        {

        }


      
    }
}
