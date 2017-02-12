using HoneyComb.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyComb.IDataAccess.Users
{
    public interface IUserManager
    {
        MCR_PERSONS AddUser(MCR_PERSONS User);

        MCR_PERSONS Login(MCR_PERSONS User);
    }
}
