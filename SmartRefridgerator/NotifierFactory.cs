using System;

namespace SmartRefridgerator
{
    public class NotifierFactory
    {
        public INotification GetNotifier(String type)
        {
            switch (type)
            {
                case "bymail":
                    return new EmailNotification();

                case "bytext":
                    return new TextNotification();


                default:
                    throw new NotSupportedException();
            }
        }
    }
}
    
