using System.ComponentModel.DataAnnotations;

namespace GoMapsCloudAPI.Models
{
    public class User
    {
        [Key]
        [Required]
        public long user_id { get; set; }
    }
}
