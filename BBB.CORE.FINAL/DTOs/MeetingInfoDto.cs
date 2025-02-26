using BBB.CORE.FINAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BBB.CORE.FINAL.DTOs
{
    [XmlRoot("response")]
    public class MeetingInfoDto
    {
        //[XmlElement("returncode")]
        //public string ReturnCode { get; set; }
        //[XmlElement("messageKey")]
        //public string MessageKey { get; set; }

        [XmlElement("message")]
        public string Message { get; set; }

        [XmlElement("meetingID")]
        public string MeetingID { get; set; }

        [XmlElement("internalMeetingID")]
        public string InternalMeetingID { get; set; }

        [XmlElement("createTime")]
        public long? CreateTime { get; set; }

        [XmlElement("participantCount")]
        public int? ParticipantCount { get; set; }


        [XmlElement("MeetingName")]
        public string MeetingName { get; set; }


        [XmlElement("CreateDate")]
        public string CreateDate { get; set; }

        [XmlElement("VoiceBridge")]
        public int? VoiceBridge { get; set; }

        [XmlElement("DialNumber")]
        public string DialNumber { get; set; }

        [XmlElement("ModeratorPW")]
        public string ModeratorPW { get; set; }

        [XmlElement("AttendeePW")]
        public string AttendeePW { get; set; }

        [XmlElement("Running")]
        public bool? Running { get; set; }

        [XmlElement("Duration")]
        public int? Duration { get; set; }

        [XmlElement("HasUserJoined")]
        public bool? HasUserJoined { get; set; }

        [XmlElement("Recording")]
        public bool? Recording { get; set; }

        [XmlElement("HasBeenForciblyEnded")]
        public bool? HasBeenForciblyEnded { get; set; }

        [XmlElement("StartTime")]
        public long? StartTime { get; set; }

        [XmlElement("EndTime")]
        public long? EndTime { get; set; }

        [XmlElement("ListenerCount")]
        public int? ListenerCount { get; set; }

        [XmlElement("VoiceParticipantCount")]
        public int? VoiceParticipantCount { get; set; }

        [XmlElement("VideoCount")]
        public int? VideoCount { get; set; }

        [XmlElement("MaxUsers")]
        public int? MaxUsers { get; set; }

        [XmlElement("ModeratorCount")]
        public int? ModeratorCount { get; set; }

        [XmlElement("IsBreakout")]
        public bool? IsBreakout { get; set; }

        [XmlElement("BreakoutRooms")]
        public List<string> BreakoutRooms { get; set; }

        [XmlElement("ParentMeetingID")]
        public string ParentMeetingID { get; set; }

        [XmlElement("Sequence")]
        public int? Sequence { get; set; }

        [XmlElement("FreeJoin")]
        public bool? FreeJoin { get; set; }


        [XmlArray("attendees")]
        [XmlArrayItem("Attendee")]
        public List<AttendeeDto> Attendees { get; set; }

    }
}
