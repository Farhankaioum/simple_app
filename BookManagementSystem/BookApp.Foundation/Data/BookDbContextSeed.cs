using BookApp.Foundation.Contexts;
using BookApp.Foundation.Helpers;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.Foundation.Data
{
    public class BookDbContextSeed
    {
        public static async Task SeedEssentialsAsync(BookDbContext context)
        {
            //Seed Permission
            if (context.Permissions.All(p => p.Name != PermissionConstant.get)) 
            {
                context.Permissions.Add(new Entities.Permission { Name = PermissionConstant.get, IsPermitted = true});
                await context.SaveChangesAsync();
            }
            if (context.Permissions.All(p => p.Name != PermissionConstant.add))
            {
                context.Permissions.Add(new Entities.Permission { Name = PermissionConstant.add, IsPermitted = true });
                await context.SaveChangesAsync();
            }
            if (context.Permissions.All(p => p.Name != PermissionConstant.edit))
            {
                context.Permissions.Add(new Entities.Permission { Name = PermissionConstant.edit, IsPermitted = true });
                await context.SaveChangesAsync();
            }
            if (context.Permissions.All(p => p.Name != PermissionConstant.delete))
            {
                context.Permissions.Add(new Entities.Permission { Name = PermissionConstant.delete, IsPermitted = true });
                await context.SaveChangesAsync();
            }

        }
    }
}
