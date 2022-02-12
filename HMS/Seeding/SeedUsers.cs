using HMS.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMS.Seeding
{
    public static class SeedUsers
    {
        public static void seed(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            seedRoles(roleManager);

            seedUsers(userManager);
        }

        private static void seedRoles(RoleManager<IdentityRole> roleManager)
        {
            try
            {
                if (!roleManager.RoleExistsAsync("Admin").Result)
                {
                    var role = new IdentityRole();

                    role.Name = "Admin";

                    roleManager.CreateAsync(role).Wait();
                }

                if (!roleManager.RoleExistsAsync("Receptionist").Result)
                {
                    var role = new IdentityRole();

                    role.Name = "Receptionist";

                    roleManager.CreateAsync(role).Wait();
                }

                if (!roleManager.RoleExistsAsync("Nurse").Result)
                {
                    var role = new IdentityRole();

                    role.Name = "Nurse";

                    roleManager.CreateAsync(role).Wait();
                }

                if (!roleManager.RoleExistsAsync("Doctor").Result)
                {
                    var role = new IdentityRole();

                    role.Name = "Doctor";

                    roleManager.CreateAsync(role).Wait();
                }

                if (!roleManager.RoleExistsAsync("Lab").Result)
                {
                    var role = new IdentityRole();

                    role.Name = "Lab";

                    roleManager.CreateAsync(role).Wait();
                }

                if (!roleManager.RoleExistsAsync("Optician").Result)
                {
                    var role = new IdentityRole();

                    role.Name = "Optician";

                    roleManager.CreateAsync(role).Wait();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void seedUsers(UserManager<AppUser> userManager)
        {
            try
            {
                #region Admin
                var admin = userManager.FindByEmailAsync("admin@gmail.com");

                if (admin.Result == null)
                {
                    var user = new AppUser();

                    user.UserName = "admin@gmail.com";

                    user.Email = "admin@gmail.com";

                    user.PhoneNumber = "0704509484";

                    user.FirstName = "Alex";

                    user.LastName = "Jobs";

                    user.EmailConfirmed = true;

                    user.isActive = true;

                    user.CreateDate = DateTime.Now;

                    string userPWD = "Admin@2022";

                    var chkUser = userManager.CreateAsync(user, userPWD);

                    //Add default User to Role Admin    
                    if (chkUser.Result.Succeeded)
                    {
                        userManager.AddToRoleAsync(user, "Admin").Wait();

                    }  
                }
                #endregion

                #region Doctor

                var doctor = userManager.FindByEmailAsync("doctor@gmail.com");

                if (doctor.Result == null)
                {
                    var user = new AppUser();

                    user.UserName = "doctor@gmail.com";

                    user.Email = "doctor@gmail.com";

                    user.PhoneNumber = "0704509484";

                    user.FirstName = "Steve";

                    user.LastName = "Jobs";

                    user.EmailConfirmed = true;

                    user.isActive = true;

                    user.CreateDate = DateTime.Now;

                    string userPWD = "Doctor@2022";

                    var chkUser = userManager.CreateAsync(user, userPWD);

                    //Add default User to Role Admin    
                    if (chkUser.Result.Succeeded)
                    {
                        userManager.AddToRoleAsync(user, "Doctor").Wait();

                    }
                }
                #endregion

                #region Nurse
                var nurse = userManager.FindByEmailAsync("nurse@gmail.com");

                if (nurse.Result == null)
                {
                    var user = new AppUser();

                    user.UserName = "nurse@gmail.com";

                    user.Email = "nurse@gmail.com";

                    user.PhoneNumber = "0704509484";

                    user.FirstName = "Moureen";

                    user.LastName = "Marvins";

                    user.EmailConfirmed = true;

                    user.isActive = true;

                    user.CreateDate = DateTime.Now;

                    string userPWD = "Nurse@2022";

                    var chkUser = userManager.CreateAsync(user, userPWD);

                    //Add default User to Role Admin    
                    if (chkUser.Result.Succeeded)
                    {
                        userManager.AddToRoleAsync(user, "Nurse").Wait();

                    }
                }
                #endregion

                #region Receptionist
                var receptionist = userManager.FindByEmailAsync("receptionist@gmail.com");

                if (receptionist.Result == null)
                {
                    var user = new AppUser();

                    user.UserName = "receptionist@gmail.com";

                    user.Email = "receptionist@gmail.com";

                    user.PhoneNumber = "0704509484";

                    user.FirstName = "Anne";

                    user.LastName = "Jobs";

                    user.EmailConfirmed = true;

                    user.isActive = true;

                    user.CreateDate = DateTime.Now;

                    string userPWD = "Receptionist@2022";

                    var chkUser = userManager.CreateAsync(user, userPWD);

                    //Add default User to Role Admin    
                    if (chkUser.Result.Succeeded)
                    {
                        userManager.AddToRoleAsync(user, "Receptionist").Wait();

                    }
                }
                #endregion


                #region Lab
                var lab = userManager.FindByEmailAsync("lab@gmail.com");

                if (lab.Result == null)
                {
                    var user = new AppUser();

                    user.UserName = "lab@gmail.com";

                    user.Email = "lab@gmail.com";

                    user.PhoneNumber = "0704509484";

                    user.FirstName = "Kelly";

                    user.LastName = "Rotich";

                    user.EmailConfirmed = true;

                    user.isActive = true;

                    user.CreateDate = DateTime.Now;

                    string userPWD = "Lab@2022";

                    var chkUser = userManager.CreateAsync(user, userPWD);

                    //Add default User to Role Admin    
                    if (chkUser.Result.Succeeded)
                    {
                        userManager.AddToRoleAsync(user, "Lab").Wait();

                    }
                }
                #endregion

                #region Optician
                var optician = userManager.FindByEmailAsync("optician@gmail.com");

                if (optician.Result == null)
                {
                    var user = new AppUser();

                    user.UserName = "optician@gmail.com";

                    user.Email = "optician@gmail.com";

                    user.PhoneNumber = "0704509484";

                    user.FirstName = "Marvin";

                    user.LastName = "Limo";

                    user.EmailConfirmed = true;

                    user.isActive = true;

                    user.CreateDate = DateTime.Now;

                    string userPWD = "Optician@2022";

                    var chkUser = userManager.CreateAsync(user, userPWD);

                    //Add default User to Role Admin    
                    if (chkUser.Result.Succeeded)
                    {
                        userManager.AddToRoleAsync(user, "Optician").Wait();

                    }
                } 
                #endregion
            }
            catch (Exception ex)
            {
                Console.WriteLine( ex.Message);
                
            }
        }

    }
}
