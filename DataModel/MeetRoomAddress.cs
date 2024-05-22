using System;
using System.Collections.Generic;

namespace MeetWebApi.DataModel;

public partial class MeetRoomAddress
{
    public int RoomId { get; set; }

    public string? RoomAddress { get; set; }

    public DateTime? CreateTime { get; set; }

    public DateTime? UpdateTime { get; set; }
}
