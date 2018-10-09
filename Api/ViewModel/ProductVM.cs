using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facturaction.ViewModel
{
    public class ProductVM
    {
        public Buy Buys { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
