using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    [Table("Products")]
   public class Product
    {
        public int Id { get; set; }

        [Required, MaxLength(30)]
        public string NameProduct { get; set; }

     
        [MaxLength(30)]
        public string BrandProduct { get; set; }

      
        [MaxLength(30)]
        public string Category { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int Quatity { get; set; }

        [ForeignKey("Providers")]
        public int IdProvider { get; set; }
        public Provider Providers { get; set; }

    }
}
