using System.ComponentModel.DataAnnotations;

namespace Qcet.Models {
  /// <summary>A registered user of the Qcet system.</summary>
  public class User {
    /// <summary>Unique user identifier.</summary>
    public int Id { get; set; }

    /// <summary>User's first name.</summary>
    [Required]
    public string FirstName { get; set; }

    /// <summary>User's family name.</summary>
    [Required]
    public string FamilyName { get; set; }
    
    /// <summary>User's nick.</summary>
    public string Nick { get; set; }
    
    /// <summary>User's place of living.</summary>
    [Required]
    public string City { get; set; }
  }
}
