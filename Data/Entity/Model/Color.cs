using System.ComponentModel.DataAnnotations;

namespace Entity.Model
{
    public partial class Color
    {
        [Key]
        public int Id { get; set; }
        public int? ItemId { get; set; }
        public string Hex { get; set; } = null!;
    }
}
