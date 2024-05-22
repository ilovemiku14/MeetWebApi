using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetWebApi.DTOs
{
    public class Meet
    {
        private int meetId;
        private string meetTitle;
        private DateTime meetStartTime;
        private DateTime meetEndTime;
        private string meetMessage;
        private DateTime meetCreateTime;
        private string address;
        private bool regular;
        private string meetingRoom;


    
        public Meet()
        {
        }

        public Meet(int meetId, string meetTitle, DateTime meetStartTime, DateTime meetEndTime, string meetMessage, DateTime meetCreateTime, string address, bool regular, string meetingRoom)
        {
            this.meetId = meetId;
            this.meetTitle = meetTitle;
            this.meetStartTime = meetStartTime;
            this.meetEndTime = meetEndTime;
            this.meetMessage = meetMessage;
            this.meetCreateTime = meetCreateTime;
            this.address = address;
            this.regular = regular;
            this.meetingRoom = meetingRoom;
        }
        public int MeetId
        {
            get => meetId;
            set => meetId = value;
        }

        public string MeetTitle
        {
            get => meetTitle;
            set => meetTitle = value ?? throw new ArgumentNullException(nameof(value));
        }

        public DateTime MeetStartTime
        {
            get => meetStartTime;
            set => meetStartTime = value;
        }

        public DateTime MeetEndTime
        {
            get => meetEndTime;
            set => meetEndTime = value;
        }

        public string MeetMessage
        {
            get => meetMessage;
            set => meetMessage = value ?? throw new ArgumentNullException(nameof(value));
        }

        public DateTime MeetCreateTime
        {
            get => meetCreateTime;
            set => meetCreateTime = value;
        }

        public string Address
        {
            get => address;
            set => address = value ?? throw new ArgumentNullException(nameof(value));
        }

        public bool Regular
        {
            get => regular;
            set => regular = value;
        }

        public string MeetingRoom
        {
            get => meetingRoom;
            set => meetingRoom = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}
