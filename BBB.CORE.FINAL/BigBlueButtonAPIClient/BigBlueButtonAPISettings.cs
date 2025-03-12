using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.CORE.FINAL.BigBlueButtonAPIClient
{
    public class BigBlueButtonAPISettings
    {
        public string ServerAPIUrl { get; set; } = "https://domain/bigbluebutton/api/";


        public string SharedSecret { get; set; } = "SharedSecret";
    }
}
