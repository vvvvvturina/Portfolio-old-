using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

[Table("User")]
public class User
{
    [Column("UserID")]
    public Guid UserID { get; set; }
    
    [Column("Name")]
    [Required]
    [MaxLength(50, ErrorMessage = "Length must be less then 50 characters")]
    public string Name { get; set; }
    
    [Column("Email")]
    [Required]
    [MaxLength(50, ErrorMessage = "Length must be less then 50 characters")]
    public string Email { get; set; }
    
    [Column("Age")]
    public int Age { get; set; }
}