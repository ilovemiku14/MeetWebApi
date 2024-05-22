using System;
using System.Collections.Generic;

namespace MeetWebApi.DataModel;

public partial class MeetAddress
{
    public int MeetAddressId { get; set; }

    public string? MeetAddressName { get; set; }

    public DateTime? CreateTime { get; set; }

    public DateTime? UpdataTime { get; set; }
}
