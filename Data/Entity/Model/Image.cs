using System.ComponentModel.DataAnnotations;

namespace Entity.Model
{
    public partial class Image
    {
        [Key]
        public int Id { get; set; }
        public int? ItemId { get; set; }
        public byte[]? ImageData { get; set; }

    }
}
