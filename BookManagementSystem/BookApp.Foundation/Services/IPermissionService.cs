using BookApp.Foundation.Entities;
using System.Collections.Generic;

namespace BookApp.Foundation.Services
{
    public interface IPermissionService
    {
        public IList<Permission> GetAll();
        public Permission GetById(int id);
        public Permission GetByName(string name);
        public void UpdatePermission(int id, bool value);
    }
}
