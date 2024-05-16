﻿using System;
using System.Collections.Generic;
using System.Text;
using static SPLUS.Customer.Domain.Enum.DomainEnum;

namespace SPLUS.Customer.Domain.ViewModels
{
    public class ResGetResidentByNameAndPhoneInApartment
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public DateTime? Birthday { get; set; }
        public string? CardId { get; set; }
        public DateTime? DateId { get; set; }
        public ResidentRequestIdentifyType? TypeCardId { get; set; }
        public string AddressId { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Sex { get; set; }
        public int? RelationshipId { get; set; }
        public string RelationshipName { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
