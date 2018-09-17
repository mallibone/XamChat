using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
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
        public async Task SendMessage(ChatMessage message)
        {
            var numberOfMessagesToTake = _messages.Count > 99 ? 99 : _messages.Count;
            _messages = new List<ChatMessage>(_messages.Take(numberOfMessagesToTake)) {message};
            await Task.Delay(300);
            _chatHasChanged.OnNext(_messages);
        }

        public IObservable<IEnumerable<ChatMessage>> ChatUpdated => _chatHasChanged;
    }
}
