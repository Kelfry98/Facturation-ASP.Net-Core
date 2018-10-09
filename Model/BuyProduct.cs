using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    public class BuyProduct
    {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        public int IdBuy { get; set; }
        public int Quatity { get; set; }

        [ForeignKey("IdBuy")]
        public virtual Buy Buy { get; set; }
        [ForeignKey("IdProduct")]
        public virtual Product Product { get; set; }

    }
}
