using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Model.DetailsItem
{
    public class CategoryDto
    {
        public string Id { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }

    }
    public class ColorDto
    {
        public string Id { get; set; }
        public string Label { get; set; }
        public string Hex { get; set; }
    }

    public class MaterialDto
    {
        public string Id { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }

    }

    public class AddColorByItem
    {
        public int ColorId { get; set; }
        public int ItemId { get; set; }

    }

    public class AddImageByItem
    {
        [Required(ErrorMessage = "Veuillez insere un artcile")]

        public int ItemId { get; set; }

        [Required(ErrorMessage = "Veuillez insere une image")]
        public IFormFile ImageData { get; set; }

    }
}
