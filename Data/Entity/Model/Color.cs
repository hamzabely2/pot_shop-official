﻿using System.ComponentModel.DataAnnotations;

namespace Entity.Model
{
    public partial class Color
    {
        [Key]
        public int Id { get; set; }
        public string Label { get; set; } = null!;
        //public string Hex { get; set; } = null!;
        public virtual ICollection<Item>? Items { get; set; }
    }
}
