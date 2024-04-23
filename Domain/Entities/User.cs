using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharkITTesteTecnico.Domain.Entities;

[Table("user")]
public class User : BaseEntity
{
    [Column("username")]
    [MaxLength(100)]
    public string Username { get; set; } = default!;
    [Column("email")]
    public string Email { get; set; } = default!;
}
