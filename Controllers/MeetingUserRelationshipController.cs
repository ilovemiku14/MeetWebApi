using Microsoft.AspNetCore.Mvc;
using MeetWebApiPro.ApiReposes;
using MeetWebApi.DataModel;
using Microsoft.Identity.Client;
using System.Linq;
using MeetWebApi.Util;
using MeetWebApi.DTOs;


namespace MeetWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingUserRelationshipController
    {
        [HttpGet("FindOneAccountToMeet")]
        public MsgCode FindOneAccountToMeet(int aid)
        {
            WebApiContext con = new WebApiContext();
            return new MsgCode(200,"OK", con.MeetingUserRelationships.Where(x => x.Aid == aid).ToList());
        }
        [HttpPost("AddMeetingUserRelationships")]
        public MsgCode AddMeetingUserRelationships(List<MeetingUserRelationship> meetingUserRelationship)
        {
            try
            {
                WebApiContext con = new WebApiContext();
                con.AddRange(meetingUserRelationship);
                con.SaveChanges();
                return new MsgCode(200, "OK", 1);
            }
            catch (Exception ex) { 
            return new MsgCode(401,"ERROR",ex.Message);
            }
        }
        [HttpPost("AddMeetingUserRelationship")]
        public MsgCode AddMeetingUserRelationship(MeetingUserRelationship meetingUserRelationship)
        {
            try
            {
                WebApiContext con = new WebApiContext();
                con.Add(meetingUserRelationship);
                con.SaveChanges();

                return new MsgCode(200, "OK", meetingUserRelationship.Id);
            }
            catch (Exception ex)
            {
                return new MsgCode(401, "ERROR", ex.Message);
            }
        }
        [HttpGet("GetMeetingCreatorByMeetingId")]
        public MsgCode GetMeetingCreatorByMeetingId(int meetingId) {
            try
            {
                WebApiContext con = new WebApiContext();
                MeetingUserRelationship m = con.MeetingUserRelationships.Where(x => x.Mid == meetingId).FirstOrDefault();
                AccountInfo Account =  con.AccountInfos.Where(x => x.AccountId == m.Aid).FirstOrDefault();
                return new MsgCode(200, "Ok", Account);
            }
            catch (Exception ex)
            {
                return new MsgCode(401, "ERROR", ex.Message);
            }
        }
    }
}
