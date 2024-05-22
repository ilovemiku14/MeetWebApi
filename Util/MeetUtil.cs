using MeetWebApi.DataModel;

namespace MeetWebApi.Util
{
    public class MeetUtil
    {
        public List<Meet> FilterConflictingMeetings(List<Meet> meets)
        {
            WebApiContext con = new WebApiContext();
            List<Meet> result = new List<Meet>();
            foreach (var meet in meets)
            {
                DateTime MeetDay = (DateTime)meet.MeetStartTime;
                List<Meet> selectMeets = con.Meets.Where(x => x.MeetStartTime.Year == MeetDay.Year
                                        && x.MeetStartTime.Month == MeetDay.Month
                                        && x.MeetStartTime.Day == MeetDay.Day &&
                                        x.Address == meet.Address && x.MeetingRoom == meet.MeetingRoom).ToList();
                Meet conflictMeet =  CheckMeetingConflict(selectMeets, meet);
                result.Add(conflictMeet);
            }
            return result;
        }
        public Meet CheckMeetingConflict(List<Meet> meetings, Meet newMeeting)
        {
            foreach (var meeting in meetings)
            {
                if (newMeeting.MeetStartTime < meeting.MeetEndTime && newMeeting.MeetEndTime > meeting.MeetStartTime)
                {
                    // 返回冲突的会议对象
                    return newMeeting;
                }
            }

            // 如果没有冲突，返回null
            return null;
        }
    }
}
