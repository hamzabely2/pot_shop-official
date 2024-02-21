using System.ComponentModel.DataAnnotations;

namespace Entity.Model
{
    public partial class Color
    {
        [Key]
        public int Id { get; set; }
        public string? Label { get; set; }
        public string Hex { get; set; } = null!;
        public virtual List<ColorItem> Colors_Items { get; set; }
    }
}
