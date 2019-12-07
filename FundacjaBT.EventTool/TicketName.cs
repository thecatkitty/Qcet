﻿using System.Runtime.Serialization;

namespace FundacjaBT.EventTool
{
    [DataContract]
    class TicketName
    {
        [DataMember(Name = "ticket")]
        public int Number;

        [DataMember(Name = "givenName")]
        public string GivenName;

        [DataMember(Name = "familyName")]
        public string FamilyName;
    }
}
