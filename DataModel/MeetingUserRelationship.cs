using System;
using System.Collections.Generic;

namespace MeetWebApi.DataModel;

public partial class MeetingUserRelationship
{
    public MeetingUserRelationship(int id, int aid, int mid)
    {
        Id = id;
        Aid = aid;
        Mid = mid;
    }

    public int Id { get; set; }

    public int Aid { get; set; }

    public int Mid { get; set; }
}
