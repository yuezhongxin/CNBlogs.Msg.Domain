
using CNBlogs.Msg.Application.DTO;
using CNBlogs.Msg.Domain.Entity;
using CNBlogs.Msg.Domain.ValueObject;
using CNBlogs.Msg.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace CNBlogs.Msg.Domain.Repositories
{
    public interface IMessageRepository : IRepository<Message>
    {
        Task<IEnumerable<MessageListDTO>> GetUnreadMessageList(Contact reader, PageQuery pageQuery);

        Task<int> GetUnreadMessageCount(Contact reader);

        Task<int> GetInboxCount(Contact reader);

        Task<int> GetOutboxCount(Contact reader);

        Task<IEnumerable<Message>> GetInbox(Contact receiver);

        Task<IEnumerable<Message>> GetInbox(Contact receiver, Contact sender);

        Task<IEnumerable<MessageListDTO>> GetInbox(Contact reader, PageQuery pageQuery);

        Task<IEnumerable<MessageListDTO>> GetOutbox(Contact reader, PageQuery pageQuery);

        Task<IEnumerable<Message>> GetAll(Contact contact);

        Task<Message> Get(int id);

        Task<IEnumerable<Message>> GetMessages(Message message, Contact reader);

        Task<int> GetMessageCountByIP(string ip);

        Task<int> GetOutboxCountBySender(Contact sender);
    }
}
