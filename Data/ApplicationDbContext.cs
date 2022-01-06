using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Kamenici.ViewModels;

namespace Kamenici.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Frame> Frames { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Kamenici.ViewModels.EditFrameViewModel> EditFrameViewModel { get; set; }
        public DbSet<Kamenici.ViewModels.DeleteFrameViewModel> DeleteFrameViewModel { get; set; }
        public DbSet<Kamenici.ViewModels.CreateOrderViewModel> CreateOrderViewModel { get; set; }
        public DbSet<Kamenici.ViewModels.DeleteOrderViewModel> DeleteOrderViewModel { get; set; }
        public DbSet<Kamenici.ViewModels.EditOrderViewModel> EditOrderViewModel { get; set; }
    }
}