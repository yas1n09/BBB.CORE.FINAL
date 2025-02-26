using BBB.CORE.FINAL.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BBB.CORE.FINAL.Requests.Meeting
{
    [Serializable, XmlRoot("request")]
    public class IsMeetingRunningRequest : BaseRequest
    {
        public string meetingID { get; set; }
    }
}
