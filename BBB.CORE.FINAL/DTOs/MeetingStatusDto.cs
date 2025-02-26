using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BBB.CORE.FINAL.DTOs
{
    [XmlRoot("response")]
    public class MeetingStatusDto
    {
        public string MeetingID { get; set; }
        public bool IsRunning { get; set; }
        public string Message { get; set; }
        public string Details { get; set; } // Ek bilgi için alan eklendi
    }
}
