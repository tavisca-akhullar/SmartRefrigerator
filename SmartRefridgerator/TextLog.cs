using System;

namespace SmartRefridgerator
{
    public class TextLog : INotification
    {
        public void Notify(string message)
        {
            Console.WriteLine(message);
        }
    }
}
    
