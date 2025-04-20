using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Api.Data.Entities
{
    public class UserEntity
    {
        // Id için bu özellikleri vermezsek bile ef core id ismini analyıp otomatik olarak pk gösteriyor zaten.
        [Key] // Id => PK olması sağlanıyor
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Identity özelliği sağlanıyor
        public int Id { get; set; }

        [Required, StringLength(50, MinimumLength = 1)]
        public string Name { get; set; } = string.Empty; // Default value

        [Required, StringLength(50, MinimumLength = 1), EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, DataType(DataType.Password), MinLength(4)]
        public string Password { get; set; } = string.Empty;
    }
}
