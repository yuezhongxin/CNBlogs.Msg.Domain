/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using CNBlogsMsg.Domain.Entity;
namespace CNBlogsMsg.Domain.DomainService
{
    /// <summary>
    /// ReplyMessageService 领域服务-回复消息
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
