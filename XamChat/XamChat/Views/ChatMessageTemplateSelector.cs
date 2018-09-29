using System;
using System.Collections.Generic;
using System.Text;
using Splat;
using Xamarin.Forms;
using XamChat.Services;
using XamChat.ViewModels;

namespace XamChat.Views
{
    public class ChatMessageTemplateSelector : DataTemplateSelector
    {
        private readonly IUserService _userService;

        public ChatMessageTemplateSelector() : this(null)
        {
        }

        public ChatMessageTemplateSelector(IUserService userService = null)
        {
            _userService = userService ?? Locator.Current.GetService<IUserService>();
        }

        public DataTemplate SentMessage { get; set; }
        public DataTemplate ReceivedMessage { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var msg = (ChatMessage) item;
            return msg.Author == _userService.GetCurrentUser() ? SentMessage : ReceivedMessage;
        }
    }
}
