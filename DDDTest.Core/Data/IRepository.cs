using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDTest.Core.Data
{
    public partial interface IRepository<T> where T : BaseEntity,IAggregateRoot
    {
        List<T> RS { get; }
        T GetById(Guid id);

        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(T entity);
    }
}
