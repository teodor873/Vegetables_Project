using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teodor_11a_23.Model
{
    public class VegetableType
    {
        public int Id { get; set; }

        public string TypeName { get; set; }
        //1:M
        public ICollection<Vegetable> Vegetables { get; set; }
    }
}
