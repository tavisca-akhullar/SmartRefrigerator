using System;

namespace SmartRefridgerator
{
    public class EmailNotifier : INotification
    {
        public void Notify(string message)
        {
            Console.WriteLine(message);
        }
    }
}
    
