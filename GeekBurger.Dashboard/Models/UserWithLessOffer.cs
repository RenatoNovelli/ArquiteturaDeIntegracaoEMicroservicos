using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GeekBurger.Dashboard.Model
{
    public class UserWithLessOffer
    {
        [Key]      
        public Guid UserId { get; set; }
        public string UserRestrictions { get; set; }
    }
}
