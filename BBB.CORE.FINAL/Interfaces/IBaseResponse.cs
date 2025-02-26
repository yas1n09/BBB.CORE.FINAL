using BBB.CORE.FINAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.CORE.FINAL.Interfaces
{
    public interface IBaseResponse
    {
        Returncode returncode { get; set; }
        string messageKey { get; set; }
        string message { get; set; }
    }
}
