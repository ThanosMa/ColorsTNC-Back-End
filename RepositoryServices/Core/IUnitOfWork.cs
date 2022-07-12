using RepositoryServices.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryServices.Core
{
    internal interface IUnitOfWork : IDisposable
    {

        ICustomerRepository Customers { get; }
        IColorFormulaRepository ColorFormulas { get; }
        IProductRepository Products { get; }

        int Complete();
    }
}
