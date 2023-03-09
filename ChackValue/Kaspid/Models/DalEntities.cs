using Kaspid.Models.Utility;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace Kaspid.Models
{
    public class UserInfo : IdentityUser
    {
       #region GenerateUserIdentity Method

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<UserInfo> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        #endregion GenerateUserIdentity Method
    }

    public partial class DalEntities : IdentityDbContext<UserInfo>
    {
        #region Ctor

        public DalEntities() : base("name=DalEntities")
        {
        }

        #endregion Ctor

        #region CreateDb Method

        public static DalEntities Create()
        {
            return new DalEntities();
        }

        #endregion CreateDb Method

        #region Properties Dbset

        public virtual DbSet<RangeValue> RangeValues { get; set; }
       
        #endregion Properties Dbset

  
    }
}