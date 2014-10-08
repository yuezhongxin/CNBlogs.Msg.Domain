/**
* author:xishuai
**/

using CNBlogs.Infrastructure.IoC.Contracts;
using CNBlogs.Msg.Domain.Entity;
using CNBlogs.Msg.Domain.Repositories;
using CNBlogs.Msg.Domain.ValueObject;
using CNBlogs.Msg.Infrastructure;
using System.Threading.Tasks;
namespace CNBlogs.Msg.Domain.DomainService
{
    /// <summary>
    /// SendSiteMessag 领域服务实现-站内短消息发送
    /// </summary>
    public class SendSiteMessageService : ISendMessageService
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
