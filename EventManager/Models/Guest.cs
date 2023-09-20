using System.ComponentModel.DataAnnotations;

namespace EventManager.Models
{
    public class EventGuest
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string MobileNo1 { get; set; } = string.Empty;
        public string MobileNo2 { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }
}
