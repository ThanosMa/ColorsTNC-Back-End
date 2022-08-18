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
    public class ColorFormulaRepository:GenericRepository<ColorFormula>, IColorFormulaRepository
    {
        public ColorFormulaRepository(ApplicationDbContext context): base(context)
        {

        }

        //public IEnumerable<ColorFormula> GetAllWithProducts()
        //{
        //    return db.ColorFormulas.Include(x => x.Products).ToList();
        //}
    }
}
