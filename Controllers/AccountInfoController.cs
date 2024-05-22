using MeetWebApiPro.ApiReposes;
using MeetWebApiPro.DTO;
using Microsoft.AspNetCore.Mvc;
namespace MeetWebApiPro.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class AccountInfoController:ControllerBase
{
    

    [HttpGet]
    public IActionResult reg()
    {
        MsgCode msgCode = new MsgCode();
        try
        {
           // var dbAccount = dbContext.AccountInfos.Where(t=>t.AccountId == accountInfo.AccountId).FirstOrDefault();
            msgCode.Msg = "test";
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return new JsonResult(msgCode);
    }
}