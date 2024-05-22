using Microsoft.AspNetCore.Mvc;
namespace MeetWebApiPro.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController
{
    [HttpGet("[action]")]
    public IActionResult SayHello()
    {
        
        return new JsonResult("Hello World");
    }

}