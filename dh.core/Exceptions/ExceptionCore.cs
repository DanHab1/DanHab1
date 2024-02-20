using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dh.core.Exceptions
{
    public class ExceptionCore : ArgumentException
    {
        public ExceptionCore(string message, string val = "") : base(message, val)
        {
            
        }
    }
}
