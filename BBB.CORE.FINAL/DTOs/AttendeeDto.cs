using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BBB.CORE.FINAL.DTOs
{
    [XmlRoot("Attendee")]
    public class AttendeeDto
    {
        [XmlElement("userID")]
        public string UserID { get; set; }

        [XmlElement("fullName")]
        public string FullName { get; set; }

        [XmlElement("role")]
        public string Role { get; set; }

        [XmlElement("isPresenter")]
        public bool IsPresenter { get; set; }

        [XmlElement("isListeningOnly")]
        public bool IsListeningOnly { get; set; }

        [XmlElement("hasJoinedVoice")]
        public bool HasJoinedVoice { get; set; }

        [XmlElement("hasVideo")]
        public bool HasVideo { get; set; }
    }

}


