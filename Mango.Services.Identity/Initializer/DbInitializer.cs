﻿using IdentityModel;
using Mango.Services.Identity.DbContexts;
using Mango.Services.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Mango.Services.Identity.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext applicationDbContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _applicationDbContext = applicationDbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initialize()
        {
            if (_roleManager.FindByNameAsync(SD.Admin).Result == null)
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Customer)).GetAwaiter().GetResult();
            }
            else { return; }

            ApplicationUser adminUser = new ApplicationUser()
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "111222333",
                FirstName = "ExampleAdmin",
                LastName = "ExampleAdmin"
            };

            _userManager.CreateAsync(adminUser, "Admin!23").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(adminUser, SD.Admin).GetAwaiter().GetResult();

            var temp1 = _userManager.AddClaimsAsync(adminUser, new Claim[]
                { 
                    new Claim(JwtClaimTypes.Name, adminUser.FirstName+" "+adminUser.LastName),
                    new Claim(JwtClaimTypes.GivenName, adminUser.FirstName),
                    new Claim(JwtClaimTypes.FamilyName, adminUser.LastName),
                    new Claim(JwtClaimTypes.Role, SD.Admin)
                }).Result;

            ApplicationUser customerUser = new ApplicationUser()
            {
                UserName = "customer@gmail.com",
                Email = "customer@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "111222333",
                FirstName = "ExampleCustomer",
                LastName = "ExampleCustomer"
            };

            _userManager.CreateAsync(customerUser, "Admin!23").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(customerUser, SD.Admin).GetAwaiter().GetResult();

            var temp2 = _userManager.AddClaimsAsync(customerUser, new Claim[]
                {
                    new Claim(JwtClaimTypes.Name, customerUser.FirstName+" "+customerUser.LastName),
                    new Claim(JwtClaimTypes.GivenName, customerUser.FirstName),
                    new Claim(JwtClaimTypes.FamilyName, customerUser.LastName),
                    new Claim(JwtClaimTypes.Role, SD.Customer)
                }).Result;
        }
    }
}
