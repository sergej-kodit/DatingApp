using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Photos")]
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; } = default!;
        public bool IsMain { get; set; }
        public string? PublicId { get; set; } = default!;
        public AppUser AppUser { get; set; } = default!;
        public int AppUserId { get; set; }

    }
}