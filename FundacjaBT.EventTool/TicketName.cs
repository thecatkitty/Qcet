using System.Runtime.Serialization;

namespace FundacjaBT.EventTool
{
    [DataContract]
    public class TicketName
    {
        [DataMember(Name = "ticket")]
        public int Number { get; set; }

        [DataMember(Name = "givenName")]
        public string GivenName { get; set; }

        [DataMember(Name = "familyName")]
        public string FamilyName { get; set; }

        [IgnoreDataMember]
        public string FullName => $"{GivenName} {FamilyName}";
    }
}
