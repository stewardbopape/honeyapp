using HoneyComb.BusinessObjects;
using HoneyComb.DataAccess.GenericRepository;
using HoneyComb.IDataAccess.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyComb.DataAccess.Users
{
    public class UserManager : GenericRepository<MCR_PERSONS>,IUserManager
    {
        private readonly HoneyCombEntities _context;

        public UserManager(HoneyCombEntities context) : base(context)
        {
            _context = context;
        }

        public MCR_PERSONS AddUser(MCR_PERSONS User)
        {
            return base.Insert(User);
        }
        public MCR_PERSONS Login(MCR_PERSONS User)
        {


            var user = _context.MCR_PERSONS.Where(o => o.LOGIN_USERNAME == User.LOGIN_USERNAME && o.LOGIN_PASSWORD == User.LOGIN_PASSWORD).SingleOrDefault();
            return user;

        }

    }
}
