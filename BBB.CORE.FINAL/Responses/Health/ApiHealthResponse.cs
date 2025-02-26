using BBB.CORE.FINAL.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.CORE.FINAL.Responses.Health
{
    public class ApiHealthResponse : BaseResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string Details { get; set; } = string.Empty; // Opsiyonel, hata detayları için
        public int? MeetingCount { get; set; }
    }
}
