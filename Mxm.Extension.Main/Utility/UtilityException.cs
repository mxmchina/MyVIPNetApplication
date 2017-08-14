using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mxm.Extension.Main.Utility
{
    public class UtilityException : Exception
    {
        public int Code { get; set; }
        public UtilityException(int code, string message)
            : base(message)
        {
            Code = code;
        }
    }
}
