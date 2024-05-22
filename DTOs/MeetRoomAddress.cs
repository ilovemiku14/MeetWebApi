using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetWebApi.DTOs;

public class MeetRoomAddress
{
    private int roomId;
    private string roomAddress;
    private DateTime createTime;
    private DateTime updateTime;

    public MeetRoomAddress(int roomId, string roomAddress, DateTime createTime, DateTime updataTime)
    {
        this.roomId = roomId;
        this.roomAddress = roomAddress;
        this.createTime = createTime;
        this.updateTime = updataTime;
    }

    public MeetRoomAddress()
    {
    }

    public int RoomId
    {
        get => roomId;
        set => roomId = value;
    }

    public string RoomAddress
    {
        get => roomAddress;
        set => roomAddress = value ?? throw new ArgumentNullException(nameof(value));
    }

    public DateTime CreateTime
    {
        get => createTime;
        set => createTime = value;
    }

    public DateTime UpdateTime
    {
        get => updateTime;
        set => updateTime = value;
    }
}