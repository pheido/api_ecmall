using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using api_ecmall.Domain.Entities;
using System.Data.Entity;
using System.Collections.Generic;

namespace api_ecmall.WebUI.Models
{
    // 可以通过向 ApplicationUser 类添加更多属性来为用户添加个人资料数据，若要了解详细信息，请访问 http://go.microsoft.com/fwlink/?LinkID=317594。
    /// <summary>
    /// 
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="authenticationType"></param>
        /// <returns></returns>
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // 请注意，authenticationType 必须与 CookieAuthenticationOptions.AuthenticationType 中定义的相应项匹配
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // 在此处添加自定义用户声明
            return userIdentity;
        }
        /// <summary>
        /// 
        /// </summary>
        public virtual List<AspNetClient> AspNetClients { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        /// <summary>
        /// 
        /// </summary>
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<AspNetClient> AspNetClients { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}