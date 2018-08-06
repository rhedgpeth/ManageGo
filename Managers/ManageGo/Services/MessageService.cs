using System;
using ManageGo.Core.Services;
using Xamarin.Forms;

namespace ManageGo.Services
{
    public class MessageService : IMessageService
    {
        public void Send(MessageType sender, string message)
        {
            MessagingCenter.Send(message, sender.ToString());
        }

        public void Subscribe(object subscriber, MessageType message, Action<string> callback)
        {
            MessagingCenter.Subscribe(subscriber, message.ToString(), callback);
        }
    }
}
