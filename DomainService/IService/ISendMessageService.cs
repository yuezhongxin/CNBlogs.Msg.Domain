/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using CNBlogsMsg.Domain.Entity;
using System.Threading.Tasks;
namespace CNBlogsMsg.Domain.DomainService
{
    public interface ISendMessageService
    {
        Task<bool> SendMessage(Message message);
    }
}
