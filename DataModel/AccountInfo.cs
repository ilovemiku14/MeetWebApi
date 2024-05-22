using System;
using System.Collections.Generic;

namespace MeetWebApi.DataModel;

public partial class AccountInfo
{
    public int AccountId { get; set; }

    public string Name { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string DxcGmail { get; set; } = null!;
}
