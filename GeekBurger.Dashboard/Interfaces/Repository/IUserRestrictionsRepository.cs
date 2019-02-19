using GeekBurger.Dashboard.Contract;
using GeekBurger.Dashboard.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeekBurger.Dashboard.Interfaces.Repository
{
    public interface IUserRestrictionsRepository
    {
        Task<List<UserRestrictions>> GetAll();        
        Task Add(UserRestrictions userRestrictions);
    }
}
