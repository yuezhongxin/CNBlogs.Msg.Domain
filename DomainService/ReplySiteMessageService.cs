using CNBlogs.Msg.Domain.Entity;
using CNBlogs.Msg.Domain.ValueObject;
using CNBlogs.Msg.Infrastructure;

namespace CNBlogs.Msg.Domain.DomainService
{
    /// <summary>
    /// ReplySiteMessageService 领域服务-回复消息
    /// </summary>
    public class ReplySiteMessageService
    {
        public bool ReplySiteMessage(Message parentMessage, Message replyMessage)
        {
            if (parentMessage.Sender == replyMessage.Sender && parentMessage.Recipient == replyMessage.Recipient)
            {
                if (parentMessage.DisplayType == MessageDisplayType.Outbox)
                {
                    parentMessage.DisplayType = MessageDisplayType.OutboxAndInbox;
                }
                else
                {
                    throw new CustomMessageException("消息已被您删除，无法回复");
                }
            }
            else if (parentMessage.Sender == replyMessage.Recipient && parentMessage.Recipient == replyMessage.Sender)
            {
                if (parentMessage.DisplayType == MessageDisplayType.Inbox)
                {
                    parentMessage.DisplayType = MessageDisplayType.OutboxAndInbox;
                }
                else
                {
                    throw new CustomMessageException("消息已被您删除，无法回复");
                }
            }
            else
            {
                throw new CustomMessageException("您不是收发件人，没有权限回复");
            }
            replyMessage.ParentMessage = parentMessage;
            return true;
        }
    }
}
