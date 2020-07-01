using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NetDataLibrary.Data;
using NetDataLibrary.Models.Account;
using WebNetCoreDataLib.Extensions;

namespace WebNetCoreDataLib.Areas.Test.Pages.Account
{
    public class GetMyRolesModel : PageModel
    {
        private readonly IAccountData _accountData;
        public List<UserRoles> myRoles { get; set; }

        public GetMyRolesModel(IAccountData accountData)
        {
            _accountData = accountData;
        }


        public async Task OnGet()
        {
            var user = User.Identity;
            myRoles = await _accountData.GetUserRoles(user.GetUserGUID(), 1);
        }
    }
}
