using System.Runtime.Serialization;

namespace FundacjaBT.EventTool
{
    [DataContract]
    public class TicketBadge
    {
        [DataMember(Name = "ticket")]
        public int Number { get; set; }

        [DataMember(Name = "nickname")]
        public string Nickname { get; set; }

        [DataMember(Name = "city")]
        public string City { get; set; }

        [DataMember(Name = "file")]
        public string File { get; set; }
    }
}
