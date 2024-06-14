using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teodor_11a_23.Controller;
using Teodor_11a_23.Model;

namespace Teodor_11a_23.View
{
    public class Display
    {
        private VegetableLogic dogLogic = new VegetableLogic();
        private int closeOperation = 6;
        public Display()
        {
            Input();
        }

        public void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "MENU" + new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all entries");
            Console.WriteLine("2. Add new entry");
            Console.WriteLine("3. Update entry");


            Console.WriteLine("4. Fetch entry by ID");
            Console.WriteLine("5. Delete entry by ID");
            Console.WriteLine("6. Exit");
        }

        private void Input()
        {
            var operation = -1;
            do
            {
                ShowMenu();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1:
                        ListAll();
                        break;
                    case 2:
                        Add();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        Fetch();
                        break;
                    case 5:
                        Delete();
                        break;
                    default:
                        break;
                }
            } while (operation != closeOperation);
        }

        private void PrintVegetable(Vegetable _vegetable)
        {
            Console.WriteLine($"{_vegetable.Id}. {_vegetable.Name} {_vegetable.Price} {_vegetable.Description}");
        }

        private void Delete()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            VegetableLogic vegetableContorller = new VegetableLogic();
            Vegetable _vegetable = vegetableContorller.Get(id);
            if (_vegetable != null)
            {
                vegetableContorller.Delete(id);
            }
        }

        private void Fetch()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            VegetableLogic vegetableContorller = new VegetableLogic();
            Vegetable _vegetable = vegetableContorller.Get(id);
            if (_vegetable != null)
            {
                PrintVegetable(_vegetable);
            }
        }

        private void Update()
        {
            Console.Write("Enter the vegetable's id: ");
            int dogId = int.Parse(Console.ReadLine());
            Vegetable newVegetable = dogLogic.Get(dogId);
            if (newVegetable == null)
            {
                Console.WriteLine("No find");
                return;
            }
            PrintVegetable(newVegetable);

            Console.WriteLine("Enter the new values: ");
            Console.Write("Name: ");
            newVegetable.Name = Console.ReadLine();

            Console.Write("Price: ");
            newVegetable.Price = double.Parse(Console.ReadLine());

            Console.Write("Deskription: ");
            newVegetable.Description = Console.ReadLine();


            VegetableTypeLogic vegetableTypeLogic = new VegetableTypeLogic();
            List<VegetableType> allBreeds = vegetableTypeLogic.GetAllVegetables();
            Console.WriteLine("Types:");
            Console.WriteLine(new string('-', 4));
            foreach (var item in allBreeds)
            {
                Console.WriteLine(item.Id + ". " + item.TypeName);
            }
            Console.WriteLine("Enter type:");
            newVegetable.VegetableTypeId = int.Parse(Console.ReadLine());

            VegetableLogic dogContorller = new VegetableLogic();
            dogContorller.Update(dogId, newVegetable);
        }

        private void Add()
        {
            Vegetable newVegetable = new Vegetable();
            Console.Write("Name: ");
            newVegetable.Name = Console.ReadLine();

            Console.Write("Price: ");
            newVegetable.Price = double.Parse(Console.ReadLine());

            Console.Write("Description: ");
            newVegetable.Description = Console.ReadLine();

            VegetableTypeLogic vegetableTypeLogic = new VegetableTypeLogic();
            List<VegetableType> allBreeds = vegetableTypeLogic.GetAllVegetables();
            Console.WriteLine("Types:");
            Console.WriteLine(new string('-', 4));
            foreach (var item in allBreeds)
            {
                Console.WriteLine(item.Id + ". " + item.TypeName);
            }
            Console.WriteLine("Izberi poroda:");
            newVegetable.VegetableTypeId = int.Parse(Console.ReadLine());

            VegetableLogic dogContorller = new VegetableLogic();
            dogContorller.Create(newVegetable);

            Console.WriteLine($"{newVegetable.Id}.  {newVegetable.Name} ({newVegetable.VegetableType}) - {newVegetable.Price}.");
        }

        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "Vegetables" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            VegetableLogic vegetableContorller = new VegetableLogic();
            var products = vegetableContorller.GetAll();
            foreach (var item in products)
            {
                Console.WriteLine($"{item.Id}.  {item.Name} ({item.VegetableType}) - {item.Price}.");
            }
        }


    }
}
