using HoneyComb.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyComb.IProvider.Users
{
    public interface IUserProvider
    {
        ResultObj<MCR_PERSONS> AddUser(MCR_PERSONS User);
        ResultObj<MCR_PERSONS> Login(MCR_PERSONS User);
    }
}
