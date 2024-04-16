using Microsoft.EntityFrameworkCore;
using SeniorApi.Models;

namespace SeniorApi.Data {
  public class DataContext : DbContext {
    public DataContext(DbContextOptions<DataContext> options)
      :base(options) {}
      public DbSet<User> User { get; set; }
  }

}