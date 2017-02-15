using HoneyComb.IProvider.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HoneyComb.BusinessObjects;
using HoneyComb.IDataAccess;

namespace HoneyComb.Provider.Users
{
    public class UserProvider : IUserProvider
    {
        private IUnitOfWork _unitOfWork;

        public UserProvider(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public ResultObj<MCR_PERSONS> AddUser(MCR_PERSONS User)
        {
           return _unitOfWork.UserManager.AddUser(User);
        }

        public ResultObj<MCR_PERSONS> Login(MCR_PERSONS User)
        {
            return _unitOfWork.UserManager.Login(User);
        }
    }
}
