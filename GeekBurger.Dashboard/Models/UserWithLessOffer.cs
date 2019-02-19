using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GeekBurger.Dashboard.Model
{
    public class UserWithLessOffer
    {
        [Key]      
        public int UsersId { get; set; }
        public List<string> UserRestrictions { get; set; }
    }
}
