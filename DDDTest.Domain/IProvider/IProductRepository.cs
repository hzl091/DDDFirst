using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDTest.Core.Data;

namespace DDDTest.Domain.IProvider
{
    public interface IProductRepository : IRepository<Product>
    {
        ICollection<Product> GetByIds(Guid[] ids);

        ICollection<Product> GetAll();
    }
}
