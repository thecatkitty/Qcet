using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace FundacjaBT.EventTool
{
    [DataContract]
    public class Ticket
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "email")]
        public string EmailAddress { get; set; }

        [DataMember(Name = "ticketType")]
        public TicketType Type { get; set; }

        [DataMember(Name = "ticketNames")]
        public TicketName[] Names { get; set; }

        [DataMember(Name = "ticketBadges")]
        public TicketBadge[] Badges { get; set; }

        [DataMember(Name = "price")]
        public int Price { get; set; }

        [DataMember(Name = "isValid")]
        public bool IsValid { get; set; } = false;

        [DataMember(Name = "isValidated")]
        public bool IsValidated { get; set; } = false;

        [DataMember(Name = "code")]
        public string Code { get; set; }

        public async Task Validate(ApiClient api)
        {
            await api.ValidateTicketAsync(this);
        }

        [IgnoreDataMember]
        public TicketName PrincipalName => Names.FirstOrDefault();

        [IgnoreDataMember]
        public TicketBadge PrincipalBadge => Badges.FirstOrDefault();

        [IgnoreDataMember]
        public string DisplayName =>
            (PrincipalBadge.Nickname?.Length ?? 0) > 0
            ? PrincipalBadge.Nickname
            : PrincipalName?.FullName ?? "<Unknown>";

        [IgnoreDataMember]
        public string FormattedPrice =>
            string.Format("{0:C}", Convert.ToDecimal(Price) / 100);
    }
}
