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

        public void Send<TSender>(TSender sender, string message) where TSender : class
        {
            MessagingCenter.Send(sender, message);
        }

        public void Subscribe(object subscriber, MessageType message, Action<string> callback)
        {
            MessagingCenter.Subscribe(subscriber, message.ToString(), callback);
        }

        public void Subscribe<TSender>(object subscriber, string message, Action<TSender> callback) where TSender : class
        {
            MessagingCenter.Subscribe(subscriber, message, callback);
        }
    }
}
