using API.Core.DbModels;
using API.Core.DbModels.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Infrastructure.DataContext
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Yunus",
                    Email ="kldhfwleık@com.tr",
                    UserName = "yunus",
                    Address = new Address
                    {
                        FirstName ="Yunus",
                        LastName ="Arslan",
                        Street = "Kanarya",
                        City =   "İstanbul",
                        State = "TR",
                        ZipCode = "34000"
                    }
                };
                await userManager.CreateAsync(user,"Admin*123");
            }

        }
    }
}
