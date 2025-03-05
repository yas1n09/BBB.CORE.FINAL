using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.CORE.FINAL.Enums
{
    public class GuestPolicy
    {
        public static readonly List<string> Options = new()
    {
        "ALWAYS_ACCEPT",
        "ALWAYS_DENY",
        "ASK_MODERATOR"
    };
    }

}
