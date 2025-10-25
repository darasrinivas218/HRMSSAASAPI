using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMSSAASAPI.Domain.Entities
{
    public class PasswordResetRequest
    {
        [Key]
        public int RequestId { get; set; }

        [ForeignKey("UserAccount")]
        public int UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string ResetToken { get; set; }

        public DateTime ExpiryDate { get; set; }

        public bool IsUsed { get; set; } = false;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Navigation Property (Optional)
        //public virtual UserAccount UserAccount { get; set; }
    }
}
