using HoneyComb.IDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.Composition;
using System.Text;
using System.Threading.Tasks;
using HoneyComb.IDataAccess.Addresses;
using HoneyComb.IDataAccess.Users;
using System.Data.Entity;
using System.Data.Entity.Validation;
using HoneyComb.DataAccess.Addresses;
using HoneyComb.DataAccess.Users;

namespace HoneyComb.BusinessObjects
{
    public partial class HoneyCombEntities : IUnitOfWork
    {
        private IUserManager _userManager;
        private IUserAddressManager _userAddressManager;
        private DbContextTransaction _dbContextTransaction;
        public IUserAddressManager UserAddressManager
        {
            get
            {
                return this._userAddressManager ?? (this._userAddressManager = new UserAddressManager(this));
            }            
        }

        public IUserManager UserManager
        {
            get
            {
                return this._userManager ?? (this._userManager = new UserManager(this));
            }            
        }

        public void BeginTransaction()
        {
            if (_dbContextTransaction == null)
            {

                 this._dbContextTransaction   = this.Database.BeginTransaction();
            }
        }

        public void CommitTransaction()
        {

            try
            {
                _dbContextTransaction.Commit();
            }
            catch (DbEntityValidationException ex)
            {
                _dbContextTransaction.Rollback();
                var exceptionMessage = ExceptionHaddler(ex);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var exceptionMessage = ExceptionHaddler(ex);
                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }

        private string ExceptionHaddler(DbEntityValidationException ex)
        {
            // Retrieve the error messages as a list of strings.
            var errorMessages = ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage);
            // Join the list to a single string.
            var fullErrorMessage = string.Join("; ", errorMessages);
            // Combine the original exception message with the new one.
            return string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);
        }
    }
}