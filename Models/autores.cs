﻿using System.ComponentModel.DataAnnotations;

namespace L02P02_2022AJ650_2022PD651.Models
{
    public class autores
    {
        [Key]
        public int id { get; set; }

        [Required]
        [MaxLength(200)]
        public string autor { get; set; }

    }
}
