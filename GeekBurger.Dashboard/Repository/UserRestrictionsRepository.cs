using GeekBurger.Dashboard.Contract;
using GeekBurger.Dashboard.Interfaces.Repository;
using GeekBurger.Dashboard.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekBurger.Dashboard.Repository
{
    public class UserRestrictionsRepository : IUserRestrictionsRepository
    {
        private DashboardContext _context;

        public UserRestrictionsRepository(DashboardContext context)
        {
            _context = context;
        }

        public async Task<List<UserWithLessOffer>> GetAll()
        {
            return _context.UserWithLessOffer?
                .ToList();
        }

        public async Task Add(UserWithLessOffer userWithLessOffer)
        {
            _context.UserWithLessOffer.Add(userWithLessOffer);
        }
    }
}
