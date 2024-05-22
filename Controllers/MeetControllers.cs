using Microsoft.AspNetCore.Mvc;
using MeetWebApiPro.ApiReposes;
using MeetWebApi.DataModel;
using Microsoft.Identity.Client;
using System.Linq;
using MeetWebApi.Util;
using MeetWebApi.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace MeetWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetControllers
    {
        [HttpPost("AddMeet")]
        [Produces("application/json")]
        public MsgCode AddMeet(DataModel.Meet meet)
        {
            try
            {
                MeetUtil meetUtil = new MeetUtil();
                List<DataModel.Meet> meets = new List<DataModel.Meet>();
                meets.Add(meet);
                List<DataModel.Meet> ConflictingMeets = meetUtil.FilterConflictingMeetings(meets);
                List<DataModel.Meet> ConflictingMeet = meets.Except(ConflictingMeets).ToList();
                WebApiContext con = new WebApiContext();
                if(ConflictingMeet.Count > 0)
                {
                    con.Meets.Add(ConflictingMeet[0]);
                    con.SaveChanges();
                    return new MsgCode(200, "成功！", ConflictingMeet[0]);
                }
                else
                {
                    return new MsgCode(401, "添加失败！", "会议冲突");
                }
                
            }
            catch (Exception ex)
            {
                return new MsgCode(401, "添加失败！", ex);
            }
           
        }
        [HttpPost("AddMeets")]
        [Produces("application/json")]
        public MsgCode AddMeets(List<DataModel.Meet> meet)
        {
            try
            {
                MeetUtil meetUtil = new MeetUtil();
                List<DataModel.Meet> ConflictingMeets = meetUtil.FilterConflictingMeetings(meet);
                List<DataModel.Meet> ConflictingMeet = meet.Except(ConflictingMeets).ToList();
                WebApiContext con = new WebApiContext();
                con.Meets.AddRangeAsync(ConflictingMeet);
                con.SaveChanges();
                return new MsgCode(200, "成功！", ConflictingMeet);
            }
            catch (Exception ex)
            {
                return new MsgCode(401, "添加失败！", ex);
            }

        }
        [HttpPost("DeleteMeet")]
        [Produces("application/json")]
        public MsgCode DeleteMeet(DataModel.Meet meet)
        {
            WebApiContext con = new WebApiContext();
            con.Meets.RemoveRange(meet);
            MeetingUserRelationship deleteMeetingUserRelationships = con.MeetingUserRelationships.Where(x => x.Mid == meet.MeetId).FirstOrDefault();
            con.MeetingUserRelationships.Remove(deleteMeetingUserRelationships);
            con.SaveChanges();
            return new MsgCode(200,"pact",0);
        }
        [HttpGet("FindAll")]
        public MsgCode GetMeetAll() {
            WebApiContext con = new WebApiContext();
            return new MsgCode(200,"OK", con.Meets.ToList());
        }
        [HttpGet("GetMeetingsForMonth")]
        public MsgCode GetMeetingsForMonth(DateTime currentMonth,string Address, string MeetingRoom)
        {
            WebApiContext con = new WebApiContext();
            List<DataModel.Meet> getMeetingsForMonths = con.Meets.Where(x => x.MeetStartTime.Year == currentMonth.Year
                                        && x.MeetStartTime.Month == currentMonth.Month &&
                                        x.Address == Address && x.MeetingRoom == MeetingRoom).ToList();
            return new MsgCode(200, "OK", getMeetingsForMonths);
        }

        [HttpGet("GetgMeetAppointmentList")]
        public MsgCode GetgMeetAppointmentList(string Address, int Aid)
        {
            WebApiContext con = new WebApiContext();
            List<MeetingUserRelationship> getMidList = con.MeetingUserRelationships.Where(x => x.Aid == Aid).ToList();
            List<DataModel.Meet> getMeetingsForMonths = new List<DataModel.Meet>();
            foreach(MeetingUserRelationship meetingUserRelationship in getMidList)
            {
                DataModel.Meet meet = con.Meets.Where(x => x.MeetId == meetingUserRelationship.Mid).FirstOrDefault();
                getMeetingsForMonths.Add(meet);
            }
            return new MsgCode(200, "OK", getMeetingsForMonths);
        }
        [HttpPut("UpdateMeets")]
        [Produces("application/json")]
        public MsgCode UpdateMeets(List<DataModel.Meet> meets)
        {
            try
            {
                
                    WebApiContext con = new WebApiContext();
                    int Aid = 0;
                    foreach (var meet in meets)
                    {
                        MeetingUserRelationship UserAndAid = con.MeetingUserRelationships.Where(m => meet.MeetId == m.Mid).FirstOrDefault();
                        Aid = UserAndAid.Aid;
                        con.MeetingUserRelationships.Remove(UserAndAid);
                    }
                    con.Meets.RemoveRange(meets);
                    con.SaveChanges();
                    foreach (var meet in meets)
                    {
                        meet.MeetId = 0;
                    }
                    con.Meets.AddRange(meets);
                    con.SaveChanges();
                    foreach (var meet in meets)
                    {
                        con.MeetingUserRelationships.Add(new MeetingUserRelationship(0, Aid, meet.MeetId));
                    }
                    con.SaveChanges();
                    return new MsgCode(200, "成功！", con.Meets.ToList());
               
            }
            catch (Exception ex)
            {
                return new MsgCode(401, "添加失败！", ex);
            }

        }
    }
}
