using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDTest.Service.Core
{
    public abstract class OptionBase<TRequest,TResponse>
    {
        public OptionBase(TRequest request)
        {
            this.Request = request;
        }
        public TRequest Request { get; set; }

        public TResponse Response { get; set; }

        public abstract void Execute(); 
    }
}
