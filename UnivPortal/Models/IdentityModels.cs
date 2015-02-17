using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace UnivPortal.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
   
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
<<<<<<< HEAD

        public System.Data.Entity.DbSet<UnivPortal.Models.ApplicationUser> ApplicationUsers { get; set; }
    } 
    /*
    /// <summary>
    //Application 1
    /// </summary>
    /*
    public class ApplicationUser1 : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser1> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
=======
>>>>>>> parent of a9559fb... Views added
    }
    public class Application1DbContext : IdentityDbContext<ApplicationUser1>
    {
        public Application1DbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static Application1DbContext Create()
        {
            return new Application1DbContext();
        }

        public System.Data.Entity.DbSet<UnivPortal.Models.ApplicationUser1> ApplicationUser1s { get; set; }
    }*/
}