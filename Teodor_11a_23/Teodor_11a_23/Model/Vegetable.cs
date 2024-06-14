using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teodor_11a_23.Model
{
    public class Vegetable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public int VegetableTypeId { get; set; } //F.K
        //M:1
        public VegetableType VegetableType { get; set; }

    }
}
