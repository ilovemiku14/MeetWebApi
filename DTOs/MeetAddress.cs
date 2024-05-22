using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetWebApiPro.DTOs;

public class MeetAddress
{
    private int MeetAddressId;
    private string MeetAddressName;
    private DateTime createTime;
    private DateTime updateTime;

    public int MeetAddressId1
    {
        get => MeetAddressId;
        set => MeetAddressId = value;
    }

    public string MeetAddressName1
    {
        get => MeetAddressName;
        set => MeetAddressName = value ?? throw new ArgumentNullException(nameof(value));
    }

    public DateTime CreateTime
    {
        get => createTime;
        set => createTime = value;
    }

    public DateTime UpdataTime
    {
        get => updateTime;
        set => updateTime = value;
    }

    public MeetAddress()
    {
    }

    public MeetAddress(int meetAddressId, string meetAddressName, DateTime createTime, DateTime updataTime)
    {
        MeetAddressId = meetAddressId;
        MeetAddressName = meetAddressName;
        this.createTime = createTime;
        this.updateTime = updataTime;
    }
}