
using System.ComponentModel.DataAnnotations;

namespace AcxiomCRM.Models
{
    public class Opportunity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string CustomerName { get; set; } = string.Empty;

        [Range(0.01, 1000000000,
            ErrorMessage = "Amount must be greater than zero")]
        public decimal Amount { get; set; }

        [Range(0, 100,
            ErrorMessage = "Probability must be between 0 and 100")]
        public int Probability { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ExpectedCloseDate { get; set; }

        [Required]
        public string Status { get; set; } = "Open";
    }
}
