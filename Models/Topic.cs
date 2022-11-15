using System.ComponentModel.DataAnnotations;

namespace foro.Models
{
    public class Topic
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public int UserId { get; set; }
    }
}
