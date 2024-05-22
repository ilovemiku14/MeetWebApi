using System;
using System.Collections.Generic;

namespace MeetWebApi.DataModel;

public partial class Meet
{
    public int MeetId { get; set; }

    public string? MeetTitle { get; set; }

    public DateTime MeetStartTime { get; set; }

    public DateTime MeetEndTime { get; set; }

    public string? MeetMessage { get; set; }

    public DateTime? MeetCreateTime { get; set; }

    public string? Address { get; set; }

    public bool? Regular { get; set; }

    public string? MeetingRoom { get; set; }
}
