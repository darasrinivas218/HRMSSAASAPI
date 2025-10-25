using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMSSAASAPI.Domain.Entities
{
    [Table("Clients")]
    public class Client
    {
        [Key]
        public int ClientId { get; set; }

        [Required, StringLength(150)]
        public string ClientName { get; set; }

        [Required, StringLength(50)]
        public string ClientCode { get; set; }

        [StringLength(100)]
        public string Industry { get; set; }

        [StringLength(100)]
        public string ContactPerson { get; set; }

        [StringLength(150)]
        public string ContactEmail { get; set; }

        [StringLength(20)]
        public string ContactPhone { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        [StringLength(100)]
        public string Country { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
    }
}
