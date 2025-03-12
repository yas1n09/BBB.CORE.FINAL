using BBB.CORE.FINAL.BaseClasses;
using BBB.CORE.FINAL.Helpers;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BBB.CORE.FINAL.Requests.Meeting
{
    [Serializable, XmlRoot("request")]
    public class CreateMeetingRequest : BaseRequest
    {
        private static Random random = new Random();

        // Toplantı adı (Zorunlu)
        [XmlElement(ElementName = "name", IsNullable = false)]
        public string name { get; set; }

        // Benzersiz toplantı ID'si (Zorunlu)
        [XmlElement(ElementName = "meetingID")]
        public string meetingID { get; set; } = Guid.NewGuid().ToString();

        // Toplantı süresi (dakika) (Varsayılan: 0, sınırsız)
        [XmlElement(ElementName = "duration")]
        public int duration { get; set; } = 0;

        // Toplantı kaydı yapılacak mı? (Varsayılan: false)
        [XmlElement(ElementName = "record")]
        public bool record { get; set; } = false;

        // Moderatör şifresi (Zorunlu)
        [XmlElement(ElementName = "moderatorPW", IsNullable = false)]
        public string moderatorPW { get; set; }

        // Katılımcı şifresi (Zorunlu)
        [XmlElement(ElementName = "attendeePW", IsNullable = false)]
        public string attendeePW { get; set; }

        // Moderator yoksa toplantı sonlandır (Varsayılan: false)
        [XmlElement(ElementName = "endWhenNoModerator")]
        public bool endWhenNoModerator { get; set; } = false;


        // Moderator yoksa toplantı sonlandır (Varsayılan: false)
        [XmlElement(ElementName = "endWhenNoModeratorDelayInMinutes")]
        public int endWhenNoModeratorDelayInMinutes { get; set; }

        //
        [XmlElement(ElementName = "learningDashboardEnabled")]
        public bool learningDashboardEnabled { get; set; } = true;

        [XmlElement(ElementName = "learningDashboardCleanupDelayInMinutes")]
        public int learningDashboardCleanupDelayInMinutes { get; set; } = 0;

        // Karşılama mesajı (Varsayılan: "Welcome to the meeting!")
        [XmlElement(ElementName = "welcome")]
        public string welcome { get; set; } = "Welcome to the meeting!";

        // Toplantı telefon numarası (Opsiyonel)
        [XmlElement(ElementName = "dialNumber")]
        public string dialNumber { get; set; }

        // Ses köprüsü numarası (Varsayılan: Rastgele 1000-9999999 arası)
        [XmlElement(ElementName = "voiceBridge")]
        public int voiceBridge { get; set; } = random.Next(1000, 9999999);

        // Maksimum katılımcı sayısı (Varsayılan: 0, sınırsız)
        [XmlElement(ElementName = "maxParticipants")]
        public int maxParticipants { get; set; } = 0;

        // Başlangıçta tüm katılımcıları susturma (Varsayılan: true)
        [XmlElement(ElementName = "muteOnStart")]
        public bool muteOnStart { get; set; } = true;

        // Sadece moderatör için webcam (Varsayılan: false)
        [XmlElement(ElementName = "webcamsOnlyForModerator")]
        public bool webcamsOnlyForModerator { get; set; } = false;

        // Çıkış URL'si (Opsiyonel)
        [XmlElement(ElementName = "logoutURL")]
        public string logoutURL { get; set; }

        // Meta veriler (Opsiyonel)
        [XmlElement(ElementName = "meta")]
        public List<MetaData> meta { get; set; } = new List<MetaData>();

        // Toplantı başlangıcında otomatik kayıt başlatma (Varsayılan: false)
        [XmlElement(ElementName = "autoStartRecording")]
        public bool autoStartRecording { get; set; } = false;

        // Kayıt başlat/durdur izni (Varsayılan: true)
        [XmlElement(ElementName = "allowStartStopRecording")]
        public bool allowStartStopRecording { get; set; } = true;


        // Toplantı logosu URL'si (Opsiyonel)
        [XmlElement(ElementName = "logo")]
        public string logo { get; set; }

        // Banner metni (Opsiyonel)
        [XmlElement(ElementName = "bannerText")]
        public string bannerText { get; set; }

        // Banner rengi (Opsiyonel)
        [XmlElement(ElementName = "bannerColor")]
        public string bannerColor { get; set; }

        // Kamera kullanımını engelle (Varsayılan: false)
        [XmlElement(ElementName = "lockSettingsDisableCam")]
        public bool lockSettingsDisableCam { get; set; } = false;

        // Mikrofon kullanımını engelle (Varsayılan: false)
        [XmlElement(ElementName = "lockSettingsDisableMic")]
        public bool lockSettingsDisableMic { get; set; } = false;

        // Özel sohbeti engelle (Varsayılan: false)
        [XmlElement(ElementName = "lockSettingsDisablePrivateChat")]
        public bool lockSettingsDisablePrivateChat { get; set; } = false;

        // Genel sohbeti engelle (Varsayılan: false)
        [XmlElement(ElementName = "lockSettingsDisablePublicChat")]
        public bool lockSettingsDisablePublicChat { get; set; } = false;

        // Not kullanımını engelle (Varsayılan: false)
        [XmlElement(ElementName = "lockSettingsDisableNote")]
        public bool lockSettingsDisableNote { get; set; } = false;

        // Kilitli düzen (Varsayılan: false)
        [XmlElement(ElementName = "lockSettingsLockedLayout")]
        public bool lockSettingsLockedLayout { get; set; } = false;

        // Katılımcı girişinde kilit (Varsayılan: false)
        [XmlElement(ElementName = "lockSettingsLockOnJoin")]
        public bool lockSettingsLockOnJoin { get; set; } = false;

        // Misafir politikası (Varsayılan: "ALWAYS_ACCEPT")
        [XmlElement(ElementName = "guestPolicy")]
        public string guestPolicy { get; set; }
    }
}