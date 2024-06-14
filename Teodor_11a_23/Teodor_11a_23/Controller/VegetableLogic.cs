using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teodor_11a_23.Model;

namespace Teodor_11a_23.Controller
{
    public class VegetableLogic
    {
        private VegetableContext vegitableLogic = new VegetableContext();

        public Vegetable Get(int id)
        {
            Vegetable vegetable = vegitableLogic.Vegetables.Find(id);
            if (vegetable != null)
            {
                vegitableLogic.Entry(vegetable).Reference(x => x.VegetableType).Load();
            }
            return vegetable;
        }

        public List<Vegetable> GetAll()
        {
            return vegitableLogic.Vegetables.Include("VegetableType").ToList();
        }

        public void Create(Vegetable vegetable)
        {
            vegitableLogic.Vegetables.Add(vegetable);
            vegitableLogic.SaveChanges();
        }
        public void Update(int id, Vegetable vegetable)
        {
            Vegetable veg = vegitableLogic.Vegetables.Find(id);
            if (veg == null)
            {
                return;
            }
            
            veg.Name = vegetable.Name;
            veg.Price = vegetable.Price;
            veg.Description = vegetable.Description;
            veg.VegetableTypeId = vegetable.VegetableTypeId;

            vegitableLogic.SaveChanges();
        }
        public void Delete(int id)
        {
            Vegetable veg = vegitableLogic.Vegetables.Find(id);
            vegitableLogic.Vegetables.Remove(veg);
            vegitableLogic.SaveChanges();
        }

    }
}
