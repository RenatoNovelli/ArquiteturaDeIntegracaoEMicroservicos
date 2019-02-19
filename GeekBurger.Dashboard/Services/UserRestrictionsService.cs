using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeekBurger.Dashboard.Contract;
using GeekBurger.Dashboard.Interfaces.Repository;
using GeekBurger.Dashboard.Model;
using GeekBurger.Dashboard.Repository;
using Microsoft.Azure.ServiceBus;

namespace GeekBurger.Dashboard.Service
{
    public class UserRestrictionsService
    {
        private readonly IUserRestrictionsRepository _userRestrictionRepository;
        public UserRestrictionsService(IUserRestrictionsRepository userRestrictionRepository)
        {
            _userRestrictionRepository = userRestrictionRepository;
        }

        public async Task SaveUserRestriction(UserRestrictions user)
        {
            await _userRestrictionRepository.Add(user);
        }

        private static IEnumerable<UserRestrictions> ConsolidateUserRestrictions(List<UserRestrictions> userRestrictions)
        {
            return userRestrictions
                .GroupBy(g => g.Restrictions)
                .Select(g => new UserRestrictions()
                {
                    Restrictions = g.Key,
                    Users = g.Count()
                })
                .OrderByDescending(g => g.Users);
        }
    }
}
