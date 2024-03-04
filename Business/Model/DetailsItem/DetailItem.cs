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


    /// <summary>
    /// material
    /// </summary>
    public class ReadMaterial
    {
        public string Id { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }

    }
    public class CreateMaterial
    {
        [Required(ErrorMessage = "Veuillez insere le titre de matériel")]
        public string Label { get; set; }
        [Required(ErrorMessage = "Veuillez insere la description  le matériel")]
        public string Description { get; set; }

    }



    /// <summary>
    /// color
    /// </summary>
    public class AddColorByItem
    {
        public int ColorId { get; set; }
        public int ItemId { get; set; }

    }


    /// <summary>
    /// image
    /// </summary>
    public class AddImageByItem
    {
        [Required(ErrorMessage = "Veuillez insere un artcile")]
        public int ItemId { get; set; }

        [Required(ErrorMessage = "Veuillez insere une image")]
        public IFormFile ImageData { get; set; }

    }

    public class DeleteImageByItem
    {
        public int ItemId { get; set; }
        public int ImageId { get; set; }

    }
}
