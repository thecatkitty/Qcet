using System.Runtime.Serialization;

namespace FundacjaBT.EventTool
{
    [DataContract]
    class TicketBadge
    {
        [DataMember(Name = "ticket")]
        public int Number;

        [DataMember(Name = "nickname")]
        public string Nickname;

        [DataMember(Name = "city")]
        public string City;

        [DataMember(Name = "file")]
        public string File;
    }
}
