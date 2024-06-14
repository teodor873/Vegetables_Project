using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teodor_11a_23.Model;

namespace Teodor_11a_23.Controller
{
    public class VegetableTypeLogic
    {
        private VegetableContext typeLogic = new VegetableContext();

        public List<VegetableType> GetAllVegetables()
        {
            return typeLogic.VegetableTypes.ToList();
        }
        public string GetVegetableById(int id)
        {
            return typeLogic.VegetableTypes.Find(id).TypeName;
        }
    }
}
