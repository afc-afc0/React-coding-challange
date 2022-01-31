using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infastructure.Entities
{
    public class File
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FileId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(200)]
        public string RawImageUrl { get; set; }
        [Required]
        [StringLength(200)]
        public string RegularImageUrl { get; set; }
        [Required]
        [StringLength(200)]
        public string ThumbImageUrl { get; set; }
        [Required]
        public long Views { get; set; }
        [Required]
        public long Likes { get; set; }
        [Required]
        public int Height { get; set; }
        [Required]
        public int Width { get; set; }
    }
}
