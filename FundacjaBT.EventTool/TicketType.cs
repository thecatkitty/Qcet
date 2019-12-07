using System.Runtime.Serialization;

namespace FundacjaBT.EventTool
{
    [DataContract]
    class TicketType
    {
        [DataMember(Name = "id")]
        public int Id;

        [DataMember(Name = "name")]
        public string Name;

        [DataMember(Name = "description")]
        public string Description;

        [DataMember(Name = "defaultRole")]
        public Role DefaultRole;

        [DataMember(Name = "price")]
        public int Price;

        [DataMember(Name = "color")]
        public string HtmlColor;
    }
}