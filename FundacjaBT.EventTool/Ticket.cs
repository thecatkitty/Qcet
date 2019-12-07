using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace FundacjaBT.EventTool
{
    [DataContract]
    public class Ticket
    {
        [DataMember(Name = "id")]
        public int Id;

        [DataMember(Name = "email")]
        public string EmailAddress;

        [DataMember(Name = "ticketType")]
        public TicketType Type;

        [DataMember(Name = "ticketNames")]
        public TicketName[] Names;

        [DataMember(Name = "ticketBadges")]
        public TicketBadge[] Badges;

        [DataMember(Name = "price")]
        public int Price;

        [DataMember(Name = "isValid")]
        public bool Valid;

        [DataMember(Name = "isValidated")]
        public bool Validated;

        public async Task Validate(ApiClient api)
        {
            await api.ValidateTicketAsync(this);
        }
    }
}
