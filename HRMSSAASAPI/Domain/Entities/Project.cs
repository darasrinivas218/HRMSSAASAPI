using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMSSAASAPI.Domain.Entities
{
    [Table("Projects")]
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        [Required, StringLength(50)]
        public string ProjectCode { get; set; }

        [Required, StringLength(150)]
        public string ProjectName { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        [ForeignKey("ProjectManager")]
        public int ProjectManagerId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [StringLength(50)]
        public string Status { get; set; } = "Active";

        public decimal? Budget { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        // Navigation Properties (optional)
        //public virtual Client Client { get; set; }
        //public virtual Department Department { get; set; }
        //public virtual Employee ProjectManager { get; set; }
    }
}
