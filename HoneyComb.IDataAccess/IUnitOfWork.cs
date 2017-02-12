using HoneyComb.IDataAccess.Addresses;
using HoneyComb.IDataAccess.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyComb.IDataAccess
{
    public interface IUnitOfWork
    {


        int SaveChanges();
        void BeginTransaction();
        void CommitTransaction();
        IUserManager UserManager { get; }
        IUserAddressManager UserAddressManager { get;  }
    }
}
