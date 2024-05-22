using Microsoft.AspNetCore.Mvc;
using MeetWebApiPro.ApiReposes;
using MeetWebApi.DataModel;
using Microsoft.Identity.Client;
using System.Linq;

namespace MeetWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
     
        [HttpGet("Login")]
        public MsgCode Account(string Gmali , string password )
        {
            WebApiContext con = new WebApiContext();
            AccountInfo account = con.AccountInfos.Where(m => m.DxcGmail == Gmali && m.Password == password).FirstOrDefault();
            ////foreach (var account in accounts)
            ////{
            ////    Console.WriteLine($"ID: {account.AccountId}, Username: {account.Name}, Password: {account.Password}");
            ////}
            Console.WriteLine(account);
            if (account.Equals(false))
            {
                return new MsgCode(401, "登陆失败！", 111);
            }
            else
            {

                return new MsgCode(200, "登陆成功！", account);
            }
        }
        //}
    }
}
