using System;
using System.Collections.Generic;

namespace SmartRefridgerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class VegetableTracker
    {
        public List<KeyValuePair<Vegetable, int>> GetInsufficientVegetableQuantity()
        {

        }
    }

    public class Refrigerator
    {
        private VegetableTray _vegetableTray = new VegetableTray();

        private ConfigurationManager _configurationManager = new ConfigurationManager(new InMemoryStorage());
        
        public void AddVegetable(Vegetable vegetable, int quantity)
        {
            _vegetableTray.Add(vegetable, quantity);
        }

        public void TakeOutVegetable(Vegetable vegetable, int quantity)
        {
            _vegetableTray.TakeOut(vegetable, quantity);

            var vegetableQuantity = _vegetableTray.GetVegetableQuantity();
        }


    }

    public class ConfigurationManager
    {
        private IStorage _storage;

        public ConfigurationManager(IStorage storage)
        {
            this._storage = storage;
        }

        public void SetMinimumQuantity(Vegetable vegetable, int quantity)
        {
            _storage.SetVegetableMinimumQuantity(vegetable, quantity);
        }

        public int GetMinimumQuantity(Vegetable vegetable)
        {
            return _storage.GetVegetableMinimumQuantity(vegetable);
        }
    }

    public interface IStorage
    {
        void SetVegetableMinimumQuantity(Vegetable vegetable, int quantity);

        int GetVegetableMinimumQuantity(Vegetable vegetable);
    }

    public class InMemoryStorage : IStorage
    {
        private Dictionary<Vegetable, int> _vegetableQuantities = new Dictionary<Vegetable, int>();
        public int GetVegetableMinimumQuantity(Vegetable vegetable)
        {
            if(_vegetableQuantities.ContainsKey(vegetable))
            {
                return _vegetableQuantities[vegetable];
            }

            throw new VegetableNotFoundException();
        }

        public void SetVegetableMinimumQuantity(Vegetable vegetable, int quantity)
        {
            if(_vegetableQuantities.ContainsKey(vegetable))
            {
                _vegetableQuantities[vegetable] = quantity;
            }
            else
            {
                _vegetableQuantities.Add(vegetable, quantity);
            }
        }
    }
}
