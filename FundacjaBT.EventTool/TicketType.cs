using System.Runtime.Serialization;

namespace FundacjaBT.EventTool
{
    [DataContract]
    public class TicketType
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "defaultRole")]
        public Role DefaultRole { get; set; }

        [DataMember(Name = "price")]
        public int Price { get; set; }

        [DataMember(Name = "color")]
        public string HtmlColor { get; set; }
    }
}