namespace SmartRefridgerator
{
    public class Refrigerator
    {
        private VegetableTray _vegetableTray = new VegetableTray();

        private StorageFactory _storageFactory = new StorageFactory();

        private ConfigurationManager _configurationManager; 
        
        public void AddVegetable(Vegetable vegetable, int quantity)
        {
            _vegetableTray.Add(vegetable, quantity);
            _configurationManager = new ConfigurationManager(_storageFactory.GetStorage("inmemory"));
        }

        public void TakeOutVegetable(Vegetable vegetable, int quantity)
        {
            _vegetableTray.TakeOut(vegetable, quantity);

            var vegetableQuantity = _vegetableTray.GetVegetableQuantity();
        }


    }
}
