using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Teodor_11a_23.Model
{
    public class VegetableContext: DbContext
    {

        public VegetableContext() : base("VegetableContext")
        {

        }

        public DbSet<Vegetable> Vegetables { get; set; }
        public DbSet<VegetableType> VegetableTypes { get; set; }

    }
}
