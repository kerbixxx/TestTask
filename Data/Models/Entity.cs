﻿using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
