using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDTest.ServiceContract.Dto;

namespace DDDTest.Service.Core
{
    public class RemoveItemCore :OptionBase<RemoveItemRequest,RemoveItemResponse>
    {
        public RemoveItemCore(RemoveItemRequest request) 
            : base(request)
        { 
            
        }
        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
