using BBB.CORE.FINAL.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BBB.CORE.FINAL.Responses.Meeting
{
    [Serializable, XmlRoot("response")]
    public class EndMeetingResponse : BaseResponse
    {
        public string meetingID { get; set; }   
        public string message { get; set; }
    }
}
