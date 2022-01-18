using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VicShop.Entities;
using VicShop.Enums;

namespace VicShop;

public class DataInitializer
{

    private readonly VicShopDbContext vicShopDbContext;
    private readonly UserManager<AppUser> userManager;
    private readonly RoleManager<AppRole> roleManager;
    public DataInitializer(VicShopDbContext vicShopDbContext,
        UserManager<AppUser> userManager,
        RoleManager<AppRole> roleManager)
    {
        this.vicShopDbContext = vicShopDbContext;
        this.userManager = userManager;
        this.roleManager = roleManager;
    }
    public async Task Seed()
    {
        Console.WriteLine("--------Start migrate database---------");
        if (!roleManager.Roles.Any())
        {
            await this.roleManager.CreateAsync(new AppRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Admin",
                Description = "Super Admin"
            });
        }
        if (userManager.Users.Any())
        {
            var user = await this.userManager.FindByEmailAsync("phuquyfrec@gmail.com");
            await this.userManager.DeleteAsync(user);
            await this.userManager.CreateAsync(new AppUser
            {
                Id = Guid.NewGuid().ToString(),
                FullName = "Nguyễn Phú Quý",
                Email = "phuquyfrec@gmail.com",
                Address = "Mỹ Đình 2- Nam Từ Liêm - Hà Nội",
                Gender = Gender.Female,
                UserName = "qunp",
                DepartmentId = Guid.NewGuid().ToString(),
                PhoneNumber = "0349626569"
            }, "Hoannt0509@");
            var usserCreated = await this.userManager.FindByEmailAsync("phuquyfrec@gmail.com");
            await this.userManager.AddToRoleAsync(usserCreated, "Admin");
        }
        else
        {
            await this.userManager.CreateAsync(new AppUser
            {
                Id = Guid.NewGuid().ToString(),
                FullName = "Nguyễn Phú Quý",
                Email = "phuquyfrec@gmail.com",
                Address = "Mỹ Đình 2- Nam Từ Liêm - Hà Nội",
                Gender = Gender.Female,
                UserName = "qunp",
                DepartmentId = Guid.NewGuid().ToString(),
                PhoneNumber = "0349626569"
            }, "Hoannt0509@");
            var usserCreated = await this.userManager.FindByEmailAsync("phuquyfrec@gmail.com");
            await this.userManager.AddToRoleAsync(usserCreated, "Admin");
        }
    }
}