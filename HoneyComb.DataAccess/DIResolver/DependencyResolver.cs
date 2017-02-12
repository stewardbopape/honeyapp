using HoneyComb.BusinessObjects;
using HoneyComb.IDataAccess;
using HoneyComb.Resolver;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyComb.DataAccess.DIResolver
{
    [Export(typeof(IComponent))]
    public class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<IUnitOfWork, HoneyCombEntities>();
        }
    }
}
