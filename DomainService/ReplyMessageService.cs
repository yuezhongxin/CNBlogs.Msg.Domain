using CNBlogs.Msg.Domain.Entity;
namespace CNBlogs.Msg.Domain.DomainService
{
    /// <summary>
    /// SendSiteMessageService 领域服务-回复消息
    /// </summary>
    public class ReplyMessageService
    {
        public bool ReplyMessage(Message parentMessage, Message replyMessage)
        {
            replyMessage.ParentMessage = parentMessage;
            return true;
        }
    }
}
