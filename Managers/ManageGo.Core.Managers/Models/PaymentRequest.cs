﻿using System.Collections.Generic;

namespace ManageGo.Core.Managers.Models
{
    public class PaymentRequest : DateRangeRequest
    {
        public decimal? AmountFrom { get; set; }
        public decimal? AmountTo { get; set; }
        public int? PaymentStatus { get; set; }
        public int? PropertyId { get; set; }
        public string Search { get; set; }
        public List<int> Buildings { get; set; }
        public List<int> Units { get; set; }
        public List<int> Tenants { get; set; }
    }
}
