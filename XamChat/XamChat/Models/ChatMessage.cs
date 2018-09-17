using System;
using XamChat.Models;

namespace XamChat.ViewModels
{
    internal class ChatMessage : IEquatable<ChatMessage>
    {
        public User Author { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeEdited { get; set; }
        public string Message { get; set; }

        public bool Equals(ChatMessage other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Author, other.Author) && TimeCreated.Equals(other.TimeCreated) && TimeEdited.Equals(other.TimeEdited);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ChatMessage) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Author != null ? Author.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ TimeCreated.GetHashCode();
                hashCode = (hashCode * 397) ^ TimeEdited.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(ChatMessage left, ChatMessage right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ChatMessage left, ChatMessage right)
        {
            return !Equals(left, right);
        }
    }
}