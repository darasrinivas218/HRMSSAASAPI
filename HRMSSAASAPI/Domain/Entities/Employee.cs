using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMSSAASAPI.Domain.Entities
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required, StringLength(20)]
        public string EmployeeCode { get; set; }

        [Required, StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(1)]
        public string Gender { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DOB { get; set; }

        [StringLength(150)]
        public string Email { get; set; }

        [StringLength(15)]
        public string Phone { get; set; }

        // Foreign keys
        public int? DepartmentId { get; set; }        

        public int? DesignationId { get; set; }        

        [Column(TypeName = "date")]
        [Required]
        public DateTime DateOfJoining { get; set; }

        public int? ReportingManagerId { get; set; }      

        [StringLength(50)]
        public string EmploymentType { get; set; } // Permanent / Contract

        [StringLength(50)]
        public string Status { get; set; } = "Active";

        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Column(TypeName = "datetime")]
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        // Navigation properties
        //public ICollection<UserAccount> UserAccounts { get; set; }
    }
}
