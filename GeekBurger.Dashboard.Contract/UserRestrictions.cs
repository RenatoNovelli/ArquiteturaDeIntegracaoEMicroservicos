using System;

namespace GeekBurger.Dashboard.Contract
{
    public class UserRestrictions
    {
        public Guid UserId { get; set; }
        public string Restrictions { get; set; }
    }
}
