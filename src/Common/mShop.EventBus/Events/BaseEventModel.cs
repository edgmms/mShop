using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mShop.EventBus.Events
{
    public class BaseEventModel
    {
        public Guid RequestId { get; set; }
    }
}
