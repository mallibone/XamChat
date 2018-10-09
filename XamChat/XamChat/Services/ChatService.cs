using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using XamChat.Models;
using XamChat.ViewModels;

namespace XamChat.Services
{
    internal interface IChatService
    {
        Task SendMessage(ChatMessage message);
        IObservable<IEnumerable<ChatMessage>> ChatUpdated { get; }
    }

    class DummyChatService : IChatService
    {
        private List<ChatMessage> _messages;
        private Subject<IEnumerable<ChatMessage>> _chatHasChanged;
        public DummyChatService()
        {
            _messages = new List<ChatMessage>();
            _chatHasChanged = new Subject<IEnumerable<ChatMessage>>();
        }
        public Task SendMessage(ChatMessage message)
        {
            var numberOfMessagesToTake = _messages.Count > 99 ? 98 : _messages.Count;
            _messages = new List<ChatMessage>(_messages.Take(numberOfMessagesToTake)) {message};
            _chatHasChanged.OnNext(_messages);
            SendDummyMessage();
            return Task.CompletedTask;
        }

        private async void SendDummyMessage()
        {
            await Task.Delay(2000);
            var dummyMessage = new ChatMessage {Author = new User {Username = "Dr. Who"}, TimeCreated = DateTime.Now, Message = "Come on it's not rocket science only quantum mechanics.", TimeEdited = DateTime.Now};
            _messages = new List<ChatMessage>(_messages.Take(_messages.Count)) {dummyMessage};
            _chatHasChanged.OnNext(_messages);
        }

        public IObservable<IEnumerable<ChatMessage>> ChatUpdated => _chatHasChanged;
    }
}
