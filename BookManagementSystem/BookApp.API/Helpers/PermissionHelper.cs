using BookApp.Foundation.Helpers;
using BookApp.Foundation.Services;

namespace BookApp.API.Helpers
{
    public class PermissionHelper
    {
        private readonly IPermissionService _permissionService;

        public PermissionHelper(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        public bool IsGetPermission()
        {
            var permission = _permissionService.GetByName(PermissionConstant.get);
            if (permission == null)
                return false;

            if (permission.IsPermitted)
                return true;

            return false;
        }

        public bool IsPostPermission()
        {
            var permission = _permissionService.GetByName(PermissionConstant.add);
            if (permission == null)
                return false;

            if (permission.IsPermitted)
                return true;

            return false;
        }

        public bool IsEditPermission()
        {
            var permission = _permissionService.GetByName(PermissionConstant.edit);
            if (permission == null)
                return false;

            if (permission.IsPermitted)
                return true;

            return false;
        }

        public bool IsDeletePermission()
        {
            var permission = _permissionService.GetByName(PermissionConstant.delete);
            if (permission == null)
                return false;

            if (permission.IsPermitted)
                return true;

            return false;
        }
    }
}
