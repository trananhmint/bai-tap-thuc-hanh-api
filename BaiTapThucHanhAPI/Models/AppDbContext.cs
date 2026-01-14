using BaiTapThucHanhAPI.Controllers;
using Microsoft.EntityFrameworkCore;

namespace BaiTapThucHanhAPI.Models;

public class AppDbContext : DbContext
{
    public AppDbContext()
    {
        
    }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    public virtual DbSet<DonViTinh> DonViTinh { get; set; }
    public virtual DbSet<LoaiSanPham> LoaiSanPham { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString: "Data Source=(local);database=BaiTapThucHanh;uid=sa;pwd=12345;TrustServerCertificate=True;MultipleActiveResultSets=True");
    }
}   