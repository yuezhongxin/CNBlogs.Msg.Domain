using CNBlogs.Msg.Domain.ValueObject;
using CNBlogs.Msg.Infrastructure;
using System;

namespace CNBlogs.Msg.Domain.Entity
{
    public class Message : IAggregateRoot
    {
        public Message()
        { }

        public Message(string title, string content, Contact sender, Contact recipient)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new CustomMessageException("title can't be null");
            }
            if (title.Length > 50)
            {
                throw new CustomMessageException("主题长度不能超过50");
            }
            if (string.IsNullOrEmpty(content))
            {
                throw new CustomMessageException("content can't be null");
            }
            if (content.Length > 20000)
            {
                throw new CustomMessageException("内容过长");
            }
            if (sender == null)
            {
                throw new CustomMessageException("sender can't be null");
            }
            if (recipient == null)
            {
                throw new CustomMessageException("recipient can't be null");
            }
            if (sender.ID == recipient.ID)
            {
                throw new CustomMessageException("发件人和收件人不能为同一人");
            }
            this.Title = title;
            this.Content = MarkDownHelper.MarkDownTransform(content);
            this.OriginalContent = content.Replace("\n", "<br />");
            this.SendTime = DateTime.Now;
            this.IP = Util.GetUserIpAddress();
            this.State = MessageState.Unread;
            if (sender.ID == 0 || sender.ID == 35695)
            {
                this.Type = MessageType.Notice;
            }
            else
            {
                this.Type = MessageType.Personal;
            }
            this.DisplayType = MessageDisplayType.OutboxAndInbox;
            this.Sender = sender;
            this.Recipient = recipient;
        }
        public int ID { get; set; }
        public string Title { get; private set; }
        public string Content { get; private set; }
        public string OriginalContent { get; set; }
        public DateTime SendTime { get; private set; }
        public string IP { get; private set; }
        public Message ParentMessage { get; set; }
        public MessageState State { get; private set; }
        public MessageType Type { get; private set; }
        public MessageDisplayType DisplayType { get; private set; }
        public virtual Contact Sender { get; set; }
        public virtual Contact Recipient { get; set; }

        public bool Read(Contact reader)
        {
            if (this.Recipient.ID.Equals(reader.ID) && this.State == MessageState.Unread)
            {
                this.State = MessageState.Read;
                return true;
            }
            return false;
        }

        public bool CanRead(Contact reader)
        {
            if (this.Sender.ID == reader.ID)
            {
                if (this.DisplayType == MessageDisplayType.Outbox || this.DisplayType == MessageDisplayType.OutboxAndInbox)
                {
                    return true;
                }
            }
            else if (this.Recipient.ID == reader.ID)
            {
                if (this.DisplayType == MessageDisplayType.Inbox || this.DisplayType == MessageDisplayType.OutboxAndInbox)
                {
                    return true;
                }
            }
            return false;
        }

        public void DisposeMessage(Contact reader)
        {
            // to do...
            if (this.Sender.ID == reader.ID)
            {
                if (this.DisplayType == MessageDisplayType.Outbox)
                {
                    this.DisplayType = MessageDisplayType.NoOutboxAndInbox;
                }
                else if (this.DisplayType == MessageDisplayType.OutboxAndInbox)
                {
                    this.DisplayType = MessageDisplayType.Inbox;
                }
            }
            else if (this.Recipient.ID == reader.ID)
            {
                if (this.DisplayType == MessageDisplayType.Inbox)
                {
                    this.DisplayType = MessageDisplayType.NoOutboxAndInbox;
                }
                else if (this.DisplayType == MessageDisplayType.OutboxAndInbox)
                {
                    this.DisplayType = MessageDisplayType.Outbox;
                }
            }
        }

        public bool DisposeMessage()
        {
            if (this.DisplayType != MessageDisplayType.NoOutboxAndInbox)
            {
                this.DisplayType = MessageDisplayType.NoOutboxAndInbox;
                return true;
            }
            return false;
        }
    }
}
