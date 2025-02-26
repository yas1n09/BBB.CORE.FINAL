using BBB.CORE.FINAL.BaseClasses;
using BBB.CORE.FINAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BBB.CORE.FINAL.Responses.Meeting
{
    [Serializable, XmlRoot("response")]
    public class GetMeetingsResponse : BaseResponse
    {
        [XmlElement(ElementName = "meetings")]
        public Meetings meetings { get; set; }

        [Serializable]
        public class Meetings
        {
            [XmlElement(ElementName = "meeting")]
            public List<MeetingInfo> meetingList { get; set; } = new List<MeetingInfo>();
        }
    }
}
