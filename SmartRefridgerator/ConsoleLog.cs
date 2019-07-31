using System;

namespace SmartRefridgerator
{
    public class ConsoleLog : INotification
    {
        public void Notify(string message)
        {
            Console.WriteLine(message);
        }
    }
}
    
