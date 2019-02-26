using GeekBurger.Dashboard.Contract;
using GeekBurger.Dashboard.Models.Enums;
using GeekBurger.Orders.Contract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeekBurger.Dashboard.Interfaces.Service
{
    public interface IUserRestrictionsService
    {
        Task<IEnumerable<UserRestrictions>> ConsolidateUserRestrictions();
        Task SaveUserRestriction(UserRestrictions order);
    }
}
