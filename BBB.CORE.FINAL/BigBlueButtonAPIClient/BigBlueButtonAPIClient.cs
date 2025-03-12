using BBB.CORE.FINAL.BaseClasses;
using BBB.CORE.FINAL.Helpers;
using BBB.CORE.FINAL.Requests.LearningDashboard;
using BBB.CORE.FINAL.Requests.Meeting;
using BBB.CORE.FINAL.Responses.LearningDashboard;
using BBB.CORE.FINAL.Responses.Meeting;

using Newtonsoft.Json;
using System.Text;


namespace BBB.CORE.FINAL.BigBlueButtonAPIClient
{
    public class BigBlueButtonAPIClient
    {
        private readonly HttpClient httpClient;
        private readonly UrlBuilder urlBuilder;

        public BigBlueButtonAPIClient(BigBlueButtonAPISettings settings, HttpClient httpClient)
        {
            this.urlBuilder = new UrlBuilder(settings);
            this.httpClient = httpClient;
        }


        #region HTTP Methods
        private async Task<T> HttpGetAsync<T>(string method, BaseRequest request)
        {
            var url = urlBuilder.Build(method, request);
            var result = await HttpGetAsync<T>(url);
            return result;
        }


        private async Task<T> HttpPostAsync<T>(string method, BaseRequest request)
        {
            var url = urlBuilder.Build(method, request);
            var xmlContent = XmlHelper.ToXml(request); // XML formatında veri oluştur
            var content = new StringContent(xmlContent, Encoding.UTF8, "application/xml"); // Content-Type: application/xml

            var response = await httpClient.PostAsync(url, content);
            var xmlOrJson = await response.Content.ReadAsStringAsync();

            if (typeof(T) == typeof(string)) return (T)(object)xmlOrJson;

            if (xmlOrJson.StartsWith("<"))
            {
                return XmlHelper.FromXml<T>(xmlOrJson);
            }
            else
            {
                var wrapper = JsonConvert.DeserializeObject<ResponseJsonWrapper<T>>(xmlOrJson);
                return wrapper.response;
            }
        }


        private async Task<T> HttpGetAsync<T>(string url)
        {
            // HTTP isteği gönder
            var response = await httpClient.GetAsync(url);

            // Yanıtı metin olarak oku
            var xmlOrJson = await response.Content.ReadAsStringAsync();

            // Yanıtı logla
            Console.WriteLine("Response XML/JSON: " + xmlOrJson);

            // Eğer tip string ise yanıtı direkt döndür
            if (typeof(T) == typeof(string)) return (T)(object)xmlOrJson;

            // Eğer XML ise deserialize et
            if (xmlOrJson.StartsWith("<"))
            {
                return XmlHelper.FromXml<T>(xmlOrJson);
            }
            else
            {
                // JSON formatı varsa işle
                var wrapper = JsonConvert.DeserializeObject<ResponseJsonWrapper<T>>(xmlOrJson);
                return wrapper.response;
            }
        }



        private async Task<T> HttpPostFileAsync<T>(string method, BasePostFileRequest request)
        {
            var url = urlBuilder.Build(method, request);
            var cts = new CancellationTokenSource();
            using (var content = new MultipartFormDataContent())
            {
                content.Add(new ByteArrayContent(request.file.FileData), request.file.Name, request.file.FileName);

                var response = await httpClient.PostAsync(url, content, cts.Token);
                var xmlOrJson = await response.Content.ReadAsStringAsync();
                if (typeof(T) == typeof(string)) return (T)(object)xmlOrJson;

                // Most APIs return XML string.
                // The getRecordingTextTracks API may return JSON string.
                if (xmlOrJson.StartsWith("<"))
                {
                    return XmlHelper.FromXml<T>(xmlOrJson);
                }
                else
                {
                    var wrapper = JsonConvert.DeserializeObject<ResponseJsonWrapper<T>>(xmlOrJson);
                    return wrapper.response;
                }

            }

        }

        #endregion





        #region Meeting Management
        public async Task<CreateMeetingResponse> CreateMeetingAsync(CreateMeetingRequest request)
        {
            //if (request == null) throw new ArgumentNullException("request");
            if (request == null) throw new ArgumentNullException(nameof(request));

            return await HttpGetAsync<CreateMeetingResponse>("create", request);
        }

        public async Task<EndMeetingResponse> EndMeetingAsync(EndMeetingRequest request)
        {
            return await HttpGetAsync<EndMeetingResponse>("end", request);
        }

        public async Task<GetMeetingInfoResponse> GetMeetingInfoAsync(GetMeetingInfoRequest request)
        {
            return await HttpGetAsync<GetMeetingInfoResponse>("getMeetingInfo", request);
        }

        public async Task<IsMeetingRunningResponse> IsMeetingRunningAsync(IsMeetingRunningRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            return await HttpGetAsync<IsMeetingRunningResponse>("isMeetingRunning", request);
        }

        public async Task<GetMeetingsResponse> GetMeetingsAsync()
        {
            var url = urlBuilder.Build("getMeetings", null); // BaseRequest null olabilir çünkü parametre yok
            return await HttpGetAsync<GetMeetingsResponse>(url);

        }

        public async Task<string> GetJoinMeetingUrl(JoinMeetingRequest request)
        {
            //var url = urlBuilder.Build("join", request);
            //return url;

            if (request.redirect == false) request.redirect = true;

            return urlBuilder.Build("join", request);
        }


        public async Task<GetLearningDashboardResponse> GetLearningDashboardAsync(GetLearningDashboardRequest request)
        {
            return await HttpGetAsync<GetLearningDashboardResponse>("GetLearningDashboard", request);
        }



        #endregion






    }
}
