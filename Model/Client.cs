using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    [Table("Clients")]
    public class Client
    {
        public int Id { get; set; }

        [Required, MaxLength(20)]
        public string Name { get; set; }

        [Required, MaxLength(40)]
        public string LastName { get; set; }

        [Required, MaxLength(60)]
        public string Address { get; set; }

        [Required, MaxLength(30)]
        public string Email { get; set; }

        [Required, MaxLength(11)] 
        public string Dni { get; set; }

        [Required, MaxLength(12)]
        public string Telephone { get; set; }
    }
}
