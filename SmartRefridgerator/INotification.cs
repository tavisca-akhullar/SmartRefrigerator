using System;

namespace SmartRefridgerator
{
    public interface INotification
    {
         void Notify(String message);
    }

    public interface IEmailNotification:INotification
    {
        void SetSubject(String subject);
        String GetSubject();
        
    }
    public interface ITextNotification : INotification
    {
        void SetMessage(String subject);
        String GetMessage();
    }

    public class EmailNotification : IEmailNotification
    {
        private String _subject { set; get; }
        public String GetSubject()
        {
            return this._subject;
        }

        public void Notify(string subject)
        {
            Console.WriteLine(subject);
        }

        public void SetSubject(string subject)
        {
          _subject = subject;
        }
    }
    class TextNotification : ITextNotification
    {
      private  String _message { set; get; }
        public String GetMessage()
        {
            return this._message;
        }

        public void Notify(string message)
        {
            Console.WriteLine(message);
        }

        public void SetMessage(string message)
        {
            _message = message;
        }
    }
}
    
