using CNBlogs.Msg.Domain.Entity;
using System.Threading.Tasks;

namespace CNBlogs.Msg.Domain.DomainService
{
    public interface ISendMessageService
    {
        Task<bool> SendMessage(Message message);
    }
}
