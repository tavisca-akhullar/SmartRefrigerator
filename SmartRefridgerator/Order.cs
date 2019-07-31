using System.Collections.Generic;

namespace SmartRefridgerator
{
  public class Order
    {
       private VegetableTracker _vegetableTracker { get;  }
        public ConfigurationManager _configurationManager { get; }
        private VegetableTray _vegetableTray { get; }

        public  Order(VegetableTracker vegetableTracker,ConfigurationManager configurationManager,VegetableTray vegetableTray)
        {
            _vegetableTracker = vegetableTracker;
            _configurationManager = configurationManager;
            _vegetableTray = vegetableTray;
        }
        public void PlaceOrder( )
        {
            List<KeyValuePair<Vegetable, int>> insufficientVegetables = new List<KeyValuePair<Vegetable, int>>();
            if(insufficientVegetables.Count>0)
            {
                List<KeyValuePair<Vegetable, int>> vegetables = _vegetableTray.GetVegetableQuantity();
                foreach (KeyValuePair<Vegetable,int> vegetable in insufficientVegetables )
                {
                    int miniminQuantity = _configurationManager.GetMinimumQuantity(vegetable.Key);
                    _vegetableTray.Add(vegetable.Key,miniminQuantity-vegetable.Value);
                }
            }
        }
    }
}
