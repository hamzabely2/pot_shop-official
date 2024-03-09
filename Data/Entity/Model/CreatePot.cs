﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public partial class CreatePot
    {
        [Key]
        public int Id { get; set; }
        public int? UserId { get; set; }
        public byte[]? ImageData { get; set; }

    }
}
