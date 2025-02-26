using BBB.CORE.FINAL.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BBB.CORE.FINAL.Responses.Meeting
{
    [XmlRoot("response")]
    public class IsMeetingRunningResponse : BaseResponse
    {
        public bool? running { get; set; }
        public string message { get; set; } // Ek bilgi için alan eklendi
        
    }
}
