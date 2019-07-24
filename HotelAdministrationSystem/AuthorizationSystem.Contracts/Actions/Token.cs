using System;

namespace AuthorizationSystem.Domain.Entities
{
    public class Token
    {
        public string Value;
        public DateTime ExpirationDate;
    }
}
