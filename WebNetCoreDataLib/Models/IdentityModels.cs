using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebNetCoreDataLib.Data;

namespace WebNetCoreDataLib.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        [Column("UserID")]
        public override int Id { get => base.Id; set => base.Id = value; }

        [Required]
        [StringLength(50)]
        public string UserGUID { get; set; }

        [Required]
        [Column("LoginEmail")]
        [StringLength(256)]
        public override string Email { get => base.Email; set => base.Email = value; }



        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(50)]
        public string LoginName { get; set; }

        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        public int GenderID { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(256)]
        public string PhotoURL { get; set; }





        [Required]
        [Column("Phone")] // Mapping to EonExperience Phone Column
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(20)]
        public override string PhoneNumber { get => base.PhoneNumber; set => base.PhoneNumber = value; }




        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(50)]
        public string Country { get; set; }

        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(50)]
        public string Company { get; set; }

        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(50)]
        public string Department { get; set; }

        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(100)]
        public string BusinessNature { get; set; }

        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(400)]
        public string BusinessInfo { get; set; }

        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(256)]
        public string SocialNetwork1 { get; set; }

        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(256)]
        public string SocialNetwork2 { get; set; }

        [Required]
        public int AccountStateID { get; set; } //required in EON

        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(200)]
        public string UserIntroduction { get; set; }

        [Required]
        public bool IsPaypalSeller { get; set; }

        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(256)]
        public string PaypalEmail { get; set; }

        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(50)]
        public string PaypalFirstName { get; set; }

        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(50)]
        public string PaypalLastName { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(20)]
        public string ActivationCode { get; set; }




        [Required]
        [Column("Password")] // Mapping to EonExperience Password Column
        //[StringLength(50)]
        public override string PasswordHash { get => base.PasswordHash; set => base.PasswordHash = value; }




        [Required]
        public int? PasswordFormat { get; set; }

        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(100)]
        public string PasswordQuestion { get; set; }

        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(50)]
        public string PasswordAnswer { get; set; }

        [Required]
        public bool IsApproved { get; set; }
        [Required]
        public bool IsLockedOut { get; set; }
        [Required]
        public DateTime LastLogin { get; set; }
        [Required]
        public bool IsPortalLogin { get; set; }

        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        public int LoginCount { get; set; }
        public bool? IsDeleted { get; set; }
        [Required]
        public int DefaultInstituteId { get; set; }



        //Remaining Identity Fields
        public override DateTimeOffset? LockoutEnd { get => base.LockoutEnd; set => base.LockoutEnd = value; }
        public override bool LockoutEnabled { get => base.LockoutEnabled; set => base.LockoutEnabled = value; }
        public override int AccessFailedCount { get => base.AccessFailedCount; set => base.AccessFailedCount = value; }


        //  public override DateTime? LockoutEndDateUtc { get; set; } //Identity but not identitycore

        public override string SecurityStamp { get => base.SecurityStamp; set => base.SecurityStamp = value; }
        public override string ConcurrencyStamp { get => base.ConcurrencyStamp; set => base.ConcurrencyStamp = value; }
        public override bool TwoFactorEnabled { get => base.TwoFactorEnabled; set => base.TwoFactorEnabled = value; }


        public override bool EmailConfirmed { get => base.EmailConfirmed; set => base.EmailConfirmed = value; }
        public override bool PhoneNumberConfirmed { get => base.PhoneNumberConfirmed; set => base.PhoneNumberConfirmed = value; }
        public override string UserName { get => base.UserName; set => base.UserName = value; }


        //IdentityCore Additional Fields
        public override string NormalizedUserName { get => base.NormalizedUserName; set => base.NormalizedUserName = value; }
        public override string NormalizedEmail { get => base.NormalizedEmail; set => base.NormalizedEmail = value; }




        public ApplicationUser()
        {
            UserGUID = Guid.NewGuid().ToString();

            //added to skip  validation of incomplete user record on Registration
            LoginName = "";
            FirstName = "";
            LastName = "";
            GenderID = 1;
            PhotoURL = "";
            PasswordFormat = 0;
 
            IsDeleted = false;
            DefaultInstituteId = 0;
            UserName = Email;
        }

    }


    public class ApplicationUserRole : IdentityUserRole<int> { }
    public class ApplicationUserClaim : IdentityUserClaim<int> { }
    public class ApplicationUserLogin : IdentityUserLogin<int> { }

    public class ApplicationRole : IdentityRole<int>
    {
        public ApplicationRole() { }
        public ApplicationRole(string name) { Name = name; }
    }

    public class ApplicationUserStore : UserStore<ApplicationUser, ApplicationRole, ApplicationDbContext, int>
    {
        public ApplicationUserStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }

    public class ApplicationRoleStore : RoleStore<ApplicationRole, ApplicationDbContext, int>
    {
        public ApplicationRoleStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
