using System;

namespace Lingual.Tests.Domain
{
    public class Account
    {
        public long Id { get; set; }
        public decimal TotalBalance { get; set; }
        public AccountStatuses Status { get; set; }
        public DateTime LastActivityDate { get; set; }
    }
}