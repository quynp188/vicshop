using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VicShop.Entities;
using VicShop.Enums;

namespace VicShop;

public class VicShopDbContext : IdentityDbContext<AppUser, AppRole, string>
{
    public VicShopDbContext(DbContextOptions<VicShopDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { set; get; }
    public DbSet<Category> Categories { set; get; }
    public DbSet<Color> Colors { set; get; }
    public DbSet<Origin> Origins { set; get; }
    public DbSet<ProductColor> ProductColors { set; get; }
    public DbSet<ProductImage> ProductImages { set; get; }
    public DbSet<ProductOrigin> ProductOrigins { set; get; }
    public DbSet<ProductSize> ProductSizes { set; get; }
    public DbSet<ProductTag> ProductTags { set; get; }
    public DbSet<Size> Sizes { set; get; }
    public DbSet<Tag> Tags { set; get; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<ProductColor>((entity) =>
        {
            entity.HasIndex(productColor => new { productColor.ProductId, productColor.ColorId }).IsUnique();
        });
        builder.Entity<ProductOrigin>((entity) =>
        {
            entity.HasIndex(productOrigin => new { productOrigin.ProductId, productOrigin.OriginId }).IsUnique();
        });
        builder.Entity<ProductSize>((entity) =>
        {
            entity.HasIndex(productSize => new { productSize.ProductId, productSize.SizeId }).IsUnique();
        });
        builder.Entity<ProductTag>((entity) =>
        {
            entity.HasIndex(productTag => new { productTag.ProductId, productTag.TagId }).IsUnique();
        });        
        builder.Entity<Category>().HasData(new List<Category> {
            new Category(){Id =1, Name = "Camera",Image = string.Empty},
            new Category(){Id =2, Name = "Camera TP-Link",Image = string.Empty, ParentId =1},
            new Category(){Id =3, Name = "Camera Xiaomi",Image = string.Empty,ParentId = 1},
            new Category(){Id =4,Name = "Phone",Image = string.Empty},
            new Category(){Id =5, Name = "Iphone",Image = string.Empty, ParentId =4},
            new Category(){Id =6, Name = "Samsung",Image = string.Empty,ParentId = 4},
        });
        builder.Entity<Product>().HasData(new List<Product>
        {
            new Product { Id =1, ProductName = "Camera IP Wifi TP-Link Tapo C200 360° 1080P 2MP", CategoryId = 2, ProductNumber = "013", Unit = "Cái", Price = 1000000, Status = ProductStatus.Available, Image ="https://phucanhcdn.com/media/product/42241_tapo_c200_ha2.jpg" },
            new Product { Id =2, ProductName = "Camera Xiaomi Mi Home Security 360 - 1080P BHR4885GL", CategoryId = 3, ProductNumber = "012", Unit = "Cái", Price = 1000000, Status = ProductStatus.Available, Image ="https://salt.tikicdn.com/ts/product/fd/57/2b/ceaec0bb0cf63fbbaf45d7eb2ec994b5.jpg" },
            new Product { Id =3, ProductName = "Iphone 12", CategoryId = 5, ProductNumber = "014", Unit = "Cái", Price = 1600000, Status = ProductStatus.Available, Image ="https://cdn.tgdd.vn/Products/Images/42/228736/iphone-12-violet-1-600x600.jpg" },
            new Product { Id =4, ProductName = "IPhone 13", CategoryId = 5, ProductNumber = "016", Unit = "Cái", Price = 1600000, Status = ProductStatus.Available, Image ="https://cdn.hoanghamobile.com/i/productlist/dsp/Uploads/2021/09/15/image-removebg-preview-15.png" },
            new Product { Id =5, ProductName = "Samsung Galaxy S21", CategoryId = 6, ProductNumber = "015", Unit = "Cái", Price = 1800000, Status = ProductStatus.Available, Image ="https://images.samsung.com/is/image/samsung/p6pim/vn/galaxy-s21/gallery/vn-galaxy-s21-5g-g991-sm-g991bzvdxxv-368334509?$624_624_PNG$" },
        });
        builder.Entity<Color>().HasData(new List<Color>
        {
            new Color {Id =1, Name="White", Code = "#ffffff" },
            new Color {Id =2,Name="black", Code = "#000000" },
            new Color {Id =3,Name="Gray", Code = "#808080" },
            new Color {Id =4,Name="red", Code = "ff0000" },
            new Color {Id =5,Name="green",Code = "008000"},
            new Color {Id =6,Name="blue",Code = "0000ff"},
        });
        builder.Entity<Size>().HasData(new List<Size>
        {
           new Size {Id =1, Name="XXL",Code="XXL"},
           new Size {Id =2, Name="XL" ,Code="XL"},
           new Size {Id =3, Name="L" ,Code="L"},
           new Size {Id =4, Name="M" ,Code="M"},
           new Size {Id =5, Name="S",Code="S" },
        });
        builder.Entity<Origin>().HasData(new List<Origin>
        {
           new Origin {Id =1,Name="Việt Nam", Code = "VN" },
           new Origin {Id =2,Name="Trung QUốc",Code = "CN"},
           new Origin {Id =3,Name="Mỹ",Code = "USA"},
        });
        builder.Entity<Tag>().HasData(new List<Tag>
        {
           new Tag {Id =1,Name="camera xiaomi" },
           new Tag {Id =2,Name="samsung" },
           new Tag {Id =3,Name="iphone"},
           new Tag {Id =4,Name="camera tplink"},
        });
        builder.Entity<ProductImage>().HasData(new List<ProductImage>
        {
           new ProductImage { Id =1, ProductId=1, Path = "https://cdn.cellphones.com.vn/media/catalog/product/cache/7/image/9df78eab33525d08d6e5fb8d27136e95/c/a/camera-ip-wifi-ezviz-c6n-1080p-2mp.jpg" },
           new ProductImage {Id=2, ProductId=1, Path = "https://cdn.cellphones.com.vn/media/catalog/product/cache/7/image/9df78eab33525d08d6e5fb8d27136e95/c/a/camera-ip-wifi-ezviz-c6n-1080p-2mp.jpg" },
           new ProductImage {Id =3, ProductId=1, Path = "https://cdn.cellphones.com.vn/media/catalog/product/cache/7/image/9df78eab33525d08d6e5fb8d27136e95/c/a/camera-ip-wifi-ezviz-c6n-1080p-2mp.jpg" },
           new ProductImage {Id=4, ProductId=1, Path = "https://cdn.cellphones.com.vn/media/catalog/product/cache/7/image/9df78eab33525d08d6e5fb8d27136e95/c/a/camera-ip-wifi-ezviz-c6n-1080p-2mp.jpg" },
        });
        builder.Entity<ProductTag>().HasData(new List<ProductTag>
        {
           new ProductTag {Id=1, ProductId=1, TagId =1},
           new ProductTag {Id=2, ProductId=1, TagId =4},
        });
        builder.Entity<ProductSize>().HasData(new List<ProductSize>
        {
           new ProductSize {Id=1, ProductId=1, SizeId =1 },
           new ProductSize {Id=2, ProductId=2, SizeId =1 },
        });
        builder.Entity<ProductColor>().HasData(new List<ProductColor>
        {
           new ProductColor {Id =1,ProductId=1, ColorId =1 },
           new ProductColor {Id =2,ProductId=2, ColorId =1 },
           new ProductColor {Id =3,ProductId=3, ColorId =1 },
        });
        builder.Entity<ProductOrigin>().HasData(new List<ProductOrigin>
        {
           new ProductOrigin {Id =1, ProductId=1, OriginId =1 },
           new ProductOrigin {Id=2, ProductId=2, OriginId =1 },
           new ProductOrigin {Id=3, ProductId=3, OriginId =1 },
        });
    }

    private void SeedRoles(ModelBuilder builder)
    {
        builder.Entity<AppRole>().HasData(new AppRole
        {
            Id = "1C2F081B-EE6B-4BD1-BD84-1E6384D2F284",
            Name = "Admin",
            Description = "Super Admin",
            ConcurrencyStamp = "1",
            NormalizedName = "Admin"
        });

        builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "1C2F081B-EE6B-4BD1-BD84-1E6384D2F284",
            UserId = "66C2E4F8-8661-4BA7-B540-431D6763F6F8",
        });
    }
    private void SeedUsers(ModelBuilder builder)
    {
       
        var user = new AppUser
        {
            Id = "66C2E4F8-8661-4BA7-B540-431D6763F6F8",
            FullName = "Nguyễn Phú Quý",
            Email = "phuquyfrec@gmail.com",
            Address = "Mỹ Đình 2- Nam Từ Liêm - Hà Nội",
            Gender = Gender.Female,
            UserName = "phuquyfrec@gmail.com",
            DepartmentId = Guid.NewGuid().ToString(),
            PhoneNumber = "0349626569",
            NormalizedUserName = "phuquyfrec@gmail.com",
            LockoutEnabled = false,
            SecurityStamp = Guid.NewGuid().ToString(),
        };
        PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();
        user.PasswordHash = passwordHasher.HashPassword(user, "Hoant0509");
        builder.Entity<AppUser>().HasData(user);
    }
}