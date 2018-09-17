using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ReactiveUI;
using Splat;
using XamChat.Services;

namespace XamChat.ViewModels
{
    class MainViewModel : ReactiveObject
    {
        private readonly IChatService _chatService;
        private readonly IUserService _userService;
        private string _currentMessage;

        public MainViewModel(IChatService chatService = null, IUserService userService = null)
        {
            Messages = new ObservableCollection<ChatMessage>();
            _chatService = chatService ?? Locator.Current.GetService<IChatService>();
            _userService = userService ?? Locator.Current.GetService<IUserService>();
            _chatService.ChatUpdated.Subscribe(ChatUpdated);
            SendMessageCommand = ReactiveCommand.Create<string, Task>(async (msg) =>
            {
                await SendMessage(msg);
            });
        }

        public ReactiveCommand<string, Task> SendMessageCommand { get;}

        public string CurrentMessage
        {
            get => _currentMessage;
            set => this.RaiseAndSetIfChanged(ref _currentMessage, value);
        }

        public ObservableCollection<ChatMessage> Messages { get; }
        public bool IsAuthenticated => _userService.IsAuthenticated;

        private async Task SendMessage(string message)
        {
            var chatMessage = new ChatMessage
                {Author = _userService.GetCurrentUser(), Message = message, TimeCreated = DateTime.Now, TimeEdited = DateTime.Now};
            await _chatService.SendMessage(chatMessage);
            CurrentMessage = string.Empty;
        }

        private void ChatUpdated(IEnumerable<ChatMessage> chatHistory)
        {
            var deltaMessages = chatHistory.Where(m => !Messages.Contains(m));
            foreach (var deltaMessage in deltaMessages)
            {
                Messages.Add(deltaMessage);
            }
        }
    }
}
