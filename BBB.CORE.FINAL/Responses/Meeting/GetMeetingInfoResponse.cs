using BBB.CORE.FINAL.Entities;
using BBB.CORE.FINAL.Enums;
using BBB.CORE.FINAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BBB.CORE.FINAL.Responses.Meeting
{
    [Serializable, XmlRoot("response")]
    public class GetMeetingInfoResponse : MeetingInfo, IBaseResponse
    {
        [XmlElement("returncode")]
        public Returncode returncode { get; set; }

        [XmlElement("messageKey")]
        public string messageKey { get; set; }

        [XmlElement("message")]
        public string message { get; set; }

        [XmlElement("meetingID")]
        public string meetingID { get; set; }

        [XmlElement("internalMeetingID")]
        public string internalMeetingID { get; set; }

        [XmlElement("meetingName")]
        public string meetingName { get; set; }

        [XmlElement("createTime")]
        public long? createTime { get; set; }

        [XmlElement("voiceBridge")]
        public int? voiceBridge { get; set; }

        [XmlElement("dialNumber")]
        public string dialNumber { get; set; }

        [XmlElement("attendeePW")]
        public string attendeePW { get; set; }

        [XmlElement("moderatorPW")]
        public string moderatorPW { get; set; }

        [XmlElement("running")]
        public bool? running { get; set; }

        [XmlElement("duration")]
        public int? duration { get; set; }

        [XmlElement("hasUserJoined")]
        public bool? hasUserJoined { get; set; }

        [XmlElement("recording")]
        public bool? recording { get; set; }

        [XmlElement("hasBeenForciblyEnded")]
        public bool? hasBeenForciblyEnded { get; set; }

        [XmlElement("startTime")]
        public long? startTime { get; set; }

        [XmlElement("endTime")]
        public long? endTime { get; set; }

        [XmlElement("participantCount")]
        public int? participantCount { get; set; }

        [XmlElement("listenerCount")]
        public int? listenerCount { get; set; }

        [XmlElement("voiceParticipantCount")]
        public int? voiceParticipantCount { get; set; }

        [XmlElement("videoCount")]
        public int? videoCount { get; set; }

        [XmlElement("maxUsers")]
        public int? maxUsers { get; set; }

        [XmlElement("moderatorCount")]
        public int? moderatorCount { get; set; }

        [XmlElement("isBreakout")]
        public bool? isBreakout { get; set; }



        [XmlArray("attendees")]
        [XmlArrayItem("attendee")]
        public List<Attendee> attendeeList { get; set; } = new List<Attendee>();

    }
}
