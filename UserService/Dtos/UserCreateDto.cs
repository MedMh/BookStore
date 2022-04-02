using System.ComponentModel.DataAnnotations;

namespace UserService.Dtos
{
    public class UserCreateDto
    {

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string FamilyName { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; } 
    }
}