using BBB.CORE.FINAL.BaseClasses;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BBB.CORE.FINAL.Responses.Meeting
{
    [Serializable, XmlRoot("response")]
    public class CreateMeetingResponse : BaseResponse
    {
        // Toplantı ID'si
        [XmlElement(ElementName = "meetingID")]
        public string meetingID { get; set; }

        // Dahili toplantı ID'si
        [XmlElement(ElementName = "internalMeetingID")]
        public string internalMeetingID { get; set; }       

        // Moderatör şifresi
        [XmlElement(ElementName = "moderatorPW")]
        public string moderatorPW { get; set; }

        // Katılımcı şifresi
        [XmlElement(ElementName = "attendeePW")]
        public string attendeePW { get; set; }

        // Toplantı süresi (dakika)
        [XmlElement(ElementName = "duration")]
        public int duration { get; set; }

        // Maksimum katılımcı sayısı
        [XmlElement(ElementName = "maxParticipants")]
        public int maxParticipants { get; set; }

        // Kayıt durumu
        [XmlElement(ElementName = "recording")]
        public bool recording { get; set; }

        // Toplantı oluşturulma tarihi (ISO 8601 formatında)
        [XmlElement(ElementName = "createDate")]
        public string createDate { get; set; }

        // Toplantı oluşturulma zamanı (Unix timestamp)
        [XmlElement(ElementName = "createTime")]
        public long createTime { get; set; }

        // Ses köprüsü numarası
        [XmlElement(ElementName = "voiceBridge")]
        public int? voiceBridge { get; set; }

        // Toplantı telefon numarası
        [XmlElement(ElementName = "dialNumber")]
        public string dialNumber { get; set; }

        // Toplantı kilitlendi mi?
        [XmlElement(ElementName = "hasBeenLocked")]
        public bool hasBeenLocked { get; set; }

                // Moderator yoksa toplantı sonlandır (Varsayılan: false)
        [XmlElement(ElementName = "endWhenNoModerator")]
        public bool endWhenNoModerator { get; set; } = false;

        // Moderator yoksa toplantı sonlandır (Varsayılan: false)
        [XmlElement(ElementName = "endWhenNoModeratorDelayInMinutes")]
        public int endWhenNoModeratorDelayInMinutes { get; set; }

        [XmlElement(ElementName = "learningDashboardEnabled")]
        public bool learningDashboardEnabled { get; set; } = true;

        [XmlElement(ElementName = "learningDashboardCleanupDelayInMinutes")]
        public int learningDashboardCleanupDelayInMinutes { get; set; }

        // Misafir politikası (Varsayılan: "ALWAYS_ACCEPT")
        [XmlElement(ElementName = "guestPolicy")]
        public string guestPolicy { get; set; }

        // Meta veriler
        [XmlElement(ElementName = "metadata")]
        public string metadata { get; set; }



    }
}