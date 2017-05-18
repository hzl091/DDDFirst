using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DDDTest.Domain;
using DDDTest.Domain.IProvider;
namespace DDDTest.Data
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ICollection<Product> GetByIds(Guid[] ids)
        {
            return this.RS.Where(item => ids.Contains(item.Id)).ToList();
        }

        public ICollection<Product> GetAll()
        {
            return this.RS;
        }
    }
}
