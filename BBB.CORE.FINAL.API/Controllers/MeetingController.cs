
using BBB.CORE.FINAL.DTOs;
using BBB.CORE.FINAL.Entities;
using BBB.CORE.FINAL.Enums;
using BBB.CORE.FINAL.Helpers;
using BBB.CORE.FINAL.Requests.Meeting;
using BBB.CORE.FINAL.Responses.Meeting;
using Microsoft.AspNetCore.Mvc;

namespace BBB.CORE.FINAL.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class MeetingController : ControllerBase
    {
        private readonly BigBlueButtonAPIClient.BigBlueButtonAPIClient client;

        public MeetingController(BigBlueButtonAPIClient.BigBlueButtonAPIClient client)
        {
            this.client = client;
        }



        #region Create Meeting

        [HttpPost("create")]
        public async Task<IActionResult> CreateMeeting(
    string name,
    string meetingID,
    string moderatorPW = "",
    string attendeePW = "",
    int duration = 60,
    int maxParticipants = 20,

    bool record = true,
    bool autoStartRecording = true,
    bool allowStartStopRecording = true,

    bool endWhenNoModerator = false,
    int endWhenNoModeratorDelayInMinutes = 60,
    bool learningDashboardEnabled = true,
    int learningDashboardCleanupDelayInMinutes = 0,


    bool muteOnStart = true,
    bool webcamsOnlyForModerator = false,
    
    string welcome = "Welcome to the meeting!",
    string logoutURL = "",
    
    
    string logo = "",
    string bannerText = "",
    string bannerColor = "",

    


    bool lockSettingsDisableCam = false,
    bool lockSettingsDisableMic = false,
    bool lockSettingsDisablePrivateChat = false,
    bool lockSettingsDisablePublicChat = false,
    bool lockSettingsDisableNote = false,
    bool lockSettingsLockedLayout = false,
    bool lockSettingsLockOnJoin = false,
    [FromQuery] string guestPolicy = "ALWAYS_ACCEPT") // Varsayılan değer
    //string guestPolicy = "ALWAYS_ACCEPT")

        {
            try
            {
                var request = new CreateMeetingRequest
                {
                    name = name,
                    meetingID = meetingID,
                    moderatorPW = moderatorPW,
                    attendeePW = attendeePW,
                    duration = duration,
                    maxParticipants = maxParticipants,

                    record = record,
                    autoStartRecording = autoStartRecording,
                    allowStartStopRecording = allowStartStopRecording,

                    endWhenNoModerator = endWhenNoModerator,
                    endWhenNoModeratorDelayInMinutes = endWhenNoModeratorDelayInMinutes,
                    learningDashboardEnabled = learningDashboardEnabled,
                    learningDashboardCleanupDelayInMinutes = learningDashboardCleanupDelayInMinutes,

                    muteOnStart = muteOnStart,
                    webcamsOnlyForModerator = webcamsOnlyForModerator,
                    
                    
                    welcome = welcome,
                    logoutURL = logoutURL,
                    
                    
                    logo = logo,
                    bannerText = bannerText,
                    bannerColor = bannerColor, 
                    
                    lockSettingsDisableCam = lockSettingsDisableCam,
                    lockSettingsDisableMic = lockSettingsDisableMic,
                    lockSettingsDisablePrivateChat = lockSettingsDisablePrivateChat,
                    lockSettingsDisablePublicChat = lockSettingsDisablePublicChat,
                    lockSettingsDisableNote = lockSettingsDisableNote,
                    lockSettingsLockedLayout = lockSettingsLockedLayout,
                    lockSettingsLockOnJoin = lockSettingsLockOnJoin,
                    guestPolicy = guestPolicy,

                };

                var result = await client.CreateMeetingAsync(request);

                if (result.returncode == Returncode.FAILED)
                {
                    return Content(XmlHelper.ToXml(new MeetingErrorResponseDto
                    {
                        Message = "Failed to create meeting.",
                        Details = result.message
                    }), "application/xml");
                }

                return Content(XmlHelper.ToXml(new CreateMeetingResponse
                {
                    
                    meetingID = result.meetingID,
                    internalMeetingID = result.internalMeetingID,                   
                    moderatorPW = result.moderatorPW,
                    attendeePW = result.attendeePW,
                    duration = result.duration,
                    maxParticipants = result.maxParticipants,

                    recording = result.recording,
                    createDate = result.createDate,
                    createTime = result.createTime,
                    voiceBridge = result.voiceBridge,
                    dialNumber = result.dialNumber,
                    hasBeenLocked = result.hasBeenLocked,
                    metadata = result.metadata,
                    endWhenNoModerator = result.endWhenNoModerator,
                    endWhenNoModeratorDelayInMinutes = result.endWhenNoModeratorDelayInMinutes,
                    learningDashboardEnabled = learningDashboardEnabled,
                    learningDashboardCleanupDelayInMinutes = learningDashboardCleanupDelayInMinutes,
                    guestPolicy = guestPolicy

                }), "application/xml");
            }
            catch (Exception ex)
            {
                return StatusCode(500, XmlHelper.ToXml(new MeetingErrorResponseDto
                {
                    Message = "An error occurred during meeting creation.",
                    Details = ex.Message
                }));
            }
        }

        #endregion

        #region End Meeting

        [HttpPost("end")]
        public async Task<IActionResult> EndMeeting(string meetingID, string password)
        {
            try
            {
                var result = await client.EndMeetingAsync(new EndMeetingRequest
                {
                    meetingID = meetingID,
                    password = password
                });

                if (result.returncode == Returncode.FAILED)
                {
                    return Content(XmlHelper.ToXml(new MeetingErrorResponseDto
                    {
                        Message = "Failed to end meeting.",
                        Details = result.message
                    }), "application/xml");
                }

                return Content(XmlHelper.ToXml(new MeetingEndDto
                {
                    MeetingID = meetingID,
                    Message = "Meeting ended successfully."
                }), "application/xml");
            }
            catch (Exception ex)
            {
                return StatusCode(500, XmlHelper.ToXml(new MeetingErrorResponseDto
                {
                    Message = "An error occurred while ending the meeting.",
                    Details = ex.Message
                }));
            }
        }

        #endregion

        #region Join Meeting

        [HttpGet("join")]
        public async Task<IActionResult> JoinMeeting(string meetingID, string fullName, string password, bool redirect = true, string userdata = "")
        {
            try
            {
                var joinRequest = new JoinMeetingRequest
                {
                    fullName = fullName,
                    meetingID = meetingID,
                    password = password,
                    redirect = redirect,  // ToString() gerekmez, doğrudan atanabilir
                    userdata = userdata
                };



                var joinUrl = await client.GetJoinMeetingUrl(joinRequest);

                return Content(XmlHelper.ToXml(new JoinMeetingResponse
                {
                    JoinUrl = joinUrl,
                    Redirect = redirect,
                    Message = "Join URL generated successfully."
                }), "application/xml");
            }
            catch (Exception ex)
            {
                return StatusCode(500, XmlHelper.ToXml(new MeetingErrorResponseDto
                {
                    Message = "An error occurred while generating join URL.",
                    Details = ex.Message
                }));
            }
        }


        #endregion

        #region Is Meeting Running

        [HttpGet("isMeetingRunning")]
        public async Task<IActionResult> IsMeetingRunning(string meetingID)
        {
            if (string.IsNullOrEmpty(meetingID))
            {
                return Content(XmlHelper.ToXml(new MeetingErrorResponseDto
                {
                    Message = "Meeting ID cannot be null or empty.",
                    Details = "Invalid input."
                }), "application/xml");
            }

            try
            {
                var response = await client.IsMeetingRunningAsync(new IsMeetingRunningRequest
                {
                    meetingID = meetingID
                });

                if (response == null || response.returncode != Returncode.SUCCESS)
                {
                    return Content(XmlHelper.ToXml(new MeetingErrorResponseDto
                    {
                        Message = "Failed to check meeting status.",
                        Details = response?.message ?? "No details available."
                    }), "application/xml");
                }

                return Content(XmlHelper.ToXml(new MeetingStatusDto
                {
                    MeetingID = meetingID,
                    IsRunning = response.running ?? false,
                    Message = response.running == true ? "Meeting is running." : "Meeting is not running."
                }), "application/xml");
            }
            catch (Exception ex)
            {
                return StatusCode(500, XmlHelper.ToXml(new MeetingErrorResponseDto
                {
                    Message = "An error occurred while checking meeting status.",
                    Details = ex.ToString()
                }));
            }
        }



        #endregion

        #region Get Meeting Info
        [HttpGet("getMeetingInfo")]
        public async Task<IActionResult> GetMeetingInfo(string meetingID, string password)
        {
            try
            {
                var result = await client.GetMeetingInfoAsync(new GetMeetingInfoRequest
                {
                    meetingID = meetingID,
                    password = password
                });

                if (result == null || result.returncode != Returncode.SUCCESS)
                {
                    return Content(XmlHelper.ToXml(new MeetingErrorResponseDto
                    {
                        Message = "Failed to retrieve meeting info.",
                        Details = $"{result?.message} (Key: {result?.messageKey})"
                    }), "application/xml");
                }

                var dto = new MeetingInfoDto
                {
                    MeetingName = result.meetingName,
                    MeetingID = result.meetingID,
                    InternalMeetingID = result.internalMeetingID,
                    ModeratorPW = result.moderatorPW,
                    AttendeePW = result.attendeePW,
                    Duration = result.duration,
                    MaxUsers = result.maxUsers,
                    Running = result.running,
                    FreeJoin = result.freeJoin,
                    Sequence = result.sequence,

                    ParticipantCount = result.participantCount,
                    ModeratorCount = result.moderatorCount,
                    ListenerCount = result.listenerCount,
                    VoiceParticipantCount = result.voiceParticipantCount,
                    VideoCount = result.videoCount,

                    Recording = result.recording,
                    CreateDate = result.createDate,
                    CreateTime = result.createTime,                    
                    VoiceBridge = result.voiceBridge,
                    DialNumber = result.dialNumber,

                    HasStarted = result.HasStarted,
                    StartTime = result.startTime,
                    EndTime = result.endTime,
                    HasBeenLocked  = result.HasBeenLocked,
                    HasUserJoined = result.hasUserJoined,
                    HasBeenForciblyEnded = result.hasBeenForciblyEnded,



                    Attendees = result.attendeeList?.Select(a => new AttendeeDto
                    {
                        UserID = a.userID,
                        FullName = a.fullName,
                        Role = a.role,
                        IsPresenter = a.isPresenter,
                        IsListeningOnly = a.isListeningOnly,
                        HasJoinedVoice = a.hasJoinedVoice,
                        HasVideo = a.hasVideo
                    }).ToList() ?? new List<AttendeeDto>(), // Null kontrolü
                    Message = "Meeting info retrieved successfully."
                };

                return Content(XmlHelper.ToXml(dto), "application/xml");
            }
            catch (Exception ex)
            {
                return StatusCode(500, XmlHelper.ToXml(new MeetingErrorResponseDto
                {
                    Message = "An error occurred while retrieving meeting info.",
                    Details = ex.ToString()
                }));
            }
        }

        #endregion

        #region Get All Meetings
        [HttpGet("getMeetings")]
        public async Task<IActionResult> GetAllMeetings()
        {
            try
            {
                var meetingsResponse = await client.GetMeetingsAsync();

                if (meetingsResponse == null ||
                    meetingsResponse.returncode == Returncode.FAILED ||
                    meetingsResponse.meetings == null ||
                    meetingsResponse.meetings.meetingList == null)
                {
                    return Content(XmlHelper.ToXml(new MeetingErrorResponseDto
                    {
                        Message = "No meetings found.",
                        Details = "The meetings list is empty or an error occurred while fetching the data."
                    }), "application/xml");
                }

                var response = new AllMeetingsDto
                {
                    Message = "Meetings retrieved successfully.",
                    Meetings = meetingsResponse.meetings.meetingList.Select(m => new MeetingInfoDto
                    {
                        MeetingName = m.meetingName,
                        MeetingID = m.meetingID,
                        InternalMeetingID = m.internalMeetingID,
                        
                        CreateTime = m.createTime,
                        CreateDate = m.createDate,
                        VoiceBridge = m.voiceBridge,
                        DialNumber = m.dialNumber,
                        AttendeePW = m.attendeePW,
                        ModeratorPW = m.moderatorPW,
                        Running = m.running,
                        Duration = m.duration,
                        HasUserJoined = m.hasUserJoined,
                        Recording = m.recording,
                        HasBeenForciblyEnded = m.hasBeenForciblyEnded,
                        StartTime = m.startTime,
                        EndTime = m.endTime,
                        ParticipantCount = m.participantCount,
                        ListenerCount = m.listenerCount,
                        VoiceParticipantCount = m.voiceParticipantCount,
                        VideoCount = m.videoCount,
                        MaxUsers = m.maxUsers,
                        ModeratorCount = m.moderatorCount,
                        IsBreakout = m.isBreakout,
                        BreakoutRooms = m.breakoutRooms ?? new List<string>(),
                        ParentMeetingID = m.parentMeetingID,
                        Sequence = m.sequence,
                        FreeJoin = m.freeJoin
                    }).ToList()
                };

                return Content(XmlHelper.ToXml(response), "application/xml");
            }
            catch (Exception ex)
            {
                return StatusCode(500, XmlHelper.ToXml(new MeetingErrorResponseDto
                {
                    Message = "An error occurred while retrieving meetings.",
                    Details = ex.ToString()
                }));
            }
        }
        #endregion

        
    }
}
