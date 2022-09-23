using Entities.Models;
using MyDatabase;
using RepositoryServices.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryServices.Persistance.Repositories
{
    public class WarehouseProductRepository : GenericRepository<WarehouseProduct>, IWarehouseProductRepository
    {
        public WarehouseProductRepository(ApplicationDbContext context): base(context)
        {

        }
    }
}
