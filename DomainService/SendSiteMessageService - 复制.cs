/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using CNBlogs.Infrastructure.IoC.Contracts;
using CNBlogsMsg.Domain.Entity;
using CNBlogsMsg.Domain.Repositories;
using CNBlogsMsg.Domain.ValueObject;
using CNBlogsMsg.Infrastructure;
using System.Threading.Tasks;
namespace CNBlogsMsg.Domain.DomainService
{
    /// <summary>
    /// SendSiteMessag 领域服务实现-站内短消息发送
    /// </summary>
    public class ReplyMessageService : ISendMessageService
    {
        //ValidateSendingMessage(message)
        //ValidateSendingMessage.Validate(message)

        public async Task<bool> SendMessage(Message message)
        {
            IMessageRepository messageRepository = IocContainer.Resolver.Resolve<IMessageRepository>();
            if (message.Type == MessageType.Personal)
            {
                if (System.Web.HttpContext.Current != null)
                {
                    if (await messageRepository.GetMessageCountByIP(Util.GetUserIpAddress()) > 100)
                    {
                        throw new CustomMessageException("一天内只能发送100条短消息");
                    }
                }
                if (await messageRepository.GetOutboxCountBySender(message.Sender) > 20)
                {
                    throw new CustomMessageException("1小时内只能向20个不同的用户发送短消息");
                }
            }
            return true;
        }
    }
}
