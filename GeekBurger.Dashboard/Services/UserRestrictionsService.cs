using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeekBurger.Dashboard.Contract;
using GeekBurger.Dashboard.Interfaces.Repository;
using GeekBurger.Dashboard.Interfaces.Service;
using GeekBurger.Dashboard.Model;
using GeekBurger.Dashboard.Repository;
using GeekBurger.Orders.Contract.Messages;
using Microsoft.Azure.ServiceBus;

namespace GeekBurger.Dashboard.Service
{
    public class UserRestrictionsService : IUserRestrictionsService
    {
        private readonly IUserRestrictionsRepository _userRestrictionRepository;

        public UserRestrictionsService()
        {
        }

        public UserRestrictionsService(IUserRestrictionsRepository userRestrictionRepository)
        {
            _userRestrictionRepository = userRestrictionRepository;
        }

        public async Task SaveUserRestriction(UserRestrictions user)
        {
            var userWithLessOffer = new UserWithLessOffer();
            await _userRestrictionRepository.Add(userWithLessOffer);
        }

        private async Task<IEnumerable<UserRestrictions>> ConsolidateUserRestrictions(List<UserRestrictions> userRestrictions)
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

        Task<IEnumerable<UserRestrictions>> IUserRestrictionsService.ConsolidateUserRestrictions(List<UserRestrictions> userRestrictions)
        {
            throw new NotImplementedException();
        }
    }
}
