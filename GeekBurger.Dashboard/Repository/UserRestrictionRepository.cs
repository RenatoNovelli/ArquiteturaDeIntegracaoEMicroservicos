using GeekBurger.Dashboard.Contract;
using GeekBurger.Dashboard.Interfaces.Repository;
using GeekBurger.Dashboard.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekBurger.Dashboard.Repository
{
    public class UserRestrictionRepository : IUserRestrictionsRepository
    {
        private DashboardContext _context;

        public UserRestrictionRepository(DashboardContext context)
        {
            _context = context;
        }

        public async Task<List<UserRestrictions>> GetAll()
        {
            return _context.UserRestrictions?
                .ToList();
        }

        public async Task Add(UserRestrictions userRestriction)
        {
            _context.UserRestrictions.Add(userRestriction);
        }      
    }
}
