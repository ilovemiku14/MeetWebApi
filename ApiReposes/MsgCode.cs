namespace MeetWebApiPro.ApiReposes;

public class MsgCode
{
    public MsgCode(int resultCode, string msg, object resultData)
    {
        ResultCode = resultCode;
        Msg = msg;
        ResultData = resultData;
    }

    public MsgCode()
    {
    }

    public int ResultCode { get; set; }
    public string Msg { get; set; }
    public object ResultData { get; set; }
  
}