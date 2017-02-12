using HoneyComb.IDataAccess.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HoneyComb.BusinessObjects;

namespace HoneyComb.DataAccess.Addresses
{
    public class UserAddressManager : IUserAddressManager
    {
        private HoneyCombEntities honeyCombEntities;

        public UserAddressManager(HoneyCombEntities honeyCombEntities)
        {
            this.honeyCombEntities = honeyCombEntities;
        }
    }
}
