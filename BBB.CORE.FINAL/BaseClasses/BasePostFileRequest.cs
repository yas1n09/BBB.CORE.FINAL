using BBB.CORE.FINAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.CORE.FINAL.BaseClasses
{
    public class BasePostFileRequest : BaseRequest
    {
        public FileContentData file { get; set; }
    }
}
