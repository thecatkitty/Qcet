using Microsoft.EntityFrameworkCore;

namespace Qcet.Models {
  /// <summary>Database context.</summary>
  public class QcetContext : DbContext {
    /// <summary>Constructor.</summary>
    public QcetContext(DbContextOptions<QcetContext> options)
      : base(options) {
    }

    /// <summary>Table containing user information.</summary>
    public DbSet<User> Users { get; set; }
  }
}
