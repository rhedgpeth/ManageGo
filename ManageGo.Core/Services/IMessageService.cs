using System;

namespace ManageGo.Core.Services
{
    public class MessageType
    {
        readonly string name;
        readonly int value;

        public static readonly MessageType ApiForbiddenStatus = new MessageType(1, "ApiForbiddenStatus");
        //public static readonly MessageType SAMPLE = new AuthenticationMethod(2, "SAMPLE");

        MessageType(int value, string name)
        {
            this.name = name;
            this.value = value;
        }

        public override string ToString()
        {
            return name;
        }
    }

    public interface IMessageService
    {
        void Send(MessageType sender, string message);

        void Subscribe(object subcriber, MessageType message, Action<string> callback);
    }
}
