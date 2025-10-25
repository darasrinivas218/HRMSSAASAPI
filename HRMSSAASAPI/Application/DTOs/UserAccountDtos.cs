using System.ComponentModel.DataAnnotations;

namespace HRMSSAASAPI.Application.DTOs
{
    public class UserAccountCreateDto
    {
        [Required]
        public int EmployeeId { get; set; }

        [Required, MaxLength(50)]
        public string Username { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; } // Plain-text only for creation

        [Required]
        public int RoleId { get; set; }
    }

    public class UserAccountUpdateDto
    {
        [Required]
        public int UserId { get; set; }

        [MaxLength(150)]
        public string Email { get; set; }

        public bool? IsActive { get; set; }
        public bool? TwoFactorEnabled { get; set; }
    }
   

    

    
}
