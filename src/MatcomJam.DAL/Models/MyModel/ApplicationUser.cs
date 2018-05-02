using System;
using System.Collections.Generic;
using CodeFirstDatabase;
using DAL.Models.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace MatcomJamDAL.Models.MyModel
{
    public class ApplicationUser : IdentityUser, IAuditableEntity
    {
        public virtual string FriendlyName
        {
            get
            {
                string friendlyName = string.IsNullOrWhiteSpace(FullName) ? UserName : FullName;

                if (!string.IsNullOrWhiteSpace(JobTitle))
                    friendlyName = $"{JobTitle} {friendlyName}";

                return friendlyName;
            }
        }


        public string JobTitle { get; set; }
        public string FullName { get; set; }
        public string Configuration { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsLockedOut => this.LockoutEnabled && this.LockoutEnd >= DateTimeOffset.UtcNow;

        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }



        /// <summary>
        /// Navigation property for the roles this user belongs to.
        /// </summary>
        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        /// <summary>
        /// Navigation property for the claims this user possesses.
        /// </summary>
        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        /// <summary>
        /// Demo Navigation property for orders this user has processed
        /// </summary>
        //public ICollection<Order> Orders { get; set; }


        public string Name { get; set; }
        //public string Email { get; set; }

        //public int GroupId { get; set; }
        //public Group Group { get; set; }

        //public int InstitutionId { get; set; }
        //public Institution Institution { get; set; }

        public ICollection<Blog> Blog { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<UserTeam> UserTeams { get; set; }

        // Ready!!!
        // TODO Check this entity
    }
}
