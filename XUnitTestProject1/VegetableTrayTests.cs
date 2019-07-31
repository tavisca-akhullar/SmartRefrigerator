using SmartRefridgerator;
using System;
using System.Collections.Generic;
using Xunit;

namespace XUnitTestProject1
{
    public class VegetableTrayTests
    {
       
        [Fact]
        public void AddVegetableToEmptyTrayTest()
        {
            var tray = new VegetableTray();
            tray.Add(new Tomato(),8000);
            tray.Add(new Cabbage(), 5000);

            List<KeyValuePair<Vegetable, int>> cartItems = new List<KeyValuePair<Vegetable, int>>()
                { new KeyValuePair<Vegetable, int>(new Tomato(), 8000),
                new KeyValuePair<Vegetable, int>(new Cabbage(), 5000) };

            var trayVegetables = tray.GetVegetableQuantity();

            for(int i=0;i<cartItems.Count;i++)
            {
                Assert.Equal(cartItems[i].Value,trayVegetables[i].Value);
            }
        }
        [Fact]
        public void WhenNoVegetableIsAdded()
        {
            VegetableTray tray = new VegetableTray();
            Assert.Throws<VegetableNotFoundException>(() => tray.TakeOut(new Tomato(),2000));
        }

        [Fact]
        public void TakeOutVegetableFromTray()
        {
            var tray = new VegetableTray();
            Tomato tomato = new Tomato();
            Cabbage cabbage = new Cabbage();
            tray.Add(tomato, 8000);
            tray.Add(cabbage, 5000);
            tray.TakeOut(tomato, 2000);
            tray.TakeOut(cabbage,2000);

            var trayVegetables = tray.GetVegetableQuantity();

            List<KeyValuePair<Vegetable, int>> cartItems = new List<KeyValuePair<Vegetable, int>>()
                { new KeyValuePair<Vegetable, int>(new Tomato(), 6000),
                new KeyValuePair<Vegetable, int>(new Cabbage(), 3000) };

            for (int i = 0; i < cartItems.Count; i++)
            {
                Assert.Equal(cartItems[i].Value, trayVegetables[i].Value);
            }
        }

        [Fact]
        public void MinimunVegetableQuantity()
        {
            ConfigurationManager configurationManager = new ConfigurationManager(new InMemoryStorage());
            Tomato tomato = new Tomato();
            configurationManager.SetMinimumQuantity(tomato,2000);

            Assert.Equal(2000,configurationManager.GetMinimumQuantity(tomato));

        }

        [Fact]
        public void InsufficientQauntity()
        {
            Tomato tomato = new Tomato();
            Cabbage cabbage = new Cabbage();

            VegetableTray tray = new VegetableTray();
            tray.Add(tomato,5000);
            tray.Add(cabbage,4000);
            tray.TakeOut(tomato,4000);

            IStorage storage = new InMemoryStorage();

            ConfigurationManager configurationManager = new ConfigurationManager(storage);
            configurationManager.SetMinimumQuantity(tomato, 2000);
            configurationManager.SetMinimumQuantity(cabbage, 2000);

            VegetableTracker vegetableTracker = new VegetableTracker(configurationManager,tray);
            var insufficientVegetables=vegetableTracker.GetInsufficientVegetableQuantity();

            Assert.Equal(tomato.Name,insufficientVegetables[0].Key.Name);

        }

        [Fact]
        public void PlaceOrder()
        {
            Tomato tomato = new Tomato();
            Cabbage cabbage = new Cabbage();

            VegetableTray tray = new VegetableTray();
            tray.Add(tomato, 5000);
            tray.Add(cabbage, 4000);
            

            IStorage storage = new InMemoryStorage();

            ConfigurationManager configurationManager = new ConfigurationManager(storage);
            configurationManager.SetMinimumQuantity(tomato, 2000);
            configurationManager.SetMinimumQuantity(cabbage, 2000);

            tray.TakeOut(tomato, 4000);

            VegetableTracker vegetableTracker = new VegetableTracker(configurationManager, tray);
            var insufficientVegetables = vegetableTracker.GetInsufficientVegetableQuantity();

            Order order = new Order(vegetableTracker,configurationManager,tray);
            order.PlaceOrder();

            List<KeyValuePair<Vegetable, int>> cartItems = new List<KeyValuePair<Vegetable, int>>()
                { new KeyValuePair<Vegetable, int>(new Tomato(), 2000),
                new KeyValuePair<Vegetable, int>(new Cabbage(), 4000) };

            var trayVegetables = tray.GetVegetableQuantity();

            for (int i = 0; i < cartItems.Count; i++)
            {
                Assert.Equal(cartItems[i].Value, trayVegetables[i].Value);
            }
        }
    }
}
