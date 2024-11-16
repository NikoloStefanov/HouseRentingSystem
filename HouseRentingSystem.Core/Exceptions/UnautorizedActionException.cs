using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Core.Exceptions
{
    public class UnautorizedActionException:Exception
    {
        public UnautorizedActionException()
        {

        }
        public UnautorizedActionException(string message) : base(message) { }
        
    }
}
