using System;
using System.Collections.Generic;
using System.Text;

namespace AuthorizationSystem.Domain.Entities
{
    public class Token
    {
        public string Value;
        public DateTime ExpirationDate;
    }
}
