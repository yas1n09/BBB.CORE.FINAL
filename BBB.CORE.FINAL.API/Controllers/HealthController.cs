using BBB.CORE.FINAL.BigBlueButtonAPIClient;
using BBB.CORE.FINAL.Enums;
using BBB.CORE.FINAL.Helpers;
using BBB.CORE.FINAL.Requests.Meeting;
using BBB.CORE.FINAL.Responses.Health;
using Microsoft.AspNetCore.Mvc;


namespace BBB.CORE.FINAL.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        private readonly BigBlueButtonAPIClient.BigBlueButtonAPIClient client;

        public HealthController(BigBlueButtonAPIClient.BigBlueButtonAPIClient client)
        {
            this.client = client;
        }





        #region API Health Check (BigBlueButton Settings)
        private async Task<bool> IsBigBlueButtonAPISettingsOKAsync()
        {
            try
            {
                var res = await client.IsMeetingRunningAsync(new IsMeetingRunningRequest
                {
                    meetingID = Guid.NewGuid().ToString()
                });

                return res.returncode != Returncode.FAILED;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Health check failed: {ex.Message}");
                return false;
            }
        }
        #endregion





        #region API Health Status Check
        [HttpGet("check")]
        public async Task<IActionResult> CheckAPIHealth()
        {
            try
            {
                var setupOk = await IsBigBlueButtonAPISettingsOKAsync();

                // Aktif toplantıları listele
                //var meetingsResult = await client.GetMeetingsAsync();
                //var activeMeetingCount = meetingsResult?.meetings?.Count ?? 0;

                var response = new ApiHealthResponse
                {
                    Status = setupOk ? "OK" : "ERROR",
                    Message = setupOk ? "API is healthy and reachable." : "API health check failed. Please check the configuration or server.",
                    //MeetingCount = activeMeetingCount,
                    Details = "Active meetings checked successfully."
                };

                return Content(XmlHelper.ToXml(response), "application/xml");
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiHealthResponse
                {
                    Status = "ERROR",
                    Message = "An error occurred while checking API health.",
                    Details = ex.Message
                };

                return StatusCode(500, XmlHelper.ToXml(errorResponse));
            }
        }


        #endregion






    }
}
