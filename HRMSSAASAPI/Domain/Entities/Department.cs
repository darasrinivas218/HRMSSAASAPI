using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMSSAASAPI.Domain.Entities
{
    [Table("Departments")]
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required, StringLength(100)]
        public string DepartmentName { get; set; }

        [StringLength(20)]
        public string DepartmentCode { get; set; }

        public int? ManagerId { get; set; }

        [ForeignKey(nameof(ManagerId))]
        public Employee Manager { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Column(TypeName = "datetime")]
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;

        // Navigation properties
        //public ICollection<Designation> Designations { get; set; }
        //public ICollection<Employee> Employees { get; set; }
    }
}
