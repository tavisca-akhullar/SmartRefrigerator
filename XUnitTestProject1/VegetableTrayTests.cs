using SmartRefridgerator;
using System;
using Xunit;

namespace XUnitTestProject1
{
    public class VegetableTrayTests
    {
        [Fact]
        public void AddVegetableToEmptyTrayTest()
        {
            var tray = new VegetableTray();
        }
    }
}
