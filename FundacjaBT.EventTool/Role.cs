using System.Runtime.Serialization;

namespace FundacjaBT.EventTool
{
    [DataContract]
    public class Role
    {
        [DataMember(Name = "name")]
        public string Name;

        [DataMember(Name = "color")]
        public string HtmlColor;

        [DataMember(Name = "description")]
        public string Description;
    }
}
