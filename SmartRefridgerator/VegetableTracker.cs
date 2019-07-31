using System.Collections.Generic;

namespace SmartRefridgerator
{
    public class VegetableTracker
    {
        public ConfigurationManager _configurationManager { get; }
        private VegetableTray _vegetableTray { get; }

         public VegetableTracker(ConfigurationManager configurationManager, VegetableTray vegetableTray)
        {
            _configurationManager = configurationManager;
            _vegetableTray = vegetableTray;
        }
        public List<KeyValuePair<Vegetable, int>> GetInsufficientVegetableQuantity()
        {
            List<KeyValuePair<Vegetable,int>> insufficientVegetables = new List<KeyValuePair<Vegetable, int>>();
            foreach (KeyValuePair<Vegetable,int> vegetable in this._vegetableTray.GetVegetableQuantity())
            {
                if (vegetable.Value < this._configurationManager.GetMinimumQuantity(vegetable.Key))
                {
                    insufficientVegetables.Add(vegetable);   
                }
            }
            return insufficientVegetables;
        }
    }
}
