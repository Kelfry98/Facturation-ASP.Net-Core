using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    [Table("Buys")]
    public class Buy
    {
        public int Id { get; set; }
        [Required]
        public DateTime DateBuy { get; set; }
        [Required]
        public double TotalBuy { get; set; }
        [Required]
        public int TotalArticle { get; set; }

        [Required, ForeignKey("Clients")]
        public int IdClient { get; set; }
        public Client Clients { get; set; }

        [Required, ForeignKey("Users")]
        public int IdUser { get; set; }
        public User Users { get; set; }

        
    }
}
