using System.Runtime.Serialization;

namespace FundacjaBT.EventTool
{
    [DataContract]
    class Event
    {
        [DataMember(Name = "id")]
        public int Id;

        [DataMember(Name = "name")]
        public string Name;

        [DataMember(Name = "description")]
        public string Description;

        [DataMember(Name = "hasNames")]
        public bool HasNames = false;

        [DataMember(Name = "hasBadge")]
        public bool HasBadge = false;

        [DataMember(Name = "hasTalks")]
        public bool HasTalks = false;

        [DataMember(Name = "hasCosplay")]
        public bool HasCosplay = false;

        [DataMember(Name = "hasVolunteers")]
        public bool HasVolunteers = false;

        [DataMember(Name = "codeLength")]
        public int CodeLength;

        [DataMember(Name = "hasAddons")]
        public bool HasAddons = false;

        [DataMember(Name = "hasMerchant")]
        public bool HasMerchant = false;

        [DataMember(Name = "ticketTypes")]
        public TicketType[] TicketTypes;

        [DataMember(Name = "slug")]
        public string ShortName;

        [DataMember(Name = "account")]
        public string BankAccount;
    }
}
