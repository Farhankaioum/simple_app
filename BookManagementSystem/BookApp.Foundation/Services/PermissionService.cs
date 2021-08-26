using BookApp.Foundation.Entities;
using BookApp.Foundation.Exceptions;
using BookApp.Foundation.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Foundation.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IBookUnitOfWork _bookUnitOfWork;

        public PermissionService(IBookUnitOfWork bookUnitOfWork)
        {
            _bookUnitOfWork = bookUnitOfWork;
        }

        public IList<Permission> GetAll()
        {
            return _bookUnitOfWork.PermissionRepository.GetAll();
        }

        public Permission GetById(int id)
        {
            var existingPermission = _bookUnitOfWork.PermissionRepository.GetById(id);
            if (existingPermission == null)
                throw new NotFoundException("Permission not found!");

            return existingPermission;
        }

        public Permission GetByName(string name)
        {
            var existingPermission = _bookUnitOfWork.PermissionRepository.Get(p => p.Name == name)
                .FirstOrDefault();
            if (existingPermission == null)
                throw new NotFoundException("Permission not found!");

            return existingPermission;
        }

        public void UpdatePermission(int id, bool value)
        {
            var existingPermission = _bookUnitOfWork.PermissionRepository.GetById(id);
            if (existingPermission == null)
                throw new NotFoundException("Permission not found!");

            existingPermission.IsPermitted = value;
            _bookUnitOfWork.Save();
        }
    }
}
