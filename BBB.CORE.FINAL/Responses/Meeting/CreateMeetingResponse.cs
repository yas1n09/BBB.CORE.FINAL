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

        //// Ana toplantı ID'si (Opsiyonel)
        //[XmlElement(ElementName = "parentMeetingID")]
        //public string parentMeetingID { get; set; }

        // Moderatör şifresi
        [XmlElement(ElementName = "moderatorPW")]
        public string moderatorPW { get; set; }

        // Katılımcı şifresi
        [XmlElement(ElementName = "attendeePW")]
        public string attendeePW { get; set; }

        // Toplantı oluşturulma zamanı (Unix timestamp)
        [XmlElement(ElementName = "createTime")]
        public long createTime { get; set; }

        // Ses köprüsü numarası
        [XmlElement(ElementName = "voiceBridge")]
        public int? voiceBridge { get; set; }

        // Toplantı telefon numarası
        [XmlElement(ElementName = "dialNumber")]
        public string dialNumber { get; set; }

        // Toplantı oluşturulma tarihi (ISO 8601 formatında)
        [XmlElement(ElementName = "createDate")]
        public string createDate { get; set; }

        // Kullanıcı katıldı mı?
        [XmlElement(ElementName = "hasUserJoined")]
        public bool hasUserJoined { get; set; }

        // Toplantı süresi (dakika)
        [XmlElement(ElementName = "duration")]
        public int duration { get; set; }

        // Toplantı zorla sonlandırıldı mı?
        [XmlElement(ElementName = "hasBeenForciblyEnded")]
        public bool hasBeenForciblyEnded { get; set; }

        // Maksimum katılımcı sayısı
        [XmlElement(ElementName = "maxParticipants")]
        public int maxParticipants { get; set; }

        // Katılımcı sayısı
        [XmlElement(ElementName = "participantCount")]
        public int participantCount { get; set; }

        // Dinleyici sayısı
        [XmlElement(ElementName = "listenerCount")]
        public int listenerCount { get; set; }

        // Sesli katılımcı sayısı
        [XmlElement(ElementName = "voiceParticipantCount")]
        public int voiceParticipantCount { get; set; }

        // Video katılımcı sayısı
        [XmlElement(ElementName = "videoCount")]
        public int videoCount { get; set; }

        // Kayıt durumu
        [XmlElement(ElementName = "recording")]
        public bool recording { get; set; }

        // Toplantı kilitlendi mi?
        [XmlElement(ElementName = "hasBeenLocked")]
        public bool hasBeenLocked { get; set; }

        // Toplantı başladı mı?
        [XmlElement(ElementName = "hasStarted")]
        public bool hasStarted { get; set; }

        // Toplantı çalışıyor mu?
        [XmlElement(ElementName = "running")]
        public string running { get; set; }

        // Meta veriler
        [XmlElement(ElementName = "metadata")]
        public string metadata { get; set; }

        // Katılımcı listesi
        [XmlArray("attendeeList")]
        [XmlArrayItem("attendee")]
        public List<string> attendeeList { get; set; } = new List<string>();
    }
}